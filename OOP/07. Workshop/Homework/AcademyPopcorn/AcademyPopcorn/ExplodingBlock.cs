namespace AcademyPopcorn
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 10 - Exploding block
    /// </summary>
    public class ExplodingBlock : Block
    {
        public const char Symbol = 'B';
        protected char pieceSymbol = '`';

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public ExplodingBlock(MatrixCoords topLeft, char pieceSymbol)
            : this(topLeft)
        {
            this.PieceSymbol = pieceSymbol;
        }

        public char PieceSymbol
        {
            get
            {
                return this.pieceSymbol;
            }
            set
            {
                this.pieceSymbol = value;
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            // explosion produces pieces
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new ExplosionPiece(this.topLeft, new char[,] { { this.PieceSymbol } }, new MatrixCoords(-1, 0)));
                produceObjects.Add(new ExplosionPiece(this.topLeft, new char[,] { { this.PieceSymbol } }, new MatrixCoords(1, 0)));
                produceObjects.Add(new ExplosionPiece(this.topLeft, new char[,] { { this.PieceSymbol } }, new MatrixCoords(0, 1)));
                produceObjects.Add(new ExplosionPiece(this.topLeft, new char[,] { { this.PieceSymbol } }, new MatrixCoords(0, -1)));
            }

            return produceObjects;
        }
    }
}
