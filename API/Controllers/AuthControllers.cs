using Microsoft.AspNetCore.Mvc;
using API.Models;


namespace API.Controllers
{
    [ApiController]//indica que la clase es un controlador de API
    [Route("api/[controller]")] //define la ruta base para las solicitudes HTTP
    public class AuthController : ControllerBase
    {
        // Placeholder for user registration
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            // Registration logic would go here (e.g., save user to database)
            return Ok(new { message = "User registered successfully" });
        }

        // Placeholder for user login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            // Authentication logic would go here (e.g., verify user credentials)
            return Ok(new { token = "dummy-jwt-token" });
        }
    }
}