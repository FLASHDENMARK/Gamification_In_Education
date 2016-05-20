using UnityEngine;
using System;

public class EntryBase : MonoBehaviour
{
	public EntryBase (GUIContent content)
	{
		if (content.image && string.IsNullOrEmpty(content.tooltip))
		{
			throw new ArgumentNullException("A figure label cannot be empty or null");
		}

		_content = content;
	}

	GUIContent _content;
    public GUIContent Content
    {
    	get { return _content; }
    }
}