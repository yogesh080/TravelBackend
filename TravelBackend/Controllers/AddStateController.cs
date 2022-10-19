using BusinessLayer.Interfaces;
using CommonLayer.AddStateModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TravelBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStateController : ControllerBase
    {
        private readonly IAddStateBL stateBL;
        public AddStateController(IAddStateBL stateBL)
        {
            this.stateBL = stateBL;
        }

        [HttpPost("Register")]
        public ActionResult AddState(AddStateModel addstatemodel)
        {
            try
            {
                var state = this.stateBL.AddState(addstatemodel);
                if (state != null)
                {
                    return this.Ok(new { success = true, message = "state added Successfully", data = state });
                }
                return this.BadRequest(new { success = false, message = "state Already Exits", data = state });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
