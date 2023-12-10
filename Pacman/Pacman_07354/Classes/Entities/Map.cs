using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Pacman_07354.Classes.Entities
{
    public static class Map
    {
        public static readonly int Tile_Size = 25;
        public static Color BackColor = Color.Black;
        public static Color WallColor = Color.Aquamarine;
        public static string Path = "../../Classes/Resources/";
        public static string Map_File = "Map.txt";
        public static Abstract_Entity[,] Array_Entities = null;
        public static List<Ghost_Room> Ghost_Room_List = new List<Ghost_Room>();
        public static List<Empty_Tile> Empty_Tiles_List = new List<Empty_Tile>();

        public static int Count_Eatable_Entities = 0;

        public static int Max_Rows = 10;
        public static int Max_Columns = 10;
        public static void Load_Data()
        {
            string[] lines = File.ReadAllLines(Map.Path + Map.Map_File);

            Map.Max_Rows = lines.Length;
            Map.Max_Columns = lines[0].ToCharArray().Length;
            Map.Array_Entities = new Abstract_Entity[Map.Max_Rows , Map.Max_Columns];

            int row = 0;
            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                int column = 0;
                foreach (char character in chars)
                {
                    Abstract_Entity obj;
                    switch (character)
                    {
                        case 'W'://Create a Wall
                            obj = new Wall(row, column);
                            break;
                        case 'D'://Create a Dot
                            obj = new Dot(row, column);
                            Count_Eatable_Entities++;
                            break;
                        case 'B': //Create a Booster
                            obj = new Booster(row, column);
                            Count_Eatable_Entities++;
                            break;
                        case 'F'://Create a Fruit
                            obj = new Fruit(row, column);
                            Count_Eatable_Entities++;
                            break;
                        case 'R'://Create a ghost Room
                            obj = new Ghost_Room(row, column);
                            Ghost_Room_List.Add(obj as Ghost_Room);
                            break;
                        case 'T'://Empty Tile
                            obj = new Empty_Tile(row, column);
                            Empty_Tiles_List.Add(obj as Empty_Tile);
                            break;
                        default:
                            obj = new Empty_Tile(row, column);
                            Empty_Tiles_List.Add(obj as Empty_Tile);
                            break;
                    }
                    Map.Array_Entities[row, column] = obj;
                    column++;
                }//End of chars

                row++;
            }//End Lines
        }//End of Load

        public static bool Is_Valid_Tile(int row, int column)
        {
            int max_rows = Map.Array_Entities.GetUpperBound(0);//rows
            int max_cols = Map.Array_Entities.GetUpperBound(1);//columns
            //Check if the indexes are valid
            if(row>=0 && column >=0 && row< max_rows && column < max_cols)
            {
                Abstract_Entity obj = Map.Array_Entities[row, column];
                //return true, if the obj is not a wall
                return !(obj is Wall);
            }
            return false;
        }

    }
}
