using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class JournalMenu : JournalEntryBase 
{
	public JournalMenu (string subject) : base (subject, "")
	{
		_subject = subject;
	}

	string _subject;
	public string Subject 
	{
		get { return _subject; }
		private set { _subject = value; }
	}

	int _selection;
	public int Selection 
	{
		get { return _selection; }
		set {_selection = value; }
	}

	List<JournalEntryBase> journalEntries = new List<JournalEntryBase>();
	public List<JournalEntryBase> Entries
	{
		get { return journalEntries; }
	}

	public override string Body
	{
		get { return journalEntries[_selection].Body; }
	} 

	public override string Headline 
	{
		get { return journalEntries[_selection].Headline; }
	}

	// Adds a new entry to the list of entries
	public void AddJournalEntry (JournalEntryBase entry)
	{
		journalEntries.Add(entry);
	}
}
