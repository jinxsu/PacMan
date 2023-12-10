using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.IO;

namespace Pacman.Classes.Entities
{
    public static class Map
    {
        public static int Tile_Size = 25;
        public static Color BackColor = Color.Black;
        public static Color WallColor = Color.Aquamarine;
        public static string Path = "../../Classes/Ressources/";
        public static string Map_File = "Map.txt";



        public static Abstract_entities[,] abstract_Entities = null;
        public static List<GhostRoom> ghost_room=new List<GhostRoom>();
        public static List<EmptyTile> empty_tile=new List<EmptyTile>();
        public static int Max_Rows = 10;
        public static int Max_Columns = 10;

        public static int Count_Eatable_entity=0;



        public static void LoadData()
        {
            string[] lines = File.ReadAllLines(Map.Path + Map.Map_File);



            Map.Max_Rows = lines.Length;
            Map.Max_Columns = lines[0].Length;
            Map.abstract_Entities = new Abstract_entities[Map.Max_Rows, Map.Max_Columns];



            int row = 0;
            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                int column = 0;
                foreach (char character in chars)
                {
                    Abstract_entities obj = null;
                    switch (character)
                    {
                        case 'W'://Create a wall
                            obj = new Wall(row, column);
                            break;
                        case 'D'://Create a Dot
                            obj = new Dot(row, column);
                            Count_Eatable_entity++;
                            break;
                        case 'B'://Create a Booster
                            obj = new Booster(row, column);
                            Count_Eatable_entity++;
                            break;
                        case 'R'://Create a Ghost Room
                            obj = new GhostRoom(row, column);
                            ghost_room.Add(obj as GhostRoom);
                            break;
                        case 'F'://Create a Fruit
                            obj = new Fruit(row, column);
                            Count_Eatable_entity++;
                            break;
                        case 'T'://Create an Empty tile
                            obj = new EmptyTile(row, column);
                            empty_tile.Add(obj as EmptyTile);
                            break;
                        default:
                            obj = new EmptyTile(row, column);
                            empty_tile.Add(obj as EmptyTile);
                            break;
                    }
                    Map.abstract_Entities[row, column] = obj;
                    column++;
                }//End of chars array
                row++;
            }
        }
        public static bool Is_Valid_Tile(int row, int column)
        {
            int max_rows = Map.abstract_Entities.GetUpperBound(0);//rows
            int max_cols = Map.abstract_Entities.GetUpperBound(1);//columns
            //Check if the indexes are valid
            if (row >= 0 && column >= 0 && row < max_rows && column < max_cols)
            {
                Abstract_entities obj = Map.abstract_Entities[row, column];
                //return true, if the obj is not a wall
                return !(obj is Wall);
            }
            return false;
        }


    }
}
