using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class LedgeDetectionCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public LedgeDetectionCollisionHandler(IEnemy redkoopa)
        {
            this.subject = redkoopa;
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
