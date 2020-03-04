using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.ViewModel
{
    public class PlayerViewModel
    {
        public int PlayerID { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public int TeamID { get; set; }
        public string TeamLocation { get; set; }
        public string TeamName { get; set; }
    }
}
