
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.FluentValidation.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValidateEntity;
using ServiceStack.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Models
{
   
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        
        public string CountryName { get; set; }

       
    }
}
