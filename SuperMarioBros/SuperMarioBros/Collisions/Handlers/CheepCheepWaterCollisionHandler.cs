﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class CheepCheepWaterCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public CheepCheepWaterCollisionHandler(IEnemy cheepcheep)
        {
            this.subject = cheepcheep;
        }

        public void CollisionAbove(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SCheepCheepDeadLeft(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_CHEEPCHEEP));
                Sound.kickEffect.Play();
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SCheepCheepDeadLeft(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_CHEEPCHEEP));
                Sound.kickEffect.Play();
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SCheepCheepDeadLeft(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_CHEEPCHEEP));
                Sound.kickEffect.Play();
            }
        }
        public void CollisionRight(ITangible type)
        {
            if ((type is IPlayer && ((IPlayer)type).Decorator is StarPlayer) || type is Fireball)
            {
                subject.State = new SCheepCheepDeadLeft(subject);
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_CHEEPCHEEP;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_CHEEPCHEEP));
                Sound.kickEffect.Play();
            }
        }
    }
}
