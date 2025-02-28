﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BytecodeApi
{
	internal static class Check
	{
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Argument(bool condition, string parameterName, string message)
		{
			if (!condition) throw new ArgumentException(message, parameterName);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ArgumentNull<T>(T parameter, string parameterName)
		{
			if (parameter == null) throw new ArgumentNullException(parameterName);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvalidOperation(bool condition, string message)
		{
			if (!condition) throw new InvalidOperationException(message);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ArgumentOutOfRange(bool condition, string parameterName, string message)
		{
			if (!condition) throw new ArgumentOutOfRangeException(parameterName, message);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void IndexOutOfRange(int index, int count)
		{
			if (index < 0 || index >= count) throw new IndexOutOfRangeException();
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void KeyNotFoundException(bool condition, string message)
		{
			if (!condition) throw new KeyNotFoundException(message);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Format(bool condition, string message)
		{
			if (!condition) throw new FormatException(message);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvalidCast(bool condition, string parameterName)
		{
			if (!condition) throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture, ExceptionMessages.InvalidCast, parameterName));
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Overflow(bool condition)
		{
			if (!condition) throw new OverflowException();
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DivideByZero(int parameter, string parameterName)
		{
			if (parameter == 0) throw new DivideByZeroException(string.Format(CultureInfo.InvariantCulture, ExceptionMessages.DivideByZero, parameterName));
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DivideByZero(long parameter, string parameterName)
		{
			if (parameter == 0) throw new DivideByZeroException(string.Format(CultureInfo.InvariantCulture, ExceptionMessages.DivideByZero, parameterName));
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void FileNotFound(string path)
		{
			if (!File.Exists(path)) throw new FileNotFoundException(null, path);
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DirectoryNotFound(string path)
		{
			if (!Directory.Exists(path)) throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, ExceptionMessages.DirectoryNotFound, path));
		}
		[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TargetParameterCount(bool condition)
		{
			if (!condition) throw new TargetParameterCountException();
		}

		public static class ArgumentEx
		{
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void StringNotEmpty(string parameter, string parameterName)
			{
				if (parameter == "") throw new ArgumentException(ExceptionMessages.Argument.StringNotEmpty, parameterName);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void StringNotEmptyOrWhiteSpace(string parameter, string parameterName)
			{
				if (parameter == "" || parameter.Any(c => char.IsWhiteSpace(c))) throw new ArgumentException(ExceptionMessages.Argument.StringNotEmptyOrWhiteSpace, parameterName);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void OffsetAndLengthOutOfBounds(int offset, int count, int length)
			{
				if (offset + count > length) throw new ArgumentException(ExceptionMessages.Argument.OffsetAndLengthOutOfBounds);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ArrayElementsRequired<T>(IEnumerable<T> parameter, string parameterName)
			{
				if (!parameter.Any()) throw new ArgumentException(ExceptionMessages.Argument.ArrayElementsRequired, parameterName);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ArrayValuesNotNull<T>(IEnumerable<T> parameter, string parameterName)
			{
				if (parameter.Any(itm => itm == null)) throw new ArgumentException(ExceptionMessages.Argument.ArrayValuesNotNull, parameterName);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void EnumerableElementsRequired(bool any, string parameterName)
			{
				if (!any) throw new ArgumentException(ExceptionMessages.Argument.EnumerableElementsRequired, parameterName);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ArrayValuesNotStringEmpty(IEnumerable<string> parameter, string parameterName)
			{
				if (parameter.Any(itm => itm == "")) throw new ArgumentException(ExceptionMessages.Argument.ArrayValuesNotStringEmpty, parameterName);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Handle(IntPtr handle, string parameterName)
			{
				if (handle == IntPtr.Zero || handle == (IntPtr)(-1)) throw new ArgumentException(ExceptionMessages.Argument.InvalidHandle, parameterName);
			}
		}
		public static class ArgumentOutOfRangeEx
		{
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(byte parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(sbyte parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(decimal parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(double parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(float parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(int parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(uint parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(long parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(ulong parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(short parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(ushort parameter, string parameterName)
			{
				if (parameter < 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqual0(TimeSpan parameter, string parameterName)
			{
				if (parameter < TimeSpan.Zero) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.GreaterEqual0);
			}

			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(byte parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(sbyte parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(decimal parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(double parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(float parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(int parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(uint parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(long parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(ulong parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(short parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(ushort parameter, string parameterName)
			{
				if (parameter <= 0) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Greater0(TimeSpan parameter, string parameterName)
			{
				if (parameter <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Greater0);
			}

			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Between0And1(decimal parameter, string parameterName)
			{
				if (parameter < 0 || parameter > 1) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Between0And1);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Between0And1(double parameter, string parameterName)
			{
				if (parameter < 0 || parameter > 1) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Between0And1);
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Between0And1(float parameter, string parameterName)
			{
				if (parameter < 0 || parameter > 1) throw new ArgumentOutOfRangeException(parameterName, ExceptionMessages.ArgumentOutOfRange.Between0And1);
			}

			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(byte parameter1, byte parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(sbyte parameter1, sbyte parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(decimal parameter1, decimal parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(double parameter1, double parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(float parameter1, float parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(int parameter1, int parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(uint parameter1, uint parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(long parameter1, long parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(ulong parameter1, ulong parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(short parameter1, short parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(ushort parameter1, ushort parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(TimeSpan parameter1, TimeSpan parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
			[DebuggerHidden, MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void GreaterEqualValue(DateTime parameter1, DateTime parameter2, string parameter1Name, string parameter2Name)
			{
				if (parameter1 < parameter2) throw new ArgumentOutOfRangeException(parameter1Name, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange.GreaterEqualValue, parameter2Name));
			}
		}
	}
}