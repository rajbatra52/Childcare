using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using  static Childcare.Models.Child;

namespace Childcare
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //Database.SetInitializer<ChildDBContext>
            //(new DropCreateDatabaseIfModelChanges<ChildDBContext>());
            Database.SetInitializer<ChildDBContext>(null);
            //Database.SetInitializer(new DBInitializer());

            //// Forces initialization of database on model changes.
            //using (var context = new ApplicationDB())
            //{
            //    context.Database.Initialize(force: true);
            //}
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
