using MyGateAPI.Models;
using MyGateAPI.ViewModels;

namespace MyGateAPI.DAL
{
    public class FlatOwnerDataAccess
    {
        public static List<FlatOwnerViewModel> GetFlatOwnersList()
        {
            using (MyGateApidbContext db = new MyGateApidbContext())
            {
                List<FlatOwnerViewModel> flatOwners = (from ua in db.UserProfiles
                                                       join f in db.FlatOwners on ua.UserId equals f.UserId
                                                       select new FlatOwnerViewModel
                                                       {
                                                           FlatOwnerID=f.FlatOwnerId,
                                                           firstName = ua.FirstName,
                                                           lastName = ua.LastName,
                                                           phoneNumber = ua.Contact,
                                                           email = ua.Email,
                                                           aadharCardNo = ua.AadharCardNo,
                                                           gender = ua.Gender,
                                                           flatNumber = f.FlatNo,
                                                           SCitizens = f.NoOfSeniorCitizen,
                                                           pets = f.NoOfPets
                                                       }).ToList();
                return flatOwners;
            }
        }
        public static bool EditFlatOwner(FlatOwner owner)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                FlatOwner existingFlatOwner = _context.FlatOwners.Where(x => x.FlatOwnerId == owner.FlatOwnerId).FirstOrDefault();

                if (existingFlatOwner != null)
                {
                    existingFlatOwner.FlatNo = owner.FlatNo;
                    existingFlatOwner.NoOfSeniorCitizen = owner.NoOfSeniorCitizen;
                    existingFlatOwner.NoOfPets = owner.NoOfPets;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static FlatOwner GetFlatOwnerByID(int ID)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                return _context.FlatOwners.Where(x => x.FlatOwnerId == ID).FirstOrDefault();

            }
        }
        public static bool DeleteFlatOwner(int userID)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                UserProfile existingUser = _context.UserProfiles.Where(x => x.UserId == userID).FirstOrDefault();
                FlatOwner existingFlatOwner = _context.FlatOwners.Where(x => x.UserId == userID).FirstOrDefault();

                if (existingFlatOwner != null && existingUser != null)
                {
                    _context.UserProfiles.Remove(existingUser);
                    _context.FlatOwners.Remove(existingFlatOwner);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
