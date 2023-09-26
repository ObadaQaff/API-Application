using Microsoft.AspNetCore.Mvc;
using MyApp.Application.services.Users;
using MyApp.Domain.Users;
using AutoMapper;
using MyApp.Application.Usrs;

namespace MyApp.Web.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices,
            IMapper mapper)
        {

            _userServices = userServices;
            _mapper = mapper;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {



            return Ok(await _userServices.GetAll());
        }
        [HttpGet]
        [Route(template: "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userServices.GetById(id);
            if (user == null) { return NotFound(); }

            else
                return Ok(user);
        }
        [HttpPost]
        [Route(template: "AddUser")]
        public async Task<IActionResult> Add(UserMapperProfile Dto)
        {
            var uu = _mapper.Map<User>(Dto);
            var user = new User{ Name = Dto.Name, Email = Dto.Email };
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            else
            {


                await _userServices.Add(user);
                await _userServices.Save();

                return Ok(user);

            }

           

        }
        [HttpDelete]
        [Route(template:"Delete")]
        public async Task<IActionResult> Delete(int id)
            {
            var user = await _userServices.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userServices.Delete(user);
            await _userServices.Save();
            return NoContent();

        }
        [HttpPatch]
        [Route(template: "Update")]
        public async Task<IActionResult> Update(UserMapperProfile Dto)
        {
            var user = await _userServices.GetById(Dto.Id);
            if (user == null) { return NotFound(); }
            user.Name = Dto.Name;
            user.Email = Dto.Email;
            await _userServices.Update(user);
            await _userServices.Save();
            return NoContent();

        }

    }


    //create
    //update
    //getById
    //getAll
    //Find
    //delete

    //[HttpGet]
    //public IActionResult Get()
    //{

    //    return Ok(_unitOfWork.Users.Get(1

    //}

    //[HttpGet]
    //public IActionResult GetAll()
    //{

    //    return Ok(_unitOfWork.Users.GetAll());

    //}

    //[HttpGet]
    //public async Task<IActionResult> GetAsyncByID()
    //{

    //    return Ok(await _unitOfWork.Users.GetAsync(1));

    //}
    //[HttpGet]
    //public IActionResult GetAll1()
    //{

    //    return Ok(_unitOfWork.Users.FindAll(b => b.Name.Contains("Obada")));

    //}


}
