using MyGateAPI.Models;
using MyGateAPI.ViewModels;

namespace MyGateAPI.DAL
{
    public class VisitorDataAccess
    {
        public static List<VisitorViewModel> GetVisitorsList()
        {
            using(MyGateApidbContext _context=new MyGateApidbContext())
            {
                List<VisitorViewModel> visitors=(from u in _context.UserProfiles
                                                 join v in _context.Visitors
                                                 on u.UserId equals v.UserId
                                                 select new VisitorViewModel
                                                 {
                                                     VisitorID = v.VisitorId,
                                                     firstName=u.FirstName,
                                                     lastName=u.LastName,
                                                     email=u.Email,
                                                     phoneNumber=u.Contact,
                                                     aadharCardNo=u.AadharCardNo,
                                                     gender=u.Gender,
                                                     inTime=v.InTime,
                                                     outTime=v.OutTime,
                                                     visitingPurpose=v.PurposeOfVisit,
                                                     vehicleNo=v.VehicleNo
                                                 }).ToList();
                return visitors;
            }
        }
        public static bool EditVisitor(Visitor visitor)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                Visitor existingVisitor=_context.Visitors.Where(x=>x.VisitorId==visitor.VisitorId).FirstOrDefault();
                if(existingVisitor!=null)
                {
                    existingVisitor.InTime=visitor.InTime;
                    existingVisitor.OutTime=visitor.OutTime;
                    existingVisitor.PurposeOfVisit=visitor.PurposeOfVisit;
                    existingVisitor.VehicleNo=visitor.VehicleNo;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool DeleteVisitor(int userID)
        {
            using (MyGateApidbContext _context = new MyGateApidbContext())
            {
                UserProfile existingUser = _context.UserProfiles.Where(x => x.UserId == userID).FirstOrDefault();
                Visitor existingVisitor = _context.Visitors.Where(x => x.UserId == userID).FirstOrDefault();

                if (existingVisitor != null && existingUser != null)
                {
                    _context.UserProfiles.Remove(existingUser);
                    _context.Visitors.Remove(existingVisitor);
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
