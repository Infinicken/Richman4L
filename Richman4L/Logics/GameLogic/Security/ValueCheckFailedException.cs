using System;

namespace WenceyWang . Richman4L . Security
{

	public sealed class ValueCheckFailedException : Exception
	{
		public byte [ ] HashCode { get; set; }

		public byte [ ] Value { get; set; }

		internal ValueCheckFailedException ( byte [ ] hashCode , byte [ ] value ) : base ( "Hash code check failed." )
		{
			HashCode = hashCode;
			Value = value;
		}

	}

}