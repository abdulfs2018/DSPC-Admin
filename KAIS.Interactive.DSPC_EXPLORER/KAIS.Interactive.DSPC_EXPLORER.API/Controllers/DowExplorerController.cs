using KAIS.Interactive.DSPC_EXPLORER.Infrastructure;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowExplorerController : Controller
    {

        public DowExplorerController(IDSPC_Repository repository)
        {
            this._repository = repository;
        }


        [HttpGet("kais/api/dspc_explorer/getallregistrar")]
        public async Task<IActionResult> GetRegistrars()
        {
            try
            {
                var data = await _repository.GetListRegistrar();

                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("kais/api/dspc_explorer/getregistrarbyname")]
        public async Task<IActionResult> GetRegistrarByName(string firstName)
        {
            try
            {
                var data = await _repository.GetRegistrarByName(firstName);

                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #region repository
        private readonly IDSPC_Repository _repository;
        #endregion

    }
}
