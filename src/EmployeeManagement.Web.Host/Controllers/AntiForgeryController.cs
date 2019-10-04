using Microsoft.AspNetCore.Antiforgery;
using EmployeeManagement.Controllers;

namespace EmployeeManagement.Web.Host.Controllers
{
    public class AntiForgeryController : EmployeeManagementControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
