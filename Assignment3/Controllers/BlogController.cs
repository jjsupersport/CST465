using Assignment3;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assignment3Namespace.DataModels;
using Assignment3Namespace.Repositories;


namespace Assignment3Namespace.Controllers
{
    [Route("")]
    [Route("Blog")]
    public class BlogController : Controller
    {
        private readonly BlogDBRepository _repository;

        public BlogController(IConfiguration configuration)
        {
            _repository = new BlogDBRepository(configuration);
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var posts = _repository.GetAll();
            return View(posts);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new BlogPostModel());
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new BlogPost
                {
                    Author = model.Author,
                    Title = model.Title,
                    Content = model.Content,
                    Timestamp = DateTime.Now
                };
                _repository.Save(post);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Route("Edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _repository.GetById(id);
            if (post == null) return NotFound();

            var model = new BlogPostModel
            {
                ID = post.ID,
                Author = post.Author,
                Title = post.Title,
                Content = post.Content
            };
            return View(model);
        }

        [Route("Edit/{ID}")]
        [HttpPost]
        public IActionResult Edit(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new BlogPost
                {
                    ID = model.ID,
                    Author = model.Author,
                    Title = model.Title,
                    Content = model.Content,
                    Timestamp = DateTime.Now
                };
                _repository.Save(post);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
