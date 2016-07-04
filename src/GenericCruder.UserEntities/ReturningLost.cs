using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.ReturningLost
{
    //מטרת המחלקה לאפיין את משתמש האתר - מוצא או מאבד
    public class person : IHasId
    {
        public int personId { get; set; }//מזהה לקוח
        public string name { get; set; }//שם הלקוח
        public string phone { get; set; }//טלפון הלקוח
        public string email { get; set; }//מייל הלקוח (ליצירת קשר
        public string userName { get; set; }//שם המתשתמש האישי של הלקוח (לזיהוי
        public string password { get; set; }//סיסמת הלקוח (לזיהוי

        public virtual ICollection<product> products { get; set; }
        int IHasId.Id
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
            }
        }
    }

    //מטרת המחלקה לאפיין מוצר המתואר באפליקציה - אבידה
    public class product : IHasId
    {
        public int productId { get; set; }//מזהה מוצר
        public int personId { get; set; }//הלקוח המפרסם מוצר זה (המוצא
        public string name { get; set; }//שם המוצר
        public DateTime date { get; set; }//תאריך מציאת המוצר
        public string city { get; set; }//עיר מציאת המוצר *
        public string category { get; set; }//קטגורית המוצר *
        public string status { get; set; }//סטטוס המוצר

        public virtual ICollection<sign> signs { get; set; }
        int IHasId.Id
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        // * העיר והקטגוריה מוצגים למשתמש לבחירה כרשימה של מחרוזות ולכן החיפוש נעשה בהשואה של מחרוזות
    }

    //מטרת המחלקה לאפיין את הסימנים להחזרת המוצר לבעליו ע"י שאלות  שתשובותיהן הן חיוביות או שליליות
    public class sign : IHasId
    {
        public int signId { get; set; }//מזהה לסימן 
        public int productId { get; set; }//קישור הסימן למוצר (למוצר אחד כמה סימנים ולכן מוצר אחד מקושר רבות 
        public string question { get; set; }// השאלה בעצמה (שאלה לתשובה נכון/לא נכון
        public Boolean answer { get; set; }//התשובה לשאלה

        int IHasId.Id
        {
            get
            {
                return signId;
            }
            set
            {
                signId = value;
            }
        }
    }
}
