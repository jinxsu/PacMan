using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pacman.Classes.States;
using Pacman.Classes;
using System.Drawing.Text;
using System.Windows.Forms;
using Pacman.Classes.Behaviours;

namespace Pacman.Classes.Entities
{
    

    public class Pacman : Living_Entities
    {
        public event Update_Ghost_Behaviours Pacman_moved;
        public event Update_Ghost_Behaviours Pacman_boosted;
        public event Update_Ghost_Behaviours Pacman_normal;
        public event Update_Ghost_Behaviours Ghost_dead;


        private static string[] imageFile = { "Pacman_None.png", "Pacman_Up.png", "Pacman_Down.png", "Pacman_Left.png", "Pacman.Right.png" };
        private const int BOOST_DURATION = 10;
        private DateTime start_Boost_Time;


        private iState current_Behaviour;
        private int lives;

        public int Lives { get => lives; set => lives = value; }

        public Pacman(int row, int column) : base(row, column, 0)
        {
            current_Behaviour = Normal_State.Instance();
            this.lives = 3;

        }
        public void Subscribe(Ghost ghost)
        {
            this.Pacman_boosted += ghost.Set_Scared_Behavior;
            this.Pacman_normal += ghost.Reset_Behavior;
            this.Ghost_dead += ghost.Set_Dead_Behavior;

            if (ghost.DefaultBehaviour is Chase)
            {
                this.Pacman_moved += ghost.Update_Path;
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw_Background(graphics);
            Rectangle rectangle = base.GetRectangle();


            int index = (int)base.CurrentDirection;
            string myFileName = Pacman.imageFile[index];

            using (Image image = Image.FromFile(Map.Path + myFileName))
            {
                graphics.DrawImage(image, rectangle);
            }

        }
        public override void Move()
        {
            Point velocity = this.GetVelocity();
            int next_row = this.Row + velocity.Y;
            int next_column = this.Column + velocity.X;
            Abstract_entities obj = Map.abstract_Entities[next_column, next_row];
            if (this.PassThrough(obj))
            {
                this.Row = next_row;
                this.Column = next_column;

            }
            if (this.Pacman_moved != null)
            {
                this.Pacman_moved.Invoke();
            }
            if (this.Eatable(obj))
            {
                this.Eat(obj);
            }

        }
        public override bool PassThrough(Abstract_entities entity)
        {
            return !(entity is Wall) && !(entity is GhostRoom);
        }
        public void Eat_Ghost(Ghost ghost)
        {
            if (Ghost_dead!=null)
            {
                //Notify the ghost by Event
                int index = GameManager.Ghost_List.IndexOf(ghost);
                this.Ghost_dead.GetInvocationList().ElementAt(index).DynamicInvoke();
            }
        }
        public override void Eat(Abstract_entities entity)
        {
            this.Score += entity.Score;
            EmptyTile obj = new EmptyTile(entity.Row, entity.Column);
            Map.abstract_Entities[entity.Row, entity.Column] = obj;
            Map.empty_tile.Add(obj);

            Map.Count_Eatable_entity--;
            if (Map.Count_Eatable_entity == 0)
            {
                MessageBox.Show("You Win !");
            }
            if (entity is Booster)
            {
                this.current_Behaviour = Super_State.GetInstance();
                this.start_Boost_Time = DateTime.Now;
                //Notify Ghosts with an Event
                if (this.Pacman_boosted != null)
                {
                    this.Pacman_boosted.Invoke();
                }
            }
        }
        public override bool Eatable(Abstract_entities entity)
        {
            return !(entity is Tile);
        }
        public bool Is_Boost_Timeout()
        {
            if (DateTime.Now.Subtract(this.start_Boost_Time).Seconds >= BOOST_DURATION)
            {
                return true;
            }
            return false;
        }
        public void Check_Boost_Time()
        {
            if (this.current_Behaviour is Super_State)
            {
                if (this.Is_Boost_Timeout())
                {
                    this.current_Behaviour = Normal_State.Instance();
                    //Notify the ghosts with Events
                    //if we change state we should notify the ghost with events we should let the ghost know that 
                    //the pacman is ready to eat and chase and you can run after pacman
                    //depending on pacman behaviour, the ghost behaviour will be updated
                    if (this.Pacman_normal != null)
                    {
                        this.Pacman_normal.Invoke();
                    }
                }
            }
        }

        public void Check_Ghost_Collision()
        {
            foreach (Ghost obj in GameManager.Ghost_List)
            {
                if (base.Row == obj.Row && base.Column == obj.Column)
                {
                    this.current_Behaviour.Ghost_Collision(obj, this);
                }
            }
        }

    }
    
}


