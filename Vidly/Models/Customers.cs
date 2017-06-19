using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Newsletter Subscription")]
        public bool IsSubscribedToNewsletter { get; set; }

        [ForeignKey("Membership")]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public virtual Membership Membership { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime? BirthDate { get; set; }
    }
}