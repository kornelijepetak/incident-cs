using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS
{
	/// <summary>
	/// Generates random primitive values
	/// </summary>
	public class PrimitiveRandomizer : IPrimitiveRandomizer
	{
		/// <summary>
		/// Gets a random boolean (true or false)
		/// </summary>
		public virtual bool Boolean
		{
			get
			{
				return Incident.Rand.NextDouble() < 0.5;
			}
		}

		/// <summary>
		/// Returns a new random GUID
		/// </summary>
		public virtual Guid Guid
		{
			get
			{
				return new Guid();
			}
		}

		/// <summary>
		/// Gets a random DateTime from interval [0000-01-01 00:00:00, 9999-12-31 23:59:59.9*]
		/// </summary>
		public virtual DateTime DateTime
		{
			get
			{
				var days = (DateTime.MaxValue - DateTime.MinValue).TotalDays;
				return DateTime.MinValue.AddDays(Incident.Rand.NextDouble() * days);
			}
		}

		/// <summary>
		/// Gets a random time between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The time of <paramref name="start"/> is greater than the time of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random time in specified interval</returns>
		public virtual DateTime TimeBetween(DateTime start, DateTime end)
		{
			if (start > end)
				throw new ArgumentException("The time of 'start' must be less than the time of 'end'!");

			return start.AddDays((end - start).TotalDays * Incident.Rand.NextDouble());
		}

		/// <summary>
		/// Gets a random byte from interval [0, 255]
		/// </summary>
		public virtual byte Byte
		{
			get
			{
				return (Byte)Incident.Rand.Next(256);
			}
		}

		/// <summary>
		/// Gets a random byte between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than 0.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 256.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random byte in specified interval</returns>
		public virtual byte ByteBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			if (start < 0)
				throw new ArgumentOutOfRangeException("The value of 'start' must be non-negative.");

			if (end > 256)
				throw new ArgumentOutOfRangeException("The value of 'end' must be less than or equal 256.");

			return (byte)Incident.Rand.Next(start, end);
		}

		/// <summary>
		/// Gets a random signed byte from interval [-128, 127]
		/// </summary>
		public virtual sbyte SignedByte
		{
			get
			{
				return Convert.ToSByte(Byte - 128);
			}
		}

		/// <summary>
		/// Gets a random signed byte between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than -128.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 128.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random signed byte in specified interval</returns>
		public virtual sbyte SignedByteBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			if (start < -128)
				throw new ArgumentOutOfRangeException("The value of 'start' must be greater than or equal -128.");

			if (end > 128)
				throw new ArgumentOutOfRangeException("The value of 'end' must be less than or equal 128.");

			return (sbyte)Incident.Rand.Next(start, end);
		}

		/// <summary>
		/// Gets a random short from interval [-32768, 32767]
		/// </summary>
		public virtual short Short
		{
			get
			{
				byte[] shortArray = new byte[2];
				Incident.Rand.NextBytes(shortArray);
				return BitConverter.ToInt16(shortArray, 0);
			}
		}

		/// <summary>
		/// Gets a random positive short from interval [0, 32767]
		/// </summary>
		public virtual short PositiveShort
		{
			get
			{
				return (short)Incident.Rand.Next(0, short.MaxValue);
			}
		}

		/// <summary>
		/// Gets a random short between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than -32768.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 32768.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random short in specified interval</returns>
		public virtual short ShortBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			if (start < -32768)
				throw new ArgumentOutOfRangeException("The value of 'start' must be greater than or equal -32768.");

			if (end > 32768)
				throw new ArgumentOutOfRangeException("The value of 'end' must be less than or equal 32768.");

			return (short)Incident.Rand.Next(start, end);
		}

		/// <summary>
		/// Gets a random unsigned short from interval [0, 65535]
		/// </summary>
		public virtual ushort UnsignedShort
		{
			get
			{
				byte[] ushortArray = new byte[2];
				Incident.Rand.NextBytes(ushortArray);
				return BitConverter.ToUInt16(ushortArray, 0);
			}
		}

		/// <summary>
		/// Gets a random unsigned short between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than 0.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 65536.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random unsigned short in specified interval</returns>
		public virtual ushort UnsignedShortBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			if (start < 0)
				throw new ArgumentOutOfRangeException("The value of 'start' must be greater than or equal 0.");

			if (end > 65536)
				throw new ArgumentOutOfRangeException("The value of 'end' must be less than or equal 65536.");

			return (ushort)Incident.Rand.Next(start, end);
		}

		/// <summary>
		/// Gets a random integer from interval [-2147483648, 2147483647]
		/// </summary>
		public virtual int Integer
		{
			get
			{
				byte[] intArray = new byte[4];
				Incident.Rand.NextBytes(intArray);
				return BitConverter.ToInt32(intArray, 0);
			}
		}

		/// <summary>
		/// Gets a random integer between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random integer in specified interval</returns>
		public virtual int IntegerBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			return Incident.Rand.Next(start, end);
		}

		/// <summary>
		/// Gets a random integer from interval [0, 2147483647]
		/// </summary>
		public virtual int PositiveInteger
		{
			get
			{
				return Incident.Rand.Next();
			}
		}

		/// <summary>
		/// Gets a random unsigned integer from interval [0, 4294967295]
		/// </summary>
		public virtual uint UnsignedInteger
		{
			get
			{
				byte[] uintArray = new byte[4];
				Incident.Rand.NextBytes(uintArray);
				return BitConverter.ToUInt32(uintArray, 0);
			}
		}

		/// <summary>
		/// Gets a random unsigned integer between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random unsigned integer in specified interval</returns>
		public virtual uint UnsignedIntegerBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			return (uint)(Incident.Rand.Next(start, end) + 2147483648L);
		}

		/// <summary>
		/// Gets a random float from interval [float.MinValue, float.MaxValue]
		/// </summary>
		public virtual float Float
		{
			get
			{
				double mantissa = (Incident.Rand.NextDouble() * 2.0) - 1.0;
				double exponent = Math.Pow(2.0, Incident.Rand.Next(-126, 128));
				return (float)(mantissa * exponent);
			}
		}

		/// <summary>
		/// Gets a random float between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		public virtual float FloatUnit
		{
			get
			{
				float num;

				do
				{
					num = (float)Incident.Rand.NextDouble();
				} while (num == 1);

				return num;
			}
		}

		/// <summary>
		/// Gets a random float between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random float in specified interval</returns>
		public virtual float FloatBetween(float start, float end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			double randomValue;

			do
			{
				randomValue = Incident.Rand.NextDouble() * (end - start) + start;
			} while ((float)randomValue == end);

			return (float)randomValue;
		}

		/// <summary>
		/// Gets a random float between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		public virtual double Double
		{
			get
			{
				// Revise this method when better solution is found
				double sign = Boolean ? 1 : -1;
				return sign * Incident.Rand.NextDouble() * double.MaxValue;
			}
		}

		/// <summary>
		/// Gets a random double precision value between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		public virtual double DoubleUnit
		{
			get
			{
				return Incident.Rand.NextDouble();
			}
		}

		/// <summary>
		/// Gets a random double between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random double in specified interval</returns>
		public virtual double DoubleBetween(double start, double end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			return Incident.Rand.NextDouble() * (end - start) + start;
		}


	}

}
