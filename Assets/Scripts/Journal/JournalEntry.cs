using UnityEngine;
using System;

class JournalEntry : JournalEntryBase 
{	
	public JournalEntry (string body) : this (body, "") { }

	public JournalEntry (string body, string label)
	{
		_content = new GUIContent(body, label);
	}

	GUIContent _content;
    public override GUIContent Content
    {
    	get { return _content; }
    }
}
