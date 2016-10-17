using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace Lab5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            // Artist Automapping
            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistList>();
            Mapper.CreateMap<Controllers.ArtistAdd, Models.Artist>();

            // Album Autompping
            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Models.Album, Controllers.AlbumList>();
            Mapper.CreateMap<Controllers.AlbumAdd, Models.Album>();

            // Song Automapping
            Mapper.CreateMap<Models.Song, Controllers.SongBase>();
            Mapper.CreateMap<Models.Song, Controllers.SongList>();
            Mapper.CreateMap<Controllers.SongAdd, Models.Song>();

        }
    }
}
