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
        public DbSet<Music.MusicSchoolUser> MusicSchoolUsers { get; set; }
        public DbSet<Music.Song> Songs { get; set; }
        public DbSet<Music.SongRow> SongRows { get; set; }

        //ProjectManagement
        public DbSet<ProjectManagementUser> ProjectManagementUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Design> Design { get; set; }
        public DbSet<ProjectManagementTask> Tasks { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<File> Files { get; set; }

        //KidumNoar
        public DbSet<Kidum.kidumPerson> KidumPersons { get; set; }
        public DbSet<Kidum.question> Questions { get; set; }
        public DbSet<Kidum.answer> Answers { get; set; }
        public DbSet<Kidum.fillForms> FillForms { get; set; }

        //Nibit
        public DbSet<Nibit.Activity> Activities { get; set; }
        public DbSet<Nibit.NibitCategory> NibitCategories { get; set; }
        public DbSet<Nibit.Client> Clients { get; set; }
        public DbSet<Nibit.Notification> Notifications { get; set; }
        public DbSet<Nibit.NibitProduct> NibitProducts { get; set; }
        public DbSet<Nibit.NibitTask> NibitTasks { get; set; }
        public DbSet<Nibit.Worker> Worker { get; set; }

        //WhereHouse
        public DbSet<WhereHouse.WhereHouseCategory> WhereHouseCategories { get; set; }
        public DbSet<WhereHouse.Item> Items { get; set; }
        public DbSet<WhereHouse.Location> Locations { get; set; }
        public DbSet<WhereHouse.WhereHouseUser> WhereHouseUsers { get; set; }
        public DbSet<WhereHouse.ItemCategoryRelation> ItemCategoryRelations { get; set; }


        public UserEntitiesContext()
        {
            Database.SetInitializer<UserEntitiesContext>(new MigrateDatabaseToLatestVersion<UserEntitiesContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Message>().ToTable("Messages", typeof(Message).Namespace.Split('.').Last());

            //MusicSchool
            modelBuilder.Entity<Music.MusicSchoolUser>().ToTable("Users", typeof(Music.MusicSchoolUser).Namespace.Split('.').Last());
            modelBuilder.Entity<Music.Song>().ToTable("Songs", typeof(Music.Song).Namespace.Split('.').Last());
            modelBuilder.Entity<Music.SongRow>().ToTable("SongRows", typeof(Music.SongRow).Namespace.Split('.').Last());

            
            
            //ProjectManagement
            modelBuilder.Entity<ProjectManagementUser>().ToTable("Users", typeof(ProjectManagementUser).Namespace.Split('.').Last());
            modelBuilder.Entity<Category>().ToTable("Categories", typeof(Category).Namespace.Split('.').Last());
            modelBuilder.Entity<Design>().ToTable("Designs", typeof(Design).Namespace.Split('.').Last());
            modelBuilder.Entity<ProjectManagementTask>().ToTable("Tasks", typeof(ProjectManagementTask).Namespace.Split('.').Last());
            modelBuilder.Entity<Bug>().ToTable("Bugs", typeof(Bug).Namespace.Split('.').Last());
            modelBuilder.Entity<File>().ToTable("Files", typeof(File).Namespace.Split('.').Last());

            modelBuilder.Entity<ProjectManagementUser>().HasMany(u => u.designs).WithOptional().HasForeignKey(d => d.owner);
            modelBuilder.Entity<ProjectManagementUser>().HasMany(u => u.ownedTasks).WithOptional().HasForeignKey(t => t.owner);
            modelBuilder.Entity<ProjectManagementUser>().HasMany(u => u.assigedTasks).WithOptional().HasForeignKey(t => t.assignTo);
            modelBuilder.Entity<ProjectManagementUser>().HasMany(u => u.ownedBugs).WithOptional().HasForeignKey(b => b.owner);
            modelBuilder.Entity<ProjectManagementUser>().HasMany(u => u.assignedBugs).WithOptional().HasForeignKey(b => b.assignTo);


            //KidumNoar
            modelBuilder.Entity<Kidum.kidumPerson>().ToTable("persons", typeof(Kidum.kidumPerson).Namespace.Split('.').Last());
            modelBuilder.Entity<Kidum.question>().ToTable("questions", typeof(Kidum.question).Namespace.Split('.').Last());
            modelBuilder.Entity<Kidum.answer>().ToTable("answers", typeof(Kidum.answer).Namespace.Split('.').Last());
            modelBuilder.Entity<Kidum.fillForms>().ToTable("fillForms", typeof(Kidum.fillForms).Namespace.Split('.').Last());

            modelBuilder.Entity<Kidum.kidumPerson>().HasMany(p => p.answers).WithOptional().HasForeignKey(a => a.studentId);
            modelBuilder.Entity<Kidum.kidumPerson>().HasMany(p => p.teacherForms).WithOptional().HasForeignKey(f => f.userId);
            modelBuilder.Entity<Kidum.kidumPerson>().HasMany(p => p.studentForms).WithOptional().HasForeignKey(f => f.studentId);



            //Nibit
            modelBuilder.Entity<Nibit.Activity>().ToTable("Activities", typeof(Nibit.Activity).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.NibitCategory>().ToTable("Categories", typeof(Nibit.NibitCategory).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Client>().ToTable("Clients", typeof(Nibit.Client).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Notification>().ToTable("Notifications", typeof(Nibit.Notification).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.NibitProduct>().ToTable("Products", typeof(Nibit.NibitProduct).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.NibitTask>().ToTable("Tasks", typeof(Nibit.NibitTask).Namespace.Split('.').Last());
            modelBuilder.Entity<Nibit.Worker>().ToTable("Workers", typeof(Nibit.Worker).Namespace.Split('.').Last());

            modelBuilder.Entity<Nibit.NibitTask>().HasMany(t => t.Activities).WithOptional().HasForeignKey(a => a.ParentTaskId);
            modelBuilder.Entity<Nibit.Worker>().HasMany(w => w.Activities).WithOptional().HasForeignKey(a => a.ActualWorker);

            


            //WhereHouse
            modelBuilder.Entity<WhereHouse.WhereHouseCategory>().ToTable("Categories", typeof(WhereHouse.WhereHouseCategory).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.Item>().ToTable("Items", typeof(WhereHouse.Item).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.Location>().ToTable("Locations", typeof(WhereHouse.Location).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.WhereHouseUser>().ToTable("Users", typeof(WhereHouse.WhereHouseUser).Namespace.Split('.').Last());
            modelBuilder.Entity<WhereHouse.ItemCategoryRelation>().ToTable("ItemCategoryRelations", typeof(WhereHouse.ItemCategoryRelation).Namespace.Split('.').Last());

        }
    }
}
