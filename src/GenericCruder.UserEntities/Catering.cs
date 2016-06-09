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
        public DateTime? dateAndTime { get; set; } //תאריך ושעת הארוע
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
        public virtual order order { get; set; }

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
