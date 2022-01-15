using System.Collections.Generic;

namespace WebApplication1
{
    public class LoginRepository : ILoginrespository
    {

       public  string ValidateUser(string loginid, string password)
        {

            if (loginid =="test" &&  password =="test")
            {
                return "success";
            }
            else
            { return  "notok"; }
        }
    }
}