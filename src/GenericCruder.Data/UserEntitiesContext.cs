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
//using ETL.GenericCruder.UserEntities.Kitchen;
//using ETL.GenericCruder.UserEntities.Restaurant;
using ETL.GenericCruder.UserEntities.Gantt;
//using ETL.GenericCruder.UserEntities.HouseCommittee;
using ETL.GenericCruder.UserEntities.GmachHon;
using ETL.GenericCruder.UserEntities.InviteesManager;
using ETL.GenericCruder.UserEntities.ReturningLost;
using ETL.GenericCruder.UserEntities.Catering;
using ETL.GenericCruder.UserEntities.BookStore;
using Music = ETL.GenericCruder.UserEntities.MusicSchool;
using ETL.GenericCruder.UserEntities.ProjectManagement;
using Kidum = ETL.GenericCruder.UserEntities.KidumNoar;
using Nibit = ETL.GenericCruder.UserEntities.Nibit;
using WhereHouse = ETL.GenericCruder.UserEntities.WhereHouse;

namespace ETL.GenericCruder.Data
{
    public class UserEntitiesContext : DbContext
    {
        //public DbSet<Task> Tasks { get; set; }
        public DbSet<Car> Cars { get; set; }
        //public DbSet<Person> People { get; set; }

        ////kitchen
        //public DbSet<product> Products { get; set; }
        //public DbSet<vegetableAndFruit> VegetablesAndFruits { get; set; }
        //public DbSet<receipe> Receipes { get; set; }
        //public DbSet<card> Cards { get; set; }
        //public DbSet<image> Images { get; set; }

        ////restaurant
        //public DbSet<person> Persons { get; set; }
        //public DbSet<clubMember> ClubMembers { get; set; }
        //public DbSet<reaction> Reactions { get; set; }
        //public DbSet<account> Accounts { get; set; }
        //public DbSet<payCardInvitation> payCardInvitations { get; set; }

        //gantt
        //public DbSet<task> Tasks { get; set; }
        //public DbSet<simTask> SimTasks { get; set; }
        //public DbSet<project> Projects { get; set; }
        //public DbSet<employeePart> EmployeeParts { get; set; }
        //public DbSet<managerDetails> ManagerDetails { get; set; }

        ////house committee
        //public DbSet<Task> HouseTasks { get; set; }
        //public DbSet<Message> HouseMessages { get; set; }

        //gmachhon
        public DbSet<contact> Contacts { get; set; }
        public DbSet<transaction> Transactions { get; set; }

        //InviteesManager
        public DbSet<user> Users { get; set; }
        public DbSet<@event> Events { get; set; }
        public DbSet<invitee> Invitees { get; set; }

