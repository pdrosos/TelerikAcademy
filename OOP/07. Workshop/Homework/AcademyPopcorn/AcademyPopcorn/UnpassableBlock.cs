namespace AcademyPopcorn
{
    /// <summary>
    /// Task 8 - Unpassable block
    /// </summary>
    public class UnpassableBlock : IndestructibleBlock
    {
        public const char Symbol = '█';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft) : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
