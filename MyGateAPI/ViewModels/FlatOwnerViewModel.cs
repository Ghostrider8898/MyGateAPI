using MyGateAPI.Models;

namespace MyGateAPI.ViewModels
{
    public class FlatOwnerViewModel
    {
        public int FlatOwnerID { get; set; }
        public string? firstName { get; set; } = string.Empty;
        public string? lastName { get; set; } = string.Empty;
        public string? fullName { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? phoneNumber { get; set; } = string.Empty;
        public string? aadharCardNo { get; set; } = string.Empty;
        public string? gender { get; set; } = string.Empty;
        public int? flatNumber { get; set; }
        public int? SCitizens { get; set; }
        public int? pets { get; set; }
        internal FlatOwner ToFlatOwner()
        {
            return new FlatOwner()
            {
                FlatOwnerId = this.FlatOwnerID,
                FlatNo=this.flatNumber,
                NoOfSeniorCitizen = this.SCitizens,
                NoOfPets = this.pets
            };
        }
    }
}
