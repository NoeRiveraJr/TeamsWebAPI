using System;
using System.Collections.Generic;

namespace TeamAPI.Models
{
    public partial class Players
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Teams Team { get; set; }
    }
}
