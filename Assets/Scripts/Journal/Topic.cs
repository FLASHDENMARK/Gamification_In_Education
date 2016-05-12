using System.Collections.Generic;

class Topic 
{
	public Topic (string name)
	{
		_name = name;
	}
	
	List<JournalEntryBase> journalEntries = new List<JournalEntryBase>();

	string _name;
	public string Name
	{
		get { return _name; }
		private set { _name = value; }
	}

	public List<JournalEntryBase> Entries 
	{
		get { return journalEntries; }
	}

	public void AddEntry (JournalEntryBase entry)
	{
		journalEntries.Add(entry);
	}
}
