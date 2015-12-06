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
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/sede").Include(
                       "~/Scripts/sede.js"));

            bundles.Add(new ScriptBundle("~/bundles/mesa").Include(
                        "~/Scripts/Mesa.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.*"));

            bundles.Add(new StyleBundle("~/bundles/jquery-ui").Include(
                        "~/Content/jquery-ui.*"));

            bundles.Add(new ScriptBundle("~/bundles/andarCss").Include(
                        "~/Content/Andar.css",
                        "~/Content/TerceiroAndarCWISL.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"));
                    
        }
    }
}