using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace BlumMicali.Generator
{
    internal class BlumMicaliGenerator
    {
        BigInteger mod;
        BigInteger seed;
        BigInteger primitiveRoot;

        public BlumMicaliGenerator(BigInteger seed, BigInteger primitiveRoot, BigInteger mod)
        {
            this.seed = seed;
            this.primitiveRoot = primitiveRoot;
            this.mod = mod;
        }

        // Получение бита числа
        private char GetNextBit(BigInteger nextValue)
        {
            return nextValue < (mod - 1) / 2 ? '1' : '0';
        }

        // Получение случайного числа
        private byte GetNumber()
        {
            string result = string.Empty;

            for (int j = 0; j < 8; j++)
            {
                seed = BigInteger.ModPow(primitiveRoot, seed, mod);
                result += GetNextBit(seed);                
            }

            result = new string(result.ToCharArray().Reverse().ToArray());

            return Convert.ToByte(result, 2);
        }

        // Получение списка случайных чисел
        public List<byte> GetRandomNumbers(int countOfNumbers)
        {            
            List<byte> result = new List<byte>();

            while (result.Count != countOfNumbers)
                result.Add(GetNumber());

            return result;            
        }
    }
}