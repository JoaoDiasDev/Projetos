using JoaoDiasBlog.Entities;
using JoaoDiasBlog.Models;
using JoaoDiasBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace JoaoDiasBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        PostService _postService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _postService = new PostService(configuration);
        }

        public IActionResult Index()
        {

            List<Post> myPostList = _postService.GetAll();
            //BlogModel model = new BlogModel();
            //model.postList = myPostList;

            BlogModel model = new BlogModel
            {
                postList = myPostList,

            };
            return View(model);
        }


        public IActionResult PostDetail(int id)
        {
            Post myPost = _postService.Get(id);
            BlogModel model = new BlogModel
            {

                post = myPost
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Search([FromQuery(Name = "q")] string searchText = "")
        {
            List<Post> mySearchList = _postService.GetSearch(searchText);
            BlogModel model = new BlogModel
            {
                postList = mySearchList
            };

            return View("Index", model);
        }

    }
}
