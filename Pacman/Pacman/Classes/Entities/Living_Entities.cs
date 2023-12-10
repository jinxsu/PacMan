using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Pacman.Classes.Entities
{
    public abstract class Living_Entities : Abstract_entities
    {
        private Direction currentDirection;
        public Direction CurrentDirection { get => currentDirection; set => currentDirection = value; }

        protected Living_Entities(int row, int column, int score ) : base(row, column, 0, Color.Black)
        {
            this.currentDirection = Direction.NONE;
        
        }

        

        public abstract void Move();
        public abstract bool PassThrough(Abstract_entities entity);
        public abstract void Eat(Abstract_entities entity);
        public abstract bool Eatable(Abstract_entities entity);
        public  Point GetVelocity()
        {
            Point velocity = new Point(0, 0);

            switch(this.currentDirection)
            {
                case Direction.UP:
                       velocity=new Point(0, -1);
                    break;
                case Direction.DOWN:
                    velocity=new Point(0, 1);
                    break;
                case Direction.LEFT:
                    velocity=new Point(-1, 0);
                    break;
                case Direction.RIGHT:
                    velocity=new Point(1, 0);
                    break;
                default:
                    velocity=new Point(0, 0);
                    break;

            }
            return velocity;
        }


    }
}
