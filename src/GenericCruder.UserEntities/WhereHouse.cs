using ETL.GenericCruder.Core;
using System.Collections.Generic;
using System;

namespace ETL.GenericCruder.UserEntities.WhereHouse
{
    // item's location
    public class Location :IHasId
    {
        public int LocationId { get; set; }

        public int? WhereHouseUserId { get; set; } // the user who added 

        public string Name { get; set; } // The item name

        public string Description { get; set; } // The item description

        public virtual ICollection<Item> Items { get; set; }

        int IHasId.Id
        {
            get
            {
                return LocationId;
            }
            set
            {
                LocationId = value;
            }
        }
    }

    // item's category
    public class WhereHouseCategory : IHasId
    {
        public int WhereHouseCategoryId { get; set; }

        public int? WhereHouseUserId { get; set; } // the user who added 

        public string Name { get; set; } // The item name

        public string Description { get; set; } // The item description

        public virtual ICollection<ItemCategoryRelation> Items { get; set; }

        int IHasId.Id
        {
            get
            {
                return WhereHouseCategoryId;
            }
            set
            {
                WhereHouseCategoryId = value;
            }
        }
    }

    // item in stock
    public class Item : IHasId
    {
        public int ItemId { get; set; }

        public int? WhereHouseUserId { get; set; } // the user who inserted the item

        public string Name { get; set; } // item's name

        public virtual ICollection<ItemCategoryRelation> Categories { get; set; } // item's categories

        public int? LocationId { get; set; } // item's location

        int IHasId.Id
        {
            get
            {
                return ItemId;
            }
            set
            {
                ItemId = value;
            }
        }
    }

    public class ItemCategoryRelation : IHasId
    {
        public int ItemCategoryRelationId { get; set; }

        public int ItemId { get; set; }

        public int WhereHouseCategoryId { get; set; }

        int IHasId.Id
        {
            get
            {
                return ItemCategoryRelationId;
            }

            set
            {
                ItemCategoryRelationId = value;
            }
        }
    }

    // user details
    public class WhereHouseUser :IHasId
    {
        public int WhereHouseUserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<WhereHouseCategory> Categories { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        int IHasId.Id
        {
            get
            {
                return WhereHouseUserId;
            }
            set
            {
                WhereHouseUserId = value;
            }
        }
    }
}