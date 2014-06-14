using System;
using System.Text;

class GenericMatrix<T> 
{
    //Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

    private T[,] matrix;

    public GenericMatrix(int row, int col)
    {
        matrix = new T[row, col];
    }

    public int Rows
    {
        get { return this.matrix.GetLength(0); }
    }

    public int Columns
    {
        get { return this.matrix.GetLength(1); }
    }

    //Implement an indexer this[row, col] to access the inner matrix cells.
    public T this[int row, int col]
    {
        get
        {
            if (row >= this.matrix.GetLength(0) || row < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid row: {0}.", row));
            }

            if (col >= this.matrix.GetLength(1) || col < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid column: {0}.", col));
            }

            T result = matrix[row,col];
            return result;
        }

        set
        {
            if (row >= this.matrix.GetLength(0) || row < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid row: {0}.", row));
            }

            if (col >= this.matrix.GetLength(1) || col < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid column: {0}.", col));
            }

            matrix[row, col] = value;
        }
    }

    //Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
    //Throw an exception when the operation cannot be performed. 
    //Implement the true operator (check for non-zero elements).

    //Addition
    public static GenericMatrix<T> operator +(GenericMatrix<T> matrixA, GenericMatrix<T> matrixB)
    {
        if (matrixA.matrix.GetLength(0) != matrixB.matrix.GetLength(0) || 
            matrixA.matrix.GetLength(1) != matrixB.matrix.GetLength(1))
        {
            throw new ArgumentException("We can add only matrices of the same size!");
        }
        GenericMatrix<T> result = new GenericMatrix<T>(matrixA.matrix.GetLength(0), matrixA.matrix.GetLength(1));

        //At compile time we don't know what variables we will be given under T
        //so we use dynamic as variable type - it asumes the variables we get can be added
        for (int i = 0; i < matrixA.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.matrix.GetLength(1); j++)
            {
                dynamic elementA = matrixA[i, j];
                dynamic elementB = matrixB[i, j];
                dynamic elementSum = elementA + elementB;
                result[i, j] = elementSum;
            }
        }

        return result;
    }

    //Substraction
    public static GenericMatrix<T> operator -(GenericMatrix<T> matrixA, GenericMatrix<T> matrixB)
    {
        if (matrixA.matrix.GetLength(0) != matrixB.matrix.GetLength(0) ||
            matrixA.matrix.GetLength(1) != matrixB.matrix.GetLength(1))
        {
            throw new ArgumentException("We can substract only matrices of the same size!");
        }
        GenericMatrix<T> result = new GenericMatrix<T>(matrixA.matrix.GetLength(0), matrixA.matrix.GetLength(1));

        //At compile time we don't know what variables we will be given under T
        //so we use dynamic as variable type - it asumes the variables we get can be substracted
        for (int i = 0; i < matrixA.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.matrix.GetLength(1); j++)
            {
                dynamic elementA = matrixA[i, j];
                dynamic elementB = matrixB[i, j];
                dynamic elementDifference = elementA - elementB;
                result[i, j] = elementDifference;
            }
        }

        return result;
    }

    //Multiplication
    public static GenericMatrix<T> operator *(GenericMatrix<T> matrixA, GenericMatrix<T> matrixB)
    {
        if (matrixA.matrix.GetLength(0) != matrixB.matrix.GetLength(0) ||
            matrixA.matrix.GetLength(1) != matrixB.matrix.GetLength(1))
        {
            throw new ArgumentException("We can multiply only matrices of the same size!");
        }
        GenericMatrix<T> result = new GenericMatrix<T>(matrixA.matrix.GetLength(0), matrixA.matrix.GetLength(1));

        //At compile time we don't know what variables we will be given under T
        //so we use dynamic as variable type - it asumes the variables we get can be multiplied
        for (int i = 0; i < matrixA.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.matrix.GetLength(1); j++)
            {
                dynamic elementA = matrixA[i, j];
                dynamic elementB = matrixB[i, j];
                dynamic elementProduct = elementA * elementB;
                result[i, j] = elementProduct;
            }
        }

        return result;
    }

    //public static bool operator true(GenericMatrix<T> matrixA)
    //{
       
    //}

    public override string ToString()
    {
        StringBuilder print = new StringBuilder();

        //Members are displayed row by row, each on a new line
        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                print.Append(matrix[i, j]);
                print.AppendLine();
            }
        }

        string result = print.ToString();
        return result;
    }
}

