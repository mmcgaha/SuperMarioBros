﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class SKoopaWalkingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SKoopaWalkingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.koopaLeftWalking, 2, 10);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_OFFSET_X, Hitboxes.KOOPA_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(-0.55f, 0);
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
