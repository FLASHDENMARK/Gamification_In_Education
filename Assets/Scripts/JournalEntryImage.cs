using UnityEngine;
using System;

class JournalEntryImage : JournalEntryBase 
{	
	public JournalEntryImage (Texture image) : this(image, "") { }

    public JournalEntryImage (Texture image, string label)
    {
        _content = new GUIContent(image, label);
    }

    GUIContent _content;
    public override GUIContent Content
    {
        get { return _content; }
    }
}