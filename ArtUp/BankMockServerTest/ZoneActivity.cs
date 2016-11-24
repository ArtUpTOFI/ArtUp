using System;

namespace BankMockServerTest
{
	public sealed class ZoneActivity : IComparable<ZoneActivity>
	{
		public string Name { get; set; }

		public string Code { get; set; }

		public string Description { get; set; }

		public string LongDescription { get; set; }

		public string Start { get; set; }

		public string End { get; set; }

		public int CompareTo(ZoneActivity other)
		{
			if (other == null)
				return 1;

			return string.Compare(this.Start, other.Start, StringComparison.Ordinal);
		}
	}
}