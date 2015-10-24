using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class Matrix<TypeName>
    {
        public int Rows { get; protected set; }
        public int Columns { get; protected set; }
        public TypeName [,] Data { get; protected set; }
        public Matrix(int rowCount, int columnCount)
        {
            Data = new TypeName[rowCount , columnCount];
            Rows = rowCount;
            Columns = columnCount;
        }
        public Matrix<TypeName> Copy()
        {
            if (Rows == 0 || Columns == 0)
            {
                throw new Exception("Invalid matrix size");
            }
            Matrix<TypeName> newMatrix = new Matrix<TypeName>(Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    newMatrix.Set(i, j, Data[i, j]);
                }
            }
            return newMatrix;
        }
        public void Set(int i, int j, TypeName value) { Data[i, j] = value; }
        public void ChangeRows(int firstRowNumber, int secondRowNumber)
        {
            if (firstRowNumber >= 0 && firstRowNumber < Rows &&
                secondRowNumber >= 0 && secondRowNumber < Rows && firstRowNumber != secondRowNumber)
            {
                for (int i = 0; i < Columns; i++)
                {
                    TypeName tmpValue = Data[firstRowNumber, i];
                    Data[firstRowNumber, i] = Data[secondRowNumber, i];
                    Data[secondRowNumber, i] = tmpValue;
                }
            }
        }
     

        public TypeName[] ToArray()
        {
            if (Rows == 0 || Columns == 0)
            {
                throw new Exception("Invalid matrix size");
            }

            TypeName[] array = new TypeName[Rows * Columns];

            for (int i = 0, k = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    array[k] = Data[i, j];
                    k++;
                }
            }
            return array;
        }
    }
}
