namespace Familestan.Core.Models
{
    public class VerifyOtpDto
    {
        public required string Email { get; set; }
        public required string OtpCode { get; set; }
    }
}
