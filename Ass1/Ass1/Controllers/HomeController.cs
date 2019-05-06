using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ass1.Models;
using Microsoft.AspNetCore.Http;
using Ass1.ViewModels;
using Ass1;

namespace Ass1.Controllers
{
    public class HomeController : Controller
    {
        private Assignment1DataContext _dataContext;

        public HomeController(Assignment1DataContext context)
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
            var editPost = (from b in _dataContext.BlogPosts where b.BlogPostId == id select b).FirstOrDefault();
            return View(editPost);
        }

        [HttpPost]// GET: /<controller>/
        public IActionResult EditBlogPost(BlogPost posts)
        {

            int id = Convert.ToInt32(Request.Form["BlogPostId"]);
            var postUpdate = (from m in _dataContext.BlogPosts where m.BlogPostId == id select m).FirstOrDefault();
            postUpdate.Title = posts.Title;
            postUpdate.Content = posts.Content;

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

                _dataContext.BlogPosts.Add(blogPost);
                _dataContext.SaveChanges();
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

            //add the comments to the page
            _dataContext.Comments.Add(comments);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DisplayFullBlogPost(int id)
        {
            var post = (from p in _dataContext.BlogPosts where p.BlogPostId == id select p).FirstOrDefault();
            if (post != null)
            {
                List<CommentViewModel> viewComments = new List<CommentViewModel>();
                BlogPostViewModel blogPostView = new BlogPostViewModel
                {
                    BlogPost = post,

                    Comments = viewComments
                };


                var commentList = (from c in _dataContext.Comments where c.BlogPostId == id select c).ToList();
                foreach (Comment comment in commentList)
                {
                    var user = (from u in _dataContext.Users where u.UserId == comment.UserId select u).FirstOrDefault();
                    string commentAuthor = user.FirstName + " " + user.LastName;

                    CommentViewModel temp = new CommentViewModel
                    {
                        Author = commentAuthor,
                        Comment = comment
                    };

                    if (temp != null)
                    {
                        blogPostView.Comments.Add(temp);
                    }
                }

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
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

