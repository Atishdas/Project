using RiskAssessmentMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Business_Logic
{
    public interface IRiskAssessmentServices
    {
        public CollateralRisk GetCollateralRisk(int loanId);
    }
}
