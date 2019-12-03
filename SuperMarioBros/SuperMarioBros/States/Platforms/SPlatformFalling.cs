﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBros
{
    public class SPlatformFalling : IBlockState
    {
        public IBlock Block { get; set; }
        private int width;

        public SPlatformFalling(IBlock block, int width)
        {
            this.Block = block;
            this.width = width;

            Block.Hitbox.Clear();
            SetHitbox();

            Block.Acceleration = Physics.GRAVITY / 4;
            Block.Velocity = Vector2.Zero;
        }

        public void Update()
        {
            Block.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.PLATFORM_WIDTH * width,
                    Hitboxes.PLATFORM_HEIGHT
                );
        }
    }
}
