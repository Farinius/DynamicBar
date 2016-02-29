using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DynamicBar.Models.DBEntities
{
    public class Unit
    {
        [Display(Name = "Einheitennummer")]
        public int UnitId { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Required]
        [Display(Name = "Einheit")]
        public string Title { get; set; }

        [StringLength(128, MinimumLength = 1)]
        [Display(Name = "Einheit abgekürzt")]
        public string ShortName { get; set; }
        [Display(Name = "Beschreibung")]
        public string Description { get; set; }
        [Display(Name = "Faktor")]
        public double BasisFactor { get; set; }
        [Display(Name = "Erstellt am")]
        public DateTime DateCreated { get; set; }

        //foreign keys
        public string CreatedById { get; set; }

        //navigation properties        
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}