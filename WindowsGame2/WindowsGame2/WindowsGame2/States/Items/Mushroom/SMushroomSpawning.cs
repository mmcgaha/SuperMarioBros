﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class SMushroomSpawning : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }
        private int counter;

        public SMushroomSpawning(IPowerUp powerup)
        {
            this.counter = 0;
            this.Powerup = powerup;
            Powerup.Velocity = Vector2.Zero;
            SoundPanel.PlaySoundEffect(Sound.powerupappearsEffect);
        }

        public void  Update()
        {
            counter++;
            if (counter > HotDAMN.TICKS_UNTIL_POWERUP_APPEARS)
            {
                Powerup.Sprite = new Animation(Textures.powerupMushroom);
                Powerup.Velocity = new Vector2(0, -0.3f);
            }
            if (counter > HotDAMN.TICKS_UNTIL_POWERUP_MOVES)
            {
                Powerup.State = new SMushroomMovingRight(Powerup);
            }
        }

        public void Spawn() { }
    }
}
