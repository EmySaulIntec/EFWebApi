using Bussiness.Repositories.Users;
using Bussiness.Services.Base;
using Bussiness.Services.Users.Dto;

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
                password = "23",
                status = true
            });

            _userRepository.SaveChanges();
        }


        public void SaveUser(UserDto userDto)
        {
            // Esto 
            MyDbTest.Models.Usuario user = AutoMapp.Map<MyDbTest.Models.Usuario>(userDto);

            _userRepository.Create(user);

            // en  vez de esto

            _userRepository.Create(new MyDbTest.Models.Usuario()
            {
                apellido = user.LastName,
                idRol = user.RolId,
                Nombre = user.Name,
                password = user.Password,
                status = user.Status
            });
            // 

            _userRepository.SaveChanges();
        }
    }
}
