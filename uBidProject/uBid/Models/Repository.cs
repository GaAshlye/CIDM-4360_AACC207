using System.Collections.Generic;

namespace uBid.Models {

    public static class Repository {
        
        private static List<UserModel> logins = new List<UserModel>()
        {
            //chapter 4 of the freeman book
            new UserModel(){userName = "test@test.com", passWord = "xXyYzZaA"}
        };

        public static IEnumerable<UserModel> Logins {
            get {
                return logins;
            }
        }

        public static UserModel ValidateLogin(string userName)
        {
            foreach(UserModel um in Repository.Logins)
            {
                if(userName == um.userName)
                {
                    return um;
                }
            }

            return null;
        }

        public static bool ValidatePassword(UserModel login)
        {
            foreach(UserModel um in Repository.Logins)
            {
                if(login.userName == um.userName && login.passWord == um.passWord)
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddLogin(UserModel login) {
            logins.Add(login);
        }
    }
}