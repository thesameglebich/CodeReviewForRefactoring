using BackendTest1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest1.Models
{
    public class StorageViewModel
    {
        public int created { get; set; }
        public int destroyed { get; set; }
        public List<Modification> modifications { get; set; } = new List<Modification>();
        public List<MyRobot> myRobots { get; set; } = new List<MyRobot>();
    }
}
