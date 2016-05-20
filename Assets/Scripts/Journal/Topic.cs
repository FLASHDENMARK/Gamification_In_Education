using System.Collections.Generic;

class Topic 
{
	public Topic (string name)
	{
		_name = name;
	}
	
	List<EntryBase> journalEntries = new List<EntryBase>();

	string _name;
	public string Name
	{
		get { return _name; }
		private set { _name = value; }
	}

	public List<EntryBase> Entries 
	{
		get { return journalEntries; }
	}

	public void AddEntry (EntryBase entry)
	{
		journalEntries.Add(entry);
	}
}
