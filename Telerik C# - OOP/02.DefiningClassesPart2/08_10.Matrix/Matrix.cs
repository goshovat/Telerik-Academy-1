namespace _08_10.Matrix
{
    /*
        8.Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
       
        9.Implement an indexer this[row, col] to access the inner matrix cells.
        
        10.Implement the operators + and - (addition and subtraction of matrices of the same size) 
        and * for matrix multiplication. Throw an exception when the operation cannot be performed. 
        Implement the true operator (check for non-zero elements).
    */

    using System;
    using System.Text;

    public class Matrix<T> 
        where T : IComparable
    {
        // Fields
        private T[,] matrix;
        private readonly int rows;
        private readonly int cols;

        // Constructor
        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
            this.rows = rows;
            this.cols = cols;
        }

        // Properties
        public int Rows
        {
            get { return this.rows; }
        }

        public int Cols
        {
            get { return this.cols; }
        }

        // Indexer
        public T this[int row, int col]
        {
            get 
            {
                if (row < 0 || col < 0 || row >= this.rows || col >= this.cols)
                {
                    throw new IndexOutOfRangeException(string.Format("There is no element on index[{0}, {1}] !!!", row, col));
                }

                return this.matrix[row, col]; 
            }
            set 
            {
                if (row < 0 || col < 0 || row >= this.rows || col >= this.cols)
                {
                    throw new IndexOutOfRangeException(string.Format("There is no element on index[{0}, {1}] !!!", row, col));
                }

                this.matrix[row, col] = value; 
            }
        }

        // Addition
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (!(firstMatrix.Rows == secondMatrix.Rows && firstMatrix.Cols == secondMatrix.Cols))
            {
                throw new Exception("The matrices can't be added because their rows or cols are not equals !!!");
            }
            
            Matrix<T> matrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < matrix.Rows; row++)
                for (int col = 0; col < matrix.Cols; col++)
                    matrix[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];

            return matrix;
        }

        // Subtraction
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (!(firstMatrix.Rows == secondMatrix.Rows && firstMatrix.Cols == secondMatrix.Cols))
            {
                throw new Exception("The matrices can't be substracted because their rows or cols are not equals !!!");
            }

            Matrix<T> matrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < matrix.Rows; row++)
                for (int col = 0; col < matrix.Cols; col++)
                    matrix[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];

            return matrix;
        }

        // Native multiplication
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (!(firstMatrix.Cols == secondMatrix.Rows))
            {
                throw new Exception("The matrices can't be added because their rows or cols are not equals !!!");
            }

            Matrix<T> matrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);

            for (int row = 0; row < matrix.Rows; row++)
                for (int col = 0; col < matrix.Cols; col++)
                    for (int rowCol = 0; rowCol < firstMatrix.Cols; rowCol++)
                        matrix[row, col] += (dynamic)firstMatrix[row, rowCol] * secondMatrix[rowCol, col];

            return matrix;
        }

        // Print
        public override string ToString()
        {
            StringBuilder matrixToString = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    matrixToString.Append(" " + this.matrix[row, col]);
                }
                matrixToString.Append("\n");
            }
            return matrixToString.ToString();
        }
    }
}
