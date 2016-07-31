using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;

namespace ETL.GenericCruder.UserEntities.KidumNoar
{
    public class kidumPerson : IHasId  //מחלקה המייצגת אנשים
    {
        public int kidumPersonId { get; set; } //מזהה אדם
        public string idNumber { get; set; } //מספר תעודת זהות
        public string name { get; set; } // שם

        public string role { get; set; } //תפקיד
        public string password { get; set; } //סיסמה

        public int? teacherId { get; set; } //מזהה של מורה (או אדם) מטפל, עבור תלמיד צריך לדעת מי המורה שלו , אם לא תלמיד יהיה 0 
        public string ageGroup { get; set; } //שכבת גיל של התלמיד
        public int? classNumber { get; set; } //מספר כיתה בשכבה

        public virtual ICollection<answer> answers { get; set; }
        public virtual ICollection<fillForms> teacherForms { get; set; }
        public virtual ICollection<fillForms> studentForms { get; set; }

        int IHasId.Id
        {
            get
            {
                return kidumPersonId;
            }
            set
            {
                kidumPersonId = value;
            }
        }
    }

    /********************************************************/

    public class question : IHasId //מחלקה המייצגת שאלה
    {
        public int questionId { get; set; } //מזהה שאלה
        public string formType { get; set; } //סוג הטופס אליו משתייכת השאלה
        public int? order { get; set; } //מספר השאלה בטופס
        public string subject { get; set; } //נושא השאלה
        public string title { get; set; } //כותרת השאלה
        public string description { get; set; } //תאור השאלה

        public string lebel1 { get; set; } //תאור רמה 1
        public string lebel2 { get; set; } //תאור רמה 2
        public string lebel3 { get; set; } //תאור רמה 3
        public string lebel4 { get; set; } //תאור רמה 4

        public string values { get; set; } //רשימת ערכים מופרדת ב ;
        public string type { get; set; } //שאלה מסוג drop down list(ddl) / check list(cl)

        public virtual ICollection<answer> answers { get; set; }

        int IHasId.Id
        {
            get
            {
                return questionId;
            }
            set
            {
                questionId = value;
            }
        }
    }

    /*******************************************************/

    public class answer  :IHasId //מחלקה המייצגת תשובה
    {
        public int answerId { get; set; } //מזהה תשובה
        public string typeForm { get; set; } //סוג טופס
        public string answerContent { get; set; } //תוכן התשובה
        public int? lebel { get; set; }

        public int? questionId { get; set; } //מזהה שאלה
        public int? studentId { get; set; } //מזהה תלמיד
        
        int IHasId.Id
        {
            get
            {
                return answerId;
            }
            set
            {
                answerId = value;
            }
        }
    }


    /*************************************************/

    public class fillForms:IHasId // מחלקה המתארת את מילוי הטפסים
    {
        public int fillFormsId { get; set; } // מזהה
        public DateTime date { get; set; } //תאריך מילוי טופס
        public string typeForm { get; set; } //סוג טופס
        public int? riskLevel { get; set; } //סיכום רמת סיכון

        public int? userId { get; set; } //מזהה מורה
        public int? studentId { get; set; } // מזהה תלמיד
        
        int IHasId.Id
        {
            get
            {
                return fillFormsId;
            }
            set
            {
                fillFormsId = value;
            }
        }
    }
}

