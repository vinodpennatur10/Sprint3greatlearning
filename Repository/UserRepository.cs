using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        List<UserModel> UserModels = new List<UserModel>();
        private readonly Context _context;
        private readonly IUserRepository _IUserRepository;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

     
        public UserRepository()
        { }
        public List<UserModel> GetGetalluser()
        {




            return UserModels;

        }

        public void CreateUser(UserModel objUserModel)
        {

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new UserModel
                {
                    FirstName = objUserModel.FirstName,
                    LastName = objUserModel.LastName,
                    Email = objUserModel.Email,
                    Password = objUserModel.Password
                });
            }
            _context.SaveChanges();
            UserModels.Add(objUserModel);

        }
        public string UpdateUser(UserModel UserModel)
        {

            var result = UserModels.Find(x => x.Id == UserModel.Id);
            UserModels.RemoveAll(x => x.Id == UserModel.Id);
            UserModels.Add(UserModel);
            //   UserModels.Remove(x => x.id == UserModel.Id);
            string returnresult;
            if (result == null)
            {
                returnresult = "failed";
            }
            else
            {
                returnresult = "success";
            }
            return returnresult;
        }

        public UserModel GetaUser(int id)
        {
            UserModel userModel = new UserModel();
            var result = _context.Users.Select(x => x.Id == id);
            return userModel;

        }
    }
}