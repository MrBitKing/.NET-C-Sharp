using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ass2.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Http;
using Ass2.ViewModels;
using System.IO;
using System.Text;

using Newtonsoft.Json;


namespace Ass2.Controllers
{
    public class HomeController : Controller
    {
        private Assignment2DataContext _dataContext;

        public HomeController(Assignment2DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]// GET: /<controller>/
        public IActionResult Index(BlogPostViewModel IndexModel)
        {
            //   List <BlogPost> posts = new List<BlogPost>();

            IndexModel.BlogPosts = _dataContext.BlogPosts.ToList();

            try
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId)"));
                if (userId != 0)
                {
                    //    IndexModel.User = _dataContext.Users.Where(s => s.UserId == userId).FirstOrDefault;
                    //where s.UserId.Equals(userId)
                    //select s;
                    IndexModel.User = (from m in _dataContext.Users where m.UserId == userId select m).FirstOrDefault();
                    //  IndexModel.User = _dataContext.Users.FirstOrDefault(o => o.UserId == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Put your error message here.", ex);

            }
            return View(IndexModel);
        }


        //    [HttpGet]// GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]// GET: /<controller>/
        public IActionResult Register(User user)
        {

            //   user = new User();
            if (Request.Form["User.RoleId"] == "2")
            {
                user.RoleId = 2;
            }
            else
            {
                user.RoleId = 1;
            }

            var existing = (from u in _dataContext.Users where (u.EmailAddress == user.EmailAddress) select u).FirstOrDefault();

            if (existing == null)
            {
                _dataContext.Users.Add(user);
                _dataContext.SaveChanges();
            }

            return RedirectToAction("LogIn");
        }

        //[HttpPost]// GET: /<controller>/
        //public IActionResult AddUser(User user)
        //{
        //    // save user in database
        //    _dataContext.Users.Add(user);
        //    _dataContext.SaveChanges();

        //    // save user in session
        //    HttpContext.Session.SetString("Role", user.RoleId.ToString());
        //    HttpContext.Session.SetString("FN", user.FirstName);
        //    HttpContext.Session.SetString("LN", user.LastName.ToString());
        //    HttpContext.Session.SetString("Email", user.EmailAddress);
        //    HttpContext.Session.SetString("Password", user.Password);
        //    return RedirectToAction("LogIn");

        //}

        [HttpPost]
        public IActionResult AuthenticateUser()
        {
            String email = Request.Form["EmailAddress"];
            String pass = Request.Form["Password"];

            var user = (from u in _dataContext.Users where (u.EmailAddress == email && u.Password == pass) select u).FirstOrDefault();

            if (user == null)
                return RedirectToAction("Login");

            if (user.Password != pass)
                return RedirectToAction("Login");

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetInt32("RoleId", user.RoleId);
                HttpContext.Session.SetString("FN", user.FirstName);
                HttpContext.Session.SetString("LN", user.LastName);
                HttpContext.Session.SetString("Password", user.Password);

            }

