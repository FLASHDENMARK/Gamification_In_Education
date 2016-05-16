using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Manages the main behaviour of the journal
class JournalManager : MonoBehaviour 
{
	// A list of all subjects
	List<Subject> subjects = new List<Subject>();
	// Index of selected entry
	int _selection;
	// The body (text) of the selected entry
	string _body;
	// The position and scale of the UI Window (assigned through Inspector)
	public Rect windowRect;
	// Show the journal or not (statically accessible)
	public static bool ShowJournal;
	// The color of the highlighted GUI 
	Color _highlight = Color.grey;

	Subject CurrentSubject
	{
		get { return subjects[_selection]; }
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
		subjects.Add(subject);
	}

	bool _initialized = false;

	// Is called once when the application starts
	void Start () 
	{
		//HowToAddTopic();
		Language.language += CreateEntries;
	}

	void CreateEntries ()
	{
		if (Language.IsDanish)
		{
			CreateIntroDanish();
			CreateMathematicsDanish();
			CreatePhysicsDanish();
		}
		else
		{
			CreateIntroEnglish();
			CreateMathematicsEnglish();
			CreatePhysicsEnglish();
		}

		_initialized = true;
	}

	void HowToAddTopic ()
	{
		// Create a new subject if the subject doesn't already exist
		Subject newSubject = new Subject("New Subject");
		// Add the new subject to a list of all subjects
		AddSubject(newSubject);
		// Create a new topic
		Topic newTopic = new Topic("New Topic");
		// Add the topic to the subject
		newSubject.AddTopic(newTopic);

		// Add text(JournalEntry) / images(JournalEntryImage) to the topic
		newTopic.AddEntry(new JournalEntry("This is a piece of text for the topic: New Topic", "This is a label for this text (optional)"));
		newTopic.AddEntry(new JournalEntryImage(new Texture2D(100, 100), "This is a label for this image"));
		// The above can be done in any order no matter how many entries
	}

	void CreateIntroEnglish ()
	{
        Subject intro = new Subject("Intro");
        AddSubject(intro);

        Topic aboutThisJournal = new Topic("About this journal");
        intro.AddTopic(aboutThisJournal);

        string aboutThisJournalText =
        "<b>This journal belongs to Science Professor Jameson</b>"
        + "\n\nThis journal contains the discoveries I have done, through various experiments."
        + " The finds are divided into chapters of their respective subjects."
        + "\n\nIf you are to find this book, please return it to me."
        + "\n\n<i>-- Prof. Jameson</i>";

        // Adds an entry to the topic. 
        aboutThisJournal.AddEntry(new JournalEntry(aboutThisJournalText));
	}

	void CreateIntroDanish ()
	{
        Subject intro = new Subject("Intro");
        AddSubject(intro);

        Topic aboutThisJournal = new Topic("Om denne notesbog");
        intro.AddTopic(aboutThisJournal);

        string aboutThisJournalText =
        "SKRIV";

        // Adds an entry to the topic. 
        aboutThisJournal.AddEntry(new JournalEntry(aboutThisJournalText));
	}

	public Texture geometrySquare = null;
	public Texture geometryRectangle = null;
	public Texture geometryTriangle = null;
	public Texture geometryCircle = null;

