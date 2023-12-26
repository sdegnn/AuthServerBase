using AuthServer.Core.DTOs;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService=authenticationService;
            
        }
        [HttpPost]
        public async Task <IActionResult> CreateToken(LoginDto loginDto)
        {
            var result =await _authenticationService.CreateToken(loginDto);
            return ActionResultInstance(result);
            
        }
        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var result = _authenticationService.CreateTokenByClient(clientLoginDto);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.RefreshToken);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto tokenRefreshDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(tokenRefreshDto.RefreshToken);
            return ActionResultInstance(result);
        }



    }
}
