﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBros
{
    public class EnemyPiranhaPlant : IEnemyAnimation
    {
        Texture2D texture;
        int rows;
        int cols;
        int frameCount;
        int curFrame;
        int totalFrames;
        int x;
        int y;
        bool leftFace;

        public EnemyPiranhaPlant(Texture2D texture, int rows, int cols, int x, int y)
        {
            this.texture = texture;
            this.Sprite = new SpriteMobileAnimated(texture, rows, cols, x, y);
            this.x = x;
            this.y = y;
            this.rows = rows;
            this.cols = cols;
            leftFace = false;
            curFrame = 0;
            totalFrames = rows * cols;
        }

        public void Update()
        {
            SpriteMobileAnimated(texture, rows, cols, x, y);
        }

        void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, this.x, this.y);
        }
    }
}
