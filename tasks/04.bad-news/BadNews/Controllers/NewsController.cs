using System;
using BadNews.ModelBuilders.News;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BadNews
{
    public class NewsController : Controller
    {
        private readonly INewsModelBuilder newsModelBuilder;

        public NewsController(INewsModelBuilder newsModelBuilder)
        {
            this.newsModelBuilder = newsModelBuilder;
        }
      
        public IActionResult Index(int pageIndex = 0)
        {
            var model = newsModelBuilder.BuildIndexModel(pageIndex, false, null);
            return View(model);
        }

        public IActionResult Index1(Guid id)
        {
            var model = newsModelBuilder.BuildFullArticleModel(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
    }
}