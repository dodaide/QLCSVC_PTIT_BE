

//[Route("api/[controller]")]
//[ApiController]
//public class LoginController : ControllerBase
//{
//    private readonly IConfiguration _configuration;
//    private readonly UserRepository _userRepository;

//    public LoginController(IConfiguration configuration, UserRepository userRepository)
//    {
//        _configuration = configuration;
//        _userRepository = userRepository;
//    }

//    [HttpPost("login")]
//    public async Task<IActionResult> Login([FromBody] LoginModel model)
//    {
//        var user = await _userRepository.GetUserAsync(model.Username, model.Password);
//        if (user != null)
//        {
//            var claims = new[]
//            {
//                new Claim(ClaimTypes.Name, user.Username)
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"])),
//                signingCredentials: creds
//            );

//            return Ok(new
//            {
//                access_token = new JwtSecurityTokenHandler().WriteToken(token),
//                expires_in = _configuration["Jwt:ExpirationInMinutes"]
//            });
//        }

//        return Unauthorized();
//    }
//}