using System;
using System.Collections.Generic;

namespace TeamAPI.Models
{
    public partial class Teams
    {
        public Teams()
        {
            Players = new HashSet<Players>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Players> Players { get; set; }
    }
}
