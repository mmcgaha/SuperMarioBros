﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBros
{
    public class SVineSpawnerInBlock : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }

        public SVineSpawnerInBlock(IPowerUp powerup)
        {
            this.Powerup = powerup;
            Powerup.Sprite = new Animation(Textures.blockHidden);

            Powerup.Hitbox.Clear();
            SetHitbox();

            Powerup.Acceleration = Vector2.Zero;
            Powerup.Velocity = Vector2.Zero;
        }
        public void  Update()
        {
            Powerup.Hitbox.Cycle();
            SetHitbox();
        }

        public void Spawn()
        {
            Vine v = ((VineSpawner)Powerup).vine;
            v.Position = new Vector2(Powerup.Position.X, Powerup.Position.Y - v.Hitbox.Height());
            Powerup.IsActive = false;

            SoundPanel.PlaySoundEffect(Sound.vineEffect);
        }

        private void SetHitbox()
        {
            Powerup.Hitbox.AddRectHitbox(
                    (int)Powerup.Position.X,
                    (int)Powerup.Position.Y,
                    0,
                    0
                );
        }
    }
}
