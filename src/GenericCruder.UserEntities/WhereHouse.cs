using ETL.GenericCruder.Core;
using System.Collections.Generic;

namespace ETL.GenericCruder.UserEntities.WhereHouse
{
    // item's location
    public class Location :IHasId
    {
        public int LocationId { get; set; }

        public int? UserId { get; set; } // the user who added 

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
    public class Category : IHasId
    {
        public int CategoryId { get; set; }

        public int? UserId { get; set; } // the user who added 

        public string Name { get; set; } // The item name

        public string Description { get; set; } // The item description

        public virtual ICollection<Item> Items { get; set; }

        int IHasId.Id
        {
            get
            {
                return CategoryId;
            }
            set
            {
                CategoryId = value;
            }
        }
    }

    // item in stock
    public class Item : IHasId
    {
        public int ItemId { get; set; }

        public int? UserId { get; set; } // the user who inserted the item

        public string Name { get; set; } // item's name

        public virtual ICollection<Category> Category { get; set; } // item's categories

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

    // user details
    public class User :IHasId
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        int IHasId.Id
        {
            get
            {
                return UserId;
            }
            set
            {
                UserId = value;
            }
        }
    }
}