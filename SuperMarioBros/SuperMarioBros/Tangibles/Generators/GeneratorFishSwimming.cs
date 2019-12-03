﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class GeneratorFishSwimming : IEnemy
    {
        public IAnimatedSprite Sprite { get; set; }
        public ITangibleState State { get; set; }
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        private Random rand;
        private int xEnd, xStart, counter, spawn;

        public GeneratorFishSwimming(int xStart = 0, int xEnd = 0)
        {
            this.xEnd = xEnd;
            this.xStart = xStart;
            this.Position = HUD.level.player.Position;
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(0, 0);
            this.State = new SGeneratorIdle(this);
            this.Sprite = new Animation(Textures.mushroomPointer);
            this.IsActive = true;
            this.CollisionHandler = new EmptyCollisionHandler();
            this.rand = new Random();
            this.counter = 0;
            this.spawn = rand.Next(100, 300);
        }

        public void Update()
        {
            counter++;
            State.Update();
            Position = HUD.level.player.Position;

            if (Position.X > xEnd)
            {
                this.IsActive = false;
            }
            if (counter == spawn)
            {
                counter = 0;
                if (Position.X > xStart)
                {
                    spawn = rand.Next(100, 300);
                    int y = rand.Next(14);

                    int x = HUD.level.camera.Viewport.X;
                    HUD.level.AddDynamicObject(new CheepCheepWater(x + HotDAMN.WINDOW_WIDTH, 16 * (y + 2)));
                }
            }
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            //Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
