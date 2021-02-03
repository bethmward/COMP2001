using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable

namespace WebAPI.Models
{
    public partial class Userpassword
    {
        public int PasswordId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
        public DateTime PasswordDateChanged { get; set; }

        public virtual Enduser User { get; set; }
    }
}
