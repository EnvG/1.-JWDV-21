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

        /// <summary>
        /// Запрос авторизации
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        [HttpGet("auth")]
        public bool Auth(string email, string password)
        {
            // Пользователь с заданными почтой и паролем
            User? user = this.context.Users.ToList().Where(u => u.Email == email && u.Password == password).FirstOrDefault();

            // Если пользователь найден,
            // то возвращаем true,
            // иначе — false
            return user != null;
        }

        /// <summary>
        /// Запрос регистрации
        /// </summary>
        /// <param name="fullname">ФИО пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        [HttpGet("registration")]
        public bool Registration (string fullname, string email, string password)
        {
            try
            {
                // ID пользователя
                int id = (this.context.Users.ToList().Max(u => u.UserId) == null ? 0 : this.context.Users.Max(u => u.UserId)) + 1;

                // Новый пользователя
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

                // Сохранение нового пользователя в базе данных
                this.context.Users.Add(user);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Запрос восстановления пароля
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <returns></returns>
        [HttpGet("repair-password")]
        public bool RepairPassword(string email)
        {
            User? user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();

            // Если пользователь найден,
            // то возвращаем true,
            // иначе — false
            return user != null;
        }

       /// <summary>
       /// Запрос изменения пароля
       /// </summary>
       /// <param name="email">Почта пользователя</param>
       /// <param name="password">Новый пароль пользователя</param>
       /// <returns></returns>
        [HttpGet("change-password")]
        public bool? ChangePassword (string email, string password)
        {
            User? user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();

            // Если текущий пароль пользователя совпадает с новым,
            // то возвращаем null
            if (user.Password == password)
            {
                return null;
            }

            // Если пользователь найден, 
            // то изменяем его пароль
            if (user != null)
            {
                // Изменение пароль пользователя
                user.Password = password;
                this.context.SaveChanges();
                return true;
            }
            else
            {
                // Если пользователь не найден,
                // то возвращаем false
                return false;
            }
        }
    }
}
