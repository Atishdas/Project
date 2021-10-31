using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskAssessmentMicroservice.Business_Logic;
using RiskAssessmentMicroservice.Constants;
using RiskAssessmentMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskAssessmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize]
    public class RiskAssessmentController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RiskAssessmentController));
        public IRiskAssessmentServices _services;
        public RiskAssessmentController(IRiskAssessmentServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route(RiskAssessmentControllerConstants.GetRiskValue)]
        public ActionResult GetRiskValues(int loanId)
        {
            _log4net.Info("HTTPGET Method GetRiskValues Called for loanId="+loanId);
            if (loanId<0)
            {
                _log4net.Info("Invalid LoanId input given");
                return BadRequest("Invalid Loan Id");
            }
            try
            {
                return Ok(_services.GetCollateralRisk(loanId));     
            }
            catch(Exception exception)
            {
                _log4net.Info("Exception Thrown:"+exception.Message);
                return BadRequest("An Error Occured."+exception.Message);
            }
        }
    }
}
