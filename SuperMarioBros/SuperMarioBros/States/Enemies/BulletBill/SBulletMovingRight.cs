﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    class SBulletMovingRight : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SBulletMovingRight(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.bulletBillRight);

            Enemy.Hitbox.SetOffset(Hitboxes.BULLETBILL_OFFSET_X, Hitboxes.BULLETBILL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(2f, 0);
           
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
                    Hitboxes.BULLETBILL_WIDTH,
                    Hitboxes.BULLETBILL_HEIGHT
                );
        }
    }
}

