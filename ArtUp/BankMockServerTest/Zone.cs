using System;

namespace BankMockServerTest
{
	public class Zone : IComparable<Zone>
	{
		public string Name { get; set; }

		public string Code { get; set; }

		public int IsEpamZone { get; set; }

		public string YammerFeedId { get; set; }

		public string Description { get; set; }

		public int LikesCount { get; set; }

		public bool IsLiked { get; set; }

		public ZoneActivity[] Activities { get; set; }

		public Position MarkerPosition { get; set; }

		public Position ScrollTo { get; set; }

		public int CompareTo(Zone other)
		{
			if (other == null)
				return 1;

			return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (ReferenceEquals(this, obj)) return true;
			var other = obj as Zone;
			if (other == null) return false;
			if (Name == null || other.Name == null) return false;
			if (Description == null || other.Description == null) return false;

			return Name.Equals(other.Name) && Description.Equals(other.Description);
		}

		public override int GetHashCode()
		{
			// Consider equality based on the zone names
			return 7 ^ (Name?.GetHashCode() ?? 29) ^ (Description?.GetHashCode() ?? 23);
		}
	}
}