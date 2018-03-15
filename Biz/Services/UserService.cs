using System.Linq;
using System.Net.Mail;
using Biz.Interfaces;
using Core.Domains;
using Data;
using System.Net.Mail;
using System.Text;

namespace Biz.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;

        public UserService()
        {
            _userRepo = new Repository<User>();
        }

        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public IQueryable<User> GetAll()
        {
            return _userRepo.Table;
        }

        public User GetByEmailId(string id)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            return _userRepo.GetById(id);
        }

        public void InsertOrUpdate(User user)
        {
            if (user.Id == 0)
            {
                _userRepo.Insert(user);
                sendEmailToUser(user);
            }
            else
            {
                _userRepo.Update(user);
            }

        }

        public void sendEmailToUser(User user)
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            string Body = "Please use below credential to login to IMS.\n\n Your Login Id is:   "+user.EmailId+"\n Your Password is:     " + user.PasswordHash;
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("noreplyinventory13@gmail.com", "Employee#123");

            MailMessage mm = new MailMessage("noreplyinventory13@gmail.com", user.EmailId, "PasswordDetails", Body);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

    }
}