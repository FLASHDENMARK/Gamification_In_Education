using UnityEngine;

class EntryText : EntryBase 
{	
	public EntryText (string body) 
		: this(body, "") { }

	public EntryText (string body, string label) 
		: base(new GUIContent(body, label)) { }
}