	void CreateMathematicsEnglish ()
	{
        Subject mathematics = new Subject("Mathematics");
        AddSubject(mathematics);

        Topic orderOfOperations = new Topic("Order of operations");
        mathematics.AddTopic(orderOfOperations);

        string orderOfOperationsText = "It seems that math can be misleading at times."
        + "\nI have found that the order of operations is quite important."
        + "\n\nHere's an example:"
        + "\nWe have two sticks, and then 4 sets of 3 sticks."
        + "\n || +(||| + ||| + ||| + |||)"
        + "\n\nThe mathematcial equation would then be:"
        + "\n\n<b>2+3×4</b>"
        + "\n2+3 = 5, that leaves us with 5×4."
        + "\n5×4 = 20 right? Wrong. Count the sticks for yourself, are there 20 sticks above?"
        + "\nNo, right? The correct equation would be:"
        + "\n\n<b>2+3×4</b>"
        + "\n3×4 = 12, which leaves us with: 2 + 12 = 14."
        + "\n14 sticks, just as above."
        + "\n\nIt seems that you have to multiply and divide, before addition and subtraction, to get the right result."
        + "\nFurthermore it seems that parenthesis should be calculated as the very first thing of an equation."
        + "\nthen we should calculate roots and exponents, then multiplication and division, and lastly addition and subtraction."
        + "\n\nI have come up with an easier way to remember this order. I call it PEMDAS and it stands for"
        + "\nParentheses, exponents, multiply, devide, add and subtract."
        + "\n\nAs long as equations are calculated in this order, then the result will always be correct."
        +"\n\n<i>-- Prof. Jameson</i>";

        orderOfOperations.AddEntry(new JournalEntry(orderOfOperationsText));

        Topic geometry = new Topic("Geometry");
        mathematics.AddTopic(geometry);

		string geometryTextIntro = "Through years of research I have finally cracked the "
		+ "relationship between geometry and their area and volume - how exciting! "
		+ "\n\nCalculating the area of geometrical figures seems easier than finding the volume."
		+ "This is because area is the '<i>size of a flat surface</i>', whereas volume is "
		+ "the '<i>amount of space inside an object</i>'.";

		string geometryTextSquare = "Let me start with one of the most basic geometric shapes: The square."
		+ "The square is simple because it is the same length on all sides. The formula for area for a square "
		+ "is in the name. It is the length of A multiplied with A. This means the area of a square is <i> A squared!</i>";

		string geometryTextRectangle = "The area of a rectangle is similar to the area of a square. "
		+ "The calculation is identical to the area of the square, except the rectangle does not have the same length on all sides. "
		+ "For this reason the area of a rectangle is A multiplied by B, where B is different from A.";

		string geometryTextTriangle = "Another calculation related to the area of rectangles and squares is the area of a triangle. "
		+ "The area of a triangle is super simple if you know how to calculate the area of a rectangle, because the area of a triangle "
		+ "is simply the half the area of a rectangle. <i>Amazing!</i>";

		string geometryTextCircle = "Circles are unfortunately not <i>directly</i> related to triangles, rectangles or squares... "
		+ "However I have found that when I needed to calculate anything related to circles I need to use something I have jokenly called 'PIE'. "
		+ "PIE is a mathematical constant and I have even given it a fancy symbol too: π. It is a very long number, so I just remember it as roughly 3.14. "
		+ "\n\nLuckily calculating the area of a circle is somewhat like calculating the area of a square. We multiply A by A and then we will multiply that result by PIE. "
		+ "However since this is a circle and not a square we will use the term R (for radius) instead of A. I have found that π has many practical uses.";

        geometry.AddEntry(new JournalEntry(geometryTextIntro));
        geometry.AddEntry(new JournalEntry(geometryTextSquare, "Area"));
        geometry.AddEntry(new JournalEntryImage(geometrySquare, "The area of a square"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle));
        geometry.AddEntry(new JournalEntryImage(geometryRectangle, "The area of a rectangle"));
        geometry.AddEntry(new JournalEntry(geometryTextTriangle));
        geometry.AddEntry(new JournalEntryImage(geometryTriangle, "The area of a triangle"));
        geometry.AddEntry(new JournalEntry(geometryTextCircle));
        geometry.AddEntry(new JournalEntryImage(geometryCircle, "The area of a circle"));

		string geometryTextCube = "Volume is the amount of space occupied by an object and calculating it builds upon knowledge from area calculation, but let us start simple. "
		+ "\n\nCalculating the volume of a cube is relatively simple. It is just like calculating the area of a square, but this time we just multiply by A one more time. "
		+ "This turns the calculation from 2D to 3D and only 3D objects have volumes. 3D objects have a width, height <i>and</i> depth, where as 2D objects only have a width and a height.";

		string geometryTextRectangle3D = "Calculating the volume of a 3D rectangle is done just the same way of calculating the area of a rectangle, except we have to remember to multiply by the depth as well.";

        geometry.AddEntry(new JournalEntry(geometryTextCube, "Volume"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle3D));
	}

	void CreateMathematicsDanish ()
	{
        Subject mathematics = new Subject("Matematik");
        AddSubject(mathematics);

        Topic orderOfOperations = new Topic("Order of operations");
        mathematics.AddTopic(orderOfOperations);

        string orderOfOperationsText = "Skriv";

        orderOfOperations.AddEntry(new JournalEntry(orderOfOperationsText));

        Topic geometry = new Topic("Geometri");
        mathematics.AddTopic(geometry);

		string geometryTextIntro = "Skriv";

		string geometryTextSquare = "Skriv";

		string geometryTextRectangle = "Skriv";

		string geometryTextTriangle = "Skriv";

		string geometryTextCircle = "Skriv";

        geometry.AddEntry(new JournalEntry(geometryTextIntro));
        geometry.AddEntry(new JournalEntry(geometryTextSquare, "Area"));
        geometry.AddEntry(new JournalEntryImage(geometrySquare, "The area of a square"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle));
        geometry.AddEntry(new JournalEntryImage(geometryRectangle, "The area of a rectangle"));
        geometry.AddEntry(new JournalEntry(geometryTextTriangle));
        geometry.AddEntry(new JournalEntryImage(geometryTriangle, "The area of a triangle"));
        geometry.AddEntry(new JournalEntry(geometryTextCircle));
        geometry.AddEntry(new JournalEntryImage(geometryCircle, "The area of a circle"));

		string geometryTextCube = "Skriv";

		string geometryTextRectangle3D = "Skriv";

        geometry.AddEntry(new JournalEntry(geometryTextCube, "Volume"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle3D));
	}

