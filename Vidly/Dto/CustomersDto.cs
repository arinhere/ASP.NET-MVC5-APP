using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dto
{
    public class CustomersDto
    {
        public int Id { get; set; }
        
        public string CustomerName { get; set; }
       
        public bool IsSubscribedToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }

        public virtual MembershipTypDto Membership { get; set; }

        public DateTime? BirthDate { get; set; }

    }
}