namespace AcademyPopcorn
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 12 - Gift block
    /// </summary>
    public class GiftBlock : Block
    {
        public const char Symbol = 'G';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                produceObjects.Add(new Gift(this.topLeft));
            }

            return produceObjects;
        }
    }
}
