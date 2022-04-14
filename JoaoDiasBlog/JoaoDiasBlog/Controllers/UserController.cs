using JoaoDiasBlog.Entities;
using JoaoDiasBlog.Models;
using JoaoDiasBlog.Services;
using Microsoft.AspNetCore.Mvc;

namespace JoaoDiasBlog.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        private PostService postService;

        public UserController(IConfiguration configuration)
        {
            userService = new UserService(configuration);
            postService = new PostService(configuration);
        }

        public IActionResult Index()
        {
            string? cookieUsername = HttpContext.Request.Cookies["username"];
            string? cookieUserId = HttpContext.Request.Cookies["userid"];

            if (cookieUserId == "" || cookieUserId == null || cookieUsername == "" || cookieUsername == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<Post> posts = postService.GetAll();
                BlogModel model = new BlogModel
                {
                    postList = posts
                };

                return View(model);
            }


        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel
            {
                user = new User(),
                Success = true
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(User formUser)
        {
            LoginModel model = new LoginModel
            {
                user = new User()
            };

            User myUser = userService.Login(formUser);

            if (myUser.UserId > 0 && myUser.UserName != "" && myUser.Password != "")
            {
                CookieOptions userid = new CookieOptions();
                userid.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Append("userid", myUser.UserId.ToString(), userid);
                CookieOptions username = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(5)
                };
                if (myUser.UserName != null) Response.Cookies.Append("username", myUser.UserName, username);
                return RedirectToAction("Index");
            }

            else
            {
                model = new LoginModel
                {
                    Success = false,
                    user = new User(),
                    Message = "Please check your password and username",

                };
                return View("Login", model);
            }



        }

        [HttpGet]
        public IActionResult Create()
        {
            BlogModel model = new BlogModel();

            return View(model);

        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            post.Publishing_Date = DateTime.Now;
            post.Modified_Date = DateTime.Now;
            post.UserId = int.Parse(HttpContext.Request.Cookies["userid"] ?? string.Empty);
            bool success = postService.Create(post);

            if (success)
            {
                return RedirectToAction("Index");
            }

            else
            {
                ViewBag.Error = "Something went wrong please check it!";
                return View();
            }


        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Post myPost = postService.Get(id);
            if (myPost.PostId == 0)
            {
                return RedirectToAction("Index");
            }
            BlogModel model = new BlogModel
            {
                post = myPost
            };

            return View(model);

        }


        [HttpPost]
        public IActionResult Update(Post post)
        {
            post.Modified_Date = DateTime.Now;
            bool success = postService.Update(post);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Something went wrong please check it!";
                return View();
            }

        }


        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Post post = postService.Get(id);
                if (post == null)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    BlogModel model = new BlogModel
                    {
                        post = post
                    };
                    return View(model);
                }
            }

        }

        [HttpPost]
        public IActionResult Delete(BlogModel model)
        {
            bool success = postService.Delete(model.post);
            if (success)
            {
                ViewBag.success = "Post has been deleted!";
                return View("Deleteit");

            }
            else
            {
                ViewBag.error = "something went wrong please check it";
                return View();
            }

        }

        public IActionResult Deleteit(int id)
        {
            bool success = postService.Delete(id);
            if (success)
            {
                ViewBag.success = "Post has been deleted!";
            }
            else
            {
                ViewBag.error = "something went wrong please try it again!";
            }
            return View();
        }

        public IActionResult LogOut()
        {
            if (HttpContext.Request.Cookies.Count > 0)
            {
                foreach (var item in HttpContext.Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(item);
                }

            }

            return Redirect("/");

        }
    }
}
