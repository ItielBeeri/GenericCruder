using ETL.GenericCruder.Core;
using System;


namespace ETL.GenericCruder.UserEntities.Apartment
{
    public class Advertisement : IHasId
    {
        public int AdvertisementId { get; set; }//  ����
        public string areaName { get; set; } // �� ����
        public string cityName { get; set; } // �� ���
        public string neighborhood { get; set; } //����� 
        public int numRooms { get; set; } //���� �����
        public int floor { get; set; } // ����
        public int price { get; set; } // ����
        public bool isAirConditioner { get; set; } // ����
        public bool isElevator { get; set; } // �����
        public bool isParking { get; set; }  // ����
        public bool isFurniture{ get; set; } // ������
        public bool isRenovated { get; set; } // ������

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





    public class Advertiser : IHasId // �����
    {
        public int AdvertiserId { get; set; }// \\ ����
        public string firstNAme { get; set; }// �� ����
        public string lastNAme { get; set; }// �� �����
        public string telephone { get; set; }// �����
        public string email { get; set; }// ����� ����� 
        public string password { get; set; }// �����
        public string creditCardNumber { get; set; }// ����� �����

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