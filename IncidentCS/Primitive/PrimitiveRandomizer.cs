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
	internal class PrimitiveRandomizer : IPrimitiveRandomizer
	{
		public virtual bool Boolean
		{
			get
			{
				return Incident.Rand.NextDouble() < 0.5;
			}
		}

		public virtual Guid Guid
		{
			get
			{
				return new Guid();
			}
		}

		public virtual DateTime DateTime
		{
			get
			{
				var days = (DateTime.MaxValue - DateTime.MinValue).TotalDays;
				return DateTime.MinValue.AddDays(Incident.Rand.NextDouble() * days);
			}
		}

		public virtual DateTime TimeBetween(DateTime start, DateTime end)
		{
			if (start > end)
				throw new ArgumentException("The time of 'start' must be less than the time of 'end'!");

			return start.AddDays((end - start).TotalDays * Incident.Rand.NextDouble());
		}

		public virtual byte Byte
		{
			get
			{
				return (Byte)Incident.Rand.Next(256);
			}
		}

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

		public virtual sbyte SignedByte
		{
			get
			{
				return Convert.ToSByte(Byte - 128);
			}
		}

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

		public virtual short Short
		{
			get
			{
				byte[] shortArray = new byte[2];
				Incident.Rand.NextBytes(shortArray);
				return BitConverter.ToInt16(shortArray, 0);
			}
		}

		public virtual short PositiveShort
		{
			get
			{
				return (short)Incident.Rand.Next(0, short.MaxValue);
			}
		}

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

		public virtual ushort UnsignedShort
		{
			get
			{
				byte[] ushortArray = new byte[2];
				Incident.Rand.NextBytes(ushortArray);
				return BitConverter.ToUInt16(ushortArray, 0);
			}
		}

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

		public virtual int Integer
		{
			get
			{
				byte[] intArray = new byte[4];
				Incident.Rand.NextBytes(intArray);
				return BitConverter.ToInt32(intArray, 0);
			}
		}

		public virtual int IntegerBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			return Incident.Rand.Next(start, end);
		}

		public virtual int PositiveInteger
		{
			get
			{
				return Incident.Rand.Next();
			}
		}

		public virtual uint UnsignedInteger
		{
			get
			{
				byte[] uintArray = new byte[4];
				Incident.Rand.NextBytes(uintArray);
				return BitConverter.ToUInt32(uintArray, 0);
			}
		}

		public virtual uint UnsignedIntegerBetween(int start, int end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			return (uint)(Incident.Rand.Next(start, end) + 2147483648L);
		}

		public virtual float Float
		{
			get
			{
				double mantissa = (Incident.Rand.NextDouble() * 2.0) - 1.0;
				double exponent = Math.Pow(2.0, Incident.Rand.Next(-126, 128));
				return (float)(mantissa * exponent);
			}
		}

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

		public virtual double Double
		{
			get
			{
				// Revise this method when better solution is found
				double sign = Boolean ? 1 : -1;
				return sign * Incident.Rand.NextDouble() * double.MaxValue;
			}
		}

		public virtual double DoubleUnit
		{
			get
			{
				return Incident.Rand.NextDouble();
			}
		}

		public virtual double DoubleBetween(double start, double end)
		{
			if (start > end)
				throw new ArgumentException("The value of 'start' must be less than the value of 'end'!");

			return Incident.Rand.NextDouble() * (end - start) + start;
		}


	}

}
