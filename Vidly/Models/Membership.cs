using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Display(Name = "Membership Type")]
        public string  MembershipType { get; set; }

        public int Cost { get; set; }

        [Display(Name = "Validity")]
        public int ValidityInDays { get; set; }

        public int Discount { get; set; }   
    }
}