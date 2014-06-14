using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 13
    public class ShootingRacket : Racket
    {
        int shootingTime = 200;


        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.Width = width;
            this.body = GetRacketBody(this.Width);
        }

        char[,] GetRacketBody(int width)
        {
            char[,] body = new char[1, width];

            for (int i = 0; i < width; i++)
            {
                body[0, i] = '^'; //The symbol of shooting racket
            }

            return body;
        }

        public override void Update()
        {
            if (this.shootingTime > 0)
            {
                shootingTime--;
            }

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> list = new List<GameObject>();

            if (shoot) //Gemeral check - activated by Spacebar
            {
                if (shootingTime > 0)
                {
                    Bullet bull01 = new Bullet(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + 3));
                    list.Add(bull01);
                    shoot = false; //To stop shooting when not pressed Spacebar
                }

            }

            if (shootingTime == 0) // Delete shooting Racket and start playing with normal racket
            {
                Racket myNewRacket = new Racket(this.topLeft, this.Width);
                list.Add(myNewRacket); 
                this.canShoot = false;
            }

            return list;
        }
    }
}
