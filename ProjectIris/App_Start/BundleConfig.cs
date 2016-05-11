using System.Web.Optimization;

namespace ProjectIris
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JavaScript Bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/irisjs").Include(
                "~/Scripts/js/js/Chart.min.js",
                //"~/Scripts/js/chartjs.js",
                "~/Scripts/js/js/bootstrap-switch.min.js",
                "~/Scripts/js/js/jquery.matchHeight-min.js",
                "~/Scripts/js/js/jquery.dataTables.min.js",
                "~/Scripts/js/js/dataTables.bootstrap.min.js",
                "~/Scripts/js/js/select2.full.min.js",
                "~/Scripts/js/js/ace/ace.js",
                "~/Scripts/js/js/ace/mode-html.js",
                "~/Scripts/js/js/ace/theme-github.js"));

            // CSS Bundles
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/misc/css").Include(
                "~/Content/css/themes/flat-green.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/checkbox3.min.css",
                "~/Content/css/dataTables.bootstrap.css",
                "~/Content/css/jquery.dataTables.min.css",
                "~/Content/css/select2.min.css"));
        }
    }
}
