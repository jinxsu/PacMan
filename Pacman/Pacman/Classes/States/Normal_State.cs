using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.States
{
    public class Normal_State : iState
    {
        #region Singleton
        private static Normal_State instance = null;
        private Normal_State() { }
        public static Normal_State Instance()
        {
            if(instance == null)
            {
                instance = new Normal_State();
            }
            return instance;
        }
        #endregion

        public bool Eatable(Ghost ghost)
        {
            return false;
        }

        public void Ghost_Collision(Ghost ghost, Entities.Pacman player)
        {
            ghost.Eat(player);
        }
    }
}
