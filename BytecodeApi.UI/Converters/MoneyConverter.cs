﻿using BytecodeApi.Data;

namespace BytecodeApi.UI.Converters
{
	/// <summary>
	/// Represents the converter that converts <see cref="Money" />? values to an equivalent <see cref="string" /> representation. The <see cref="Convert(Money?)" /> method returns a <see cref="string" /> based on the specified parameters using the <see cref="Money.Format()" /> method.
	/// </summary>
	public sealed class MoneyConverter : ConverterBase<Money?, string>
	{
		/// <summary>
		/// Specifies the method that is used to convert the <see cref="Money" />? value.
		/// </summary>
		public MoneyConverterMethod Method { get; set; }
		/// <summary>
		/// Specifies the number of decimals to round the result to. The default value is 2.
		/// </summary>
		public int Decimals { get; set; }
		/// <summary>
		/// <see langword="true" /> to use a thousands separator.
		/// </summary>
		public bool ThousandsSeparator { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="MoneyConverter" /> class.
		/// </summary>
		public MoneyConverter() : this(MoneyConverterMethod.AmountCurrency)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MoneyConverter" /> class with the specified parameters.
		/// </summary>
		/// <param name="method">The method that is used to convert the <see cref="Money" />? value.</param>
		public MoneyConverter(MoneyConverterMethod method) : this(method, 2)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MoneyConverter" /> class with the specified parameters.
		/// </summary>
		/// <param name="method">The method that is used to convert the <see cref="Money" />? value.</param>
		/// <param name="decimals">The number of decimals to round the result to. The default value is 2.</param>
		public MoneyConverter(MoneyConverterMethod method, int decimals) : this(method, decimals, true)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MoneyConverter" /> class with the specified parameters.
		/// </summary>
		/// <param name="method">The method that is used to convert the <see cref="Money" />? value.</param>
		/// <param name="decimals">The number of decimals to round the result to. The default value is 2.</param>
		/// <param name="thousandsSeparator"><see langword="true" /> to use a thousands separator.</param>
		public MoneyConverter(MoneyConverterMethod method, int decimals, bool thousandsSeparator)
		{
			Method = method;
			Decimals = decimals;
			ThousandsSeparator = thousandsSeparator;
		}

		/// <summary>
		/// Converts the <see cref="Money" />? value based on the specified parameters.
		/// </summary>
		/// <param name="value">The <see cref="Money" />? value to convert.</param>
		/// <returns>
		/// A <see cref="string" /> with the result of the conversion.
		/// </returns>
		public override string Convert(Money? value)
		{
			if (value == null)
			{
				return null;
			}
			else
			{
				string amount = value?.Format(Decimals, ThousandsSeparator, false);

				switch (Method)
				{
					case MoneyConverterMethod.AmountCurrency: return $"{amount} {value?.Currency}";
					case MoneyConverterMethod.CurrencyAmount: return $"{value?.Currency} {amount}";
					case MoneyConverterMethod.Amount: return amount;
					default: throw Throw.InvalidEnumArgument(nameof(Method), Method);
				}
			}
		}
	}
}