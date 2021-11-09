using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Interfaces;

namespace ServerApi.Controllers
{
  [ApiController]
    [Route("teste")]
    public class ServerApiController : ControllerBase
    {
        private readonly ILogger<ServerApiController> _logger;
        private readonly IJsonWebKeySetService _jwksService;

        public ServerApiController(ILogger<ServerApiController> logger, IJsonWebKeySetService jsonWebKeySetService)
        {
            _logger = logger;
            _jwksService = jsonWebKeySetService;
        }

        [HttpGet]
        public IActionResult Get(string jwe)
        {
            var handler = new JsonWebTokenHandler();
            var encryptingCredentials = _jwksService.GetCurrentEncryptingCredentials();
            var result = handler.ValidateToken(jwe,
                new TokenValidationParameters
                {
                    ValidIssuer = "CartãoVirtualTH",
                    ValidAudience = "cartão credito",
                    RequireSignedTokens = false,
                    TokenDecryptionKey = encryptingCredentials.Key,
                });
            if (!result.IsValid)
                BadRequest();

            return Ok(result.Claims);
        }
    }

}
