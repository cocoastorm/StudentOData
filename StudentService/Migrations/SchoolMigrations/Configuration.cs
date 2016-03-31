namespace StudentService.Migrations.SchoolMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentService.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SchoolMigrations";
        }

        protected override void Seed(SchoolContext context)
        {
            context.Students.AddOrUpdate(
              s => new { s.FirstName, s.LastName },
              new Student { FirstName = "Andrew", LastName = "Peters", Major = "Pharmacy" },
              new Student { FirstName = "Brice", LastName = "Lambson", Major = "Business" },
              new Student { FirstName = "Rowan", LastName = "Miller", Major = "Medicine" }
            );
        }

    }
}
