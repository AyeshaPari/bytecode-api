﻿using BytecodeApi.Extensions;
using BytecodeApi.Text;
using System;

namespace BytecodeApi.UI.Converters
{
	/// <summary>
	/// Represents the converter that converts or manipulates strings. The <see cref="Convert(string, object)" /> method returns an <see cref="object" /> based on the specified <see cref="StringConverterMethod" /> parameter.
	/// </summary>
	public sealed class StringConverter : ConverterBase<string, object, object>
	{
		/// <summary>
		/// Specifies the method that is used to convert the <see cref="string" /> value.
		/// </summary>
		public StringConverterMethod Method { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="StringConverter" /> class with the specified conversion method.
		/// </summary>
		/// <param name="method">The method that is used to convert the <see cref="string" /> value.</param>
		public StringConverter(StringConverterMethod method)
		{
			Method = method;
		}

		/// <summary>
		/// Converts or manipulates the <see cref="string" /> value based on the specified <see cref="StringConverterMethod" /> parameter.
		/// </summary>
		/// <param name="value">The <see cref="string" /> value to convert.</param>
		/// <param name="parameter">A parameter <see cref="object" /> that specifies the parameter used in some of the <see cref="StringConverterMethod" /> methods.</param>
		/// <returns>
		/// An <see cref="object" /> with the result of the conversion.
		/// </returns>
		public override object Convert(string value, object parameter)
		{
			switch (Method)
			{
				case StringConverterMethod.Concat: return value + parameter;
				case StringConverterMethod.ConcatBefore: return parameter + value;
				case StringConverterMethod.Trim: return value?.Trim();
				case StringConverterMethod.TrimStart: return value?.TrimStart();
				case StringConverterMethod.TrimStartString: return value?.TrimStartString(parameter?.ToString());
				case StringConverterMethod.TrimStartStringIgnoreCase: return value?.TrimStartString(parameter?.ToString(), true);
				case StringConverterMethod.TrimEnd: return value?.TrimEnd();
				case StringConverterMethod.TrimEndString: return value?.TrimEndString(parameter?.ToString());
				case StringConverterMethod.TrimEndStringIgnoreCase: return value?.TrimEndString(parameter?.ToString(), true);
				case StringConverterMethod.ToLower: return value?.ToLower();
				case StringConverterMethod.ToUpper: return value?.ToUpper();
				case StringConverterMethod.ToCamelCase: return value?.ChangeCasing(StringCasing.CamelCase);
				case StringConverterMethod.ToLowerSnakeCase: return value?.ChangeCasing(StringCasing.LowerSnakeCase);
				case StringConverterMethod.ToUpperSnakeCase: return value?.ChangeCasing(StringCasing.UpperSnakeCase);
				case StringConverterMethod.ToLowerKebabCase: return value?.ChangeCasing(StringCasing.LowerKebabCase);
				case StringConverterMethod.ToUpperKebabCase: return value?.ChangeCasing(StringCasing.UpperKebabCase);
				case StringConverterMethod.Substring: return value?.Substring((int)parameter);
				case StringConverterMethod.Left: return value?.Left((int)parameter);
				case StringConverterMethod.Right: return value?.Right((int)parameter);
				case StringConverterMethod.StartsWith: return value?.StartsWith(parameter?.ToString()) == true;
				case StringConverterMethod.StartsWithIgnoreCase: return value?.StartsWith(parameter?.ToString(), StringComparison.OrdinalIgnoreCase) == true;
				case StringConverterMethod.EndsWith: return value?.EndsWith(parameter?.ToString()) == true;
				case StringConverterMethod.EndsWithIgnoreCase: return value?.EndsWith(parameter?.ToString(), StringComparison.OrdinalIgnoreCase) == true;
				case StringConverterMethod.Reverse: return value?.Reverse();
				case StringConverterMethod.Contains: return value?.Contains(parameter?.ToString()) == true;
				case StringConverterMethod.ContainsIgnoreCase: return value?.Contains(parameter?.ToString(), SpecialStringComparisons.IgnoreCase) == true;
				case StringConverterMethod.ReplaceLineBreaks: return value?.ReplaceLineBreaks(parameter?.ToString());
				case StringConverterMethod.TrimText: return value == null ? null : Wording.TrimText(value, (int)parameter);
				case StringConverterMethod.StringDistanceLevenshtein: return value != null && parameter is string ? StringDistance.Levenshtein(value, (string)parameter) : (int?)null;
				case StringConverterMethod.StringDistanceDamerauLevenshtein: return value != null && parameter is string ? StringDistance.DamerauLevenshtein(value, (string)parameter) : (int?)null;
				default: throw Throw.InvalidEnumArgument(nameof(Method), Method);
			}
		}
	}
}