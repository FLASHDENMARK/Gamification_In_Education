using UnityEngine;
using System;

public class JournalEntryBase : MonoBehaviour
{
	public JournalEntryBase (GUIContent content)
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