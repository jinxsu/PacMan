using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Entities
{
    public class RNG:Random
    { 

        //Singleton Design Pattern
        private static RNG Instance;
        private RNG() : base() { }
        

        public static RNG Get_Instance()
        {
            if(Instance == null)
            {
                Instance = new RNG();
            }
            return Instance;
        }
       
    }
}
