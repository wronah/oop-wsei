using System.Collections;

namespace ClassLibrary
{
    public partial class BitMatrix : IEnumerable<int>
    {
        public int this[int row, int column]
        {
            get 
            {
                if ((row < 0 || row >= NumberOfRows) || (column < 0 || column >= NumberOfColumns)) throw new IndexOutOfRangeException();
                return BoolToBit(data[row * NumberOfColumns + column]);
            }
            set 
            { 
                if ((row < 0 || row >= NumberOfRows) || (column < 0 || column >= NumberOfColumns)) throw new IndexOutOfRangeException();
                data[row * NumberOfColumns + column] = BitToBool(value);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(int row = 0; row < NumberOfRows; row++)
            {
                for(int column = 0; column < NumberOfColumns; column++)
                {
                    yield return this[row, column];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
