﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMarioBros;

namespace SuperMarioBrosTests
{
    public class CollisionMarioQuestionBlockTests : CollisionTests
    {
        Collider collider = new Collider(null);

        public CollisionMarioQuestionBlockTests()
            : base()
        {
            tangible1 = new Mario();
            tangible2 = new BlockQuestion(null);
            collisions = new List<Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>>()
            {
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 0, 1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(40, 5), SuperMarioBros.Collider.CollisionFrom.Below),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 5, 0, -1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(40, 0), SuperMarioBros.Collider.CollisionFrom.Above),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, -1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(45, 0), SuperMarioBros.Collider.CollisionFrom.Left),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(45, 0), SuperMarioBros.Collider.CollisionFrom.Right),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(0, 0), new S1UpMovingLeft((_1Up)tangible2), new PhysicsBundle(40, 0), SuperMarioBros.Collider.CollisionFrom.None),
            };
        }
    }
}
