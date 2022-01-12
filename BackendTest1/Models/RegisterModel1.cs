using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTest1.Services;

namespace BackendTest1.Models
{
    public class RegisterModel1
    {
        public string robotname { get; set; }
        
        public int bodycurind { get; set; }
        public List<Modification> modifications { get; set; } = new List<Modification>();

    }
}
