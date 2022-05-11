using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private JWDVContext context = new JWDVContext();

        public UserController(ILogger<UserController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("auth")]
        public bool Auth(string email, string password)
        {
            User? user = this.context.Users.ToList().Where(u => u.Email == email && u.Password == password).FirstOrDefault();

            return user != null;
        }

        [HttpGet("registration")]
        public bool Registration (string fullname, string email, string password)
        {
            try
            {
                int id = (this.context.Users.Max(u => u.UserId) == null ? 0 : this.context.Users.Max(u => u.UserId)) + 1;
                User user = new User()
                {
                    UserId = id,
                    Email = email,
                    Password = password,
                    Person = new Person()
                    {
                        UserId = id,
                        Fullname = fullname,
                    }
                };

                this.context.Users.Add(user);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
