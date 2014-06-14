using System;

class MainClass
{
    static void Main()
    {
        //NOTE: T is a template that can accept any variable
        //However in order to use operators +, - and * T must be numeric or string type of variable
        //This is because the original operators +, - and * are suppoorted only by those types
        //We can't override operators that are not supported by the original variable - char for example
        
        //Generate sample matrix
        GenericMatrix<float> matrixA = new GenericMatrix<float>(2, 2);
        matrixA[0, 0] = 1.1f;
        matrixA[0, 1] = 2.2f;
        matrixA[1, 0] = 3.3f;
        matrixA[1, 1] = 4.4f;

        //Members are displayed row by row
        Console.WriteLine("MatrixA - members: \n{0}", matrixA.ToString());

        //Generate second matrix
        GenericMatrix<float> matrixB = new GenericMatrix<float>(2, 2);
        matrixB[0, 0] = 1.1f;
        matrixB[0, 1] = 1.1f;
        matrixB[1, 0] = 1.1f;
        matrixB[1, 1] = 1.1f;
        Console.WriteLine("MatrixB: \n{0}", matrixB.ToString());

        //Testing operator +
        GenericMatrix<float> sum = matrixA + matrixB;
        Console.WriteLine("Matrix sum: \n{0}", sum.ToString());

        //Testing operator -
        GenericMatrix<float> difference = matrixA - matrixB;
        Console.WriteLine("Matrix difference: \n{0}", difference.ToString());

        //Testing operator *
        GenericMatrix<float> product = matrixA * matrixB;
        Console.WriteLine("Matrix product: \n{0}", product.ToString());
    }
}

