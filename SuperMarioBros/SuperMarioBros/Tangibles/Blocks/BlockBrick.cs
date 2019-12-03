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
    public class BlockBrick : IBlock, IContainer
    {
        public ITangibleState State { get; set; }
        public IPowerUp[] Contains { get; set; }
        public bool IsActive { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        public BlockBrick(IPowerUp[] contains, int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.BLOCK_OFFSET_X, Hitboxes.BLOCK_OFFSET_Y);
            this.State = new SBlockIdle(this);
            this.Sprite = new SettingDependentAnimation(Textures.blockBrick);
            this.IsActive = true;
            this.Contains = contains;
            this.CollisionHandler = new BrickBlockCollisionHandler(this);
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

        public void Empty(IPlayer player)
        {
            if (Contains != null && Contains.Length > 0)
            {
                int i = player.State is ISmallMarioState || Contains.Length < 2 ? 0 : 1;
                ((IPowerUpState)Contains[i].State).Spawn();
            }
        }
    }
}
