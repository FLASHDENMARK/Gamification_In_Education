using System.Collections.Generic;

class Subject
{
 	public Subject (string name)
 	{
 		this.Name = name;
 	}

	List<Topic> _topics = new List<Topic>();

 	string _name;
 	public string Name 
 	{
 		get { return _name; }
 		private set { _name = value; }
 	}

 	int _selection;
 	public int Selection
 	{
 		get { return _selection; }
 		set {_selection = value; }
 	}

 	public List<Topic> Entries
 	{
 		get { return _topics; }
 	}
 
 	// Adds a new entry to the list of entries
 	public void AddTopic (Topic entry)
 	{
 		_topics.Add(entry);
 	}
}