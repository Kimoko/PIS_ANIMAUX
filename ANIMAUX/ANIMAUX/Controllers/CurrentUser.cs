using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMAUX.Controllers
{
    public class CurrentUser
    {
        public string name = "";
        public int organisation = 1;
        public int role = 0; //роли: 0 - админ | 1 - организации | 2 - пользователи
        public int district = -1;
        public bool isAutharized = false;

        private static CurrentUser instance = null;

        private CurrentUser(string name, int org, int role, int district)
        {
            this.name = name;
            this.organisation = org;
            this.role = role;
            this.district = district;
        }

        public static CurrentUser setUser(string name, int org, int role, int district)
        {
            if (instance == null)
            {
                instance = new CurrentUser(name, org, role, district);
            }
            return instance;
        }

        public static CurrentUser getUser()
        {
            return instance;
        }
    }

}