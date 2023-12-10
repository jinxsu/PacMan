using Pacman.Classes.Behaviours;
using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.States
{
    public class Super_State : iState
    {
        private static int nbr_eaten_ghosts = 0;

        #region Singleton
        private static Super_State instance = null;
        private Super_State() { }
        public static Super_State GetInstance()
        {
            if (instance == null)
            {
                instance = new Super_State();
            }
            Super_State.nbr_eaten_ghosts = 0;

            return instance;
        }
        #endregion

        public bool Eatable(Ghost ghost)
        {
            return true;
        }

        public void Ghost_Collision(Ghost ghost, Entities.Pacman player)
        {
            if (!(ghost.CurrentBehaviour is Death))
            {
                //pacman eats the ghost
                nbr_eaten_ghosts++;
                player.Score += (nbr_eaten_ghosts * ghost.Score);

                //Update the behavior of ghost to Dead
                player.Eat_Ghost(ghost);
            }
        }
    }
}

