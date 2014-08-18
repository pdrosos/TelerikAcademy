namespace SimpleFactory
{
    using System;
    using System.Threading;

    /// <summary>
    /// Simple Tetris Factory Demo
    /// </summary>
    public class TetrisFactoryDemo
    {
        public static void Main(string[] args)
        {
            IFigure figureT = CreateTetrisFigure(TetrisFigure.T);

            while (true)
            {
                Console.Clear();
                figureT.Render();
                figureT.Rotate();
                Console.WriteLine();
                Thread.Sleep(500);
            }
        }

        private static IFigure CreateTetrisFigure(TetrisFigure figure)
        {
            switch (figure)
            {
                case TetrisFigure.I: return new FigureI();
                case TetrisFigure.J: return new FigureJ();
                case TetrisFigure.L: return new FigureL();
                case TetrisFigure.O: return new FigureO();
                case TetrisFigure.S: return new FigureS();
                case TetrisFigure.T: return new FigureT();
                case TetrisFigure.Z: return new FigureZ();
                default: throw new ArgumentException(string.Format("Cannot generate figure: {0}", figure));
            }
        }
    }
}
