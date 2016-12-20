using System.Web.Optimization;

namespace Blog_Solution.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var kendoVersion = "2014.1.318";

            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                    .Include("~/Content/themes/base/all.css", new CssRewriteUrlTransform())
                    .Include("~/Content/bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/Content/bootstrap-cosmo.min.css", new CssRewriteUrlTransform())
                    .Include("~/Content/toastr.min.css")
                    .Include("~/Scripts/sweetalert/sweet-alert.css")
                    .Include("~/Content/flags/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                    .Include(string.Format("~/Content/kendo/{0}/kendo.common.min.css",kendoVersion) , new CssRewriteUrlTransform())
                    .Include(string.Format("~/Content/kendo/{0}/kendo.default.min.css", kendoVersion), new CssRewriteUrlTransform())
                    .Include(string.Format("~/Content/kendo/{0}/kendo.bootstrap.min.css", kendoVersion), new CssRewriteUrlTransform())
                    .Include(string.Format("~/Content/adminLTE/AdminLTE-2.3.0.min.css", kendoVersion), new CssRewriteUrlTransform())
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js",
                        "~/Scripts/json2.min.js",
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/common.js"
                    )
                );
            
            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                       "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",

                        string.Format("~/Scripts/kendo/{0}/kendo.web.min.js", kendoVersion),
                        string.Format("~/Scripts/kendo/{0}/cultures/kendo.culture.zh-CN.min.js", kendoVersion),

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/css/main.css")
                );

            //~/Bundles/js
            bundles.Add(
                new ScriptBundle("~/Bundles/js")
                    .Include("~/js/main.js")
                );
        }
    }
}