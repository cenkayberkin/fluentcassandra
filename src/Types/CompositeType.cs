﻿using System;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FluentCassandra.Types
{
	public class CompositeType : CassandraType
	{
		private static readonly CompositeTypeConverter Converter = new CompositeTypeConverter();

		#region Implimentation

		public override object GetValue(Type type)
		{
			return GetValue(_value, type, Converter);
		}

		public override void SetValue(object obj)
		{
			_value = (List<CassandraType>)SetValue(obj, Converter);
		}

		protected override TypeCode TypeCode
		{
			get { return TypeCode.Object; }
		}

		public override string ToString()
		{
			return GetValue<string>();
		}

		#endregion

		private List<CassandraType> _value;

		#region Equality

		public override bool Equals(object obj)
		{
			List<CassandraType> objArray;

			if (obj is CompositeType)
				objArray = ((CompositeType)obj)._value;
			else
				objArray = CassandraType.GetValue<List<CassandraType>>(obj, Converter);

			if (objArray == null)
				return false;

			if (objArray.Count != _value.Count)
				return false;

			for (int i = 0; i < objArray.Count; i++)
			{
				if (!_value[i].Equals(objArray[i]))
					return false;
			}

			return true;
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		#endregion

		#region Conversion

		public static implicit operator List<CassandraType>(CompositeType type)
		{
			return type._value;
		}

		public static implicit operator CompositeType(CassandraType[] s)
		{
			return new CompositeType { _value = new List<CassandraType>(s) };
		}

		public static implicit operator CompositeType(List<CassandraType> s)
		{
			return new CompositeType { _value = s };
		}

		public static implicit operator byte[](CompositeType o) { return ConvertTo<byte[]>(o); }
		public static implicit operator CompositeType(byte[] o) { return ConvertFrom(o); }

		private static T ConvertTo<T>(CompositeType type)
		{
			if (type == null)
				return default(T);

			return type.GetValue<T>();
		}

		private static CompositeType ConvertFrom(object o)
		{
			var type = new CompositeType();
			type.SetValue(o);
			return type;
		}

		#endregion
	}
}
