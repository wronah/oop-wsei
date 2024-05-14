using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class BitMatrix
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var i = 1;
            foreach (bool element in data)
            {
                stringBuilder.Append(BoolToBit(element));
                if (i % NumberOfColumns == 0 && i != 0)
                {
                    stringBuilder.AppendLine();
                }
                i++;
            }
            return stringBuilder.ToString();
        }
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
            this.NumberOfRows = numberOfRows;
            this.NumberOfColumns = numberOfColumns;
            if (bits == null || bits.Length == 0)
            {
                data = new BitArray(numberOfRows * numberOfColumns);
            }
            else
            {
                data = new BitArray(numberOfRows * numberOfColumns);
                for (int i = 0; i < data.Length; i++)
                {
                    if (i < bits.Length)
                    {
                        data[i] = BitToBool(bits[i]);
                    }
                    else
                    {
                        data[i] = false;
                    }
                }
            }
        }
        public BitMatrix(int[,] bits)
        {
            if (bits == null) throw new NullReferenceException();
            this.NumberOfRows = bits.GetLength(0);
            this.NumberOfColumns = bits.GetLength(1);
            if (NumberOfRows == 0 || NumberOfColumns == 0) throw new ArgumentOutOfRangeException();
            var bits1D = new int[NumberOfRows * NumberOfColumns];
            var x = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    bits1D[x++] = bits[i, j];
                }
            }
            data = new BitArray(NumberOfRows * NumberOfColumns);
            for (int i = 0; i < data.Length; i++)
            {
                if (i < bits1D.Length)
                {
                    data[i] = BitToBool(bits1D[i]);
                }
                else
                {
                    data[i] = false;
                }
            }
        }
        public BitMatrix(bool[,] bits)
        {
            if (bits == null) throw new NullReferenceException();
            this.NumberOfRows = bits.GetLength(0);
            this.NumberOfColumns = bits.GetLength(1);
            if (NumberOfRows == 0 || NumberOfColumns == 0) throw new ArgumentOutOfRangeException();
            var bits1D = new bool[NumberOfRows * NumberOfColumns];
            var x = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    bits1D[x++] = bits[i, j];
                }
            }
            data = new BitArray(NumberOfRows * NumberOfColumns);
            for (int i = 0; i < data.Length; i++)
            {
                if (i < bits1D.Length)
                {
                    data[i] = bits1D[i];
                }
                else
                {
                    data[i] = false;
                }
            }
        }
    }
}
