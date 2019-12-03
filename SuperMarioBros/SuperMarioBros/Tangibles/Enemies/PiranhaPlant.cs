﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class PiranhaPlant : IEnemy
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

        public PiranhaPlant(int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.PIRANHA_PLANT_OFFSET_X, Hitboxes.PIRANHA_PLANT_OFFSET_Y);
            this.State = new SPiranhaPlantWaiting(this);
            this.Sprite = new Animation(Textures.piranhaPlantGreen, 2, 11);
            this.IsActive = true;
            this.CollisionHandler = new PiranhaPlantCollisionHandler(this);
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera) {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
