using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman_07354.Classes.Behaviors;
//using Pacman_Game.Classes.Pathfinding;
using Pacman_07354.Classes.Djikstra;

namespace Pacman_07354.Classes.Entities
{
    public class Ghost : Living_Entity
    {
        private static string[,] image_Files = {{ "Blue_Ghost_None.png" , "Blue_Ghost_Up.png"  , "Blue_Ghost_Down.png", "Blue_Ghost_Left.png", "Blue_Ghost_Right.png"} ,
                                                { "Orange_Ghost_None.png" , "Orange_Ghost_Up.png"  , "Orange_Ghost_Down.png", "Orange_Ghost_Left.png", "Orange_Ghost_Right.png"},
                                                { "Pink_Ghost_None.png" , "Pink_Ghost_Up.png"  , "Pink_Ghost_Down.png", "Pink_Ghost_Left.png", "Pink_Ghost_Right.png"},
                                                { "Red_Ghost_None.png" , "Red_Ghost_Up.png"  , "Red_Ghost_Down.png", "Red_Ghost_Left.png", "Red_Ghost_Right.png"},
                                                { "Scared_Ghost_None.png" , "Scared_Ghost_Up.png"  , "Scared_Ghost_Down.png", "Scared_Ghost_Left.png", "Scared_Ghost_Right.png"},
                                                { "Dead_Ghost_None.png" , "Dead_Ghost_Up.png"  , "Dead_Ghost_Down.png", "Dead_Ghost_Left.png", "Dead_Ghost_Right.png"}
                                                };

        private readonly IBehavior default_Behavior;
        private IBehavior current_Behavior;

        private Ghost_Color myColor;
        private List<Node> path;

        public IBehavior Current_Behavior { get => current_Behavior; set => current_Behavior = value; }
        public List<Node> Path { get => path; set => path = value; }

        public IBehavior Default_Behavior => default_Behavior;

        public Ghost(int row, int column, Ghost_Color color, IBehavior behavior) : base(row, column, 200)
        {
            this.myColor = color;
            this.default_Behavior = behavior;
            this.current_Behavior = behavior;
            this.path = new List<Node>();
            switch (color)
            {
                case Ghost_Color.BLUE:
                    base.Entity_Color = Color.Blue;
                    break;
                case Ghost_Color.RED:
                    base.Entity_Color = Color.Red;
                    break;
                case Ghost_Color.PINK:
                    base.Entity_Color = Color.Pink;
                    break;
                case Ghost_Color.ORANGE:
                    base.Entity_Color = Color.Orange;
                    break;
            }
            
        }
        public void Subscribe(Pacman player)
        {
            player.Pacman_Boosted += this.Set_Scared_Behavior;
            player.Pacman_Normal  += this.Reset_Behavior;
            player.Ghost_Dead     += this.Set_Dead_Behavior;

            if (this.default_Behavior is Chase_Behavior)
            {
                player.Pacman_Moved += this.Update_Path;
            }         
        }
        public void Update_Path()
        {
            this.path = this.current_Behavior.Find_Path(this);
            this.path.RemoveAt(0);//remove the start node from the solution of A*
        }
        public void Reset_Behavior()
        { 
            //When Pacaman becomes Normal : update path only for scared ghosts
            if(this.current_Behavior is Scared_Behavior)
            {
                this.current_Behavior = default_Behavior;
                this.Update_Path();
            }
            else // Dead Behavior
            {
                this.current_Behavior = default_Behavior;
            }
        }
        public void Set_Scared_Behavior()
        {
            this.current_Behavior = Scared_Behavior.GetInstance();
            //Recalcualte the path to hide from Pacman
            this.Update_Path();
        }
        public void Set_Dead_Behavior()
        {
            this.current_Behavior = Dead_Behavior.GetInstance();
        }
        public void Draw_Path(Graphics g)
        {
            for(int i=0; i< this.path.Count-1; i++)
            {
                Node start_node = this.path[i];
                Node end_node = this.path[i + 1];

                int start_pointX = (start_node.Column * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;
                int start_pointY = (start_node.Row * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;

                int end_pointX = (end_node.Column * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;
                int end_pointY = (end_node.Row * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;

                Point start_Point = new Point(start_pointX, start_pointY);
                Point end_Point = new Point(end_pointX, end_pointY);

                 Pen myPen = new Pen(base.Entity_Color, 5);
                 g.DrawLine(myPen, start_Point, end_Point);
                 myPen.Dispose();
            }
        }
        public override void Draw(Graphics g)
        {
            //Draw the background
            base.Draw_Background(g);

            int index_row = (int)this.myColor;
            if(this.current_Behavior is Scared_Behavior)
            {
                index_row = 4;
            }else
            if(this.current_Behavior is Dead_Behavior)
            {
                index_row = 5;
            }
            //Pick a picture from the array according to current direction
            int index_column = (int)base.Current_Direction;
            
            string myFileName = image_Files[index_row , index_column];
            Rectangle myRectangle = base.GetRectangle();

            using (Image myImage = Image.FromFile(Map.Path + myFileName))
            {
                g.DrawImage(myImage, myRectangle);
            }
        }
        public override bool CanPassThrough(Abstract_Entity entity)
        {
            return !(entity is Wall);
        }
        public override void Move()
        {
            if(this.path.Count > 0)
            {
                Node next_Node = this.path[0];
                this.path.RemoveAt(0);
                this.Current_Direction = this.Next_Direction(next_Node);
                this.Row = next_Node.Row;
                this.Column = next_Node.Column;
            }
            else
            {
                this.Update_Path();
            }
        }

        public Direction Next_Direction(Node next)
        {
            if(this.Row == next.Row && this.Column == next.Column)
            {
                return Direction.NONE;
            }
            else
            {
                if(this.Row == next.Row)
                {
                    return (this.Column > next.Column) ? Direction.LEFT : Direction.RIGHT;
                }
                else// they have the same column
                {
                    return (this.Row > next.Row) ? Direction.UP : Direction.DOWN;
                }
            }
        }
        public override void Eat(Abstract_Entity entity)
        {
            if (entity is Pacman)
            {
                if ( (entity as Pacman).Lives > 0 )
                {
                    (entity as Pacman).Lives--;
                    Game_Manager.Restart_Game();
                }
                else
                {
                    Game_Manager.Game_Over();
                }
            }
        }

        public override bool CanEat(Abstract_Entity entity)
        {
            return (entity is Pacman) && (this.current_Behavior == this.default_Behavior);
        }
    }
}
