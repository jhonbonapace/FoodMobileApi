using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enumerators
{
    public class Enumerator
    {
        public enum UserType
        {
            [Description("Personal")]
            Personal = 1,
            [Description("Establishment")]
            Establishment = 2,
        }
        public enum ContactType
        {
            [Description("Telefone")]
            Telephone = 1,
            [Description("Facebook")]
            Facebook = 2,
            [Description("Instagram")]
            Instagram = 3,
            [Description("Twitter")]
            Twitter = 4,
            [Description("Site")]
            WebSite = 5,
            [Description("E-mail")]
            Email = 6,
            [Description("Outro")]
            Other = 7,
        }
    }
}
