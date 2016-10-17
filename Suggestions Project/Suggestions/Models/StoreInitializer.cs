using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Suggestions.Controllers;
using System.IO;
using CsvHelper;
using AutoMapper;

namespace Suggestions.Models
{
    public class StoreInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        private Manager m = new Manager();

        protected override void Seed(ApplicationDbContext context)
        {
            
            if (context.Programs.Count()== 0)
            {
                // File system path to the data file (in this project's App_Data folder)
                string path = HttpContext.Current.Server.MapPath("~/App_Data/ict-programs.csv");

                // Create a stream reader object, to read from the file system
                StreamReader sr = File.OpenText(path);

                // Create the CsvHelper object
                var csv = new CsvReader(sr);

                // Process the file contents in a loop

                while (csv.Read())
                {
                    ProgramAdd addProgram = csv.GetRecord<ProgramAdd>();
                    context.Programs.Add(Mapper.Map<Program>(addProgram));
                }

                // Clean up
                sr.Close();
                sr = null;

                // Deliver or otherwise process the results
                context.SaveChanges();
            }

            if (context.Courses.Count() == 0)
            {
                // File system path to the data file (in this project's App_Data folder)
                string path = HttpContext.Current.Server.MapPath("~/App_Data/ict-courses-bsd.csv");

                // Create a stream reader object, to read from the file system
                StreamReader sr = File.OpenText(path);

                // Create the CsvHelper object
                var csv = new CsvReader(sr);

                // Process the file contents in a loop

                while (csv.Read())
                {
                    CourseAdd addCourse = csv.GetRecord<CourseAdd>();
                    context.Courses.Add(Mapper.Map<Course>(addCourse));
                }

                // Clean up
                sr.Close();
                sr = null;

                // Deliver or otherwise process the results
                context.SaveChanges();
            }
             
            /*
            var bsd = new Program();
            bsd.Code = "BSD";
            bsd.Name = "Bachelor of Software Development";
            bsd.Description = "Welcome to Bachelor of Software Development...";
            bsd.Credential = "Bachelor degree";
            context.Programs.Add(bsd);
            context.SaveChanges();

            var cpa = new Program();
            cpa.Code = "CPA";
            cpa.Name = "Computer Programmer Analyst";
            cpa.Description = "Welcome to Computer Programmer Analyst...";
            cpa.Credential = "Advanced Diploma";
            context.Programs.Add(cpa);
            context.SaveChanges();

            var cpp = new Course();
            cpp.Code = "cpp";
            cpp.Name = "C++";
            cpp.Description = "Intro to C++";
            context.Courses.Add(cpp);
            context.SaveChanges();

            var oop = new Course();
            oop.Code = "oop";
            oop.Name = "Object Oriented Programming";
            oop.Description = "Programming with Objects";
            context.Courses.Add(oop);
            context.SaveChanges();

            var btc = new Course();
            btc.Code = "btc";
            btc.Name = "Communication";
            btc.Description = "Written and verbal communicaiton course";
            context.Courses.Add(btc);
            context.SaveChanges();
            */

        }
    }
}