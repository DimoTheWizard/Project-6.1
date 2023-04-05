using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Accounting
{
    public class User
    {
        private static string userName;
        private static userLevel level;

        public static string UserName
        {
<<<<<<< HEAD
<<<<<<< HEAD
            get { return userName; }
            set { userName = value; }
=======
            get { return UserName; }
            set { UserName = value; }
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            get { return userName; }
            set { userName = value; }
>>>>>>> can add transactions to database, fixed login, fixed parsing
        }

        

        public static userLevel Level
        {
            get { return level; }
            set { level = value; }
        }

    }

    public enum userLevel
    {
        SUPERUSER,
        ADMIN,
        GUEST
    }
}
