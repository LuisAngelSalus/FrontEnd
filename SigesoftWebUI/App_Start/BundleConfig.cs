using System.Web.Optimization;

namespace SigesoftWebUI
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Add DropZone Scripts
            bundles.Add(new ScriptBundle("~/bundles/dropzonejs").Include(
                     "~/Scripts/dropzone/dropzone.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/nifty").Include(
                      "~/Content/nifty.min.css",
                      "~/Content/demo/nifty-demo-icons.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/nifty").Include(
                        "~/Scripts/nifty.min.js"
                        ));

            //Add DropZone CSS
            bundles.Add(new StyleBundle("~/Content/dropzonecss").Include(
                     "~/Scripts/dropzone/basic.css",
                     "~/Scripts/dropzone/dropzone.css"));

        }
    }
}