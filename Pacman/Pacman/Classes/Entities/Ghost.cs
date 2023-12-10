using Pacman.Classes.Behaviours;
using Pacman.Classes.Dijkstra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;

namespace Pacman.Classes.Entities
{
    public class Ghost:Living_Entities
    {
        private static string[,] image_Files = 
        {
                                                { "Blue_Ghost_None.png" , "Blue_Ghost_Up.png"  , "Blue_Ghost_Down.png", "Blue_Ghost_Left.png", "Blue_Ghost_Right.png"} ,
                                                { "Orange_Ghost_None.png" , "Orange_Ghost_Up.png"  , "Orange_Ghost_Down.png", "Orange_Ghost_Left.png", "Orange_Ghost_Right.png"},
                                                { "Pink_Ghost_None.png" , "Pink_Ghost_Up.png"  , "Pink_Ghost_Down.png", "Pink_Ghost_Left.png", "Pink_Ghost_Right.png"},
                                                { "Red_Ghost_None.png" , "Red_Ghost_Up.png"  , "Red_Ghost_Down.png", "Red_Ghost_Left.png", "Red_Ghost_Right.png"},
                                                { "Scared_Ghost_None.png" , "Scared_Ghost_Up.png"  , "Scared_Ghost_Down.png", "Scared_Ghost_Left.png", "Scared_Ghost_Right.png"},
                                                { "Dead_Ghost_None.png" , "Dead_Ghost_Up.png"  , "Dead_Ghost_Down.png", "Dead_Ghost_Left.png", "Dead_Ghost_Right.png"} 
        };


        private readonly IBehaviour defaultBehaviour;
        private IBehaviour currentBehaviour;
        private GhostColor myColor;

        private List<Node> path;

        public IBehaviour CurrentBehaviour { get => currentBehaviour; set => currentBehaviour = value; }

        public IBehaviour DefaultBehaviour => defaultBehaviour;

        public List<Node> Path { get => path; set => path = value; }

        public Ghost(int row, int column, GhostColor color, IBehaviour behaviour):base(row, column, 200)
        {
           this.myColor = color;
           this.defaultBehaviour = behaviour;
           this.currentBehaviour = behaviour;
            this.Path = new List<Node>();
            switch (color)
            {
                case GhostColor.BLUE:
                    base.Entity_color = Color.Blue;
                    break;
                case GhostColor.PINK:
                    base.Entity_color = Color.Pink;
                    break;
                case GhostColor.RED:
                    base.Entity_color = Color.Red;
                    break;
                case GhostColor.ORANGE:
                    base.Entity_color= Color.Orange;
                    break;
                
            }
        }
        public void Subscribe(Pacman player)
        {

            player.Pacman_boosted += this.Set_Scared_Behavior;
            player.Pacman_normal += this.Reset_Behavior;
            player.Ghost_dead += this.Set_Dead_Behavior;

            if (this.defaultBehaviour is Chase)
            {
                player.Pacman_moved += this.Update_Path;
            }
        }
        public void Update_Path()
        {
            this.Path = this.currentBehaviour.Find_Path(this);
            this.Path.RemoveAt(0);//remove the start node from the solution of A*
        }
        public void Reset_Behavior()
        {
            //When Pacaman becomes Normal : update path only for scared ghosts
            if (this.currentBehaviour is Scared)
            {
                this.currentBehaviour = defaultBehaviour;
                this.Update_Path();
            }
            else // Dead Behavior
            {
                this.currentBehaviour =defaultBehaviour;
            }
        }
        public void Set_Scared_Behavior()
        {
            this.currentBehaviour = Scared.GetInstance();
            //Recalcualte the path to hide from Pacman
            this.Update_Path();
        }
        public void Set_Dead_Behavior()
        {
            this.currentBehaviour = Death.GetInstance();
        }
        public void Draw_Path(Graphics g)
        {
            for (int i = 0; i < this.Path.Count - 1; i++)
            {
                Node start_node = this.Path[i];
                Node end_node = this.Path[i + 1];

                int start_pointX = (start_node.Column * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;
                int start_pointY = (start_node.Row * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;

                int end_pointX = (end_node.Column * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;
                int end_pointY = (end_node.Row * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;

                Point start_Point = new Point(start_pointX, start_pointY);
                Point end_Point = new Point(end_pointX, end_pointY);

                Pen myPen = new Pen(base.Entity_color, 5);
                g.DrawLine(myPen, start_Point, end_Point);
                myPen.Dispose();
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw_Background(graphics);
            int index_row = (int)this.myColor;
            if(currentBehaviour is Scared)
            {
                index_row = 4;
            }
            else if(currentBehaviour is Death)
            {
                index_row = 5;

            }
            int index_column = (int)base.CurrentDirection;

            string myFileName = image_Files[index_row, index_column];
            Rectangle rectangle = base.GetRectangle();
            using (Image image = Image.FromFile(Map.Path + myFileName))
            {
                graphics.DrawImage(image, rectangle);
            }
        }
        public override bool PassThrough(Abstract_entities entity)
        {
            //check if the result is compatible with the given type
            return !(entity is Wall);
        }
        public override void Move()
        {
            if (this.Path.Count > 0)
            {
                Node next_Node = this.Path[0];
                this.Path.RemoveAt(0);
                this.CurrentDirection = this.Next_Direction(next_Node);
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
            if (this.Row == next.Row && this.Column == next.Column)
            {
                return Direction.NONE;
            }
            else
            {
                if (this.Row == next.Row)
                {
                    return (this.Column > next.Column) ? Direction.LEFT : Direction.RIGHT;
                }
                else// they have the same column
                {
                    return (this.Row > next.Row) ? Direction.UP : Direction.DOWN;
                }
            }
        }
        public override void Eat(Abstract_entities entity)
        {
            if (entity is Pacman)
            {
                if ((entity as Pacman).Lives > 0)
                {
                    (entity as Pacman).Lives--;
                    GameManager.Restart_Game();
                }
                else
                {
                    GameManager.Game_Over();
                }
            }
        }

        public override bool Eatable(Abstract_entities entity)
        {
            return (entity is Pacman) && (this.currentBehaviour == this.defaultBehaviour);
        }




    }
}
