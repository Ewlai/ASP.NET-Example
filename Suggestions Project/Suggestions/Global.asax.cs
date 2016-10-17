using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace Suggestions
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            //Suggestion Automapping
            Mapper.CreateMap<Models.Suggestion, Controllers.SuggestionBase>();
            Mapper.CreateMap<Models.Suggestion, Controllers.SuggestionBaseWithFollowUps>();
            Mapper.CreateMap<Models.Suggestion, Controllers.SuggestionList>();
            Mapper.CreateMap<Controllers.SuggestionAdd, Models.Suggestion>();
            
            //Suggestion Edit Automapping
            Mapper.CreateMap<Controllers.SuggestionBaseWithFollowUps, Controllers.SuggestionEditForm>().ForMember(s => s.Program, t => t.Ignore()).ForMember(s => s.Course, t => t.Ignore());
            Mapper.CreateMap<Controllers.SuggestionEdit, Controllers.SuggestionBase>();
            Mapper.CreateMap<Controllers.SuggestionEdit, Models.Suggestion>();

            // FollowUp Automapping
            Mapper.CreateMap<Models.FollowUp, Controllers.FollowUpBase>();
            Mapper.CreateMap<Models.FollowUp, Controllers.FollowUpList>();
            Mapper.CreateMap<Controllers.FollowUpAdd, Models.FollowUp>();

            //FollowUp Edit Automapping
            Mapper.CreateMap<Controllers.FollowUpBase, Controllers.FollowUpEditForm>().ForMember(s => s.Suggestion, t => t.Ignore());
            //Mapper.CreateMap<Controllers.FollowUpBase, Controllers.FollowUpEditForm>();
            Mapper.CreateMap<Controllers.FollowUpEdit, Controllers.FollowUpBase>();
            Mapper.CreateMap<Controllers.FollowUpEdit, Models.FollowUp>().ForMember(s => s.Suggestion, t => t.Ignore());

            // Program Automapping
            Mapper.CreateMap<Controllers.ProgramAdd, Models.Program>();

            // Course Automapping
            Mapper.CreateMap<Controllers.CourseAdd, Models.Course>();
        }
    }
}
