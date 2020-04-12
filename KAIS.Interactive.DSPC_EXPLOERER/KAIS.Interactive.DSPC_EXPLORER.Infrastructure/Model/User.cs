using System;
using System.Collections.Generic;
using System.Text;

namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public string ApprovalPassword { get; set; }
    }


    public enum UserType
    {
        Admin,
        Standard
    }
}
