using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapInterface
{
    public class PersonLocations
    {
        public int personCode { get; set; }
        public string personRole { get; set; } = string.Empty;
        public int lastSecurityPointNumber { get; set; }
        public string lastSecurityPointDirection  { get; set; } = string.Empty;
        public DateTime lastSecurityPointTime { get; set; }
    }
}
