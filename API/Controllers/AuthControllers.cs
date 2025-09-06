using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{
    [ApiController]//indica que la clase es un controlador de API
    [Route("api/[controller]")] //define la ruta base para las solicitudes HTTP
    public class AuthController : ControllerBase
    {
        private readonly DbContext _context;
        public AuthController(DbContext context)
        {
            _context = context;
        }
        // Placeholder for user registration
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve los errores de validación
            }

            Console.WriteLine($"Registering user: {user.Username}, Email: {user.Email}");
            return Ok(new { message = "User registered successfully", user });
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