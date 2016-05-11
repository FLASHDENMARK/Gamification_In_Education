using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class JournalMenu : JournalEntryBase
{
	List<JournalEntryBase> journalEntries = new List<JournalEntryBase>();
 	
 	public JournalMenu (string headline) : base (headline, "")
 	{
 		this.Headline = headline;
 	}

 	string _headline;
 	public override string Headline 
 	{
 		get { return _headline; }
 		private set { _headline = value; }
 	}

 	public override string Body
 	{
 		get { return journalEntries[_selection].Body; }
 	}

 	int _selection;
 	public int Selection
 	{
 		get { return _selection; }
 		set {_selection = value; }
 	}

 	public List<JournalEntryBase> Entries
 	{
 		get { return journalEntries; }
 	}
 
 	// Adds a new entry to the list of entriesx
 	public void AddJournalEntry (JournalEntryBase entry)
 	{
 		journalEntries.Add(entry);
 	}
}