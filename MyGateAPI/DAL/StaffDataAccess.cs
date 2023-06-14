using MyGateAPI.Models;
using MyGateAPI.ViewModels;

namespace MyGateAPI.DAL
{
    public class StaffDataAccess
    {
        public static List<StaffViewModel> GetStaffList()
        {
            using (MyGateApidbContext db = new MyGateApidbContext())
            {
                List<StaffViewModel> staffList = (from ua in db.UserProfiles
                                                       join s in db.Staff on ua.UserId equals s.UserId
                                                       select new StaffViewModel
                                                       {
                                                          StaffID=s.StaffId,
                                                           firstName = ua.FirstName,
                                                           lastName = ua.LastName,
                                                           phoneNumber = ua.Contact,
                                                           email = ua.Email,
                                                           aadharCardNo = ua.AadharCardNo,
                                                           gender = ua.Gender,
                                                           flatNumberforStaff = s.FlatNo,
                                                           staffShift = s.Shift
                                                       }).ToList();
                return staffList;
            }
        }
        public static bool EditStaff(Staff staff)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                Staff existingStaff = _context.Staff.Where(x => x.StaffId == staff.StaffId).FirstOrDefault();

                if (existingStaff != null)
                {
                    existingStaff.FlatNo = staff.FlatNo;
                    existingStaff.Shift = staff.Shift;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool DeleteStaff(int userID)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                UserProfile existingUser = _context.UserProfiles.Where(x => x.UserId == userID).FirstOrDefault();
                Staff existingStaff = _context.Staff.Where(x => x.UserId == userID).FirstOrDefault();

                if (existingStaff != null && existingUser != null)
                {
                    _context.UserProfiles.Remove(existingUser);
                    _context.Staff.Remove(existingStaff);
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
