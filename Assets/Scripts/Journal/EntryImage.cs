using UnityEngine;

class EntryImage : EntryBase 
{	
	public EntryImage (Texture image) 
        : this(image, "") { }

    public EntryImage (Texture image, string label) 
        : base(new GUIContent(image, label)) { }
}