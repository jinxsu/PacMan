﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class Fruit : Abstract_Entity
    {
        private static string[] imageFiles = { "Fruit_Apple.png" , "Fruit_Cherry.png" , "Fruit_Strawberry.png" };
        private string myFileName;
        public Fruit(int row, int column) : base(row, column, 150, Color.Red)
        {
            int index = RNG.GetInstance().Next(0, imageFiles.Length);
            this.myFileName = imageFiles[index];
        }

        public override void Draw(Graphics g)
        {
            //Draw the background
            base.Draw_Background(g);

            Rectangle myRectangle = base.GetRectangle();
            
            using (Image myImage = Image.FromFile(Map.Path + this.myFileName))
            {
                g.DrawImage(myImage, myRectangle);
            }
                
        }
    }
}
