using Abp.Localization.Sources;

namespace Blog_Solution.Web.Framework
{

    public class ResourceDisplayName : System.ComponentModel.DisplayNameAttribute, IModelAttribute
    {
        private string _resourceValue = string.Empty;

        public ResourceDisplayName(string resourceKey)
            : base(resourceKey)
        {
            ResourceKey = resourceKey;
        }

        public string ResourceKey { get; set; }

        public override string DisplayName
        {
            get
            {
                var localizationSource = Abp.Dependency.IocManager.Instance.Resolve<ILocalizationSource>();
                _resourceValue = localizationSource.GetString(ResourceKey);
                return _resourceValue;
            }
        }

        public string Name
        {
            get { return "ResourceDisplayName"; }
        }
    }
}