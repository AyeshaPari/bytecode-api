﻿using System.Globalization;

namespace BytecodeApi.Extensions
{
	/// <summary>
	/// Provides a set of <see langword="static" /> methods for interaction with <see cref="decimal" /> objects.
	/// </summary>
	public static class DecimalExtensions
	{
		/// <summary>
		/// Converts the value of this <see cref="decimal" /> to its equivalent <see cref="string" /> representation using the invariant culture.
		/// </summary>
		/// <param name="value">The <see cref="decimal" /> value to convert.</param>
		/// <returns>
		/// The equivalent <see cref="string" /> representation of this <see cref="decimal" />.
		/// </returns>
		public static string ToStringInvariant(this decimal value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}
		/// <summary>
		/// Converts the value of this <see cref="decimal" /> to its equivalent <see cref="string" /> representation using a specified format and the invariant culture.
		/// </summary>
		/// <param name="value">The <see cref="decimal" /> value to convert.</param>
		/// <param name="format">A <see cref="string" /> value with the format that is used to convert this <see cref="decimal" />.</param>
		/// <returns>
		/// The equivalent <see cref="string" /> representation of this <see cref="decimal" />.
		/// </returns>
		public static string ToStringInvariant(this decimal value, string format)
		{
			return value.ToString(format, CultureInfo.InvariantCulture);
		}
		/// <summary>
		/// Returns <see langword="null" />, if this <see cref="decimal" /> value is 0.0m, otherwise its original value.
		/// </summary>
		/// <param name="value">The <see cref="decimal" /> value to convert.</param>
		/// <returns>
		/// <see langword="null" />, if this <see cref="decimal" /> value is 0.0m;
		/// otherwise, its original value.
		/// </returns>
		public static decimal? ToNullIfDefault(this decimal value)
		{
			return value == default ? null : (decimal?)value;
		}
	}
}