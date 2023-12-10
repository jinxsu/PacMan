using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman_07354.Classes.States;
using Pacman_07354.Classes.Behaviors;

using System.Windows.Forms;
namespace Pacman_07354.Classes.Entities
{
    public class Pacman : Living_Entity
    {
        public event Update_Ghost_Behaviors Pacman_Moved;
        public event Update_Ghost_Behaviors Pacman_Boosted;
        public event Update_Ghost_Behaviors Pacman_Normal;
        public event Update_Ghost_Behaviors Ghost_Dead;
        
        private static string[] imageFiles = { "Pacman_None.png","Pacman_Up.png", "Pacman_Down.png","Pacman_Left.png", "Pacman_Right.png"};
        private const int BOOST_DURATION = 10;//10 seconds
        private DateTime start_Boost_Time;

        private IState current_State;
        private int lives;

        public int Lives { get => lives; set => lives = value; }

        public Pacman(int row, int column) : base(row, column, 0)
        {
            this.current_State = Normal_State.GetInstance();
            this.lives = 3;
        }
        
        public void Subscribe(Ghost ghost)
        {
            this.Pacman_Boosted += ghost.Set_Scared_Behavior;
            this.Pacman_Normal += ghost.Reset_Behavior;
            this.Ghost_Dead += ghost.Set_Dead_Behavior;

            if (ghost.Default_Behavior is Chase_Behavior)
            {
                this.Pacman_Moved += ghost.Update_Path;
            }
        }
        public override void Draw(Graphics g)
        {
            //Draw the background
            base.Draw_Background(g);

            Rectangle myRectangle = base.GetRectangle();
          
            //Pick a picture from the array according to current direction
            int index = (int)base.Current_Direction;
            string myFileName = imageFiles[index];

            using (Image myImage = Image.FromFile(Map.Path + myFileName))
            {
                g.DrawImage(myImage, myRectangle);
            }
        }

        public override void Move()
        {
            Point velocity = this.GetVelocity();

            int next_Row = this.Row + velocity.Y;
            int next_Column = this.Column + velocity.X;
            Abstract_Entity obj = Map.Array_Entities[next_Row, next_Column];

            if (this.CanPassThrough(obj))
            {
                this.Row = next_Row;
                this.Column = next_Column;

                if(this.Pacman_Moved != null)
                {
                    this.Pacman_Moved.Invoke();
                }

                if (this.CanEat(obj))
                {
                    this.Eat(obj);
                }
            }
            
        }
        public override bool CanPassThrough(Abstract_Entity entity)
        {
            return !(entity is Wall) && !(entity is Ghost_Room);
        }

        public void Eat_Ghost(Ghost ghost)
        {
            if(this.Ghost_Dead != null)
            {
                //Notify the ghost by Event
                int index = Game_Manager.Ghost_List.IndexOf(ghost);
                this.Ghost_Dead.GetInvocationList().ElementAt(index).DynamicInvoke();
            }        
        }
        public override void Eat(Abstract_Entity entity)
        {
            this.Score += entity.Score;
            Empty_Tile obj = new Empty_Tile(entity.Row, entity.Column);
            Map.Array_Entities[entity.Row, entity.Column] = obj;
            Map.Empty_Tiles_List.Add(obj);

            Map.Count_Eatable_Entities--;
            if(Map.Count_Eatable_Entities == 0)
            {
                MessageBox.Show("You Win !");
            }
            if (entity is Booster)
            {
                this.current_State = Super_State.GetInstance();
                this.start_Boost_Time = DateTime.Now;
                //Notify Ghosts with an Event
                if(this.Pacman_Boosted != null)
                {
                    this.Pacman_Boosted.Invoke();
                }
            }
        }

        public override bool CanEat(Abstract_Entity entity)
        {
            return !(entity is Tile);
        }
        public bool Is_Boost_TimeOut()
        {
            if(DateTime.Now.Subtract(this.start_Boost_Time).Seconds >= BOOST_DURATION)
            {
                return true;
            }
            return false;
        }
        public void Check_Boost_Time()
        {
            if(this.current_State is Super_State)
            {
                if (this.Is_Boost_TimeOut())
                {
                    this.current_State = Normal_State.GetInstance();
                    //Notify the ghosts with Events
                    if(this.Pacman_Normal != null)
                    {
                        this.Pacman_Normal.Invoke();
                    }
                }
            }
        }

        public void Check_Ghost_Collision()
        {
            foreach(Ghost obj in Game_Manager.Ghost_List)
            {
                if(base.Row == obj.Row && base.Column == obj.Column)
                {
                    this.current_State.Ghost_Collision(obj, this);
                }
            }
        }
    }
}
