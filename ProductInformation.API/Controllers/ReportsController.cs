using Microsoft.AspNetCore.Cors;

namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Net.Mail;
    using Telerik.Reporting.Services;
    using Telerik.Reporting.Services.AspNetCore;


    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/reports")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ReportsController : ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration reportServiceConfiguration)
            : base(reportServiceConfiguration)
        {
        }
    }
}