namespace AcademyPopcorn
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 4 - Schooting engine
    /// </summary>
    public class ShootingEngine : Engine
    {
        ShootingRacket racket;

        public ShootingEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public ShootingEngine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

        public override void AddObject(GameObject obj)
        {
            ShootingRacket racket = obj as ShootingRacket;

            if (racket != null)
            {
                this.racket = racket;
            }

            base.AddObject(obj);
        }

        public void ShootPlayerRacket()
        {
            if (this.racket != null && this.racket.CanShoot())
            {
                this.racket.Shoot();
            }
        }
    }
}
