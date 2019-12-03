﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class SRedKoopaWalkingRight : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SRedKoopaWalkingRight(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.redKoopaRightWalking, 2, 10);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_OFFSET_X, Hitboxes.KOOPA_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(0.55f, 0);
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
                    Hitboxes.KOOPA_WIDTH,
                    Hitboxes.KOOPA_HEIGHT
                );
        }
    }
}
