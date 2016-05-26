using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.Restaurant
{
    public class person : IHasId
    {
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string cellPhone { get; set; }
        public string address { get; set; }
        public string email { get; set; }

        int IHasId.Id
        {
            get { return personId; }
            set { personId = value; }
        }
    }

    public class clubMember : person
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class reaction : IHasId
    {
        public int reactionId { get; set; }
        public string username { get; set; }
        public DateTime? reactionDate { get; set; }
        public string reactionContent { get; set; }

        int IHasId.Id
        {
            get { return reactionId; }
            set { reactionId = value; }
        }
    }

    public class account : IHasId
    {
        public int accountId { get; set; }
        public double? percent { get; set; }
        public string invitationFood { get; set; }
        public virtual person person { get; set; }

        int IHasId.Id
        {
            get { return accountId; }
            set { accountId = value; }
        }
    }

    public class payCardInvitation : IHasId
    {
        public int payCardInvitationId { get; set; }
        public string cardNumber { get; set; }
        public string TzNumber { get; set; }
        public virtual account account { get; set; }

        int IHasId.Id
        {
            get { return payCardInvitationId; }
            set { payCardInvitationId = value; }
        }
    }
}
