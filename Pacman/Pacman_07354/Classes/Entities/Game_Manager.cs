using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman_07354.Classes.Behaviors;

namespace Pacman_07354.Classes.Entities
{
   
    public static class Game_Manager
    {
        public static bool IsGameOver   = false;
        public static bool IsGameWinner = false;

        public static Pacman Player = null;
        public static List<Ghost> Ghost_List;

        public static void Start_Game()
        {
            Game_Manager.IsGameOver = false;
            Game_Manager.IsGameWinner = false;

            Map.Load_Data();
            Game_Manager.Player = new Pacman(Map.Max_Rows - 2, Map.Max_Columns - 2);
            Game_Manager.Ghost_List = new List<Ghost>();

            for (int i=0; i< 4; i++)
            {
                Ghost_Room random_room = null;
                do
                {
                    int random_index = RNG.GetInstance().Next(0, Map.Ghost_Room_List.Count);
                    random_room = Map.Ghost_Room_List[random_index];

                } while (! random_room.IsEmpty);

                IBehavior behavior = Random_Behavior.GetInstance();

                if ((Ghost_Color)i == Ghost_Color.RED)
                {
                    behavior = Chase_Behavior.GetInstance();
                }else
                if((Ghost_Color)i == Ghost_Color.BLUE)
                {
                    behavior = Follow_Behavior.GetInstance();
                }
                Ghost obj = new Ghost(random_room.Row, random_room.Column, (Ghost_Color)i, behavior);
                random_room.IsEmpty = false;

                Game_Manager.Ghost_List.Add(obj);
                obj.Subscribe(Game_Manager.Player);
            }
        }
        public static void Restart_Game()
        {
            //Reset Location of Pacman
            Game_Manager.Player.Row = Map.Max_Rows - 2;
            Game_Manager.Player.Column = Map.Max_Columns - 2;
            Game_Manager.Player.Current_Direction = Direction.NONE;

            //Reset the status of Ghost Rooms
            foreach(Ghost_Room obj in Map.Ghost_Room_List)
            {
                obj.IsEmpty = true;
            }
            //Reset Location of Ghosts
            foreach(Ghost obj in Game_Manager.Ghost_List)
            {
                Ghost_Room random_room;
                do
                {
                    int random_index = RNG.GetInstance().Next(0, Map.Ghost_Room_List.Count);
                    random_room = Map.Ghost_Room_List[random_index];

                } while (! random_room.IsEmpty);

                random_room.IsEmpty = false;
                obj.Row = random_room.Row;
                obj.Column = random_room.Column;
                obj.Update_Path();
            }
        }
        public static void Game_Over()
        {
            if (!Game_Manager.IsGameOver)
            {
                Game_Manager.IsGameOver = true;
                Form_Exit form = new Form_Exit("Game Over");
                form.Show();
            }
        }
        public static void Game_Winner()
        {
            if (!Game_Manager.IsGameWinner)
            {
                Game_Manager.IsGameWinner = true;
                Form_Exit form = new Form_Exit("You Win !");
                form.Show();
            }          
        }
    }
}
