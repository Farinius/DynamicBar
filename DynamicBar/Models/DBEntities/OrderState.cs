using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DynamicBar.Models.DBEntities
{
    public class OrderState
    {
        [Display(Name = "Bestellstatusnummer")]
        public int OrderStateId { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 1)]
        [Display(Name = "Bestellstatus")]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        [Display(Name = "Beschreibung")]
        public string Description { get; set; }

        [Display(Name = "Erstellt um")]
        public DateTime DateCreated { get; set; }

        //foreign keys
        public string CreatedById { get; set; }

        //navigation properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        
    }
}