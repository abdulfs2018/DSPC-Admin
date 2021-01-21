using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarController : Controller
    {

        public RegistrarController(IDSPC_Repository repository)
        {
            this._repository = repository;
        }


        [HttpGet("getallregistrar")]
        public async Task<IActionResult> GetRegistrars()
        {
            try
            {
                var data = await _repository.GetListRegistrar();

                if (data != null) return Ok(data);
                return Ok(false);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getregistrardetailsbyId")]
        public async Task<IActionResult> GetRegistrarDetailsById(int Id)
        {
            try
            {
                var data = await _repository.GetRegistrarById(Id);

                if (data != null) return Ok(data);
                return Ok(false);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getregistrarbyname")]
        public async Task<IActionResult> GetRegistrarByName(string firstName)
        {
            try
            {
                var data = await _repository.GetRegistrarByName(firstName);

                if (data != null) return Ok(data);
                return Ok(false);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("getregistrarbyreferencecode")]
        public async Task<IActionResult> GetRegistrarByReferenceCode(string code)
        {
            try
            {
                var registrar = await _repository.GetRegistrarByReferenceCode(code);

                if (registrar != null) return Ok(registrar);
                return Ok(false);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } 

        [HttpPost("addnewregistrar")]
        public async Task<IActionResult> AddNewRegistrar([FromBody] Registrar registrar)
        {
            try
            {
                var inserted = await _repository.AddNewRegistrar(registrar);
                return Ok(inserted); 
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
