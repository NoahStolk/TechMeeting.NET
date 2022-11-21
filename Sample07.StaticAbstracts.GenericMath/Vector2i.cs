using System.Globalization;
using System.Numerics;
using System.Text;

namespace Sample07.StaticAbstracts.GenericMath;

public record struct Vector2i<T>(T X, T Y) : IFormattable
	where T : IBinaryInteger<T>, IMinMaxValue<T>
{
	public Vector2i(T value)
		: this(value, value)
	{
	}

	public static Vector2i<T> Zero => default;

	public static Vector2i<T> One => new(T.One);

	public static Vector2i<T> UnitX => new(T.One, T.Zero);

	public static Vector2i<T> UnitY => new(T.Zero, T.One);

	public static Vector2i<T> operator +(Vector2i<T> left, Vector2i<T> right)
		=> new(left.X + right.X, left.Y + right.Y);

	public static Vector2i<T> operator -(Vector2i<T> left, Vector2i<T> right)
		=> new(left.X - right.X, left.Y - right.Y);

	public static Vector2i<T> operator *(Vector2i<T> left, Vector2i<T> right)
		=> new(left.X * right.X, left.Y * right.Y);

	public static Vector2i<T> operator *(Vector2i<T> left, T right)
		=> left * new Vector2i<T>(right);

	public static Vector2i<T> operator *(T left, Vector2i<T> right)
		=> right * left;

	public static Vector2i<T> operator /(Vector2i<T> left, Vector2i<T> right)
		=> new(left.X / right.X, left.Y / right.Y);

	public static Vector2i<T> operator /(Vector2i<T> value1, T value2)
		=> value1 / new Vector2i<T>(value2);

	public static Vector2i<T> operator -(Vector2i<T> value)
		=> Zero - value;

	public static Vector2i<T> Max(Vector2i<T> value1, Vector2i<T> value2)
	{
		return new(
			value1.X > value2.X ? value1.X : value2.X,
			value1.Y > value2.Y ? value1.Y : value2.Y);
	}

	public static Vector2i<T> Min(Vector2i<T> value1, Vector2i<T> value2)
	{
		return new(
			value1.X < value2.X ? value1.X : value2.X,
			value1.Y < value2.Y ? value1.Y : value2.Y);
	}

	public static Vector2i<T> Abs(Vector2i<T> value)
		=> new(T.Abs(value.X), T.Abs(value.Y));

	public static Vector2i<T> Clamp(Vector2i<T> value1, Vector2i<T> min, Vector2i<T> max)
		=> Min(Max(value1, min), max);

	public override readonly string ToString()
		=> ToString("G", CultureInfo.CurrentCulture);

	public readonly string ToString(string? format)
		=> ToString(format, CultureInfo.CurrentCulture);

	public readonly string ToString(string? format, IFormatProvider? formatProvider)
	{
		StringBuilder sb = new();
		string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
		sb.Append('<');
		sb.Append(X.ToString(format, formatProvider));
		sb.Append(separator);
		sb.Append(' ');
		sb.Append(Y.ToString(format, formatProvider));
		sb.Append('>');
		return sb.ToString();
	}
}
