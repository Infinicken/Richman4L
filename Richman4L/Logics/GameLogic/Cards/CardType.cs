using System;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Cards
{
	public sealed class CardType
	{
		public string Name { get; }

		public string Introduction { get; }

		public Type EntryType { get; }

		internal CardType ( Type entryType , XElement element )
		{
			EntryType = entryType;

			#region Load XML



			#endregion
		}

	}
}