using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Models
{
    public class RealEstateMarketValue
    {
        public int Id { get; set; }
        public string AddressOfProperty { get; set; }
        public double RatePerSqFt { get; set; }
    }
}
