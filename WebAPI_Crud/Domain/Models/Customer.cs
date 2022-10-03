using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
       
        public string CustomerName { get; set; }       
        public string Mobile { get; set; }      
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Pincode { get; set; }

        // City Foreign key
        [Display(Name = "City")]
        public virtual int? CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        // State Foreign key
        [Display(Name = "State")]
        public virtual int? StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        // Country Foreign key
        [Display(Name = "Country")]
        public virtual int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

    }
}
