using System;

/*
    Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, 
    subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().
*/

class Matrix
{
    public int[,] matrix;
    public int rows;
    public int cols;

    // Constructor
    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
        this.rows = rows;
        this.cols = cols;
    }

    // Getter/Setter
    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    // Addition
    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix matrix = new Matrix(firstMatrix.rows, firstMatrix.cols);

        for (int i = 0; i < matrix.rows; i++)
            for (int j = 0; j < matrix.cols; j++)
                matrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];

        return matrix;
    }

    // Subtraction
    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix matrix = new Matrix(firstMatrix.rows, firstMatrix.cols);

        for (int i = 0; i < matrix.rows; i++)
            for (int j = 0; j < matrix.cols; j++)
                matrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];

        return matrix;
    }

    // Naive multiplication
    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix matrix = new Matrix(firstMatrix.rows, secondMatrix.cols);

        for (int i = 0; i < matrix.rows; i++)
            for (int j = 0; j < matrix.cols; j++)
                for (int k = 0; k < firstMatrix.cols; k++)
                    matrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];

        return matrix;
    }

    // Print
    public override string ToString()
    {
        string matrixToString = "";

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrixToString += " " + matrix[i, j];
            }
            matrixToString += "\n";
        }
        return matrixToString;
    }

    static void Main()
    {
        Console.Title = "Matrix";

        Console.ForegroundColor = ConsoleColor.Green;

        int firstRows = 0;

        do
        {
            Console.Write("How many rows does the first matrix have : ");
            firstRows = int.Parse(Console.ReadLine());
        } while (firstRows < 1);

        int firstCols = 0;

        do
        {
            Console.Write("How many cols does the first matrix have : ");
            firstCols = int.Parse(Console.ReadLine());
        } while (firstCols < 1);

        Matrix firstMatrix = new Matrix(firstRows, firstCols);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements for the first matrix:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int row = 0; row < firstRows; row++)
        {
            for (int col = 0; col < firstCols; col++)
            {
                Console.Write("Element[{0}, {1}] = ", row, col);
                firstMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Green;

        int secondRows = 0;

        do
        {
            Console.Write("\nHow many rows does the second matrix have : ");
            secondRows = int.Parse(Console.ReadLine());
        } while (secondRows < 1);

        int secondCols = 0;

        do
        {
            Console.Write("How many cols does the second matrix have : ");
            secondCols = int.Parse(Console.ReadLine());
        } while (secondCols < 1);

        Matrix secondMatrix = new Matrix(secondRows, secondCols);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the second array:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int row = 0; row < secondRows; row++)
        {
            for (int col = 0; col < secondCols; col++)
            {
                Console.Write("Element[{0}, {1}] = ", row, col);
                secondMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));
        
        // Print the first matrix
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe first matrix:");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(firstMatrix);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 20));

        // Print the second matrix
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe second matrix:");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(secondMatrix);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 20));

        // Print the matrix after adding the matrices
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nAdding the matrices");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;
       
        if (firstRows == secondRows && firstCols == secondCols)
        {
            Console.Write(firstMatrix + secondMatrix);
        }
        else
        {
            Console.WriteLine("The matrices can't be added because their rows or cols are not equals !!!");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(new string('-', 20));

        // Print the matrix after substracting the matrices
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nSubtracting the matrices");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow; 
        
        if (firstRows == secondRows && firstCols == secondCols)
        {
            Console.Write(firstMatrix - secondMatrix);
        }
        else
        {
            Console.WriteLine("The matrices can't be substracted because their rows or cols are not equals !!!");
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(new string('-', 20));

        // Print the matrix after multiplying the matrices
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nMultiplying the matrices");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        if (secondRows == firstCols)
        {
            Console.Write(firstMatrix * secondMatrix);
        }
        else
        {
            Console.WriteLine("The matrices can't be adding because their rows or cols are not equals !!!");
        } 
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('-', 20));

        Console.WriteLine("\n");
        Console.ResetColor();

    }
}