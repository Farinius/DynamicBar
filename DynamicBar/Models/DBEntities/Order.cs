using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DynamicBar.Models.DBEntities
{
    public class Order
    {
        [Display(Name = "Bestellnummer")]
        public int OrderId { get; set; }
        [Display(Name = "Menge")]
        public double Amount { get; set; }
        [Display(Name = "Bestellzeitpunkt")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Preis per Einheit")]
        public double UnitPrice { get; set; }


        //navigation properties
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public string OrderedById { get; set; }
        [Required]
        public int PlaceId { get; set; }
        [Required]
        public int OrderStateId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ApplicationUser OrderedBy { get; set; }
        public virtual Place Place { get; set; }
        public virtual OrderState OrderState { get; set; }
    }
}