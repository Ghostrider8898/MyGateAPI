using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGateAPI.DAL;
using MyGateAPI.ViewModels;

namespace MyGateAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet("GetVisitorList")]
        public async Task<IActionResult> GetVisitorList()
        {
            List<VisitorViewModel> visitors = VisitorDataAccess.GetVisitorsList();
            return Ok(new
            {
                Response = visitors
            });
        }
        [HttpPost("EditVisitor")]
        public async Task<IActionResult> EditVisitor([FromBody] VisitorViewModel visitor)
        {
            bool isUpdated = VisitorDataAccess.EditVisitor(visitor.ToVisitor());
            return Ok(new
            {
                Response = isUpdated
            });
        }
        [HttpPost("DeleteVisitor")]
        public async Task<IActionResult> DeleteVisitor(int UserID)
        {
            bool isDeleted=VisitorDataAccess.DeleteVisitor(UserID);
            return Ok(new
            {
                Response = isDeleted
            });
        }
    }
}
