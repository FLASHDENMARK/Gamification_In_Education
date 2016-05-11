using UnityEngine;
using System;

class JournalEntry : JournalEntryBase 
{	
	public JournalEntry (string body)
	{ 
		_content = new GUIContent(body);
	}

	GUIContent _content;
    public override GUIContent Content
    {
    	get { return _content; }
    }
}
