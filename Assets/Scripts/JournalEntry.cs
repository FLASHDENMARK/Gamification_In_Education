using UnityEngine;

class JournalEntry : JournalEntryBase 
{	
	public JournalEntry (string headline) : base (headline) { }

	public JournalEntry (string headline, string body) : base (headline, body) { }
}
