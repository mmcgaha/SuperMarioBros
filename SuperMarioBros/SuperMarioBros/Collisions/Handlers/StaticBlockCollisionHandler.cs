﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class StaticBlockCollisionHandler : ICollisionHandler
    {
        IBlock subject;
        public StaticBlockCollisionHandler(IBlock block)
        {
            this.subject = block;
        }

        public void CollisionAbove(ITangible type)
        {

        }
        public void CollisionBelow(ITangible type)
        {

        }
        public void CollisionLeft(ITangible type)
        {

        }
        public void CollisionRight(ITangible type)
        {

        }
    }
}
