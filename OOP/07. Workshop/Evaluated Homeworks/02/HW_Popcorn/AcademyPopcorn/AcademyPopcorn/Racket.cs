using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Racket : GameObject
    {
        public new const string CollisionGroupString = "racket";
        public bool canShoot;
        public bool shoot;
        public int Width { get; protected set; }

        public Racket(MatrixCoords topLeft, int width)
            : base(topLeft, new char[,] { { '=' } })
        {
            this.Width = width;
            this.body = GetRacketBody(this.Width);
        }

        char[,] GetRacketBody(int width)
        {
            char[,] body = new char[1, width];

            for (int i = 0; i < width; i++)
            {
                body[0, i] = '=';
            }

            return body;
        }

        public void MoveLeft()
        {
            if (this.topLeft.Col > 1)
            {
                this.topLeft.Col--;
            }

        }

        public void MoveRight()
        {
            if (this.topLeft.Col < 33)
            {
                this.topLeft.Col++;
            }

        }

        public override string GetCollisionGroupString()
        {
            return Racket.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "gift";// || otherCollisionGroupString == "ball" ||otherCollisionGroupString == "block";
        }

        //The following methods were added by my
        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] == "gift")
            {
                canShoot = true; //Used as a key in ProduseObjects method

            }

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<ShootingRacket> shootRacket = new List<ShootingRacket>();
            if (canShoot) // As a result I generate a new racket made by different symbols and able to shoot
            {
                ShootingRacket newRacket = new ShootingRacket(this.topLeft, this.Width);
                shootRacket.Add(newRacket);
            }

            return shootRacket;
        }

        public override void Update()
        {
        }
    }
}
