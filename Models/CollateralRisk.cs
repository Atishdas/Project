using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Models
{
    public class CollateralRisk
    {
        public int CollateralId { get; set; }
        public double PercentageRisk { get; set; }
        public DateTime DateAssessed
        {
            get { return DateTime.Now; }
        }
        public double MarketValue { get; set; }
        public double SanctionedLoan { get; set; }
    }
}
