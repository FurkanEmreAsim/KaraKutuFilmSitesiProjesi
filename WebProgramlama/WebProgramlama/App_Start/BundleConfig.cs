using System.Web;
using System.Web.Optimization;

namespace WebProgramlama
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/lib/jquery.appear.js",
                        "~/Scripts/lib/owl-carousel/owl.carousel.min.js",
                        "~/Scripts/lib/magnific-popup/jquery.magnific-popup.min.js",
                        "~/Scripts/lib/video/jquery.mb.YTPlayer.js",
                        "~/Scripts/lib/flipclock/flipclock.js",
                        "~/Scripts/lib/jquery.animateNumber.js",
                        "~/Scripts/lib/waypoints.min.js",
                        "~/Scripts/main.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/font-awesome/css/font-awesome.min.css",                 
                       "~/Content/style.css",  
                       "~/Content/animate.css"));

            bundles.Add(new StyleBundle("~/Scripts/cssscript").Include(
                      "~/Scripts/lib/owl-carousel/owl.carousel.css",
                      "~/Scripts/lib/owl-carousel/owl.theme.css",
                      "~/Scripts/lib/owl-carousel/owl.transitions.css",
                      "~/Scripts/lib/magnific-popup/magnific-popup.css",
                      "~/Scripts/lib/video/YTPlayer.css",
                      "~/Scripts/lib/flipclock/flipclock.css"));

            //* Admin *//

            bundles.Add(new StyleBundle("~/assets/css/styles.css").Include(
                      "~/assets/css/styles.css",
                      "~/assets/demo/variations/header-blue.css"));

            bundles.Add(new StyleBundle("~/assets/css/ie8.css").Include(
                      "~/assets/css/ie8.css"));

            bundles.Add(new ScriptBundle("~/assets/js/plugin-before").Include(
                      "~/assets/js/jqueryui-1.10.3.min.js",
                      "~/assets/js/bootstrap.min.js",
                      "~/assets/js/enquire.js",
                      "~/assets/js/jquery.cookie.js",
                      "~/assets/js/jquery.nicescroll.min.js"));

            bundles.Add(new ScriptBundle("~/assets/js/plugin-after").Include(
                      "~/assets/js/placeholdr.js",
                      "~/assets/js/application.js"));

            bundles.Add(new ScriptBundle("~/Template/js/master_core.js").Include(
                      "~/Template/js/master_core.js"));

            bundles.Add(new ScriptBundle("~/Template/js/showLoading.js").Include(
                     "~/Template/js/showLoading.js"));

            bundles.Add(new StyleBundle("~/Template/css/master_styles.css").Include(
                      "~/Template/css/master_styles.css"));
        }
    }
}
