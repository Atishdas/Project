using RiskAssessmentMicroservice.DBHandler;
using RiskAssessmentMicroservice.Models;
using RiskAssessmentMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Business_Logic
{
    public class RiskAssessmentServices : IRiskAssessmentServices
    {
        private readonly IRiskAssessmentRepository _repository;
        private readonly log4net.ILog _log4net=log4net.LogManager.GetLogger(typeof(RiskAssessmentServices));
        public RiskAssessmentServices(IRiskAssessmentRepository repository)
        {
            _repository = repository;
        }

        public CollateralRisk GetCollateralRisk(int loanId)
        {
            _log4net.Info("GetCollateralRisk under RiskAssessmentServices called for loanId=" + loanId);
            if (_repository.GetCollateralCashDeposit(loanId) != null)
            {
                return GetCollateralRiskCashDeposit(_repository.GetCollateralCashDeposit(loanId));
            }
            else if (_repository.GetCollateralRealEstate(loanId) != null)
            {
                return GetCollateralRiskRealEstate(_repository.GetCollateralRealEstate(loanId));
            }
            throw new Exception(message: "Object Not Found");
        }
        private CollateralRisk GetCollateralRiskCashDeposit(DetailCashDeposit collateralLoanCashDeposit)
        {
            CollateralRisk collateralRisk = new CollateralRisk();
            collateralRisk.CollateralId = collateralLoanCashDeposit.CollateralId;
            collateralRisk.SanctionedLoan = collateralLoanCashDeposit.SanctionedLoan;
            //collateralRisk.DateAssessed = new DateTime(DateTime.Today);
            double years = DateTime.Today.Subtract(collateralLoanCashDeposit.DateOfDeposit).TotalDays/365;
            collateralRisk.MarketValue = Math.Round(collateralLoanCashDeposit.DepositAmount * (1 + (years * (double)collateralLoanCashDeposit.InterestRate/100)),2);
            collateralRisk.PercentageRisk = Math.Round(100 * collateralRisk.SanctionedLoan / collateralRisk.MarketValue, 2);
            return collateralRisk;
        }

        private CollateralRisk GetCollateralRiskRealEstate(DetailRealEstate collateralLoanRealEstate)
        {
            CollateralRisk collateralRisk = new CollateralRisk();
            collateralRisk.CollateralId = collateralLoanRealEstate.CollateralId;
            double years = DateTime.Today.Subtract(collateralLoanRealEstate.DateOfPurchase).TotalDays/365;
            var marketPricePerSqFt = MarketValue.RealEstateMarketValues.FirstOrDefault(x => x.AddressOfProperty == collateralLoanRealEstate.AddressOfProperty).RatePerSqFt;
            var marketValueOfProperty = marketPricePerSqFt *collateralLoanRealEstate.AreaInSqFt * (double)collateralLoanRealEstate.DepreciationRate * years / 100;
            collateralRisk.MarketValue = (double)Math.Round(marketValueOfProperty,2);
            collateralRisk.SanctionedLoan = (double)collateralLoanRealEstate.SanctionedLoan;
            collateralRisk.PercentageRisk = Math.Round(100 * collateralRisk.SanctionedLoan / collateralRisk.MarketValue,2);
            
            return collateralRisk;
        }
    }
}
