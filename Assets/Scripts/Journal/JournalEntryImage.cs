using UnityEngine;

class JournalEntryImage : JournalEntryBase 
{	
	public JournalEntryImage (Texture image) 
        : this(image, "") { }

    public JournalEntryImage (Texture image, string label) 
        : base(new GUIContent(image, label)) { }
}