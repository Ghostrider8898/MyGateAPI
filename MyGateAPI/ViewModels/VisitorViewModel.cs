using MyGateAPI.Models;

namespace MyGateAPI.ViewModels
{
    public class VisitorViewModel
    {
        public int VisitorID { get; set; }
        public string? firstName { get; set; } = string.Empty;
        public string? lastName { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? phoneNumber { get; set; } = string.Empty;
        public string? aadharCardNo { get; set; } = string.Empty;
        public string? gender { get; set; } = string.Empty;
        public DateTimeOffset? inTime { get; set; }
        public DateTimeOffset? outTime { get; set; }
        public string? visitingPurpose { get; set; } = string.Empty;
        public string? vehicleNo { get; set; } = string.Empty;
        internal Visitor ToVisitor()
        {
            return new Visitor()
            {
                VisitorId = this.VisitorID,
                InTime = this.inTime,
                OutTime = this.outTime,
                PurposeOfVisit = this.visitingPurpose,
                VehicleNo = this.vehicleNo
            };
        }
    }
}
