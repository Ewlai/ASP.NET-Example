using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suggestions.Models;
using AutoMapper;

namespace Suggestions.Controllers
{
    public class Manager
    {
        private ApplicationDbContext ds = new ApplicationDbContext();

        public List<String> AllPrograms()
        {
            return ds.Programs.OrderBy(g => g.Code).Select(g => g.Code).ToList();
        }

        public List<String> AllCourses()
        {
            return ds.Courses.OrderBy(g => g.Code).Select(g => g.Code).ToList();
        }

        public SuggestionBase AddSuggestion(SuggestionAdd newItem)
        {
            var addedItem = Mapper.Map<Suggestion>(newItem);

            // extract bytes in HttpPostedFile object

            byte[] contentBytes = new byte[newItem.ContentUpload.ContentLength];
            newItem.ContentUpload.InputStream.Read(contentBytes, 0, newItem.ContentUpload.ContentLength);
            
            // configure the new object's properties
            addedItem.Attachment = contentBytes;
            addedItem.ContentType = newItem.ContentUpload.ContentType;
            addedItem.Timestamp = DateTime.Now;
            ds.Suggestions.Add(addedItem);
            ds.SaveChanges();

            return Mapper.Map<SuggestionBase>(addedItem);
        }

        public SuggestionBase EditSuggestion(SuggestionEdit editItem)
        {

            var fetchedObject = ds.Suggestions.Find(editItem.Id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                ds.Entry(fetchedObject).CurrentValues.SetValues(editItem);
                ds.SaveChanges();

                return Mapper.Map<SuggestionBase>(editItem);
            }

        }

        public bool DeleteSuggestionById(int id)
        {
            var fetchedObject = ds.Suggestions.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.Suggestions.Remove(fetchedObject);
                ds.SaveChanges();
                return true;
            }
        }

        public IEnumerable<SuggestionBase> AllSuggestions()
        {
            var fetchedObjects = ds.Suggestions.OrderBy(a => a.Title);

            return Mapper.Map<IEnumerable<SuggestionBase>>(fetchedObjects);
        }

        public IEnumerable<SuggestionList> AllSuggestionsList()
        {
            var fetchedObjects = ds.Suggestions.OrderBy(a => a.Title);

            return Mapper.Map<IEnumerable<SuggestionList>>(fetchedObjects);
        }

        public SuggestionBase GetSuggestionById(int id)
        {
            var fetchedObject = ds.Suggestions.SingleOrDefault(a => a.Id == id);

            return (fetchedObject == null) ? null : Mapper.Map<SuggestionBase>(fetchedObject);
        }

        public SuggestionBaseWithFollowUps GetSuggestionByIdWithFollowUps(int id)
        {
            var fetchedObject = ds.Suggestions.Include("FollowUps").SingleOrDefault(a => a.Id == id);

            return (fetchedObject == null) ? null : Mapper.Map<SuggestionBaseWithFollowUps>(fetchedObject);
        }

        public FollowUpBase AddFollowUp(FollowUpAdd newItem)
        {
            var fetchedObject = ds.Suggestions.Find(newItem.SuggestionId);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                var addItem = Mapper.Map<FollowUp>(newItem);

                // extract bytes in HttpPostedFile object
                byte[] contentBytes = new byte[newItem.ContentUpload.ContentLength];
                newItem.ContentUpload.InputStream.Read(contentBytes, 0, newItem.ContentUpload.ContentLength);

                // configure the new object's properties
                addItem.Attachment = contentBytes;
                addItem.ContentType = newItem.ContentUpload.ContentType;

                addItem.Timestamp = DateTime.Now;
                addItem.Suggestion = fetchedObject;
                ds.FollowUps.Add(addItem);
                ds.SaveChanges();

                return Mapper.Map<FollowUpBase>(addItem);
            }

        }

        public FollowUpBase EditFollowUp(FollowUpEdit editItem)
        {

            var fetchedObject = ds.FollowUps.Find(editItem.Id);
            var fetchedSuggestionObject = ds.Suggestions.Find(editItem.Suggestion);

            if (fetchedObject == null){

                return null;

            } else if(fetchedSuggestionObject == null){

                return null;

            } else {

                var editedItem = Mapper.Map<FollowUp>(editItem);
                editedItem.Suggestion = fetchedSuggestionObject;
                ds.Entry(fetchedObject).CurrentValues.SetValues(editedItem);
                ds.SaveChanges();

                return Mapper.Map<FollowUpBase>(editedItem);
            }

        }

        public bool DeleteFollowUpById(int id)
        {
            var fetchedObject = ds.FollowUps.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.FollowUps.Remove(fetchedObject);
                ds.SaveChanges();
                return true;
            }
        }

        public IEnumerable<FollowUpBase> AllFollowUp()
        {
            var fetchedObjects = ds.FollowUps.Include("Suggestion").OrderBy(a => a.Title);

            return Mapper.Map<IEnumerable<FollowUpBase>>(fetchedObjects);
        }

        public FollowUpBase GetFollowUpById(int id)
        {
            var fetchedObject = ds.FollowUps.Include("Suggestion").SingleOrDefault(a => a.Id == id);

            return (fetchedObject == null) ? null : Mapper.Map<FollowUpBase>(fetchedObject);
        }

    }
}