using System.Web;
using System.Web.Optimization;

namespace Konecta
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                     "~/Scripts/kendo.all.min.js",
                     "~/Scripts/kendo.aspnetmvc.min.js",
                      "~/Scripts/cultures/kendo.culture.es-CO.min.js",
                     "~/Scripts/messages/kendo.messages.es-ES.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/kendo.bootstrap.min.css",
                      "~/Content/kendo.common-bootstrap.min.css",
                      "~/Content/kendo.common.min.css",
                      "~/Content/kendo.common-material.min.css"));
        }
    }
}
