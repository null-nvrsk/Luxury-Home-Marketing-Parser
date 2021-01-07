using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryHomeMarketing
{
    class Member
    {
        public string id;
        public string name;
        public string email;
        public string www;

        public Member(string id, string name, string email, string www)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.www = www;
        }
    }

    class Members : List<Member>
    {

    }
}
