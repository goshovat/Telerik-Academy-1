namespace _05.BitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        // Class fields
        private readonly ulong decimalNumber;
        private readonly int[] bits;

        // Class constructor
        public BitArray64(ulong decimalNumber)
        {
            this.decimalNumber = decimalNumber;
            this.bits = GetBits(decimalNumber);
        }

        // Class properties
        public int[] Bits
        {
            get
            {
                return this.bits;
            }
        }

        public ulong DecimalNumber
        {
            get
            {
                return this.decimalNumber;
            }
        }

        // Indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index must be in range [0, 63].");
                }

                return this.bits[index];
            }
        }

        // Methods
        //This method converts decimal ulong to array of bits
        private int[] GetBits(ulong decimalNumber)
        {
            List<int> gotBits = new List<int>();
            
            while (decimalNumber > 0)
            {
                int remainder = (int)(decimalNumber % 2);
                decimalNumber /= 2;
                gotBits.Add(remainder);
            }

            int len = gotBits.Count;

            if (len < 64)
            {
                int[] zeroArray = new int[64 - len];
                gotBits.AddRange(zeroArray);
            }
                      
            return gotBits.ToArray();
        }

        public override bool Equals(object param)
        {
            BitArray64 secondObject = param as BitArray64;

            for (int index = 0; index < secondObject.bits.Length; index++)
            {
                if (secondObject.bits[index] != this.bits[index])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 1048576; // 2^20 = 1048576
            hashCode ^= this.decimalNumber.GetHashCode();
            hashCode *= 1000;
            hashCode += 1;
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int index = 63; index >= 0; index--)
            {
                sb.Append(this.bits[index]);
            }

            return sb.ToString();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(first.Equals(second));
        }

        
        public IEnumerator<int> GetEnumerator()
        {           
            for (int index = 63; index >= 0; index--)
            {
                yield return this.bits[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
