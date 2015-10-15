using System;
using System.Collections.Generic;
using System.Linq;

namespace IncidentCS
{
	public interface IPrimitiveRandomizer
	{
		/// <summary>
		/// Gets a random boolean (true or false)
		/// </summary>
		bool Boolean { get; }
		
		/// <summary>
		/// Returns a new random GUID
		/// </summary>
		Guid Guid { get; }
		
		/// <summary>
		/// Gets a random DateTime from interval [0000-01-01 00:00:00, 9999-12-31 23:59:59.9*]
		/// </summary>
		DateTime DateTime { get; }
		
		/// <summary>
		/// Gets a random time between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The time of <paramref name="start"/> is greater than the time of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random time in specified interval</returns>
		DateTime TimeBetween(DateTime start, DateTime end);
		
		/// <summary>
		/// Gets a random byte from interval [0, 255]
		/// </summary>
		byte Byte { get; }
		
		/// <summary>
		/// Gets a random byte between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than 0.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 256.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random byte in specified interval</returns>
		byte ByteBetween(int start, int end);
		
		/// <summary>
		/// Gets a random signed byte from interval [-128, 127]
		/// </summary>
		sbyte SignedByte { get; }
		
		/// <summary>
		/// Gets a random signed byte between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than -128.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 128.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random signed byte in specified interval</returns>
		sbyte SignedByteBetween(int start, int end);
		
		/// <summary>
		/// Gets a random short from interval [-32768, 32767]
		/// </summary>
		short Short { get; }
		
		/// <summary>
		/// Gets a random positive short from interval [0, 32767]
		/// </summary>
		short PositiveShort { get; }
		
		/// <summary>
		/// Gets a random short between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than -32768.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 32768.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random short in specified interval</returns>
		short ShortBetween(int start, int end);
		
		/// <summary>
		/// Gets a random unsigned short from interval [0, 65535]
		/// </summary>
		ushort UnsignedShort { get; }
		
		/// <summary>
		/// Gets a random unsigned short between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="start"/> is less than 0.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The value of <paramref name="end"/> is greater than 65536.</exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random unsigned short in specified interval</returns>
		ushort UnsignedShortBetween(int start, int end);
		
		/// <summary>
		/// Gets a random integer from interval [-2147483648, 2147483647]
		/// </summary>
		int Integer { get; }
		
		/// <summary>
		/// Gets a random integer between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random integer in specified interval</returns>
		int IntegerBetween(int start, int end);
		
		/// <summary>
		/// Gets a random integer from interval [0, 2147483647]
		/// </summary>
		int PositiveInteger { get; }
		
		/// <summary>
		/// Gets a random unsigned integer from interval [0, 4294967295]
		/// </summary>
		uint UnsignedInteger { get; }
		
		/// <summary>
		/// Gets a random unsigned integer between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random unsigned integer in specified interval</returns>
		uint UnsignedIntegerBetween(int start, int end);
		
		/// <summary>
		/// Gets a random float from interval [float.MinValue, float.MaxValue]
		/// </summary>
		float Float { get; }
		
		/// <summary>
		/// Gets a random float between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		float FloatUnit { get; }
		
		/// <summary>
		/// Gets a random float between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random float in specified interval</returns>
		float FloatBetween(float start, float end);
		
		/// <summary>
		/// Gets a random float between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		double Double { get; }
		
		/// <summary>
		/// Gets a random double precision value between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		double DoubleUnit { get; }
		
		/// <summary>
		/// Gets a random double between <paramref name="start"/> and <paramref name="end"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">The value of <paramref name="start"/> is greater than the value of <paramref name="end"/></exception>
		/// <param name="start">Inclusive lower bound</param>
		/// <param name="end">Exclusive upper bound</param>
		/// <returns>A random double in specified interval</returns>
		double DoubleBetween(double start, double end);
	}
}
