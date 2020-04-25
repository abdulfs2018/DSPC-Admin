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

                //SectionType sectionEnum = (SectionType)Enum.Parse(typeof(SectionType), section);
                //int sectionId = GeneralEnums.GetSectionNumberFromLetter(sectionEnum);

                //GraveOwner graveOwner = new GraveOwner
                //{
                //    SubId = subId,
                //    GraveReferenceCode = graveReferenceCode,
                //    GraveRow = graveRow,
                //    GraveDepth = graveDepth,
                //    GraveSize = graveSize,
                //    GraveLocation = graveLocation,
                //    GraveHeadStone = graveHeadStone,
                //    GraveOwnerName = graveOwnerName,
                //    GraveOwnerAddress = graveOwnerAddress,
                //    Remarks = remarks,
                //    Section = new Section
                //    {
                //        Code = section,
                //    },

                //};

                var inserted = await _repository.AddNewGraveOwner(owner);
                return Ok(inserted);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("kais/api/dspc_explorer/addnewsection")]
        public async Task<IActionResult> AddNewSection([FromBody] Section section/*string code, DateTime dateOpened, int graveCount*/)
        {
            try
            {

                //Section newSection = new Section
                //{
                //    Code = code,
                //    DateOpened = dateOpened,
                //    GraveCount = graveCount,
                //};

                var inserted = await _repository.AddNewSection(section);
                return Ok(inserted);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("kais/api/dspc_explorer/addnewregistrar")]
        public async Task<IActionResult> AddNewRegistrar([FromBody] Registrar registrar/*string bookPage, int numberInBook, string firstName, string lastName, string sex, int age, string ageDetail, string religion, string occupation, string deathLocation, string marriageStatus, DateTime deathDate, DateTime burialDate, string graveReferenceCode, string publicInfo, string proprietary, string sectionInfo, string numberInfo, string internmentSignature, string additionalComments, string registrarName*/)
        {

            try
            {

                //Registrar newRegistrar = new Registrar
                //{
                //   BookPage = bookPage,
                //   NumberInBook = numberInBook,
                //   FirstName =  firstName,
                //   LastName = lastName,
                //   Sex = sex,
                //   Age = age,
                //   AgeDetail = ageDetail,
                //   Religion = religion,
                //   Occupation = occupation,
                //   DeathLocation = deathLocation,
                //   MarriageStatus = marriageStatus,
                //   DeathDate = deathDate,
                //   BurialDate = burialDate,
                //   GraveOwner = new GraveOwner
                //   {
                //       GraveReferenceCode = graveReferenceCode
                //   },
                //   Public = publicInfo,
                //   Proprietary = proprietary,
                //   SectionInfo = sectionInfo,
                //   NumberInfo = numberInfo,
                //   InternmentSignature = internmentSignature,
                //   AdditionalComments = additionalComments,
                //   RegistrarName = registrarName,
                //};

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
