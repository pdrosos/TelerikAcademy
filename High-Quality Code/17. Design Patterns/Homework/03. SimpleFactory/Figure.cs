// ********************************
// <copyright file="Figure.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <author>Telerik Student</author>
// ********************************
namespace SimpleFactory
{
    using System;

    public abstract class Figure : IFigure
    {
        public Figure(int[,] form)
        {
            this.Form = form;
        }

        public int[,] Form { get; set; }

        public virtual void Render()
        {
            for (int row = 0; row < this.Form.GetLength(0); row++)
            {
                for (int col = 0; col < this.Form.GetLength(1); col++)
                {
                    Console.Write(this.Form[row, col]);
                }

                Console.WriteLine();
            }
        }

        public virtual void Rotate()
        {
            int width = this.Form.GetUpperBound(0) + 1;
            int height = this.Form.GetUpperBound(1) + 1;

            int[,] rotatedBlock = new int[height, width];

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    rotatedBlock[col, width - row - 1] = this.Form[row, col];
                }
            }

            this.Form = rotatedBlock;
        }
    }
}
