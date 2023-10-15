using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoTestProject.Models;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Mapping;
using UmbracoTestProject.Mapping;

namespace UmbracoTestProject.Controllers
{
    public class NewsTeaserApiController : UmbracoApiController
    {
        private readonly IUmbracoContextAccessor contentService;
        private readonly IUmbracoMapper mapper;

        public NewsTeaserApiController(IUmbracoContextAccessor contentService, IUmbracoMapper mapper)
        {
            this.contentService = contentService;
            this.mapper = mapper;
        }

        [HttpGet("api/newsteaser")]
        public JsonResult MyAction()
        {
            if (contentService.TryGetUmbracoContext(out IUmbracoContext? context) == false)
            {
                return new JsonResult(this.Problem("unable to get content"));
            }

            if (context.Content == null)
            {
                return new JsonResult(this.Problem("Content Cache is null"));
            }

            var landingSeite = (LandingPage)context.Content.GetAtRoot().First();

            BlockListItem? newsTeaser = landingSeite?.MyNewsTeaser?.First();
            var newsItemContent = (NewsItemsRow)newsTeaser.Content;
            var newsItemList = newsItemContent?.NewsItems;

            List<NewsModel> newsModelList = NewsMapper.Map(newsItemList, mapper).ToList();

            return new JsonResult(newsModelList);
        }
    }
}
