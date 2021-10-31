using RiskAssessmentMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.DBHandler
{
    public class MarketValue
    {
        public static List<RealEstateMarketValue> RealEstateMarketValues = new List<RealEstateMarketValue>()
        {
            new RealEstateMarketValue{Id=1,AddressOfProperty="Delhi",RatePerSqFt=15000},
            new RealEstateMarketValue{Id=2,AddressOfProperty="Mumbai",RatePerSqFt=14500},
            new RealEstateMarketValue{Id=3,AddressOfProperty="Chennai",RatePerSqFt=14000},
            new RealEstateMarketValue{Id=4,AddressOfProperty="Hyderabad",RatePerSqFt=14000},
            new RealEstateMarketValue{Id=5,AddressOfProperty="Kolkata",RatePerSqFt=13500}
        };
    }
}
