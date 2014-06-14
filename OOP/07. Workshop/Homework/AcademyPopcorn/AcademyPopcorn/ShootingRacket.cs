namespace AcademyPopcorn
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 13 - Schooting racket
    /// </summary>
    public class ShootingRacket : Racket
    {
        private bool canShoot = true;
        private bool shootNow = false;
 
        public ShootingRacket(MatrixCoords topLeft, int width) : base(topLeft, width)
        {
        }

        public bool CanShoot()
        {
            return this.canShoot;
        }

        public void Shoot()
        {
            this.shootNow = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            if (this.CanShoot() == true && this.shootNow == true)
            {
                this.canShoot = false;
                this.shootNow = false;

                produceObjects.Add(new Bullet(this.topLeft));
            }

            return produceObjects;
        }
    }
}
