using System.ComponentModel.DataAnnotations;

namespace MyGateAPI.ViewModels
{
    public class UserDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public int userId { get; set; }
        public string phoneNumber { get; set; } = string.Empty;
        public string aadharCardNo { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string FlatNoForPass { get; set; }
        public string flatNumberforStaff { get; set; }
        public string flatNoForVisitor { get; set; }
        public string SCitizens { get; set; } 
        public string pets { get; set; } 
        public string staffShift { get; set; } = string.Empty;
        public string inTime { get; set; } 
        public string outTime { get; set; }
        public string visitingPurpose { get; set; } = string.Empty;
        public string vehicleNo { get; set; } = string.Empty;//for Visitor
        public int userType { get; set; }

    }
}
