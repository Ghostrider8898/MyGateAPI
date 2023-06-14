using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGateAPI.DAL;
using MyGateAPI.ViewModels;

namespace MyGateAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlatOwnerController : ControllerBase
    {
        [HttpGet("GetFlatOwnerList")]
        public async Task<IActionResult> GetFlatOwnerList()
        {
            List<FlatOwnerViewModel> flatOwners = FlatOwnerDataAccess.GetFlatOwnersList();
            return Ok(new
            {
                Response = flatOwners
            });
        }
        [HttpPost("EditFlatOwner")]
        public async Task<IActionResult> EditFlatOwner([FromBody] FlatOwnerViewModel owner)
        {
            bool isUpdated = FlatOwnerDataAccess.EditFlatOwner(owner.ToFlatOwner());
            return Ok(new
            {
                Response = isUpdated
            });
        }
    }
}
