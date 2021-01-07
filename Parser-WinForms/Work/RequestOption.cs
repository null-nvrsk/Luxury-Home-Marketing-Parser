using System.Collections.Generic;
using System.Windows.Forms;

namespace LuxuryHomeMarketing
{
    public enum RequestType { rtCountry, rtState, rtMemberLevel, rtMember };

    public enum MemberLevel { mlMember, mlCLHMS, mlGuild, mlAffiliate };

    //-------------------------------------------------------------------------
    public class RequestOption
    {
        public RequestType type;
        public string country;
        public string state;
        public MemberLevel level;
        public string memberId;

        //---------------------------------------------------------------------
        public RequestOption(string country)
        {
            this.type = RequestType.rtCountry;
            this.country = country;
        }

        //---------------------------------------------------------------------
        public RequestOption(string country, string state)
        {
            this.type = RequestType.rtState;
            this.country = country;
            this.state = state;
        }

        //---------------------------------------------------------------------
        public RequestOption(string country, string state, MemberLevel level)
        {
            this.type = RequestType.rtMemberLevel;
            this.country = country;
            this.state = state;
            this.level = level;
        }

        //---------------------------------------------------------------------
        public RequestOption(string memberId, RequestType type)
        {
            if (type == RequestType.rtMember)
            {
                this.type = RequestType.rtMember;
                this.memberId = memberId;
            }
        }
    }

    //-------------------------------------------------------------------------
    class QueueRequest : Queue<RequestOption>
    {

    }
}