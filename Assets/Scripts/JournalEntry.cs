using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class JournalEntry : JournalEntryBase 
{	
	// Constructor calls base Constructor
	public JournalEntry (string headline) : base (headline) {}

	// Constructor calls base Constructor
	public JournalEntry (string headline, string body) : base (headline, body) {}

	public override List<JournalEntryBase> GetEntries ()
	{
		throw new System.NotImplementedException();
	}

	public override void Select (int selection)
	{
		throw new System.NotImplementedException();
	}
}
