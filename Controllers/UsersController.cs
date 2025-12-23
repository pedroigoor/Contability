using Gs_Contability.Dto.Users;
using Gs_Contability.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gs_Contability.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] int page = 1,
                                 [FromQuery] int size = 10)
        {
            var body = await _userService.FindAll(page, size);
            return Ok(body);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            return Ok(await _userService.FindById(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestDTO value)
        {
            var body = await _userService.CreateAsync(value);

            return CreatedAtAction(
                nameof(FindById),
                new { id = body.Id },
                body
            );
        }

        // PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteById(id);
            return NoContent();
        }
    }
}
