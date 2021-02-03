using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class Usersession
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime SessionDate { get; set; }
        public bool? SessionStatus { get; set; }
        public string SessionToken { get; set; }

        public virtual Enduser User { get; set; }
    }
}
