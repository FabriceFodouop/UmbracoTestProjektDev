using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoTestProject.Models;

namespace UmbracoTestProject.Mapping
{
    public static class NewsMapper
    {
        public static IEnumerable<NewsModel> Map(BlockListModel newsItems, IUmbracoMapper mapper) 
        {
            var newsModelList = new List<NewsModel>();
            foreach(var item in newsItems)
            {
                var newsItem = (NewsItem)item.Content;
                var newsItemSettings = (NewsItemsSettings)item.Settings;
                if (newsItemSettings.Hide) continue;

                newsModelList.Add(mapper.Map<NewsModel>(newsItem));
            }

            return newsModelList;
        }
    }
}
