using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// The JournalManager wont work without EntryList
// Tell Unity that we always need the EntryList.
[RequireComponent(typeof(EntryList))]

// Manages the main behaviour of the journal
class JournalManager : MonoBehaviour 
{
    public EntryList entryList = null;
    // The position and scale of the UI Window (assigned through Inspector)
    public Rect windowRect;
    // Show the journal or not (statically accessible)
    public static bool ShowJournal;
    // The color of the highlighted GUI 
    Color _highlight = Color.grey;
    // Index of selected entry
    int _selection;
    // A list of all subjects
    List<Subject> _subjects = new List<Subject>();

    Subject CurrentSubject
    {
        get { return _subjects[_selection]; }
    }

    Topic CurrentTopic 
    {
        get { return CurrentSubject.Entries[CurrentSubject.Selection]; }
    }

    List<Topic> Topics
    {
        get { return CurrentSubject.Entries; }
    }

    // Adds a new subject to the list of subjects
    public void AddSubject (Subject subject)
    {
        _subjects.Add(subject);
    }

    bool _initialized = false;

    // Is called once when the application starts
    void Start () 
    {
        Language.OnLanguageChanged += CreateEntries;
    }

    void CreateEntries ()
    {
        entryList.CreateEntries(this);

        _initialized = true;
    }

    // Called every frame
    void Update ()
    {
        // Check if the user has pressed down the control button(s)
        if (KeyCheck() && _initialized)
        {
            // Change the ShowJournal state from true to false or false to true
            ShowJournal = !ShowJournal; 
        }
    }

    bool KeyCheck ()
    {
        return Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);
    }

    // Called every frame and draws UI elements on screen
    void OnGUI ()
    {
        if (_initialized)
        {
            ScaleToScreenSize();
    
            if (ShowJournal)
            {
                GUI.backgroundColor = new Color(0, 0, 0, 1);

                GUI.Box(new Rect(0, 0, 20000, 10000), "");
                GUI.Box(new Rect(0, 0, 20000, 10000), "");
                GUI.Box(new Rect(0, 0, 20000, 10000), "");

                DrawMenuAndSubjects();
            }

            string english = "Press CTRL to " + (ShowJournal? "hide" : "show") + " the Professor's Journal";
            string danish = "Tryk CTRL for at " + (ShowJournal? "skjule" : "vise") + " professorens notesbog";

            // Let the user know how to toggle the Journal on and off
            GUI.Box(new Rect(0, 450, 310, 30), Language.IsDanish? danish : english);
        }
    }

    void DrawMenuAndSubjects ()
    {   
        // Draw all the subjects
        for (int i = 0; i < _subjects.Count; i++)
        {
            if (i == _selection)
            {
                Highlight();
            }

            if (GUI.Button(new Rect(50, 30 + 45 * i, 120, 30), _subjects[i].Name))
            {
                _selection = i;
            }

            ResetHighlight();
        }

        // Draw all the topic under the current subject
        for (int i = 0; i < Topics.Count; i++)
        {
            if (i == _subjects[_selection].Selection)
            {
                Highlight();
            }

            if (GUI.Button(new Rect(190, 30 + 45 * i, 205, 30), Topics[i].Name))
            {
                _subjects[_selection].Selection = i;
            }

            ResetHighlight();
        }   

        windowRect = GUI.Window(0, windowRect, TheoryUIWindow, CurrentTopic.Name);
    }

    Vector2 scrollPosition;

    float totalHeight = 0;
    // Draws the currently selected subject to the screen
    void TheoryUIWindow (int windowID) 
    {   
        float width = windowRect.width-30;
        // The XY position and XY width of a "scroll view", which allows us to scroll 
        // through the text if it exceeds its boundaries
        Rect scrollPosAndSize = new Rect(10, 20, width+20, 375);
        // The current "scroll position" (how much we have scrolled up/down, left/right)
        Rect scrollView = new Rect(0, 0, width, totalHeight);
        totalHeight = 0;

        // Draw a scroll view
        scrollPosition = GUI.BeginScrollView(scrollPosAndSize, scrollPosition, scrollView);
            List<EntryBase> journalEntries = CurrentTopic.Entries;

            for (int i = 0; i < journalEntries.Count; i++)
            {
                GUIContent g = journalEntries[i].Content;
                float height = GUIHeight(g, width);

                // Are we about to draw an image to the screen?
                if (g.image)
                {
                    // Aligns the image to the center
                    GUI.skin.label.alignment = TextAnchor.UpperCenter;
                    // Draws the image
                    GUI.Label(new Rect(0, totalHeight, width, height), g);
                    // Draws the label for the image
                    GUI.Label(new Rect(0, totalHeight + height, width, height), "<i>" + g.tooltip + "</i>");
                    // Reset the alignment
                    GUI.skin.label.alignment = TextAnchor.UpperLeft;
                    // Increment the height of the window
                    totalHeight += GUIHeight(new GUIContent(g.tooltip), width);
                }
                // We are about to draw a text
                else
                {
                    if (!string.IsNullOrEmpty(g.tooltip))
                    {
                        GUI.skin.label.alignment = TextAnchor.UpperCenter;
                        GUI.Label(new Rect(0, totalHeight, width, height), "<b>" + g.tooltip + "</b>");
                        GUI.skin.label.alignment = TextAnchor.UpperLeft;
                        totalHeight += GUIHeight(new GUIContent(g.tooltip), width);
                    }

                    GUI.Label(new Rect(0, totalHeight, width, height), g);
                }

                totalHeight += height;
            }

        // This "ends" the scroll view
        GUI.EndScrollView();
    }

    // Scales the UI to match the screen size
    void ScaleToScreenSize ()
    {
        float screenWidth = Screen.width / 853.0F; // 853 is the native width of the original screen
        float screenHeight = Screen.height / 480.0F; // 480 is the native height of the original screen

        // This makes the UI scale automatically. It creates a Translation, Rotation and Scaling(TRS) matrix.
        // The returned matrix means that positions, rotations and scale that once fit the native width/height 
        // will now scale properly on (almost) any screen
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, 
            new Vector3(screenWidth, screenHeight, 1)); 
    }

    float GUIHeight (GUIContent g, float width)
    {
        return GUI.skin.label.CalcHeight(g, width);
    }

    void Highlight ()
    {
        GUI.contentColor = _highlight;
    }

    void ResetHighlight ()
    {
        GUI.contentColor = Color.white;
    }
}