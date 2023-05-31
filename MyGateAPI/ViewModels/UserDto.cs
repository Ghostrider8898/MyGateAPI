using System.ComponentModel.DataAnnotations;

namespace MyGateAPI.ViewModels
{
    public class UserDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Contact { get; set; } = string.Empty;
        public string AadharCardNo { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int FlatNo { get; set; } = 0;
        public int NoOfSeniorCitizen { get; set; } = 0;
        public int NoOfPets { get; set; } = 0;
        public string Shift { get; set; } = string.Empty;
        public DateTimeOffset? InTime { get; set; } 
        public DateTimeOffset? OutTime { get; set; }
        public string PurposeOfVisit { get; set; } = string.Empty;
        public string VehicleNo { get; set; } = string.Empty;//for Visitor
        public string Address { get; set; }=string.Empty;// for security guard
        public int RoleId { get; set; }

    }
}
