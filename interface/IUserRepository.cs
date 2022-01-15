using System.Collections.Generic;

namespace WebApplication1
{ 
    public interface IUserRepository
    {
    List<UserModel> GetGetalluser();

        void CreateUser(UserModel UserModel);
        string UpdateUser(UserModel UserModel);

        UserModel GetaUser(int id);
}
}