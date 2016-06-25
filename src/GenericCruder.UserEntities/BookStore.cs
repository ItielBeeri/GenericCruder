using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.BookStore
{
    // המחלקה מייצגת לקוח במערכת, פרטים אישיים, רישום כלקוח במערכת והזדההות חוזרת
    public class Customer : IHasId
    {
        public int customerId { get; set; }// מזהה

        // פרטי הלקוח
        public string firstNAme { get; set; }// שם פרטי
        public string lastNAme { get; set; }// שם משפחה
        public string telephone { get; set; }// טלפון
        public string email { get; set; }// דואר אלקטרוני
        public string password { get; set; }// סיסמת כניסה למערכת

        int IHasId.Id
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
    }


    // מטרת המחלקה היא לאפשר ללקוח להזמין ספר שלא קיים באתר החנות ע"י הכנסת פרטי הספר שייקלטו בבסיס הנתונים ומחזירה למשתמש סטטוס הזמנה 
    // שיאפשר לו לעקוב אחר סטטוס ההזמנה באתר
    public class Book : IHasId
    {
        public int bookId { get; set; }// מזהה

        // פרטי הספר שברצונו להזמין לחנות
        public string bookName { get; set; }// שם הספר
        public string author { get; set; }// מחבר
        public string category { get; set; }// קטגוריה
        public float? price { get; set; }// מחיר

        int IHasId.Id
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
            }
        }
    }


    // מטרת המחלקה היא לאפשר למשתמש בדיקת סטטוס הזמנה
    public class OrderStatus : IHasId
    {
        public int orderStatusId { get; set; }// מזהה
        public string statusOrder { get; set; }// סטטוס ההזמנה

        int IHasId.Id
        {
            get
            {
                return orderStatusId;
            }
            set
            {
                orderStatusId = value;
            }
        }
    }


    // מטרת המחלקה היא לאפשר ללקוח לבצע תשלום עבור הקניה
    public class CashRegister : IHasId
    {
        public int cashRegisterId { get; set; }// מזהה

        // פרטי התשלום של הלקוח
        public string cardNumber { get; set; }// מספר כרטיס אשראי
        public string validity { get; set; }// תוקף הכרטיס
        public int? CVV { get; set; }// ספרות בטיחות בגב הכרטיס
        public int? IDCardholder { get; set; }// תעודת הזהות של בעל הכרטיס
        public string name { get; set; }// שם מלא
        public int? numberPayment { get; set; }// מספר תשלומים לפריסה בכרטיס

        int IHasId.Id
        {
            get
            {
                return cashRegisterId;
            }
            set
            {
                cashRegisterId = value;
            }
        }
    }

}
