﻿using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETL.GenericCruder.UserEntities.Nibit
{
   //מחלקת פעילויות
   //מחלקה זו מתארת את הפעילויות השונות המתבצעות בתוך כל משימה
   public class Activity : IHasId
   {
       public int ActivityId { get; set; }//מספור אוטומטי
       public string Title { get; set; }//תאור הפעילות
       public DateTime? Start { get; set; }//זמן תחילת הפעילות 
       public DateTime? End { get; set; }//זמן סיום הפעילות 
       public DateTime? Duration { get; set; }//משך זמן הפעילות(שדה מחושב
       public float? Priority { get; set; }// עדיפות
       public int? Status { get; set; }//סטטוס פעילות

       public int? TaskId { get; set; }
       public int? ActualWorker { get; set; }//עובד נוכחי לפעילות

       int IHasId.Id
       {
           get
           {
               return ActivityId;
           }
           set
           {
               ActivityId = value;
           }
       }
   }

    //מחלקת משימות
    //מחלקה זו מתארת את המשימות ובקשות הלקוחות מצוות התמיכה מחלקה זו יורשת ממחלקת פעילויות
   public class Task : Activity
    {
       public string NameAsk { get; set;}//שם מבקש המשימה 
       public string Phone { get; set; }//טלפון ליצירת קשר

       public int? WorkerId { get; set; }//קוד עובד
       public int? ClientId { get; set; }//קוד לקוח
       public int? ProductId { get; set; }//קוד מוצר תקול
       
       public ICollection<Activity> Activities { get; set; }//רשימת פעילויות למשימה
    }

    //מחלקת עובדים
    //עובדי החברה המשתמשים באפליקציה
    public class Worker : IHasId
    {
        public int WorkerId { get; set; }//מספור אוטומטי קוד עובד
        
        public int? Password { get; set; }//ססמא
        public string Name { get; set; }//שם עובד
        public string Email { get; set; }//מייל עובד

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        int IHasId.Id
        {
            get
            {
                return WorkerId;
            }
            set
            {
                WorkerId = value;
            }
        }
    }
    //מחלקת לקוחות
    //לקוחות החברה 
    public class Client : IHasId
    {
        public int ClientId { get; set; }//מספור אוטומטי קוד לקוח
        public string Name { get; set; }//שם לקוח
        public string Osek_m { get; set; }//עוסק מורשה

        public virtual ICollection<Task> Tasks { get; set; }

        int IHasId.Id
        {
            get
            {
                return ClientId;
            }
            set
            {
                ClientId = value;
            }
        }
    }
    //מחלקת קטגוריות
    //קטגוריות המוצרים המוצעים בחברה
    public class Category : IHasId
    {
        public int CategoryId { get; set; }//מספור אוטומטי
        public string Name { get; set; }//שם קטגוריות

        public virtual ICollection<Product> Products { get; set; }

        int IHasId.Id
        {
            get
            {
                return CategoryId;
            }
            set
            {
                CategoryId = value;
            }
        }
    }

    //מחלקת מוצרים
    //מגון מוצרי החברה עליהם ניתן השירות
    public class Product : IHasId
    {
        public int ProductId { get; set; }//מספור אוטומטי
        public string Name { get; set; }//שם מוצר
        
        public int? category { get; set; }//קטגורית מוצר

        public virtual ICollection<Task> Tasks { get; set; }

        int IHasId.Id
        {
            get
            {
                return ProductId;
            }
            set
            {
                ProductId = value;
            }
        }
    }
    //מחלקת הודעות 
    //הודעות ומסרים במערכת
    public class Notification : IHasId
    {
        public int NotificationId { get; set; }//מספור אוטומטי
        public string Note { get; set; }//תוכן הודעה

        int IHasId.Id
        {
            get
            {
                return NotificationId;
            }
            set
            {
                NotificationId = value;
            }
        }
    }
 


}