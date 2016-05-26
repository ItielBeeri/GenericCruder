using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;

namespace ETL.GenericCruder.UserEntities.GmachHon
{
    public class contact : IHasId//המחלקה מייצגת פרטים של איש קשר שמבצע פעולות בגמ"ח - לווה, מפקיד, תורם ועוד
    {
        public int contactId { get; set; } //מזהה
        public string firstName { get; set; } //שם פרטי
        public string lastName { get; set; } //שם משפחה
        public string idNumber { get; set; } //תעודת זהות
        public string phoneNumber { get; set; } //טלפון
        public string mobileNumber { get; set; } //נייד
        public string address { get; set; } //כתובת
        public string remarks { get; set; } //הערות
        public virtual ICollection<transaction> transactions { get; set; }
        int IHasId.Id
        {
            get
            {
                return contactId;
            }
            set
            {
                contactId = value;
            }
        }
    }
    public class transaction : IHasId //מחלקה זו מייצגת תנועה בגמ"ח: הלוואה\החזרת הלוואה\הפקדה\משיכת הפקדה\תרומה
    {
        public int transactionId { get; set; } //מזהה
        public string transactionType { get; set; }//סוג התנועה: Loan\ReturnLoan\Deposit\ReturnDeposit\Donation
        public virtual contact contact { get; set; }// איש קשר מבצע הפעולה
        public double amount { get; set; }//סכום
        public DateTime transactionDate { get; set; } //תאריך התנועה

        public DateTime? returnDate { get; set; }//תאריך החזרה מתוכנן
        public bool returned { get; set; } //הוחזר - כן\לא
        public double returnAmount { get; set; } //סכום שהוחזר

        //פרטי ערבים עבור הלוואה
        //ערב 1
        public string freind1FirstName { get; set; } //שם פרטי
        public string freind1LastName { get; set; } //שם משפחה
        public string freind1PhoneNumber { get; set; } //טלפון
        public string freind1Remark { get; set; } //הערה
                                                  //ערב 2
        public string freind2FirstName { get; set; } //שם פרטי
        public string freind2LastName { get; set; } //שם משפחה
        public string freind2PhoneNumber { get; set; } //טלפון
        public string freind2Remark { get; set; } //הערה

        int IHasId.Id
        {
            get
            {
                return transactionId;
            }
            set
            {
                transactionId = value;
            }
        }
    }
}
