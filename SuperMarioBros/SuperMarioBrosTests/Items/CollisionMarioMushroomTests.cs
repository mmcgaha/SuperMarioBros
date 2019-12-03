﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMarioBros;

namespace SuperMarioBrosTests
{
    public class CollisionMarioMushroomTests : CollisionTests
    {
        Collider collider = new Collider(null);

        public CollisionMarioMushroomTests()
            : base()
        {
            tangible1 = new Mario();
            tangible2 = new Mushroom();
            collisions = new List<Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>>()
            {
                // mario Mushroom above collision
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 0, 1), new SMushroomMovingLeft((Mushroom)tangible2), new PhysicsBundle(40, 5), SuperMarioBros.Collider.CollisionFrom.Below),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 5, 0, -1), new SMushroomMovingLeft((Mushroom)tangible2), new PhysicsBundle(40, 0), SuperMarioBros.Collider.CollisionFrom.Above),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, -1), new SMushroomMovingLeft((Mushroom)tangible2), new PhysicsBundle(45, 0), SuperMarioBros.Collider.CollisionFrom.Left),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 1), new SMushroomMovingLeft((Mushroom)tangible2), new PhysicsBundle(45, 0), SuperMarioBros.Collider.CollisionFrom.Right),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(0, 0), new SMushroomMovingLeft((Mushroom)tangible2), new PhysicsBundle(40, 0), SuperMarioBros.Collider.CollisionFrom.None),
            };
        }
    }
}