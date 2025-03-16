using Microsoft.AspNetCore.Mvc;
using Familestan.Core.Models;
using Familestan.Infrastructure.Services;

namespace Familestan.API.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _memberService.RegisterAsync(dto);
            if (!result) return BadRequest("این ایمیل قبلاً ثبت شده است.");
            return Ok("ثبت نام با موفقیت انجام شد. لطفاً کد OTP را وارد کنید.");
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpDto dto)
        {
            var result = await _memberService.VerifyOtpAsync(dto);
            if (!result) return BadRequest("کد OTP اشتباه است یا منقضی شده است.");
            return Ok("حساب شما تأیید شد.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _memberService.LoginAsync(dto);
            if (token == null) return Unauthorized("ایمیل یا رمزعبور اشتباه است.");
            return Ok(new { Token = token });
        }
    }
}
