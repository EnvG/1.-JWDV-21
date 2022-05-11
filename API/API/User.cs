using System;
using System.Collections.Generic;

namespace API
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[] Photo { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
    }
}
