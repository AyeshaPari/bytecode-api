using BytecodeApi.Data;

namespace BytecodeApi.UI.Converters
{
	/// <summary>
	/// Specifies the method that is used to convert <see cref="Money" />? values.
	/// </summary>
	public enum MoneyConverterMethod
	{
		/// <summary>
		/// Returns the amount and then currency, separated by a space.
		/// </summary>
		AmountCurrency,
		/// <summary>
		/// Returns the currency and then amount, separated by a space.
		/// </summary>
		CurrencyAmount,
		/// <summary>
		/// Returns the amount.
		/// </summary>
		Amount
	}
}