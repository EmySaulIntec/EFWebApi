using Bussiness.Repositories.User;
using Bussiness.Services.Base;

namespace Bussiness.Services
{
    public class UserAppService : AppService, IUserAppService
    {
        private IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SaveUser(string name)
        {
            _userRepository.Create(new MyDbTest.Models.Usuario()
            {
                apellido = "Emy",
                idRol = 1,
                Nombre = name,
                password=  "23",
                status = true
            });

            _userRepository.SaveChanges();
        }
    }
}
