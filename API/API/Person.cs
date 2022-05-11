using System;
using System.Collections.Generic;

namespace API
{
    public partial class Person
    {
        public int UserId { get; set; }
        public string Fullname { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
