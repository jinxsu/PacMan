using Pacman.Classes.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Entities
{
    public static class GameManager
    {
        public static bool IsGameOver = false;
        public static bool IsGameWinner = false;

        public static Pacman Player = null;
        public static List<Ghost> Ghost_List;

        public static void StartGame()
        {
            GameManager.IsGameOver = false;
            GameManager.IsGameWinner = false;

            Map.LoadData();
            GameManager.Player=new Pacman(Map.Max_Rows-2,Map.Max_Columns-2);
            GameManager.Ghost_List=new List<Ghost>();

            for (int i = 0; i < 4; i++)
            {
                GhostRoom random_room = null;
                do
                {
                    int random_index = RNG.Get_Instance().Next(0, Map.ghost_room.Count);
                    random_room = Map.ghost_room[random_index];

                } while (!random_room.IsEmpty);

                IBehaviour behavior = Behaviours.Random.GetInstance();

                if ((GhostColor)i == GhostColor.RED)
                {
                    behavior = Chase.GetInstance();
                }
                else
                if ((GhostColor)i == GhostColor.BLUE)
                {
                    behavior = Follow.GetInstance();
                }
                Ghost obj = new Ghost(random_room.Row, random_room.Column, (GhostColor)i, behavior);
                random_room.IsEmpty = false;

                GameManager.Ghost_List.Add(obj);
                obj.Subscribe(GameManager.Player);
            }
        }
        public static void Restart_Game()
        {
            //Reset Location of Pacman
            GameManager.Player.Row = Map.Max_Rows - 2;
            GameManager.Player.Column = Map.Max_Columns - 2;
            GameManager.Player.CurrentDirection = Direction.NONE;

            //Reset the status of Ghost Rooms
            foreach (GhostRoom obj in Map.ghost_room)
            {
                obj.IsEmpty = true;
            }
            //Reset Location of Ghosts
            foreach (Ghost obj in GameManager.Ghost_List)
            {
                GhostRoom random_room;
                do
                {
                    int random_index = RNG.Get_Instance().Next(0, Map.ghost_room.Count);
                    random_room = Map.ghost_room[random_index];

                } while (!random_room.IsEmpty);

                random_room.IsEmpty = false;
                obj.Row = random_room.Row;
                obj.Column = random_room.Column;
                obj.Update_Path();
            }
        }
        public static void Game_Over()
        {
            if (!GameManager.IsGameOver)
            {
                GameManager.IsGameOver = true;
                Form_Exit form = new Form_Exit("Game Over");
                form.Show();
            }
        }
        public static void Game_Winner()
        {
            if (!GameManager.IsGameWinner)
            {
                GameManager.IsGameWinner = true;
                Form_Exit form = new Form_Exit("You Win !");
                form.Show();
            }
        }
    }
}

