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
    public class SSpinyMovingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SSpinyMovingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.spinyLeft, 2, 10);

            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(-0.75f, 0);
            Enemy.Acceleration = Physics.GRAVITY;
        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.SPINY_WIDTH,
                    Hitboxes.SPINY_HEIGHT
                );
        }
    }
}
