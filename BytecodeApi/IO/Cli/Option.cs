﻿using BytecodeApi.Extensions;
using BytecodeApi.Text;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace BytecodeApi.IO.Cli
{
	/// <summary>
	/// Represents a commandline option, specified by possible arguments and alternatives.
	/// <para>Example: "-p 12345" and "--password 12345"</para>
	/// </summary>
	[DebuggerDisplay(CSharp.DebuggerDisplayString)]
	public sealed class Option : IEquatable<Option>
	{
		private string DebuggerDisplay => CSharp.DebuggerDisplay<Option>("Arguments = {0}, Alternatives = {1}", new QuotedString(Arguments.AsString("|")), new QuotedString(Alternatives.AsString("|")));
		/// <summary>
		/// Gets a collection of strings that defines what arguments apply to this commandline option.
		/// </summary>
		public ReadOnlyCollection<string> Arguments { get; private set; }
		/// <summary>
		/// Gets a collection of strings that defines what arguments apply to this commandline option alternatively.
		/// </summary>
		public ReadOnlyCollection<string> Alternatives { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Option" /> class with the specified collection of arguments.
		/// </summary>
		/// <param name="arguments">A collection of strings that defines what arguments apply to this commandline option.</param>
		public Option(params string[] arguments) : this(arguments, null)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Option" /> class with the specified collection of arguments and alternatives.
		/// </summary>
		/// <param name="arguments">A collection of strings that defines what arguments apply to this commandline option.</param>
		/// <param name="alternatives">A collection of strings that defines what arguments apply to this commandline option alternatively.</param>
		public Option(string[] arguments, string[] alternatives)
		{
			Check.ArgumentNull(arguments, nameof(arguments));
			Check.ArgumentEx.ArrayElementsRequired(arguments, nameof(arguments));
			Check.ArgumentEx.ArrayValuesNotNull(arguments, nameof(arguments));
			Check.ArgumentEx.ArrayValuesNotStringEmpty(arguments, nameof(arguments));
			Check.Argument(arguments.All(item => Validate.AlphaNumeric(item) || item == "?"), nameof(arguments), "String must be alphanumeric or a single question mark.");

			if (alternatives != null)
			{
				Check.ArgumentEx.ArrayElementsRequired(arguments, nameof(arguments));
				Check.ArgumentEx.ArrayValuesNotNull(arguments, nameof(arguments));
				Check.ArgumentEx.ArrayValuesNotStringEmpty(arguments, nameof(arguments));
				Check.Argument(arguments.All(item => Validate.AlphaNumeric(item)), nameof(arguments), "String must be alphanumeric.");
			}

			Arguments = arguments.ToReadOnlyCollection();
			Alternatives = (alternatives ?? new string[0]).ToReadOnlyCollection();
		}

		/// <summary>
		/// Determines whether the specified <see cref="object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
		/// <returns>
		/// <see langword="true" />, if the specified <see cref="object" /> is equal to this instance;
		/// otherwise, <see langword="false" />.
		/// </returns>
		public override bool Equals(object obj)
		{
			return obj is Option option && Equals(option);
		}
		/// <summary>
		/// Determines whether this instance is equal to another <see cref="Option" />.
		/// </summary>
		/// <param name="other">The <see cref="Option" /> to compare to this instance.</param>
		/// <returns>
		/// <see langword="true" />, if this instance is equal to the <paramref name="other" /> parameter;
		/// otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals(Option other)
		{
			return other != null && Arguments.SequenceEqual(other.Arguments) && Alternatives.SequenceEqual(other.Alternatives);
		}
		/// <summary>
		/// Returns a hash code for this <see cref="Option" />.
		/// </summary>
		/// <returns>
		/// The hash code for this <see cref="Option" /> instance.
		/// </returns>
		public override int GetHashCode()
		{
			return CSharp.GetHashCode(Arguments.Concat(Alternatives).ToArray());
		}

		/// <summary>
		/// Compares two <see cref="Option" /> instances for equality.
		/// </summary>
		/// <param name="a">The first <see cref="Option" /> to compare.</param>
		/// <param name="b">The second <see cref="Option" /> to compare.</param>
		/// <returns>
		/// <see langword="true" />, if both <see cref="Option" /> are equal;
		/// otherwise, <see langword="false" />.
		/// </returns>
		public static bool operator ==(Option a, Option b)
		{
			return Equals(a, b);
		}
		/// <summary>
		/// Compares two <see cref="Option" /> instances for inequality.
		/// </summary>
		/// <param name="a">The first <see cref="Option" /> to compare.</param>
		/// <param name="b">The second <see cref="Option" /> to compare.</param>
		/// <returns>
		/// <see langword="true" />, if both <see cref="Option" /> are not equal;
		/// otherwise, <see langword="false" />.
		/// </returns>
		public static bool operator !=(Option a, Option b)
		{
			return !(a == b);
		}
	}
}