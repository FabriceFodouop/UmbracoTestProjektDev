using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Mapping;
using UmbracoTestProject.Mapping;

namespace UmbracoTestProject.Composers
{
    public class NewsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
                .Add<NewstMappingDefinition>();
        }
    }
}
