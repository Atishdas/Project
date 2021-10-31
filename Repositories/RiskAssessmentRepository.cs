using RiskAssessmentMicroservice.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace RiskAssessmentMicroservice.Repositories
{
    public class RiskAssessmentRepository : IRiskAssessmentRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RiskAssessmentRepository));
        private IConfiguration Configuration { get; }
        public RiskAssessmentRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DetailCashDeposit GetCollateralCashDeposit(int loanId)
        {
            _log4net.Info("GetCollateralCashDeposit method under RiskAssessmentRepository accessed for processing loanId=" + loanId);
            HttpClientHandler clientHandler = new HttpClientHandler();
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(Configuration["ApiUrl:CollateralManagement"]);
                HttpResponseMessage response = client.GetAsync("CollateralManagement/getCollateralsCashDeposit?loanId=" + loanId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DetailCashDeposit>(stringData);
                }
                else 
                    return null;
            }
        }

        public DetailRealEstate GetCollateralRealEstate(int loanId)
        {
            _log4net.Info("GetCollateralRealEstate method under RiskAssessmentRepository accessed for processing loanId=" + loanId);
            HttpClientHandler clientHandler = new HttpClientHandler();
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(Configuration["ApiUrl:CollateralManagement"]);
                HttpResponseMessage response = client.GetAsync("CollateralManagement/getCollateralsRealEstate?loanId=" + loanId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DetailRealEstate>(stringData);
                }
                else
                    return null;
            }
        }
    }
}
