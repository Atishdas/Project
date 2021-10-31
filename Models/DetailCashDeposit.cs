using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Models
{
    public class DetailCashDeposit
    {
        public int CollateralId { get; set; }
        public int LoanId { get; set; }
        public double SanctionedLoan { get; set; }
        public DateTime PledgedDate { get; set; } 
        public string Collateraltype
        {
            get { return "Cash Deposit"; }
        }
        public string BankName { get; set; }
        public double DepositAmount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime DateOfDeposit { get; set; }
        public int LockPeriod { get; set; }
        public double CurrentValue { get; set; }
    }
}
