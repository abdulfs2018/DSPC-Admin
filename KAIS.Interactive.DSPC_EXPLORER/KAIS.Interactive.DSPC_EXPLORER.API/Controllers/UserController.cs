using KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KAIS.Interactive.DSPC_EXPLORER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: Controller
    {
        public UserController(IDSPC_Repository repository)
        {
            _repository = repository;
        }


        #region repository
        private readonly IDSPC_Repository _repository;
        #endregion
    }
}
