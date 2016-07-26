using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;

namespace ETL.GenericCruder.UserEntities.ProjectManagement
{
    //משתמשי המערכת, מיועד ללוגין ולצורך הצגה ברשימה המפרטת את משתמשי המערכת אליהם ניתן להפנות משימות או באגים
    public class User : IHasId
    {
        public int ProjectManagementUserId { get; set; }//מזהה
        public string firstName { get; set; } //שם פרטי
        public string lastName { get; set; } // שם משפחה
        public string appName { get; set; } //שם המשתמש להתחברות
        public string password { get; set; } //סיסמא
        public string permission { get; set; } // סוג הרשאה

        public virtual ICollection<Design> designs { get; set; }
        public virtual ICollection<Task> ownedTasks { get; set; }
        public virtual ICollection<Task> assigedTasks { get; set; }
        public virtual ICollection<Bug> ownedBugs { get; set; }
        public virtual ICollection<Bug> assignedBugs { get; set; }

        int IHasId.Id
        {
            get
            {
                return ProjectManagementUserId;
            }
            set
            {
                ProjectManagementUserId = value;
            }
        }
    }

    // כל אפיון / משימה / באג מקושרים לקטגוריה במערכת
    public class Category : IHasId
    {
        public int CategoryId { get; set; }//מזהה
        public string categoryName { get; set; } //שם הקטגוריה   

        public virtual ICollection<Design> designs { get; set; }
        public virtual ICollection<Task> tasks { get; set; }
        public virtual ICollection<Bug> bugs { get; set; }

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

    //מחלקה זו מייצגת אפיון מערכת, ישנם קבצים המועלים
    public class Design :IHasId
    {
        public int DesignId { get; set; } //מזהה
        public string titleName { get; set; } //כותרת ההאיפיון
        public string description { get; set; } // פירוט
        
        public int? CategoryId { get; set; } // קטגוריה
        public int? owner { get; set; } // יוצר האיפיון
        
        public virtual ICollection<File> files { get; set; } // מסמכים הקשורים לאיפיון, כיצד נשמר בסרבר??

        int IHasId.Id
        {
            get
            {
                return DesignId;
            }
            set
            {
                DesignId = value;
            }
        }
    }

    // מחלקה זו מייצגת משימה במערכת
    public class Task :IHasId
    {
        public int TaskId { get; set; } //מזהה
        public string titleName { get; set; } //כותרת המשימה
        public string description { get; set; } // פירוט
        public string status { get; set; } // סטטוס המשימה
        public int? priority { get; set; } // תיעדוף המשימה
        public DateTime? dueDate { get; set; } // תאריך אחרון לביצוע
        
        public int? CategoryId { get; set; } // קטגוריה
        public int? owner { get; set; }// יוצר המשימה
        public int? assignTo { get; set; } // למי מופנה (מתוך רשימת היוזרים)
        
        public virtual ICollection<File> files { get; set; } // מסמכים הקשורים למשימה, שוב- כיצד נשמר בסרבר?

        int IHasId.Id
        {
            get
            {
                return TaskId;
            }
            set
            {
                TaskId = value;
            }
        }
    }

    // מחלקה זו מייצגת באג במערכת
    public class Bug :IHasId
    {
        public int BugId { get; set; } //מזהה
        public string titleName { get; set; } //כותרת הבאג
        public string description { get; set; } // פירוט
        public string status { get; set; } // סטטוס הבאג
        public int? priority { get; set; } // תיעדוף הבאג
        public DateTime? dueDate { get; set; } // תאריך אחרון לביצוע
        
        public int? CategoryId { get; set; } // קטגוריה
        public int? assignTo { get; set; } // למי מופנה (מתוך רשימת היוזרים)
        public int? owner { get; set; }// יוצר המשימה
        
        public virtual ICollection<File> files { get; set; } // מסמכים הקשורים למשימה, שוב- כיצד נשמר בסרבר?

        int IHasId.Id
        {
            get
            {
                return BugId;
            }
            set
            {
                BugId = value;
            }
        }
    }

    public class File :IHasId
    {
        public int FileId { get; set; }
        public string filePath { get; set; }
        public string fileContent { get; set; }
        
        public int? DesignId { get; set; }
        public int? TaskId { get; set; }
        public int? BugId { get; set; }

        int IHasId.Id
        {
            get
            {
                return FileId;
            }
            set
            {
                FileId = value;
            }
        }
    }
}