	void CreatePhysicsEnglish ()
	{
		Subject physics = new Subject("Physics");
		AddSubject(physics);

        Topic fireTriangle = new Topic("Fire Triangle");
        physics.AddTopic(fireTriangle);

        string fireTriangleText =
        "I have spend the entire day, analyzing the behaviour of fire, and I think I have figured it out. "
        + "It seems that the ability to create a fire is based on three primary factors. "
        + "I have not been able to produce a fire without these components, so they seem essential in creating a fire. "
        + "\n\nFirstly to create a fire, I need something that can serve as a fuel, something that can burn. \n\n"
        + "I have also found that creating a fire in an oxygenless environment is impossible. It seems that oxygen is a key "
        + "component too. \n\nLastly I have found that the reaction, that is fire, can be started by raising the fuel to it's"
        + " ignition temperature, as long as the other two components are present. It seems that most wood ignites at around 300 degrees.\n\n"
        + "I am fairly certain this information will come in handy at some point."
        + "\n\n <i>-- Prof. Jameson</i>";

    	fireTriangle.AddEntry(new JournalEntry(fireTriangleText, "Day: 34 - Analysis of fire"));;

        Topic waterDistillation = new Topic("Water Distillation");
        physics.AddTopic(waterDistillation);

        string waterDistillationText =
        "<b>\tDay: 37 - Distilling of saltwater</b>"
        + "\n\nI have though of a way to make drinkable water! I just need a container to hold the water "
        + "then I can boil it and cool the steam to turn it into drinkable water. "
        + "\n\nI've made an equation to make it easier to remember "
        + "\n<b> E = m * c * ΔT</b>"
        + "\nm is the mass of what we wan't to heat, also, 1 litre of water = 1 Kg of water."
        + "\nc is the specific heat capacity of water "
        + "\nΔT is the temperature change we wish to achieve"
        + "\nE is the energy it takes to heat up something by a certain amount of degrees";

        waterDistillation.AddEntry(new JournalEntry(waterDistillationText));
	}

	void CreatePhysicsDanish ()
	{
		Subject physics = new Subject("Fysik");
		AddSubject(physics);

        Topic fireTriangle = new Topic("Fire Triangle");
        physics.AddTopic(fireTriangle);

        string fireTriangleText =
        "Jeg har brugt hele dagen på at analysere ilds opførsel, og jeg tror jeg har "
		+ "fundet ud af det! Det virker til at færdigheden at lave ild er baseret på "
		+ "tre primære faktorer. Det har ikke været muligt for mig at lave ild uden disse "
		+ "komponenter, hvilket giver mig et indtryk af at de er nødvendige for at kunne lave ild.\n\n"

		+ "Først, for at kunne lave ild har jeg brug for noget som kan bruges som "
		+ "brandsel - noget der kan brænde.\n\n"  

		+ "Jeg har også fundet ud af at det er umuligt at lave ild i et ilt-frit miljø. "
		+ "Det virker til at ilt også er et nødvendigt komponent.\n\n"

		+ "Som det sidste komponent, har jeg fundet ud af at reaktionen til at lave ild kan "
		+ "sættes igang ved at hæve temperaturen af brændslet til dets antændings-temperatur, "
		+ "den temperatur brændslet skal have for at blive antændt. Dette kan "
		+ "dog kun lade sig gøre hvis de andre to komponenter, ilt og brændsel, er til "
		+ "stede. Det virker til at træ kan antændes ved en temperatur på ca. 300 grader celsius.\n\n"

		+ "Jeg er sikker på at denne information kan blive brugbar på et tidspunkt.\n\n"

		+ "<i>-- Prof. Jameson</i>";

    	fireTriangle.AddEntry(new JournalEntry(fireTriangleText, "Day: 34 - Analysis of fire"));;

        Topic waterDistillation = new Topic("Water Distillation");
        physics.AddTopic(waterDistillation);

        string waterDistillationText =
        "Skriv";

        waterDistillation.AddEntry(new JournalEntry(waterDistillationText));
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
        for (int i = 0; i < subjects.Count; i++)
        {
			if (i == _selection)
			{
				Highlight();
			}

        	if (GUI.Button(new Rect(100, 30 + 45 * i, 120, 30), subjects[i].Name))
        	{
        		_selection = i;
        	}

    		ResetHighlight();
        }

        // Draw all the topic under the current subject
        for (int i = 0; i < Topics.Count; i++)
        {
			if (i == subjects[_selection].Selection)
			{
				Highlight();
			}

        	if (GUI.Button(new Rect(240, 30 + 45 * i, 120, 30), Topics[i].Name))
        	{
        		subjects[_selection].Selection = i;
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
	 		List<JournalEntryBase> journalEntries = CurrentTopic.Entries;

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