            return RedirectToAction("Index");
        }

        [HttpGet]// GET: /<controller>/
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]// GET: /<controller>/
        public IActionResult LogIn(User user)
        {
            return RedirectToAction("Index");
        }

        public IActionResult EditBlogPost(int id)
        {
            HttpContext.Session.SetInt32("editBlogId", id);
            var editPost = (from b in _dataContext.BlogPosts where b.BlogPostId == id select b).FirstOrDefault();
            return View(editPost);
        }

        [HttpPost]
        public IActionResult EditBlogPost(BlogPost posts)
        {

            int id = Convert.ToInt32(Request.Form["BlogPostId"]);
            var postUpdate = (from m in _dataContext.BlogPosts where m.BlogPostId == id select m).FirstOrDefault();
            postUpdate.Title = posts.Title;
            postUpdate.Content = posts.Content;
            postUpdate.Posted = posts.Posted;
            postUpdate.ShortDescription = posts.ShortDescription;

            //save changes to edits
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddBlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlogPost(BlogPost blogPost)
        {

            blogPost = new BlogPost();
            if (HttpContext.Session.GetInt32("UserId") != null)
            {

                blogPost.Content = Request.Form["Content"].ToString();
                blogPost.Title = Request.Form["Title"].ToString();
                blogPost.Posted = Convert.ToDateTime(DateTime.Now);
                blogPost.UserId = (int)(HttpContext.Session.GetInt32("UserId"));
                blogPost.ShortDescription = Request.Form["ShortDescription"].ToString();
                //    blogPost.IsAvailable = Request.Form["IsAvailable"];

                if (blogPost != null)
                {
                    _dataContext.BlogPosts.Add(blogPost);
                    _dataContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DisplayFullBlogPost()
        {
            Comment comments = new Comment
            {
                //get data for blog post display
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                BlogPostId = Convert.ToInt32(Request.Form["BlogPostId"]),
                Content = Request.Form["Content"]
            };

            if (comments != null)
            {
                //add the comments to the page
                _dataContext.Comments.Add(comments);
                _dataContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DisplayFullBlogPost(int id)
        {
            var post = (from p in _dataContext.BlogPosts where p.BlogPostId == id select p).FirstOrDefault();

            if (post != null)
            {
                List<CommentViewModel> viewComments = new List<CommentViewModel>();
                 var commentList = (from c in _dataContext.Comments where c.BlogPostId == id select c).ToList();
                //  viewComments = commentList;

                BlogPostViewModel blogPostView = new BlogPostViewModel
                {
                    BlogPost = post,
                    Comments = viewComments
                };

                foreach (Comment comment in commentList)
                {
                    var user = (from u in _dataContext.Users where u.UserId == comment.UserId select u).FirstOrDefault();
                    string commentAuthor = user.FirstName + " " + user.LastName;

                    CommentViewModel temp = new CommentViewModel
                    {
                        Author = commentAuthor,
                        Comment = comment
                    };

                    string getcomment = temp.Comment.Content.ToLower();
                    string[] words = getcomment.Split(' ');

                    var badwords = (from w in _dataContext.BadWords select w).ToList();

                    for (int i = 0; i < words.Count(); i++)
                    {
                        //now search the word in the database
                        foreach (var badw in badwords)
                        {
                            if (badw.Word.ToLower().Equals(words[i].ToLower()))
                            {
                                words[i] = "******";
                            }
                        }
                    }

                    temp.Comment.Content = ConvertStringArrayToString(words);
                    if (temp != null)
                    {
                        blogPostView.Comments.Add(temp);
                    }
                }

                IQueryable<Photo> IPhotos = (from c in _dataContext.Photos where c.BlogPostId == id select c);

                // Photo[] photos = IPhotos.ToArray<Photo>();
                blogPostView.Photos = IPhotos.ToList();

                blogPostView.User = (from user in _dataContext.Users where user.UserId == post.UserId select user).FirstOrDefault();
                return View(blogPostView);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult DeleteBlogPost(int id)

        {
            _dataContext.Comments.RemoveRange(from c in _dataContext.Comments where c.BlogPostId == id select c);
            _dataContext.SaveChanges();

            var deleteBlogs = (from u in _dataContext.BlogPosts where u.BlogPostId == id select u).FirstOrDefault();

            _dataContext.BlogPosts.Remove(deleteBlogs);
            _dataContext.Entry(deleteBlogs).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _dataContext.Photos.RemoveRange(from c in _dataContext.Photos where c.PhotoId == id select c);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddBadWordToDatabase()
        {
            BadWord badWordToAdd = new BadWord
            {
                Word = HttpContext.Request.Form["badword"]
            };

            if (badWordToAdd != null)
            {

                _dataContext.BadWords.Add(badWordToAdd);
                _dataContext.SaveChanges();
            }
            return RedirectToAction("ViewBadWords");
        }

        public IActionResult DeleteBadWord(int id)
        {
            var wordToDelete = (from c in _dataContext.BadWords where c.BadWordId == id select c).FirstOrDefault();
            _dataContext.BadWords.Remove(wordToDelete);
            _dataContext.Entry(wordToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _dataContext.SaveChanges();
            return RedirectToAction("ViewBadWords");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ICollection<IFormFile> files)
        {
            var blogId = HttpContext.Session.GetInt32("editBlogId");
            // get your storage accounts connection string
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cst8359lab5assignment2;AccountKey=yYQYWs3Q24u1okz8ro22XGyOrJj5/6jQmQlL1MdidhnQzkHiOutkj7MmV+4kNYstw1QOG2U0hEciREqor9t6Cg==;EndpointSuffix=core.windows.net");

            // create an instance of the blob client
            var blobClient = storageAccount.CreateCloudBlobClient();

            // create a container to hold your blob (binary large object.. or something like that)
            // naming conventions for the curious https://msdn.microsoft.com/en-us/library/dd135715.aspx
            var container = blobClient.GetContainerReference("frenckphotostorage");
            await container.CreateIfNotExistsAsync();

            // set the permissions of the container to 'blob' to make them public
            var permissions = new BlobContainerPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
            await container.SetPermissionsAsync(permissions);

            // for each file that may have been sent to the server from the client
            foreach (var file in files)
            {
                try
                {
                    // create the blob to hold the data
                    var blockBlob = container.GetBlockBlobReference(file.FileName);
                    if (await blockBlob.ExistsAsync())
                        await blockBlob.DeleteAsync();

                    using (var memoryStream = new MemoryStream())
                    {
                        // copy the file data into memory
                        await file.CopyToAsync(memoryStream);

                        // navigate back to the beginning of the memory stream
                        memoryStream.Position = 0;

                        // send the file to the cloud
                        await blockBlob.UploadFromStreamAsync(memoryStream);
                    }

                    // add the photo to the database if it uploaded successfully
                    var photo = new Photo();
                    photo.Url = blockBlob.Uri.AbsoluteUri;
                    photo.FileName = file.FileName;
                    photo.BlogPostId = (int)blogId;


                    System.Diagnostics.Debug.WriteLine("SomeText");
                    System.Diagnostics.Debug.WriteLine(photo.Url);

                    if (photo != null)
                    {
                        _dataContext.Photos.Add(photo);
                        _dataContext.SaveChanges();
                    }
                }
                catch
                {
                }
            }

            int id = Convert.ToInt32(Request.Form["editBlogId"]);

            return RedirectToAction("Index");
        }



        [HttpGet]// GET: /<controller>/
        public IActionResult EditProfile(int id)
        {

            HttpContext.Session.SetInt32("editProfile", id);
            var editProfile = (from b in _dataContext.Users where b.UserId == id select b).FirstOrDefault();
            return View(editProfile);

        }

        [HttpPost]// GET: /<controller>/
        public IActionResult EditProfile(User user)
        {

            int id = Convert.ToInt32(Request.Form["UserId"]);
            // var postUpdate = (from m in _dataContext.BlogPosts where m.BlogPostId == id select m).FirstOrDefault();
            User userToUpdate = new User();
            userToUpdate = (from u in _dataContext.Users where u.UserId == id select u).FirstOrDefault();

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;
            userToUpdate.Password = user.Password;
            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.Address = user.Address;
            userToUpdate.City = user.City;
            userToUpdate.Country = user.Country;
            userToUpdate.PostalCode = user.PostalCode;

            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult ViewBadWords()
        {
            var view = HttpContext.Session.GetString("UserId");
            var badWords = (from badword in _dataContext.BadWords select badword);

            return View(badWords);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }

    }

}

