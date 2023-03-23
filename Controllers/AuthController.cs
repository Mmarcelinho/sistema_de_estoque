namespace ApiEstoque.Controllers;

public class AuthController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signManager;

    private readonly UserManager<IdentityUser> _userManager;

    private readonly AppJwtSettings _appJwtSettings;

    public AuthController(SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager,
    IOptions<AppJwtSettings> appJwtSettings)
    {
        _signManager = signInManager;
        _userManager = userManager;
        _appJwtSettings = appJwtSettings.Value;
    }

    [Produces(typeof(RegisterUser))]
    [ProducesResponseType(typeof(RegisterUser), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("registro")]
    public async Task<ActionResult> Register([FromBody]RegisterUser registerUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new IdentityUser
        {
            UserName = registerUser.Email,
            Email = registerUser.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, registerUser.Password);

        if (result.Succeeded)
        {
            return Ok(GetUserResponse(user.Email));
        }

        return BadRequest(result.Errors);
    }

    [Produces(typeof(LoginUser))]
    [ProducesResponseType(typeof(LoginUser), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody]LoginUser loginUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _signManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

        if (result.Succeeded)
            return Ok(loginUser.Email);

        if (result.IsLockedOut)
            return BadRequest("O usuário está bloqueado.");

        return BadRequest("Usuário ou senha incorretos.");
    }
    private string GetFullJwt(string email)
    {
        return new JwtBuilder()
        .WithUserManager(_userManager)
        .WithJwtSettings(_appJwtSettings)
        .WithEmail(email)
        .WithJwtClaims()
        .WithUserClaims()
        .WithUserRoles()
        .BuildToken();
    }
    private UserResponse GetUserResponse(string email)
    {
        return new JwtBuilder()
        .WithUserManager(_userManager)
        .WithJwtSettings(_appJwtSettings)
        .WithEmail(email)
        .WithJwtClaims()
        .WithUserClaims()
        .WithUserRoles()
        .BuildUserResponse();
    }
}