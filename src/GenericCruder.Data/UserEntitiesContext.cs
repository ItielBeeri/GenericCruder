using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
//using ETL.GenericCruder.UserEntities.Tasks;
using ETL.GenericCruder.UserEntities.Cars;
//using ETL.GenericCruder.UserEntities.People;
using System.Data.Entity.Infrastructure;
using ETL.GenericCruder.Data.Migrations;
using ETL.GenericCruder.UserEntities.Kitchen;
using ETL.GenericCruder.UserEntities.Restaurant;
using ETL.GenericCruder.UserEntities.Gantt;
using ETL.GenericCruder.UserEntities.HouseCommittee;

namespace ETL.GenericCruder.Data
{
    public class UserEntitiesContext :DbContext
    {
        //public DbSet<Task> Tasks { get; set; }
        public DbSet<Car> Cars { get; set; }
        //public DbSet<Person> People { get; set; }

        //kitchen
        public DbSet<product> Products { get; set; }
        public DbSet<vegetableAndFruit> VegetablesAndFruits { get; set; }
        public DbSet<receipe> Receipes { get; set; }
        public DbSet<card> Cards { get; set; }
        public DbSet<image> Images { get; set; }

        //restaurant
        public DbSet<person> Persons { get; set; }
        public DbSet<clubMember> ClubMembers { get; set; }
        public DbSet<reaction> Reactions { get; set; }
        public DbSet<account> Accounts { get; set; }
        public DbSet<payCardInvitation> payCardInvitations { get; set; }
        
        //gantt
        public DbSet<task> Tasks { get; set; }
        public DbSet<simTask> SimTasks { get; set; }
        public DbSet<project> Projects { get; set; }
        public DbSet<employeePart> EmployeeParts { get; set; }
        public DbSet<managerDetails> ManagerDetails { get; set; }

        //house committee
        public DbSet<Task> HouseTasks { get; set; }
        public DbSet<Message> HouseMessages { get; set; }

        public UserEntitiesContext()
        {
            Database.SetInitializer<UserEntitiesContext>(new MigrateDatabaseToLatestVersion<UserEntitiesContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().ToTable("Tasks", typeof(Task).Namespace.Split('.').Last());
            modelBuilder.Entity<Message>().ToTable("Messages", typeof(Message).Namespace.Split('.').Last());
        }
    }
}
