

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ConsoleApplication1


{
    class Program
    {

        static string FilePath = @"Words.txt";
        static StreamReader text = new StreamReader(FilePath);
        static List<string> words = new List<string>();
        static string line = string.Empty;



        static void GetWord()
        {
            int total = 0;
            words.Clear();
            while ((line = text.ReadLine()) != null)
            {
                total++;
                words.Add(line);
                System.Console.WriteLine(line);
            }

            System.Console.WriteLine("total is " +total);

            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        }

        static void Bubble()
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            String[] result = words.ToArray();
            String temp = string.Empty;

            bool swap;

            do
            {
                swap = false;
                for (int index = 0; index < (result.Length - 1); index++)
                {
                    if (string.Compare(result[index], result[index + 1]) > 0) //if first number is greater then second then swap
                    {
                        //swap
                        temp = result[index];
                        result[index] = result[index + 1];
                        result[index + 1] = temp;
                        swap = true;
                    }
                }              
            
            } while (swap == true);
  
            // Evaluate our query.
            foreach (string value in result)
            {
                Console.WriteLine(value);
            }

            watch.Stop();
            Console.WriteLine("Time elapsed: "+watch.ElapsedMilliseconds+"ms");
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        }

        static void Distinct()
        {
            int total = 0;
            String[] result = words.ToArray();
            var output = words.SelectMany(p => p.Split(' '))
                  .Distinct()
                  .ToList();
          
            // Evaluate our query.
            foreach (string value in output)
            {
                total++;
                Console.WriteLine(value);
            }
            Console.WriteLine("Number of distinct words "+ total);
        }

        static void LinqSort(){

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = from name in words
                         orderby name
                         select name;

            foreach (string value in result)
            {
                Console.WriteLine(value);
            }

            watch.Stop();
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        }

        static void Firstten()//ok
        {

            int i = 0;
            while ((line = text.ReadLine()) != null)
            {
                if (i < 10)
                {
                    Console.WriteLine(line);
                    i++;
                }
                else
                {
                    break;
                }
            }
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

        }

        static void StartWith(){//ok
        
            int total = 0;

               while ((line = text.ReadLine()) != null)
                {

                if (line.StartsWith("j", StringComparison.Ordinal))
                {
                    Console.WriteLine(line);
                    total++;
                }
            }

            Console.WriteLine("Number of words that start with 'j': " + total);
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        }

        static void EndWith()
        {
            int total = 0;
            while ((line = text.ReadLine()) != null)
            {
               // words.Add(line);

                if (line.EndsWith("d", StringComparison.Ordinal))
                {
                    Console.WriteLine(line);
                    total++;
                }
            }
            Console.WriteLine("Number of words that end with 'd': "+total);
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        }

        static void GreaterFour(){

            int total = 0;
            while ((line = text.ReadLine()) != null)
            {
                // words.Add(line);

                if (line.Length > 4)
                {
                  //  Console.WriteLine(line);
                    total++;
                }
            }
            Console.WriteLine("Number of words greater then 4: " + total);
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

        }

        static void UnderThree()
        {

            int total = 0;
            while ((line = text.ReadLine()) != null)
            {
                // words.Add(line);

                if (line.Length < 3 && line.StartsWith("a", StringComparison.Ordinal))
                {
                    //  Console.WriteLine(line);
                    total++;
                }
            }
            Console.WriteLine("Number of words under 3: " + total);
            text.DiscardBufferedData();
            text.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

        }


        static void Main(string[] args)
        {
               Boolean running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Hello World!!!My First C# App"  +"\r\n"
               + "Options  " + "\r\n" + "----------/" +
                  "\r\n" + "1 - Import Words From File" + "\r\n" +
                  "2 - Bubble Sort words" + "\r\n" +
                  "3 - LINQ / Lambda sort words "+ "\r\n" +
                  "4 - Count the Distinct Words " +"\r\n" +
                  "5 - Take the first 10 words " + "\r\n" +
                  "6 - Get the number of words that start with 'j' and display the count " +"\r\n" +
                  "7 - Get and display of words that end with 'd' and display the count " +"\r\n" +
                  "8 - Get and display of words that are greater than 4 characters long, and display the count" + "\r\n" +
                  "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count" + "\r\n" +
                  "x - Exit" + "\r\n" + "\r\n" + "Make a selection:   ");

                string choice;
                choice = Console.In.ReadLine();

                switch (choice)
                {

                    case "1":

                    //    Program one = new Program();
                        GetWord();
                        break;

                    case "2":

                       // Program two = new Program();
                        Bubble();
                        break;

                    case "3":

                        LinqSort();
                        break;

                    case "4":

                        Distinct();
                        break;

                    case "5":

                        Firstten();
                        break;

                    case "6":

                        StartWith();
                        break;

                    case "7":

                        EndWith();
                        break;

                    case "8":

                        GreaterFour();
                        break;

                    case "9":

                        UnderThree();
                        break;

                    case "x":

                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }
    }
}
