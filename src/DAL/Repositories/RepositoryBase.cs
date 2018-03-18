using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DAL.Repositories
{
	public class RepositoryBase
	{
		protected UnitOfWork UnitOfWork { get; }

		public RepositoryBase(UnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}
		protected SqlConnection GetConnection()
		{
			return new SqlConnection(UnitOfWork.ConnectionString);
		}

		public static object GetNullableDbValue(object value)
		{
			if (value == DBNull.Value)
				return null;
			return value;
		}

		public static string GetString(object value)
		{
			string nullableDbValue = (string)GetNullableDbValue(value);
			if (nullableDbValue == null)
				return "";
			return nullableDbValue.Trim();
		}

		public static sbyte GetSByte(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return 0;
			return Convert.ToSByte(nullableDbValue);
		}

		public static byte GetByte(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return 0;
			return Convert.ToByte(nullableDbValue);
		}

		public static int GetInteger(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return 0;
			return (int)nullableDbValue;
		}

		public static long GetLong(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return 0;
			return (long)nullableDbValue;
		}

		public static double GetDouble(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return 0.0;
			return (double)nullableDbValue;
		}

		public static Decimal GetDecimal(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return Decimal.Zero;
			return (Decimal)nullableDbValue;
		}

		public static bool GetBoolean(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return false;
			return (bool)nullableDbValue;
		}

		public static DateTime GetDateTime(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return DateTime.MinValue;
			return (DateTime)nullableDbValue;
		}

		public static string GetNullableString(object value)
		{
			string nullableDbValue = (string)GetNullableDbValue(value);
			return nullableDbValue?.Trim();
		}

		public static sbyte? GetNullableSByte(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			return nullableDbValue == null ? new sbyte?() : Convert.ToSByte(nullableDbValue);
		}

		public static byte? GetNullableByte(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			return nullableDbValue == null ? new byte?() : Convert.ToByte(nullableDbValue);
		}

		public static int? GetNullableInteger(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return new int?();
			return (int)nullableDbValue;
		}

		public static long? GetNullableLong(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return new long?();
			return (long)nullableDbValue;
		}

		public static double? GetNullableDouble(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return new double?();
			return (double)nullableDbValue;
		}

		public static Decimal? GetNullableDecimal(object value)
		{
			object nullableDbValue = GetNullableDbValue(value);
			return (decimal?) nullableDbValue;
		}

		public static bool? GetNullableBoolean(object value)
		{
			var nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return new bool?();
			return (bool)nullableDbValue;
		}

		public static DateTime? GetNullableDateTime(object value)
		{
			var nullableDbValue = GetNullableDbValue(value);
			if (nullableDbValue == null)
				return new DateTime?();
			return (DateTime)nullableDbValue;
		}

		public static string XAttributeValue(XAttribute attribute)
		{
			return attribute?.Value;
		}

		public static string XElementValue(XElement element)
		{
			return element?.Value;
		}

		public static string XElementStringValue(XElement element)
		{
			return element?.ToString();
		}
	}
}
