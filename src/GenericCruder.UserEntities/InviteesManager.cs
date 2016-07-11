using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.InviteesManager
{
    //זהות משתמש
    public class user :IHasId
    {
        public int userId { get; set; }//מספור אוטומטי
        public string userName { get; set; }//שם משתמש
        public string password { get; set; }//סיסמא
        public virtual ICollection<@event> events { get; set; }//רשימת ארועים של המשתמש 

        int IHasId.Id
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }
    }

    //פרטי אירוע
    public class @event :IHasId
    {
        public int eventId { get; set; }//מספור אוטומטי
        public string eventName { get; set; }//שם משתמש
        public string eventType { get; set; }//סוג אירוע
        public string place { get; set; }//מקום
        public string address { get; set; }//כתובת
        public string date { get; set; }//תאריך
        public int userId { get; set; }
        public virtual ICollection<invitee> invitees { get; set; }// רשימת המוזמנים לאירוע

        int IHasId.Id
        {
            get
            {
                return eventId;
            }
            set
            {
                eventId = value;
            }
        }
    }

    //מוזמנים
    public class invitee : IHasId
    {
        public int inviteeId { get; set; }//מספור אוטומטי
        public string inviteeName { get; set; }//מוזמן
        public string mail { get; set; }//דואל
        public bool? isComing { get; set; }//האם אישר השתתפותו
        public string randomUrl { get; set; }
        public int eventId { get; set; }

        int IHasId.Id
        {
            get
            {
                return inviteeId;
            }
            set
            {
                inviteeId = value;
            }
        }
    }

   
}
