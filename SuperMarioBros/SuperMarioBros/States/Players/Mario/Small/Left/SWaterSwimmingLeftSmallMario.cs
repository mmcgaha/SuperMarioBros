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
    public class SWaterSwimmingLeftSmallMario : ISmallMarioState, IJumpingMarioState, ILeftMarioState
    {
        public IPlayer Player { get; set; }

        public SWaterSwimmingLeftSmallMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.smallLeftSwimming);

            Player.Hitbox.SetOffset(Hitboxes.SMALL_MARIO_SWIM_OFFSET_X, Hitboxes.SMALL_MARIO_SWIM_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            

            Player.Acceleration = new Vector2(-0.1f, Player.Acceleration.Y);
        }

        public void Update()
        {
            HUD.HangTime++;
            Player.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Player.Hitbox.AddRectHitbox(
                    (int)Player.Position.X,
                    (int)Player.Position.Y,
                    Hitboxes.SMALL_MARIO_SWIM_WIDTH,
                    Hitboxes.SMALL_MARIO_SWIM_HEIGHT
                );
        }

        public void GoLeft()
        {

        }

        public void GoRight()
        {
            Player.State = new SWaterSwimmingRightSmallMario(Player);
        }

        public void GoUp()
        {

        }

        public void GoDown()
        {
            
        }

        public void GoNowhere()
        {
            if (Player.Velocity.Y == 0)
            {
                Player.State = new SWaterIdleLeftSmallMario(Player);
            }
            else
            {
                Player.State = new SWaterSwimmingLeftIdleSmallMario(Player);
            }
        }

        public void Jump()
        {
            Player.Velocity = new Vector2(Player.Velocity.X, -3f);
            SoundPanel.PlaySoundEffect(Sound.swimEffect);
        }

        public void HoldJump()
        {

        }

        public void Run()
        {
            
        }

        public void Climb()
        {
            
        }

        public void PowerUp()
        {
            Player.State = new SMarioTansition(Player, typeof(SWaterSwimmingLeftBigMario), Textures.smallBigTransitionLeft); 
        }

        public void PowerDown()
        {
            Player.State = new SDeadMario(Player);
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }

    }
}