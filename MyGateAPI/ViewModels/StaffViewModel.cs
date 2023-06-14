using MyGateAPI.Models;

namespace MyGateAPI.ViewModels
{
    public class StaffViewModel
    {
        public int StaffID { get; set; }
        public string? firstName { get; set; } = string.Empty;
        public string? lastName { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? phoneNumber { get; set; } = string.Empty;
        public string? aadharCardNo { get; set; } = string.Empty;
        public string? gender { get; set; } = string.Empty;
        public int? flatNumberforStaff { get; set; }
        public string? staffShift { get; set; }
        internal Staff ToStaff()
        {
            return new Staff()
            {
                StaffId = StaffID,
                FlatNo = this.flatNumberforStaff,
                Shift = this.staffShift
            };
        }
    }
}
