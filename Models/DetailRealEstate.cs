using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Models
{
    public class DetailRealEstate
    {
        public int CollateralId { get; set; }
        public int LoanId { get; set; }
        public double SanctionedLoan { get; set; }
        public DateTime PledgedDate { get; set; }
        public string AddressOfProperty { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public double RatePerSqFt { get; set; }
        public int AreaInSqFt { get; set; }
        public decimal DepreciationRate { get; set; }
        public string CollateralType
        {
            get { return "RealEstate"; }
        }
        public double CurrentValue { get; set; }
    }
}
