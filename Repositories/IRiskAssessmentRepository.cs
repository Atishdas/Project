using RiskAssessmentMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Repositories
{
    public interface IRiskAssessmentRepository
    {
        public DetailCashDeposit GetCollateralCashDeposit(int loanId);
        public DetailRealEstate GetCollateralRealEstate(int loanId);
    }
}
