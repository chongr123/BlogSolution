using Abp.Localization;
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
                var localizationManager = Abp.Dependency.IocManager.Instance.Resolve<ILocalizationManager>();
                var localzableString = new LocalizableString(ResourceKey, Blog_SolutionConsts.LocalizationSourceName);
                _resourceValue = localizationManager.GetString(localzableString);
                return _resourceValue;
            }
        }

        public string Name
        {
            get { return "ResourceDisplayName"; }
        }
    }
}