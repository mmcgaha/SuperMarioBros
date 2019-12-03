﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    class SBuzzyBeetleShellMovingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SBuzzyBeetleShellMovingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.buzzyBeetleInShell);

            Enemy.Hitbox.SetOffset(Hitboxes.BUZZYBEETLE_SHELL_OFFSET_X, Hitboxes.BUZZYBEETLE_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(-2.5f, 0);
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
                    Hitboxes.BUZZYBEETLE_SHELL_WIDTH,
                    Hitboxes.BUZZYBEETLE_SHELL_HEIGHT
                );
        }
    }
}

