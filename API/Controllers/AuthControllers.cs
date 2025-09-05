using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;
using API.Data;


namespace API.Controllers
{
    [ApiController]//indica que la clase es un controlador de API
    [Route("api/[controller]")] //define la ruta base para las solicitudes HTTP
    public class AuthController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public AuthController(ApiDbContext context)
    {
        _context = context;
    }
        // Placeholder for user registration
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            // Registration logic would go here (e.g., save user to database)
            //print user info to console for demonstration
            Console.WriteLine($"Registering user: {user.Username}, Email: {user.Email}");
            //return json response with user info
            return Ok(new { message = "User registered successfully", user });

        }

        // Placeholder for user login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            // Authentication logic would go here (e.g., verify user credentials)
            return Ok(new { token = "dummy-jwt-token" });
        }
        //test db connection
        [HttpGet("testdb")]
        public IActionResult TestDbConnection()
        {
            var todasRecetas = new List<Receta>();
            try
            {
                todasRecetas = _context.Recetas.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Database connection failed", error = ex.Message });
            }
            return Ok(new { message = "Database connection successful", todasRecetas });
        }

    }
}