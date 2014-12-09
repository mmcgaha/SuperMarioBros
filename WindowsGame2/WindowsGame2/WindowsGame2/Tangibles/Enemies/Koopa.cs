﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Koopa: IEnemy
    {
        public IAnimatedSprite Sprite {get; set;}
        public ITangibleState State { get; set; }
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        public Koopa(int x = 0, int y = 0) {
            this.SequenceCounter = 0;
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Physics.GRAVITY;
            this.Hitbox = new Hitbox(Hitboxes.KOOPA_OFFSET_X, Hitboxes.KOOPA_OFFSET_Y);
            this.State = new SKoopaWalkingLeft(this);
            this.Sprite = new SettingDependentAnimation(Textures.koopaLeftWalking, 2, 10);
            this.IsActive = true;
            this.CollisionHandler = new KoopaCollisionHandler(this);
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            Sprite.Update();
            State.Update();
            if (Velocity.Y > Physics.TERMINAL_VELOCITY_FALLING)
            {
                Velocity = new Vector2(Velocity.X, Physics.TERMINAL_VELOCITY_FALLING);
            }
        }

        public void Draw(SpriteBatch sb, Rectangle camera) {
            if (State is SKoopaWalkingLeft || State is SKoopaWalkingRight || State is SKoopaBouncingRight || State is SKoopaBouncingLeft)
            {
                Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
            }
            else
            {
                Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y + 16);
            }
        }
    }
}
