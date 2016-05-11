using System.Collections.Generic;

class JournalMenu
{
	public List<JournalMenuEntry> menuEntries = new List<JournalMenuEntry>();
 	
 	public JournalMenu (string headline)
 	{
 		this.Headline = headline;
 	}

 	string _headline;
 	public string Headline 
 	{
 		get { return _headline; }
 		private set { _headline = value; }
 	}

 	int _selection;
 	public int Selection
 	{
 		get { return _selection; }
 		set {_selection = value; }
 	}

 	public List<JournalMenuEntry> Entries
 	{
 		get { return menuEntries; }
 	}
 
 	// Adds a new entry to the list of entries
 	public void AddMenuEntry (JournalMenuEntry entry)
 	{
 		menuEntries.Add(entry);
 	}
}