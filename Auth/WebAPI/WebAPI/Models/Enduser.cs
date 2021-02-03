using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable

namespace WebAPI.Models
{
    public partial class Enduser
    {
        public Enduser()
        {
            Userpasswords = new HashSet<Userpassword>();
            Usersessions = new HashSet<Usersession>();
        }

        public int UserId { get; set; }
        [JsonIgnore]
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserEmail { get; set; }

        public virtual ICollection<Userpassword> Userpasswords { get; set; }
        public virtual ICollection<Usersession> Usersessions { get; set; }
    }
}
