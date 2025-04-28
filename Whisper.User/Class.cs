using Microsoft.AspNetCore.Mvc;
using Whisper.User.Domain.Entities;
using Whisper.User.Domain.Interfaces.Repositories;

namespace Whisper.User.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class Controller(IUserRepository userRepository) : ControllerBase
    {
        [HttpGet("lol/{id}")]
        public async Task<ActionResult<UserEntity>> GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid GUID.");
            }

            try
            {
                var user = await userRepository.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}