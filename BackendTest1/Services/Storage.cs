using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest1.Services
{
    public class Storage : IStorage
    {
        int allmoney = 10000;
        readonly int created = 0;
        readonly int desroyed = 0;
        private readonly List<Modification> modifications = new List<Modification>();
        private List<MyRobot> robots = new List<MyRobot>();

        public List<MyRobot> getRobots()
        {
            return robots;
        }
        public void changeMoney(int count)
        {
            allmoney = count;
        }
        public void addRobot(MyRobot robot)
        {
            lock (robots)
            {
                robots.Add(robot);
            }
        }
        public int getmoney()
        {
            return allmoney;
        }
        public List<Modification> getmods()
        {
            return modifications;
        }
        public List<Modification> startMods()
        {
            Random rand = new Random();
            int countHead = rand.Next(3, 10);
            int countBody = rand.Next(3, 10);
            int countArm = rand.Next(3, 10);
            int countModHead = rand.Next(3, 10);
            int countModBody = rand.Next(3, 10);
            int countModArm = rand.Next(3, 10);
            for (int i = 0; i < countHead; i++)
            {
                lock (modifications)
                {
                    modifications.Add(new Modification
                    {
                        name = $"Head{i}",
                        count = countHead,
                        cost = rand.Next(200),
                        type = 1
                    });
                }
            }
            for (int i = 0; i < countBody; i++)
            {
                lock (modifications)
                {
                    modifications.Add(new Modification
                    {
                        name = $"Body{i}",
                        count = countBody,
                        cost = rand.Next(200),
                        type = 2
                    });
                }
            }
            for (int i = 0; i < countArm; i++)
            {
                lock (modifications)
                {
                    modifications.Add(new Modification
                    {
                        name = $"Arm{i}",
                        count = countArm,
                        cost = rand.Next(200),
                        type = 3
                    });
                }
            }
            for (int i = 0; i < countModBody; i++)
            {
                lock (modifications)
                {
                    modifications.Add(new Modification
                    {
                        name = $"BodyMod{i}",
                        count = countModBody,
                        cost = rand.Next(200),
                        type = 4
                    });
                }
            }
            for (int i = 0; i < countModArm; i++)
            {
                lock (modifications)
                {
                    modifications.Add(new Modification
                    {
                        name = $"ArmMod{i}",
                        count = countModBody,
                        cost = rand.Next(200),
                        type = 5
                    });
                }
            }
            return modifications;
        }
    }

    public class Modification
    {
        public string name { get; set; }
        public int count { get; set; }
        public int used { get; set; }
        public int cost { get; set; }
        public int type { get; set; }
        //type 1 - head 2 - body - 3 - arm and modules
    }
    public class MyRobot
    {
        public string name { get; set; }
        public int body { get; set; }
        public int head { get; set; }
        public int bodymod1 { get; set; }
        public int bodymod2 { get; set; }
        public int arm { get; set; }
        public int cost { get; set; }

    }
}