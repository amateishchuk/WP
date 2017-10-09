using System.Web.Optimization;

namespace WP.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/controllers/coreApp.js",
                    "~/Scripts/controllers/rootCtrl.js",
                    "~/bower_components/angucomplete-alt/dist/angucomplete-alt.min.js"));
        }
    }
}