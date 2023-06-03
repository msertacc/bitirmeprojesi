using Abstraction.Service.User;
using AutoMapper;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User
{
    [ApiController]
	[Route("[controller]")]
	public class UserController:ControllerBase
	{
		private readonly IUserService userService;
		private readonly IMapper mapper;

		public UserController(IUserService userService, IMapper mapper)
		{
			this.userService = userService;	
			this.mapper = mapper;
		}

		[HttpGet("Get")]
		public IEnumerable<ApplicationUser> Get()
		{
			var response = this.userService.GetUsers();
			return response;
		}

		[HttpGet("GetById")]
		public ApplicationUser GetById(int userId)
		{
			var response = this.userService.GetUserById(userId);
			return response;
		}

        [HttpPost("UpdateUserVerify")]
        public ApplicationUser UpdateUserVerify([FromBody] Guid id)
        {
            var response = this.userService.UpdateVerify(id);
            return response.Result;
        }




        //[HttpPost("Create")]
        //public async Task<IActionResult> Create([FromBody] UserCreateRequest model)
        //{
        //	try
        //	{
        //		var mappingModel = this.mapper.Map<UserCreateRequest, UserDto>(model);

        //		await this.userService.Create(mappingModel).ConfigureAwait(false);

        //		return this.Ok();
        //	}
        //	catch (Exception ex)
        //	{

        //		return this.BadRequest(ex.Message);
        //	}

        //}

        //[HttpPost("Update")]
        //public async Task<IActionResult> Update([FromBody] UserUpdateRequest model)
        //{
        //	try
        //	{
        //		var mappingModel = this.mapper.Map<UserUpdateRequest, UserDto>(model);

        //		await this.userService.Update(mappingModel).ConfigureAwait(false);

        //		return this.Ok();
        //	}
        //	catch (Exception ex)
        //	{

        //		return this.BadRequest(ex.Message);
        //	}

        //}

        //[HttpPost("Delete")]
        //public async Task<IActionResult> Delete([FromBody] int userId)
        //{
        //	try
        //	{
        //		await this.userService.Delete(userId).ConfigureAwait(false);

        //		return this.Ok();
        //	}
        //	catch (Exception ex)
        //	{

        //		return this.BadRequest(ex.Message);
        //	}

        //}
    }
}
