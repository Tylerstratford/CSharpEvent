using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEvent.Models
{
    public class Registration
    {
     

        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string CouponCode => $"Voucher: EC-{Id.ToString().Substring(0, 5).ToUpper()}";
    }
}
