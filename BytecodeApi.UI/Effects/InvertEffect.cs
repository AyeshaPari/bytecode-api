using BytecodeApi.UI.Extensions;
using BytecodeApi.UI.Properties;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace BytecodeApi.UI.Effects
{
	/// <summary>
	/// Provides a bitmap effect that inverts the colors of an image.
	/// </summary>
	public sealed class InvertEffect : ShaderEffect
	{
		/// <summary>
		/// Identifies the <see cref="Input" /> dependency property. This field is read-only.
		/// </summary>
		public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(InvertEffect), 0);
		/// <summary>
		/// Gets or sets a <see cref="Brush" /> that applies an invert effect on the bitmap.
		/// </summary>
		public Brush Input
		{
			get => this.GetValue<Brush>(InputProperty);
			set => SetValue(InputProperty, value);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvertEffect" /> class.
		/// </summary>
		public InvertEffect()
		{
			PixelShader = new PixelShader();
			PixelShader.SetStreamSource(new MemoryStream(Resources.FileInvertEffect));
			UpdateShaderValue(InputProperty);
		}
	}
}