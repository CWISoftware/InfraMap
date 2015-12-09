using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace InfraMap.Web.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery.easy-autocomplete.js",
                        "~/Scripts/jquery.easy-autocomplete.min.js",
                        "~/Scripts/Custom/base.js",
                        "~/Scripts/infra-map-auto-complete.js",
                        "~/Scripts/modernizr-*",
                        "~/Scripts/Custom/sede.js",
                        "~/Scripts/Custom/Mesa.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.*"));

            bundles.Add(new StyleBundle("~/bundles/jquery-ui").Include(
                        "~/Content/jquery-ui.*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/Site.css",
                        "~/Content/easy-autocomplete.min.css",
                        "~/Content/easy-autocomplete.theme.min.css",
                        "~/Content/font-awesome.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/Custom/Andar.css",
                        "~/Content/Custom/TerceiroAndarCWISL.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"));
                    
        }
    }
}