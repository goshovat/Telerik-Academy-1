﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Bullet : MovingObject
    {
        public const char Symbol = '$';
        public new const string CollisionGroupString = "bullet";

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { Bullet.Symbol } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "UnpassableBlock";
        }

        public override string GetCollisionGroupString()
        {
            return Bullet.CollisionGroupString;
        }
        
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}