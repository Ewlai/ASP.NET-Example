using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;
using AutoMapper;
namespace Lab5.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        public List<string> AllGenres()
        {
            return ds.Genres.OrderBy(g => g.Name).Select(g => g.Name).ToList();
        }

        public ArtistBase AddArtist(ArtistAdd newItem)
        {
            var addedItem = Mapper.Map<Artist>(newItem);
            ds.Artists.Add(addedItem);
            ds.SaveChanges();

            return Mapper.Map<ArtistBase>(addedItem);
        }

        public IEnumerable<ArtistBase> AllArtists()
        {
            var fetchedObjects = ds.Artists.OrderBy(a => a.Name);

            return Mapper.Map<IEnumerable<ArtistBase>>(fetchedObjects);
        }

        public IEnumerable<ArtistList> AllArtistsList()
        {
            var fetchedObjects = ds.Artists.OrderBy(a => a.Name);

            return Mapper.Map<IEnumerable<ArtistList>>(fetchedObjects); 
        }

        public AlbumBase AddAlbum(AlbumAdd newItem)
        {
            var fetchedObject = ds.Artists.Find(newItem.ArtistId);

            if(fetchedObject == null)
            {
                return null;
            }
            else
            {
                var addItem = Mapper.Map<Album>(newItem);
                addItem.Artist = fetchedObject;
                ds.Albums.Add(addItem);
                ds.SaveChanges();

                return Mapper.Map<AlbumBase>(addItem);
            }
        }

        public SongBase AddSong(SongAdd newItem)
        {
            var fetchedObject = ds.Albums.Find(newItem.AlbumId);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                var addItem = Mapper.Map<Song>(newItem);
                addItem.Album = fetchedObject;
                ds.Songs.Add(addItem);
                ds.SaveChanges();

                return Mapper.Map<SongBase>(addItem);
            }
        }

        public IEnumerable<AlbumBase> AllAlbums()
        {

            var fetchedObjects = ds.Albums.Include("Artist").OrderBy(a => a.Name);

            return Mapper.Map<IEnumerable<AlbumBase>>(fetchedObjects);
        }

        public IEnumerable<AlbumList> AllAlbumsList()
        {
            var fetchedObjects = ds.Albums.Include("Artist").OrderBy(a => a.Name);

            return Mapper.Map<IEnumerable<AlbumList>>(fetchedObjects);
        }

        public IEnumerable<SongBase> AllSongs()
        {

            var fetchedObjects = ds.Songs.Include("Album").OrderBy(a => a.Name);

            return Mapper.Map<IEnumerable<SongBase>>(fetchedObjects);
        }

    }
}