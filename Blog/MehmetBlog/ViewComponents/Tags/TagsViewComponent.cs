using BussniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.Tags
{
    public class TagsViewComponent : ViewComponent
    {
        IBlogServirce _blogServirce;

        public TagsViewComponent(IBlogServirce blogServirce)
        {
            _blogServirce = blogServirce;
        }

        public IViewComponentResult Invoke(int id)
        {

            List<string> tags = _blogServirce.GetListAll().Select(x=>x.BlogTags).ToList();
            List<string> tag = new List<string>();
            foreach (var item in tags )
            {
                foreach (var itm in item.Split(","))
                {
                    tag.Add(itm);
                }                                               
                  
            }
            return View(tag);
        }
    }
}
