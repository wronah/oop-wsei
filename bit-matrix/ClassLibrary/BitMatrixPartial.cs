using System.Collections;
using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    public partial class BitMatrix : ICloneable
    {
        public BitMatrix Clone()
        {
            var clone = new BitMatrix(NumberOfRows, NumberOfColumns);
            clone.data = new BitArray(data);
            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
