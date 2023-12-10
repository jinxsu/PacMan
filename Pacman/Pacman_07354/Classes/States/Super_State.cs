using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman_07354.Classes.Entities;
using Pacman_07354.Classes.Behaviors;

namespace Pacman_07354.Classes.States
{
    public class Super_State : IState
    {
        private static int nbr_eaten_ghosts = 0;

        #region Singleton
        private static Super_State instance = null;
        private Super_State() { }
        public static Super_State GetInstance()
        { 
            if(instance == null)
            {
                instance = new Super_State();
            }
            Super_State.nbr_eaten_ghosts = 0;

            return instance;
        }
        #endregion
        
        public bool Can_Eat(Ghost ghost)
        {
            return true;
        }

        public void Ghost_Collision(Ghost ghost, Pacman player)
        {
            if (! (ghost.Current_Behavior is Dead_Behavior))
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
