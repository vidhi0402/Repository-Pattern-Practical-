using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ServiceStack.FluentValidation.Attributes;
using Domain.ValidateEntity;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    public class State
    {
        [Key]
        public int StateId { get; set; }
     
        public string StateName { get; set; }

        // Foreign key
        [Display(Name = "Country")]
        public virtual int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
