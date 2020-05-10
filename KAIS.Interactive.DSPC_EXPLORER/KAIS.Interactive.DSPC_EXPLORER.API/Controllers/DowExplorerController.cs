using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using KAIS.Interactive.DSPC_EXPLORER.Common.Services.Enums;

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

                if (data != null) return Ok(data);
                return Ok(false);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpGet("kais/api/dspc_explorer/getregistrarbyname")]
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

        [HttpGet("kais/api/dspc_explorer/getsectionbycode")]
        public async Task<IActionResult> GetSectionByCode(string code)
        {
            try
            {

                var section = await _repository.GetSectionByCode(code);

                if (section != null) return Ok(section);
                return Ok(false);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("kais/api/dspc_explorer/getregistrarbyreferencecode")]
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

        [HttpPost("kais/api/dspc_explorer/addnewgraveowner")]
        public async Task<IActionResult> AddNewGraveOwner([FromBody] GraveOwner owner)
        {
            try
            {
                var inserted = await _repository.AddNewGraveOwner(owner);
                return Ok(inserted);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("kais/api/dspc_explorer/addnewsection")]
        public async Task<IActionResult> AddNewSection([FromBody] Section section)
        {
            try
            {

                var inserted = await _repository.AddNewSection(section);
                return Ok(inserted);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("kais/api/dspc_explorer/addnewregistrar")]
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


        [HttpGet("kais/api/dspc_explorer/GetGraveOwnerDetailsByCode")]
        public async Task<IActionResult> GetGraveOwnerDetailsByCode(string code)
        {
            try
            {
                return Ok(await _repository.GetGraveOwnerDetailsByRefCode(code));
            }
            catch
            {
                return BadRequest();
            }
        }

        #region repository
        private readonly IDSPC_Repository _repository;
        #endregion

    }
}
