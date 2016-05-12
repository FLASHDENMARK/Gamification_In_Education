using UnityEngine;
using System;

class JournalEntryImage : JournalEntryBase 
{	
	public JournalEntryImage (Texture image) : this(image, "") { }

    public JournalEntryImage (Texture image, string label)
    {
        if (string.IsNullOrEmpty(label))
            throw new ArgumentNullException("An image label cannot be empty or null");
            
        _content = new GUIContent(image, label);
    }

    GUIContent _content;
    public override GUIContent Content
    {
        get { return _content; }
    }
}