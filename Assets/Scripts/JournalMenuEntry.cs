using System.Collections.Generic;

class JournalMenuEntry 
{
	public List<JournalEntryBase> journalEntries = new List<JournalEntryBase>();

	public JournalMenuEntry (string name)
	{
		_name = name;
	}

	string _name = "";
	public string Topic
	{
		get { return _name; }
		private set {_name = value; }
	}

	public List<JournalEntryBase> Entries 
	{
		get { return journalEntries; }
	}

	public void AddJournalEntry (JournalEntryBase entry)
	{
		journalEntries.Add(entry);
	}
}
