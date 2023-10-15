using NPoco.FluentMappings;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoTestProject.Models;

namespace UmbracoTestProject.Mapping
{
    public class NewstMappingDefinition : IMapDefinition
    {
        public void DefineMaps(IUmbracoMapper mapper) 
        { 
            mapper.Define<NewsItem, NewsModel>((newsItem, context) => new NewsModel(), Map); 
        }

        private void Map(NewsItem newsItem, NewsModel newsModel, MapperContext context) 
        {
            newsModel.Detailtext = newsItem.Detailtext?.ToString();

            newsModel.Teasertext = newsItem.Teasertext;

            newsModel.Ueberschrift = newsItem.Ueberschrift;

            newsModel.TeaserbildUrl = newsItem.Teaserbild?.GetCropUrl(300, 400);

            newsModel.TeaserbildName = newsItem.Teaserbild.Name;
        }
    }
}
