using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDew
{
    public class Users
    {
        private static Users instance;
        private string userPermissions;

       

        public static Users Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Users();
                }
                return instance;
            }
        }

        public string UserPermissions
        {
            get { return userPermissions; }
            set { userPermissions = value; }
        }
    }
}
