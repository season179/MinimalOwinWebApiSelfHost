using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using MinimalOwinWebApiSelfHost.Models;

namespace MinimalOwinWebApiSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup and seed the database:
            Console.WriteLine("Initializing and seeding database...");
            Database.SetInitializer(new ApplicationDbInitializer());
            var db = new ApplicationDbContext();
            int count = db.Companies.Count();
            Console.WriteLine("Initializing and seeding databse with {0} company records...", count);

            // Specify the URI to use for the local host:
            string baseUri = "http://localhost:8080/";

            Console.WriteLine("Starting web server...");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit.", baseUri);
            Console.ReadLine();
        }
    }
}
