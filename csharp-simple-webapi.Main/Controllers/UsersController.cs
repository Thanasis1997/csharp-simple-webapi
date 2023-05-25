using csharp_simple_webapi.Main.Data;
using csharp_simple_webapi.Main.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_simple_webapi.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;


        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost]
        [Route("")]
        public async Task<IResult> InsertPerson(Person person)
        {
            try
            {
                return _userRepository.Add(person) ? Results.Ok() : Results.Problem();
               
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                return Results.Ok(_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }



    }
}
