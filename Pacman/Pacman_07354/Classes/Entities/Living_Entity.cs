using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public abstract class Living_Entity : Abstract_Entity
    {
        private Direction current_Direction;
        public Direction Current_Direction { get => current_Direction; set => current_Direction = value; }

        protected Living_Entity(int row, int column, int score) : base(row, column, score, Color.Yellow)
        {
            this.current_Direction = Direction.NONE;
        }
        public abstract void Move();
        public abstract bool CanPassThrough(Abstract_Entity entity);

        public abstract void Eat(Abstract_Entity entity);
        public abstract bool CanEat(Abstract_Entity entity);
        public Point GetVelocity()
        {
            Point velocity = new Point(0, 0);

            switch (this.current_Direction)
            {
                case Direction.UP:
                    velocity = new Point(0, -1);
                    break;
                case Direction.DOWN:
                    velocity = new Point(0, 1);
                    break;
                case Direction.LEFT:
                    velocity = new Point(-1, 0);
                    break;
                case Direction.RIGHT:
                    velocity = new Point(1, 0);
                    break;
                default:
                    velocity = new Point(0, 0);
                    break;
            }
            return velocity;
        }
        
    }
}
