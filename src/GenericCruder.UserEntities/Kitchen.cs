using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.Kitchen
{
    public class price
    {
        public double? Supersal { get; set; }
        public double? Mega { get; set; }
        public double? RamiLevi { get; set; }
    }

    public class product : IHasId
    {
        public int productId { get; set; }
        public string name { get; set; }
        public price price { get; set; }
        public double? amount { get; set; }
        public string selectAmount { get; set; }
        public double? gramsInPackage { get; set; }
        public string degree { get; set; }
        public DateTime? date { get; set; }

        int IHasId.Id
        {
            get { return productId; }
            set { productId = value; }
        }

        public product()
        {
            price = new price();
        }
    }

    public class vegetableAndFruit : product
    {
        public string crop { get; set; }
    }

    public class image : IHasId
    {
        public int imageId { get; set; }
        public string url { get; set; }

        int IHasId.Id
        {
            get { return imageId; }
            set { imageId = value; }
        }
    }

    public class receipe : IHasId
    {
        public int receipeId { get; set; }
        public string name { get; set; }
        public virtual image image { get; set; }
        public string category { get; set; }
        public string timeRating { get; set; }
        public string resultRating { get; set; }
        public virtual HashSet<product> productList { get; set; }

        private List<string> _preparationList;
        [NotMapped]
        public List<string> preparationList
        {
            get { return _preparationList; }
            set { _preparationList = value; }
        }

        public string preparationListForStorage
        {
            get
            {
                return string.Join(";", _preparationList);
            }
            set
            {
                _preparationList = value.Split(';').ToList();
            }
        }

        int IHasId.Id
        {
            get { return receipeId; }
            set { receipeId = value; }
        }
    }

    public class card : IHasId
    {
        public int cardId { get; set; }
        public string title { get; set; }
        public string tasks { get; set; }
        public DateTime? date { get; set; }
        public virtual image image { get; set; }

        int IHasId.Id
        {
            get { return cardId; }
            set { cardId = value; }
        }
    }
}
