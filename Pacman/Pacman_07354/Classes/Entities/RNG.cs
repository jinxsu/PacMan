using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class RNG : Random
    {
        //Singleton Design Pattern
        private static RNG instance = null;
        private RNG() : base() { }

        public static RNG GetInstance()
        {
            if(instance == null)
            {
                instance = new RNG();
            }
            return instance;
        }
    }
}
