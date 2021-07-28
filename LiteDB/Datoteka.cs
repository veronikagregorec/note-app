using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.Configuration;

namespace LiteDB
{
    public class File
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        static void Main(string[] args)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var files = db.GetCollection<File>("file");

                // Create your new customer instance
                var file = new File
                {
                    Name = "FirstName LastName",
                };

                // Insert new customer document (Id will be auto-incremented)
                files.Insert(file);

                // Update a document inside a collection
                file.Name = "FirstName LastName";

                files.Update(file);

                // Index document using a document property
                files.EnsureIndex(x => x.Name);

                // Use Linq to query documents
                var results = files.Find(x => x.Name.StartsWith("Fi"));

            }
        }
    }
}