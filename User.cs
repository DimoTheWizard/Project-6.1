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
        private static int id;

        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }        

        public static userLevel Level
        {
            get { return level; }
            set { level = value; }
        }

        public static int userID
        {
            get { return id; }
            set { id = value; }
        }
    }

    public enum userLevel
    {
        SUPERUSER,
        ADMIN,
        GUEST
    }
}
