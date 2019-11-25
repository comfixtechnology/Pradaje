
using Pradadge.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace DS.MerchantWebApi.core
{
    public   class TokenHelper
    {
        public static UserDetail Token()
        {
            UserDetail users = new UserDetail();
             
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                foreach(var item in identity.Claims)
                {
                    string itemType = item.Type.Split('/').LastOrDefault();

                    switch (itemType)
                    {
                        case "name":
                            users.UserName = item.Value;
                            break;
                        case "nameidentifier":
                             users.UserId = item.Value;
                            break;
                        case "emailaddress":
                            users.UserEmail = item.Value;
                            break;                          
                    }
                       
                }
                 

            }
            return users;
        }
    }

    public class Claims
    {
        public string Subject { get; }
        public string Type { get; }
        public string Value { get; }

        public Claims(string subject, string type, string value)
        {
            Subject = subject;
            Type = type;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return true;

            //return obj is Claims other &&
            //       Subject == other.Subject &&
            //       Type == other.Type &&
            //       Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hashCode = 1121400638;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Subject);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }
    }
}