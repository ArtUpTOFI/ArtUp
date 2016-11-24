namespace BankMockServerTest
{
	public sealed class Event
	{
        public Welcome Welcome { get; set; }

		public Zone[] Zones { get; set; }

		public FaqItem[] FaqItems { get; set; }

		public string InstaTag { get; set; }

		public int GlobalLikes { get; set; }

        public bool IsOnline { get; set; }
    }
}