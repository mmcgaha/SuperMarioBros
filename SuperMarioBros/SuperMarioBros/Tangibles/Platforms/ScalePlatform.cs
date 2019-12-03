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
    public class ScalePlatform : IBlock
    {
        public ITangibleState State { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public bool IsActive { get; set; }
        public int SequenceCounter { get; set; }

        public ScalePlatform partner;

        public ScalePlatform(int width, int x = 0, int y = 0, int ymin = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.PLATFORM_OFFSET_X, Hitboxes.PLATFORM_OFFSET_Y);
            this.State = new SScalePlatformIdle(this, width, ymin);
            this.Sprite = new PlatformAnimation(Textures.platform, width);
            this.IsActive = true;
            this.CollisionHandler = new ScalePlatformCollisionHandler(this);
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

        public void SetPartner(ScalePlatform partner)
        {
            this.partner = partner;
        }
    }
}
