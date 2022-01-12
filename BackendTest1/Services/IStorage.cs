using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest1.Services
{
    public interface IStorage
    {
        List<Modification> startMods();
        List<Modification> getmods();
        int getmoney();
        void addRobot(MyRobot robot);
        void changeMoney(int count);
        List<MyRobot> getRobots();
    }
}
