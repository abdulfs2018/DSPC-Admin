using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraveOwnerController : Controller
    {
        public GraveOwnerController(IDSPC_Repository repository)
        {
            _repository = repository;
        }


        [HttpPost("addnewgraveowner")]
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

        [HttpGet("GetGraveOwnerDetailsByCode")]
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

        [HttpPost("SearchGraveDetailsByFilterData")]
        public async Task<IActionResult> SearchGraveDetails([FromBody] GraveSearchFilterModel searchFilter)
        {
            try
            {
                return Ok(await _repository.SearchGravesByFilterData(searchFilter));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #region repository
        private readonly IDSPC_Repository _repository;
        #endregion
    }
}
