using System;
using System.Collections.Generic;
using System.Linq;
using Paylocity.DAL;

namespace Paylocity.Models
{
    public class Employee
    {
        public Employee()
        {
            AddDependents();
            CalculateBenefitCost();
        }

        public Dictionary<string, double> CalculateBenefitCost()
        {
           
            Dependents?.ForEach(dependent =>
            {
                BenefitCost += 500;
                if (dependent.FirstName.StartsWith("A") || dependent.LastName.StartsWith("A"))
                {
                    Discount = .10 * BenefitCost;
                    BenefitCost = BenefitCost - Discount;
                }
            });

            if (this.FirstName.StartsWith("A") || this.LastName.StartsWith("A"))
            {
                Discount = .10 * BenefitCost;
                BenefitCost = BenefitCost - Discount;
            }
            Dictionary<string, double> CostBook = new Dictionary<string, double>();
            CostBook.Add("BenefitCost", BenefitCost);
            CostBook.Add("Discount", Discount);

            return CostBook;

        }

        private void AddDependents()
        {
            using (var context = new CostOfBenefitsContext())
            {
                Dependents = context.Dependents.Where(x => x.EmployeeID == this.ID).ToList();
                Console.WriteLine(this.Dependents);
            }
        }

        public Guid ID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public double Discount { get; set; } = 0;
        public double BenefitCost { get; set; } = 1000;
        public List<Dependent> Dependents { get; set; }
    }
}
