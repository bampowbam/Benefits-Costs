using System;
namespace Paylocity.Models
{
    public class Dependent
    {
        public Dependent()
        {
        }
        public Guid ID { get; set; } = Guid.NewGuid();
        public Types Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public enum Types
        {
            Spouse=0,
            Child=1,
            Parent=2
        }

    }
}
