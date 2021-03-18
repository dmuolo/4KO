using System.Web.Optimization;

namespace StoreFront.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/vendor/owl.carousel/assets/owl.carousel.css",
                "~/Content/vendor/owl.carousel/assets/owl.theme.default.css",
                "~/Content/css/style.default.css",
                "~/Content/css/custom.css",
                "~/Content/css/PagedList.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery.cookie/jquery.cookie.js",
                "~/Content/vendor/owl.carousel/owl.carousel.min.js",
                "~/Content/vendor/owl.carousel2.thumbs/owl.carousel2.thumbs.js",
                "~/Content/js/front.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
