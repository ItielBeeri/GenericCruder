using ETL.GenericCruder.Core;
using System;


namespace ETL.GenericCruder.UserEntities.Apartment
{
    public class Advertisement : IHasId
    {
        public int AdvertisementId { get; set; }//  מזהה
        public string areaName { get; set; } // שם אזור
        public string cityName { get; set; } // שם עיר
        public string neighborhood { get; set; } //שכונה 
        public int numRooms { get; set; } //מספר חדרים
        public int floor { get; set; } // קומה
        public int price { get; set; } // מחיר
        public bool isAirConditioner { get; set; } // מזגן
        public bool isElevator { get; set; } // מעלית
        public bool isParking { get; set; }  // חניה
        public bool isFurniture{ get; set; } // מרוהטת
        public bool isRenovated { get; set; } // משופצת

        int IHasId.Id
        {
            get
            {
                return AdvertisementId;
            }

            set
            {
                AdvertisementId = value;
            }
        }
    }





    public class Advertiser : IHasId // מפרסם
    {
        public int AdvertiserId { get; set; }// \\ מזהה
        public string firstNAme { get; set; }// שם פרטי
        public string lastNAme { get; set; }// שם משפחה
        public string telephone { get; set; }// טלפון
        public string email { get; set; }// כתובת אמייל 
        public string password { get; set; }// סיסמא
        public string creditCardNumber { get; set; }// כרטיס אשראי

        int IHasId.Id
        {
            get
            {
                return AdvertiserId;
            }

            set
            {
                AdvertiserId = value;
            }
        }
    }

}