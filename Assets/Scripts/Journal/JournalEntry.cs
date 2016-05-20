using UnityEngine;

class JournalEntry : JournalEntryBase 
{	
	public JournalEntry (string body) 
		: this(body, "") { }

	public JournalEntry (string body, string label) 
		: base(new GUIContent(body, label)) { }
}
