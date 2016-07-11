using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.Catering
{
    public class order : IHasId //הזמנה לארוע בקייטרינג
    {
        public int orderId { get; set; }
        public string firstName { get; set; } //שם פרטי ומשפחה של המזמין
        public string lastName { get; set; }
        public string email { get; set; } //כתובת מייל
        public string address { get; set; } //מקום הארוע
        public string phoneNumber { get; set; } //טלפון
        public int? orderType { get; set; } //סוג הזמנה
        public string details { get; set; } //הערות
        public DateTime? dateAndTime { get; set; } //תאריך ושעת הארוע
        public double? orginalPrice { get; set; } //מחיר מקורי
        public double? finalPrice { get; set; } //מחיר סופי
        public virtual ICollection<meal> meals { get; set; } //המנות אותן המזמין בחר

        int IHasId.Id
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
            }
        }
    }

    public class meal : IHasId //מנה מהתפריט
    {
        public int mealId { get; set; }
        public string mealName { get; set; } //שם המנה
        public int? price { get; set; } //מחיר
        public int? quantity { get; set; } //כמות שהוזמנה
        public int? orderId { get; set; }

        int IHasId.Id
        {
            get
            {
                return mealId;
            }
            set
            {
                mealId = value;
            }
        }
    }
}
