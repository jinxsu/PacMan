using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman_07354.Classes.Entities;

namespace Pacman_07354.Classes.States
{
    public class Normal_State : IState
    {
        #region Singleton
        private static Normal_State instance = null;
        private Normal_State() { }
        public static Normal_State GetInstance()
        {
            if(instance == null)
            {
                instance = new Normal_State();
            }
            return instance;
        }
        #endregion
        public bool Can_Eat(Ghost ghost)
        {
            return false;
        }

        public void Ghost_Collision(Ghost ghost, Pacman player)
        {
            ghost.Eat(player);
        }
    }
}
