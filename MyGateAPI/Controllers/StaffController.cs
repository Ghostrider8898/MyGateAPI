using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGateAPI.DAL;
using MyGateAPI.ViewModels;

namespace MyGateAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpGet("GetStaffList")]
        public async Task<IActionResult> GetStaffList()
        {
            List<StaffViewModel> staffList = StaffDataAccess.GetStaffList();
            return Ok(new
            {
                Response = staffList
            });
        }
        [HttpPost("EditStaff")]
        public async Task<IActionResult> EditStaff([FromBody] StaffViewModel staff)
        {
            bool isUpdated = StaffDataAccess.EditStaff(staff.ToStaff());
            return Ok(new
            {
                Response = isUpdated
            });
        }
    }
}
