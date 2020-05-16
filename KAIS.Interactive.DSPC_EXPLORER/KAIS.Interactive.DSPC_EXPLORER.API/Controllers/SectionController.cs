using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KAIS.Interactive.DSPC_EXPLORER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController: Controller
    {
        public SectionController(IDSPC_Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("getsectionbycode")]
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

        [HttpPost("addnewsection")]
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


        #region repository
        private readonly IDSPC_Repository _repository;
        #endregion
    }
}
