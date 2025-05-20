using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SUFEEASP.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace SUFEEASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index(string username = null)
        {
            if (TempData["WelcomeMessage"] != null)
            {
                ViewData["WelcomeMessage"] = TempData["WelcomeMessage"];
            }
            else if (!string.IsNullOrEmpty(username))
            {
                ViewData["WelcomeMessage"] = $"Hi, {username}!";
            }
            else if (HttpContext.Session.GetString("Username") != null)
            {
                ViewData["WelcomeMessage"] = $"Hi, {HttpContext.Session.GetString("Username")}!";
            }

            var ebooks = GetYourEbooks();
            var blogs = GetYourBlogs();
            var qawwalis = GetYourQawwalis();
            var writers = GetYourWriters();
            var quote = GetRandomQuote();

            var viewModel = new HomeViewModel
            {
                Ebooks = ebooks,
                Blogs = blogs,
                Qawwalis = qawwalis,
                Writers = writers,
                Quote = quote

            };

            return View(viewModel);
        }

        private Quote GetRandomQuote()
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            Quote quote = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 ID, QuoteContent, Quoter FROM QuoteTable ORDER BY NEWID()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            quote = new Quote
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                QuoteContent = reader["QuoteContent"].ToString(),
                                Quoter = reader["Quoter"].ToString()
                            };
                        }
                    }
                }
            }

            return quote;
        }

        private List<Ebook> GetYourEbooks(int count = 4)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Ebook> ebooks = new List<Ebook>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT TOP (@Count) * FROM Ebook ORDER BY NEWID()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Count", count);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ebooks.Add(new Ebook
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Author = reader["Author"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Booklink = reader["Booklink"].ToString()
                            });
                        }
                    }
                }
            }

            return ebooks;
        }

        private List<Blog> GetYourBlogs(int count = 4)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Blog> blogs = new List<Blog>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT TOP (@Count) * FROM Blog ORDER BY NEWID()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Count", count);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            blogs.Add(new Blog
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                Blogimg1 = reader["BlogImg1"].ToString(),
                                Author = reader["Author"].ToString(),
                                Paragraph1 = reader["Paragraph1"].ToString(),
                                Paragraph2 = reader["Paragraph2"].ToString(),
                                Blogimg2 = reader["BlogImg2"].ToString(),
                                Category = reader["Category"].ToString(),
                                Postdate = reader["Postdate"].ToString(),
                                Tags = reader["Tags"].ToString()
                            });
                        }
                    }
                }
            }

            return blogs;
        }

        private List<Qawwali> GetYourQawwalis(int count = 4)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Qawwali> qawwalis = new List<Qawwali>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT TOP (@Count) * FROM Qawwali ORDER BY NEWID()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Count", count);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            qawwalis.Add(new Qawwali
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Poetname = reader["Poetname"].ToString(),
                                Youtubeurl = reader["Youtubeurl"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Audio = reader["Audio"].ToString(),
                                Lyrics = reader["Lyrics"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
            }

            return qawwalis;
        }

        private List<Writer> GetYourWriters(int count = 4)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Writer> writers = new List<Writer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT TOP (@Count) * FROM Writer ORDER BY NEWID()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Count", count);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            writers.Add(new Writer
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString(),
                                Desc1 = reader["Desc1"].ToString(),
                                Desc2 = reader["Desc2"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                DOD = reader["DOD"].ToString(),
                                WriterType = reader["WriterType"].ToString(),
                                Quote = reader["Quote"].ToString(),
                                Famous = reader["Famous"].ToString(),
                                ViewMore = reader["ViewMore"].ToString()
                            });
                        }
                    }
                }
            }

            return writers;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Myusers user)
        {
            if (ModelState.IsValid)
            {
                var connectionString = _configuration.GetConnectionString("SUFEEASPContext");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Myusers (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username ?? string.Empty);
                        command.Parameters.AddWithValue("@Email", user.Email ?? string.Empty);
                        command.Parameters.AddWithValue("@Password", user.Password ?? string.Empty);

                        command.ExecuteNonQuery();
                    }
                }

                HttpContext.Session.SetString("Username", user.Username);
                TempData["WelcomeMessage"] = $"Welcome, {user.Username}!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPost()
        {
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Please enter both email and password.";
                return View("Login");
            }

            // Check for admin credentials (case-insensitive)
            if (string.Equals(email, "admin@gmail.com", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(password, "admin", StringComparison.OrdinalIgnoreCase))
            {
                HttpContext.Session.SetString("Username", "Admin");
                TempData["WelcomeMessage"] = "Welcome, Admin!";
                return RedirectToAction("Index");
            }

            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Username FROM Myusers WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string username = result.ToString();
                        HttpContext.Session.SetString("Username", username);
                        TempData["WelcomeMessage"] = $"Welcome, {username}!";
                        return RedirectToAction("Index");
                    }
                }
            }

            ViewBag.Error = "Login failed. Invalid credentials.";
            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Ebook()
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Ebook> ebooks = new List<Ebook>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Ebook";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ebooks.Add(new Ebook
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Author = reader["Author"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Booklink = reader["Booklink"].ToString()
                            });
                        }
                    }
                }
            }

            return View(ebooks);
        }

        public IActionResult Blog()
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Blog> blogs = new List<Blog>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Blog";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            blogs.Add(new Blog
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                Blogimg1 = reader["BlogImg1"].ToString(),
                                Author = reader["Author"].ToString(),
                                Paragraph1 = reader["Paragraph1"].ToString(),
                                Paragraph2 = reader["Paragraph2"].ToString(),
                                Blogimg2 = reader["BlogImg2"].ToString(),
                                Category = reader["Category"].ToString(),
                                Postdate = reader["Postdate"].ToString(),
                                Tags = reader["Tags"].ToString()
                            });
                        }
                    }
                }
            }

            return View(blogs);
        }

        public IActionResult BlogDetails(int id)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Blog> allBlogs = new List<Blog>();
            Blog currentBlog = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Blog ORDER BY ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var blog = new Blog
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                Blogimg1 = reader["BlogImg1"].ToString(),
                                Author = reader["Author"].ToString(),
                                Paragraph1 = reader["Paragraph1"].ToString(),
                                Paragraph2 = reader["Paragraph2"].ToString(),
                                Blogimg2 = reader["BlogImg2"].ToString(),
                                Category = reader["Category"].ToString(),
                                Postdate = reader["Postdate"].ToString(),
                                Tags = reader["Tags"].ToString()
                            };
                            allBlogs.Add(blog);
                            if (blog.ID == id) currentBlog = blog;
                        }
                    }
                }
            }

            if (currentBlog == null)
                return NotFound();

            int index = allBlogs.FindIndex(b => b.ID == id);
            ViewBag.PrevBlog = index > 0 ? allBlogs[index - 1] : null;
            ViewBag.NextBlog = index < allBlogs.Count - 1 ? allBlogs[index + 1] : null;

            return View("BlogDetails", currentBlog);
        }

        public IActionResult Qawwali()
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Qawwali> qawwalis = new List<Qawwali>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Qawwali";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            qawwalis.Add(new Qawwali
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Poetname = reader["Poetname"].ToString(),
                                Youtubeurl = reader["Youtubeurl"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Audio = reader["Audio"].ToString(),
                                Lyrics = reader["Lyrics"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
            }

            return View("QawwaliPage", qawwalis);
        }

        public IActionResult QawwaliDetails(int id)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Qawwali> allQawwalis = new List<Qawwali>();
            Qawwali current = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Qawwali ORDER BY ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var qawwali = new Qawwali
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Poetname = reader["Poetname"].ToString(),
                                Youtubeurl = reader["Youtubeurl"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Audio = reader["Audio"].ToString(),
                                Lyrics = reader["Lyrics"].ToString(),
                                Description = reader["Description"].ToString()
                            };
                            allQawwalis.Add(qawwali);
                            if (qawwali.ID == id) current = qawwali;
                        }
                    }
                }
            }

            if (current == null)
                return NotFound();

            int index = allQawwalis.FindIndex(q => q.ID == id);
            ViewBag.PrevQawwali = index > 0 ? allQawwalis[index - 1] : null;
            ViewBag.NextQawwali = index < allQawwalis.Count - 1 ? allQawwalis[index + 1] : null;

            return View("QawwaliDetails", current);
        }

        public IActionResult Writer()
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Writer> writers = new List<Writer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Writer";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            writers.Add(new Writer
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString(),
                                Desc1 = reader["Desc1"].ToString(),
                                Desc2 = reader["Desc2"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                DOD = reader["DOD"].ToString(),
                                WriterType = reader["WriterType"].ToString(),
                                Quote = reader["Quote"].ToString(),
                                Famous = reader["Famous"].ToString(),
                                ViewMore = reader["ViewMore"].ToString()
                            });
                        }
                    }
                }
            }

            return View(writers);
        }

        public IActionResult WriterDetails(int id)
        {
            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            List<Writer> allWriters = new List<Writer>();
            Writer current = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Writer ORDER BY ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var writer = new Writer
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString(),
                                Desc1 = reader["Desc1"].ToString(),
                                Desc2 = reader["Desc2"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                DOD = reader["DOD"].ToString(),
                                WriterType = reader["WriterType"].ToString(),
                                Quote = reader["Quote"].ToString(),
                                Famous = reader["Famous"].ToString(),
                                ViewMore = reader["ViewMore"].ToString()
                            };
                            allWriters.Add(writer);
                            if (writer.ID == id) current = writer;
                        }
                    }
                }
            }

            if (current == null)
                return NotFound();

            int index = allWriters.FindIndex(w => w.ID == id);
            ViewBag.PrevWriter = index > 0 ? allWriters[index - 1] : null;
            ViewBag.NextWriter = index < allWriters.Count - 1 ? allWriters[index + 1] : null;

            return View("WriterDetails", current);
        }

        public IActionResult About() => View();
        public IActionResult Contact() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();

        [HttpGet]
        public IActionResult Search(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return RedirectToAction("Index");
            }

            var connectionString = _configuration.GetConnectionString("SUFEEASPContext");
            var searchResults = new SearchViewModel
            {
                Blogs = new List<Blog>(),
                Ebooks = new List<Ebook>(),
                Qawwalis = new List<Qawwali>(),
                Writers = new List<Writer>()
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string blogQuery = @"
                    SELECT * FROM Blog 
                    WHERE Title LIKE @SearchTerm 
                    OR Description LIKE @SearchTerm 
                    OR Author LIKE @SearchTerm 
                    OR Tags LIKE @SearchTerm";
                using (SqlCommand command = new SqlCommand(blogQuery, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{s}%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Blogs.Add(new Blog
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                Blogimg1 = reader["BlogImg1"].ToString(),
                                Author = reader["Author"].ToString(),
                                Paragraph1 = reader["Paragraph1"].ToString(),
                                Paragraph2 = reader["Paragraph2"].ToString(),
                                Blogimg2 = reader["BlogImg2"].ToString(),
                                Category = reader["Category"].ToString(),
                                Postdate = reader["Postdate"].ToString(),
                                Tags = reader["Tags"].ToString()
                            });
                        }
                    }
                }

                string ebookQuery = @"
                    SELECT * FROM Ebook 
                    WHERE Name LIKE @SearchTerm 
                    OR Author LIKE @SearchTerm";
                using (SqlCommand command = new SqlCommand(ebookQuery, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{s}%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Ebooks.Add(new Ebook
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Author = reader["Author"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Booklink = reader["Booklink"].ToString()
                            });
                        }
                    }
                }

                string qawwaliQuery = @"
                    SELECT * FROM Qawwali 
                    WHERE Title LIKE @SearchTerm 
                    OR Poetname LIKE @SearchTerm 
                    OR Description LIKE @SearchTerm 
                    OR Lyrics LIKE @SearchTerm";
                using (SqlCommand command = new SqlCommand(qawwaliQuery, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{s}%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Qawwalis.Add(new Qawwali
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = reader["Title"].ToString(),
                                Poetname = reader["Poetname"].ToString(),
                                Youtubeurl = reader["Youtubeurl"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                Audio = reader["Audio"].ToString(),
                                Lyrics = reader["Lyrics"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }

                string writerQuery = @"
                    SELECT * FROM Writer 
                    WHERE Name LIKE @SearchTerm 
                    OR City LIKE @SearchTerm 
                    OR Desc1 LIKE @SearchTerm 
                    OR Desc2 LIKE @SearchTerm 
                    OR WriterType LIKE @SearchTerm 
                    OR Quote LIKE @SearchTerm 
                    OR Famous LIKE @SearchTerm";
                using (SqlCommand command = new SqlCommand(writerQuery, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{s}%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Writers.Add(new Writer
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString(),
                                Desc1 = reader["Desc1"].ToString(),
                                Desc2 = reader["Desc2"].ToString(),
                                Imgurl = reader["Imgurl"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                DOD = reader["DOD"].ToString(),
                                WriterType = reader["WriterType"].ToString(),
                                Quote = reader["Quote"].ToString(),
                                Famous = reader["Famous"].ToString(),
                                ViewMore = reader["ViewMore"].ToString()
                            });
                        }
                    }
                }
            }

            return View("SearchResults", searchResults);
        }
    }
}