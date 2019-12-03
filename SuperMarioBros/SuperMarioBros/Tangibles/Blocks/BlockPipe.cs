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
    // A brick block.
    public class BlockPipe : IBlock
    {
        public ITangibleState State { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public bool IsActive { get; set; }
        String Name { get; set; }
        public int SequenceCounter { get; set; }

        public BlockPipe(String name, int height, bool showtop, int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.BLOCK_OFFSET_X, Hitboxes.BLOCK_OFFSET_Y);
            this.State = new SPipeIdle(this, height);
            this.Sprite = new PipeAnimation(Textures.blockPipe, height, showtop);
            this.IsActive = true;
            this.CollisionHandler = new StaticBlockCollisionHandler(this);
            this.Name = name;
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            State.Update();
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