        //ReturningLost
        public DbSet<person> Persons { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<sign> Signs { get; set; }

        //Catering
        public DbSet<order> Orders { get; set; }
        public DbSet<meal> Meals { get; set; }

        //BookStore
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<OrderStatus> OrdersStatus { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }

        //MusicSchool
        public DbSet<Music.User> MusicSchoolUsers { get; set; }
        public DbSet<Music.Song> Songs { get; set; }
        public DbSet<Music.SongRow> SongRows { get; set; }

        //ProjectManagement
        public DbSet<User> ProjectManagementUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Design> Design { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<File> Files { get; set; }

        //KidumNoar
        public DbSet<Kidum.person> KidumPersons { get; set; }
        public DbSet<Kidum.question> Questions { get; set; }
        public DbSet<Kidum.answer> Answers { get; set; }
        public DbSet<Kidum.fillForms> FillForms { get; set; }

        //Nibit
        public DbSet<Nibit.Activity> Activities { get; set; }
        public DbSet<Nibit.Category> NibitCategories { get; set; }
        public DbSet<Nibit.Client> Clients { get; set; }
        public DbSet<Nibit.Notification> Notifications { get; set; }
        public DbSet<Nibit.Product> NibitProducts { get; set; }
        public DbSet<Nibit.Task> NibitTasks { get; set; }
        public DbSet<Nibit.Worker> Worker { get; set; }

        //WhereHouse
        public DbSet<WhereHouse.Category> WhereHouseCategories { get; set; }
        public DbSet<WhereHouse.Item> Items { get; set; }
        public DbSet<WhereHouse.Location> Locations { get; set; }
        public DbSet<WhereHouse.User> WhereHouseUsers { get; set; }


        public UserEntitiesContext()
        {
            Database.SetInitializer<UserEntitiesContext>(new MigrateDatabaseToLatestVersion<UserEntitiesContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Message>().ToTable("Messages", typeof(Message).Namespace.Split('.').Last());

            //MusicSchool
            modelBuilder.Entity<Music.User>().ToTable("Users", typeof(Music.User).Namespace.Split('.').Last());
            modelBuilder.Entity<Music.Song>().ToTable("Songs", typeof(Music.Song).Namespace.Split('.').Last());
            modelBuilder.Entity<Music.SongRow>().ToTable("SongRows", typeof(Music.SongRow).Namespace.Split('.').Last());

            
            
            //ProjectManagement
            modelBuilder.Entity<User>().ToTable("Users", typeof(User).Namespace.Split('.').Last());
            modelBuilder.Entity<Category>().ToTable("Categories", typeof(Category).Namespace.Split('.').Last());
            modelBuilder.Entity<Design>().ToTable("Designs", typeof(Design).Namespace.Split('.').Last());
            modelBuilder.Entity<Task>().ToTable("Tasks", typeof(Task).Namespace.Split('.').Last());
            modelBuilder.Entity<Bug>().ToTable("Bugs", typeof(Bug).Namespace.Split('.').Last());
            modelBuilder.Entity<File>().ToTable("Files", typeof(File).Namespace.Split('.').Last());

            modelBuilder.Entity<User>().HasMany(u => u.ownedTasks).WithOptional().HasForeignKey(t => t.owner);
            modelBuilder.Entity<User>().HasMany(u => u.assigedTasks).WithOptional().HasForeignKey(t => t.assignTo);
            modelBuilder.Entity<User>().HasMany(u => u.ownedBugs).WithOptional().HasForeignKey(b => b.owner);
            modelBuilder.Entity<User>().HasMany(u => u.assignedBugs).WithOptional().HasForeignKey(b => b.assignTo);


            //KidumNoar
            modelBuilder.Entity<Kidum.person>().ToTable("Persons", typeof(Kidum.person).Namespace.Split('.').Last());
            modelBuilder.Entity<Kidum.question>().ToTable("Questions", typeof(Kidum.question).Namespace.Split('.').Last());
            modelBuilder.Entity<Kidum.answer>().ToTable("answers", typeof(Kidum.answer).Namespace.Split('.').Last());
            modelBuilder.Entity<Kidum.fillForms>().ToTable("fillForms", typeof(Kidum.fillForms).Namespace.Split('.').Last());

            modelBuilder.Entity<Kidum.person>().HasMany(p => p.answers).WithOptional().HasForeignKey(a => a.studentId);
            modelBuilder.Entity<Kidum.person>().HasMany(p => p.teacherForms).WithOptional().HasForeignKey(f => f.userId);
            modelBuilder.Entity<Kidum.person>().HasMany(p => p.studentForms).WithOptional().HasForeignKey(f => f.studentId);



            //Nibit
            modelBuilder.Entity<Nibit.Activity>().ToTable("Activities", typeof(Nibit.Activity).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Category>().ToTable("Categories", typeof(Nibit.Category).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Client>().ToTable("Clients", typeof(Nibit.Client).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Notification>().ToTable("Notifications", typeof(Nibit.Notification).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Product>().ToTable("Products", typeof(Nibit.Product).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Task>().ToTable("Tasks", typeof(Nibit.Task).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Worker>().ToTable("Workers", typeof(Nibit.Worker).Namespace.Split('.').Last());

            modelBuilder.Entity<Nibit.Task>().HasMany(t => t.Activities).WithOptional().HasForeignKey(a => a.TaskId);
            modelBuilder.Entity<Nibit.Worker>().HasMany(w => w.Activities).WithOptional().HasForeignKey(a => a.ActualWorker);

            


            //WhereHouse
            modelBuilder.Entity<WhereHouse.Category>().ToTable("Categories", typeof(WhereHouse.Category).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.Item>().ToTable("Items", typeof(WhereHouse.Item).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.Location>().ToTable("Locations", typeof(WhereHouse.Location).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.User>().ToTable("Users", typeof(WhereHouse.User).Namespace.Split('.').Last());

        }
    }
}
