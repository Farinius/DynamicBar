using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DynamicBar.Models.DBEntities
{
    public class ProductState
    {
        [Display(Name = "Produktstatusnummer")]
        public int ProductStateId { get; set; }

        [Required]
        [StringLength(128, MinimumLength =1)]
        [Display(Name = "Produktstatus")]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        [Display(Name = "Statusbeschreibung")]
        public string Description { get; set; }

        [Display(Name = "Erstellt am")]
        public DateTime DateCreated { get; set; }

        //foreign keys
        public string CreatedById { get; set; }

        //navigation properties
        public virtual ICollection<Product> Products { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
    }
}