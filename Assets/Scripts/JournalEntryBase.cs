using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class JournalEntryBase : MonoBehaviour
{
    public abstract GUIContent Content
    {
        get;
    }
}
