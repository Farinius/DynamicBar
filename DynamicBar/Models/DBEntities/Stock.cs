using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DynamicBar.Models.DBEntities
{
    public class Stock
    {
        [Display(Name = "Lagernummer")]
        public int StockId { get; set; }
        [Display(Name = "Menge")]
        public float Amount { get; set; }
        [Display(Name = "Ablaufdatum")]
        public DateTime Expires { get; set; }
        [Display(Name = "Geliefert am")]
        public DateTime Delivered { get; set; }
        [Display(Name = "Preis")]
        public float PPrice { get; set; }

        //foreign keys
        public int ProductId { get; set; }
        public string CreatedById { get; set; }

        //navigation properties
        public virtual Product Product { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}