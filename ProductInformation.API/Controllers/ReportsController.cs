using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;
namespace WebApplication1.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
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