using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DynamicBar.Models.DBEntities
{
    public class ProductType
    {
        [Display(Name = "Produkttypnummer")]
        public int ProductTypeId { get; set; }
        [Display(Name = "Produkttyp")]
        public string Title { get; set; }
        [Display(Name = "Typbeschreibung")]
        public string Description { get; set; }
        [Display(Name = "Erstellt am")]
        public DateTime DateCreated { get; set; }

        //foregin keys
        public string CreatedById { get; set; }

        //navigation properties
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}