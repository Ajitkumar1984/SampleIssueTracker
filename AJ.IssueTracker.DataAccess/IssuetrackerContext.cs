namespace AJ.IssueTracker.DataAccess
{
    using AJ.IssueTracker.DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IssuetrackerContext : DbContext
    {
        // Your context has been configured to use a 'Issuetracker' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AJ.IssueTracker.DataAccess.Issuetracker' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Issuetracker' 
        // connection string in the application configuration file.
        public IssuetrackerContext()
            : base("name=Issuetracker")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Issue> Issues { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IssueNote> IssueNotes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}