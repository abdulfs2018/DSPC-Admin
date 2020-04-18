using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model;
using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using KAIS.Interactive.DSPC_EXPLORER.API.Services.Enums;

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

        [HttpPost("kais/api/dspc_explorer/addnewgraveowner")]
        public async Task<IActionResult> AddNewGraveOwner(string subId, string jKIndex, string graveReferenceCode, 
            string section, int graveRow, int graveDepth, string graveSize, string graveLocation, bool graveHeadStone, string graveOwnerName, string graveOwnerAddress, string remarks)
        {
            try
            {

                SectionType sectionEnum = (SectionType)Enum.Parse(typeof(SectionType), section);

                GeneralEnums enumControls = new GeneralEnums();

                int sectionId = enumControls.GetSectionNumberFromLetter(sectionEnum);

                GraveOwner graveOwner = new GraveOwner
                {
                    SubId = subId,
                    JkIndex = jKIndex,
                    GraveReferenceCode = graveReferenceCode,
                    GraveRow = graveRow,
                    GraveDepth = graveDepth,
                    GraveSize = graveSize,
                    GraveLocation = graveLocation,
                    GraveHeadStone = graveHeadStone,
                    GraveOwnerName = graveOwnerName,
                    GraveOwnerAddress = graveOwnerAddress,
                    Remarks = remarks,
                    Section = new Section
                    {
                        Id = sectionId,
                    },

                };

                var inserted = await _repository.AddNewGraveOwner(graveOwner);

                if (inserted)
                {
                    return Ok(true);
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

        [HttpPost("kais/api/dspc_explorer/addnewsection")]
        public async Task<IActionResult> AddNewSection(string code, DateTime dateOpened, int graveCount)
        {
            try
            {


                Section newSection = new Section
                {
                    Code = code,
                    DateOpened = dateOpened,
                    GraveCount = graveCount,
                };

                var inserted = await _repository.AddNewSection(newSection);

                if (inserted)
                {
                    return Ok(true);
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

        [HttpGet("kais/api/dspc_explorer/getsectionbycode")]
        public async Task<IActionResult> GetSectionByCode(string code)
        {
            try
            {

                var section = await _repository.GetSectionByCode(code);

                if (section != null)
                {
                    return Ok(section);
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
