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
    public class SClimbingIdleLeftSmallMario : ISmallMarioState, IClimbingMarioState, ILeftMarioState
    {
        public IPlayer Player { get; set; }
        private int timer;

        public SClimbingIdleLeftSmallMario(IPlayer player)
        {
            this.Player = player;
            this.timer = 0;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.smallLeftClimbingIdle);

            Player.Hitbox.SetOffset(Hitboxes.SMALL_MARIO_CLIMBING_OFFSET_X, Hitboxes.SMALL_MARIO_CLIMBING_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            Player.Acceleration = Vector2.Zero;
            Player.Velocity = Vector2.Zero;
        }

        public void Update()
        {
            this.timer = timer > HotDAMN.TICKS_UNTIL_MARIO_CLIMBING_TURNS ? HotDAMN.TICKS_UNTIL_MARIO_CLIMBING_TURNS : timer + 1;
            HUD.HangTime = 0;
            Player.SequenceCounter = 0;
            Player.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Player.Hitbox.AddRectHitbox(
                    (int)Player.Position.X,
                    (int)Player.Position.Y,
                    Hitboxes.SMALL_MARIO_CLIMBING_WIDTH,
                    Hitboxes.SMALL_MARIO_CLIMBING_HEIGHT
                );
        }

        public void GoLeft()
        {
            if (timer >= HotDAMN.TICKS_UNTIL_MARIO_CLIMBING_TURNS)
            {
                Player.Position = new Vector2(Player.Position.X - Hitboxes.SMALL_MARIO_CLIMBING_WIDTH - Hitboxes.ROPE_WIDTH + 2, Player.Position.Y);
                Player.State = new SClimbingIdleRightSmallMario(Player);
            }
        }

        public void GoRight()
        {
            if (timer >= HotDAMN.TICKS_UNTIL_MARIO_CLIMBING_TURNS)
            {
                Player.State = new SIdleRightSmallMario(Player);
                Player.Position = new Vector2(Player.Position.X + 1, Player.Position.Y);
            }
        }

        public void GoUp()
        {
            Player.State = new SClimbingUpLeftSmallMario(Player);
        }

        public void GoDown()
        {
            Player.State = new SClimbingDownLeftSmallMario(Player);
        }

        public void GoNowhere()
        {

        }

        public void Jump()
        {

        }

        public void HoldJump()
        {

        }

        public void Run()
        {
            ((Mario)Player).IsRunning = true;
        }

        public void Climb()
        {

        }

        public void PowerUp()
        {
            Player.State = new SMarioTansition(Player, typeof(SIdleLeftBigMario), Textures.smallBigTransitionLeft); 
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