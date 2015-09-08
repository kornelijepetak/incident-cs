using System;
using System.Linq;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		/// <summary>
		/// Generates random primitive values
		/// </summary>
		public static class Primitive
		{
			/// <summary>
			/// Gets a random boolean (true or false)
			/// </summary>
			public static bool Boolean
			{
				get
				{
					return Rand.NextDouble() < 0.5;
				}
			}

			/// <summary>
			/// Gets a random byte from interval [0, 255]
			/// </summary>
			public static byte Byte
			{
				get
				{
					return (Byte)Rand.Next(256);
				}
			}

			/// <summary>
			/// Gets a random byte between <paramref name="start"/> and <paramref name="end"/>
			/// <remarks>If <paramref name="start"/> is greater than <paramref name="end"/>, they will be swapped and the result will be between [end, start]</remarks>
			/// </summary>
			/// <param name="start">Inclusive lower bound</param>
			/// <param name="end">Exclusive upper bound</param>
			/// <returns>A random byte in specified interval</returns>
			public static byte ByteBetween(int start, int end)
			{
				if (start < 0 || 256 < start || end < 0 || 256 < end)
				{
					// TODO Implement better error message here
					throw new ArgumentOutOfRangeException("Start and End arguments must be between 0 and 256");
				}

				return start < end 
					? (byte)Rand.Next(start, end) 
					: (byte)Rand.Next(end, start);
			}

			/// <summary>
			/// Gets a random signed byte from interval [-128, 127]
			/// </summary>
			public static sbyte SignedByte
			{
				get
				{
					return Convert.ToSByte(Byte - 128);
				}
			}

			/// <summary>
			/// Gets a random short from interval [-32768, 32767]
			/// </summary>
			public static short Short
			{
				get
				{
					byte[] shortArray = new byte[2];
					Rand.NextBytes(shortArray);
					return BitConverter.ToInt16(shortArray, 0);
				}
			}

			/// <summary>
			/// Gets a random positive short from interval [0, 32767]
			/// </summary>
			public static short PositiveShort
			{
				get
				{
					return (short)Rand.Next(0, short.MaxValue);
				}
			}

			/// <summary>
			/// Gets a random unsigned short from interval [0, 65535]
			/// </summary>
			public static ushort UnsignedShort
			{
				get
				{
					byte[] ushortArray = new byte[2];
					Rand.NextBytes(ushortArray);
					return BitConverter.ToUInt16(ushortArray, 0);
				}
			}

			/// <summary>
			/// Gets a random integer from interval [-2147483648, 2147483647]
			/// </summary>
			public static int Integer
			{
				get
				{
					byte[] intArray = new byte[4];
					Rand.NextBytes(intArray);
					return BitConverter.ToInt32(intArray, 0);
				}
			}

			/// <summary>
			/// Gets a random integer from interval [0, 2147483647]
			/// </summary>
			public static int PositiveInteger
			{
				get
				{
					return Rand.Next();
				}
			}

			/// <summary>
			/// Gets a random unsigned integer from interval [0, 4294967295]
			/// </summary>
			public static uint UnsignedInteger
			{
				get
				{
					byte[] uintArray = new byte[4];
					Rand.NextBytes(uintArray);
					return BitConverter.ToUInt32(uintArray, 0);
				}
			}

			/// <summary>
			/// Gets a random float from interval [float.MinValue, float.MaxValue]
			/// </summary>
			public static float Float
			{
				get
				{
					double mantissa = (Rand.NextDouble() * 2.0) - 1.0;
					double exponent = Math.Pow(2.0, Rand.Next(-126, 128));
					return (float)(mantissa * exponent);
				}
			}

			/// <summary>
			/// Gets a random float between 0 (inclusive) and 1 (exclusive)
			/// </summary>
			public static float FloatUnit
			{
				get
				{
					float num;

					do
					{
						num = (float)Rand.NextDouble();
					} while (num == 1);

					return num;
				}
			}

			/// <summary>
			/// Gets a random float between 0 (inclusive) and 1 (exclusive)
			/// </summary>
			public static double Double
			{
				get
				{
					// Revise this method when better solution is found
					double sign = Boolean ? 1 : -1;
					return sign * Rand.NextDouble() * double.MaxValue;
				}
			}

			/// <summary>
			/// Gets a random double precision value between 0 (inclusive) and 1 (exclusive)
			/// </summary>
			public static double DoubleUnit
			{
				get
				{
					return Rand.NextDouble();
				}
			}

		}

	}
}
