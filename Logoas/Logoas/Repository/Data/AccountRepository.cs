using Legoas.Context;
using Legoas.Models;
using System.Net.Mail;
using System.Net;
using Logoas.Models;
using Logoas.ViewModel;

namespace Legoas.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public async Task<int> Register(RegistrasiVM registerVM)
        {
            int result = 0;
            Member member = new Member
            {
                NIK= registerVM.NIK,
                Name = registerVM.Name,
                PhoneNumber = registerVM.PhoneNumber,
                Address = registerVM.Address,
                Email = registerVM.Email,

            };
            await myContext.Members.AddAsync(member);
            result = await myContext.SaveChangesAsync();

            Account account = new Account
            {
                Email = registerVM.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password)
            };

            await myContext.Accounts.AddAsync(account);
            result = await myContext.SaveChangesAsync();

            AccountRole accountRole = new AccountRole
            {
                Email = registerVM.Email,
                RoleId = 3
            };

            await myContext.AccountRoles.AddAsync(accountRole);
            result = await myContext.SaveChangesAsync();

            AccountOffice accountOffice = new AccountOffice
            {
                Email = registerVM.Email,
                OfficeId =1 
            };

            await myContext.AccountRoles.AddAsync(accountRole);
            result = await myContext.SaveChangesAsync();
            return result;
        }

        public string CheckEmail(string Email)
        {
            var account = myContext.Accounts.FirstOrDefault(a => a.Email == Email);

            if (account == null)
            {
                return null;
            }
            else
            {
                return account.Email; // Anda dapat mengganti ini dengan properti lain yang Anda butuhkan
            }
        }

        public bool CheckPassword(string Email, string password)
        {
            var account = myContext.Accounts.FirstOrDefault(a => a.Email == Email);

            if (BCrypt.Net.BCrypt.Verify(password, account.Password)) { 
                return true;
            } else {
                return false;
            }
        }

        public string[] GetRole(string Email)
        {
            var getRole = (from a in myContext.Accounts
                           join ar in myContext.AccountRoles on a.Email equals ar.Email
                           join r in myContext.Roles on ar.RoleId equals r.Id
                           where a.Email == Email
                           select new Role
                           {
                               Name = r.Name

                           }).ToList();

            string[] roles = new string[getRole.Count];
            for (int i = 0; i < getRole.Count; i++)
            {
                roles[i] = getRole[i].Name;
            }
            return roles;
        }

        public string ResetPasswordGenerator()
        {
            Guid g = Guid.NewGuid();
            string password = g.ToString().Substring(0, 12);
            return password;
        }

        public string Email(string password, string email)//tambah string email kalo mau kirim email sesuai email yg di input di model forgot password
        {
            try
            {
                DateTime today = DateTime.Now;
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ercheriom@gmail.com");//email pengirim
                message.To.Add(email);//email penerima (email testing atau string email yg disebut diatas)
                message.Subject = $"Reset Password Request From NETCoreTester {today.Date}";
                message.Body = $"Password anda sudah kami reset menjadi {password}";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ercheriom@gmail.com", "Vongola_123"); //self explanatory
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return "Email berhasil Dikirim";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



    }
}
