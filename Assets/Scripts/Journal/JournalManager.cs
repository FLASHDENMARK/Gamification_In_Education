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
		"Denne notesbog tilhører videnskabsprofesseren Jameson.\n\n"

		+ "Denne notesbog indeholder mine opdagelser fra forskellige experimenter. "
		+ "Mine noter er delt ind i hver sin kategori.\n\n"

		+ "Hvis du finder denne bog, bedes du retunere den til mig.\n\n"

 		+ "<i>-- Prof. Jameson.</i>";

        // Adds an entry to the topic. 
        aboutThisJournal.AddEntry(new JournalEntry(aboutThisJournalText));
	}

    public Texture geometrySquare = null;
    public Texture geometryRectangle = null;
    public Texture geometryTriangle = null;
    public Texture geometryCircle = null;
    public Texture geometryCube = null;
    public Texture geometry3DRectangle = null;
    public Texture geometryPyramid = null;
    public Texture geometryCylinder = null;
    public Texture geometryCone = null;

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
        + "\n\nCalculating the volume of a cube is relatively simple. It is just like calculating the area of a quadrant, but this time we just multiply by A one more time. "
        + "This turns the calculation from two-dimensional(2D) to three-dimensional(3D) and only 3D objects have volumes. 3D objects have a width, height <i>and</i> depth, where as 2D objects only have a width and a height.";

        string geometryTextRectangle3D = "Calculating the volume of a 3D rectangle is done in the same way as calculating the area of a rectangle, except we have to remember to multiply by the depth as well."
        + "This means that the formula to calculate the volume of a 3D rectangle is A multiplied B multiplied by C, where A, B, and C are different from eachother.";

        string geometryTextPyramid = "To calculate the volume of a pyramid, two things are needed: The area of the base and the height of the pyramid. "
        + "The height of the pyramid is the <i>perpendicular</i> height from the base to the same height as the top of the pyramid. The area of the base is calculated like the area of a quadrant or rectangle, "
        + "depending on the geometry of the base. The formula to calculate the volume of a pyramid is the height H multiplied by the base B multiplied by 1/3.";

        string geometryTextCylinder = "Calculating the volume of a cylinder is also relatively simple. The volume of a cylinder can be calculated by multiplying the area of the base, which is equal to the area of a circle, "
        + "with the height <i>h</i> of the cylinder.";

        string geometryTextCone = "The volume of a cone is similar to the volume of a pyramid, with only one key difference. "
        + "The base of a cone is circular, where the base of a pyramid was a square. Therefore, the volume of a cone is calculated by almost the same formula as the pyramid, with the exception of the base B being the area of a circle instead.";

        geometry.AddEntry(new JournalEntry(geometryTextCube, "Volume"));
        geometry.AddEntry(new JournalEntryImage(geometryCube, "The volume of a cube\n"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle3D));
        geometry.AddEntry(new JournalEntryImage(geometry3DRectangle, "The volume of a 3D rectangle\n"));
        geometry.AddEntry(new JournalEntry(geometryTextPyramid));
        geometry.AddEntry(new JournalEntryImage(geometryPyramid, "The volume of a pyramid\n"));
        geometry.AddEntry(new JournalEntry(geometryTextCylinder));
        geometry.AddEntry(new JournalEntryImage(geometryCylinder, "The volume of a cylinder\n"));
        geometry.AddEntry(new JournalEntry(geometryTextCone));
        geometry.AddEntry(new JournalEntryImage(geometryCone, "The volume of a cone\n"));
    }

	void CreateMathematicsDanish ()
	{
        Subject mathematics = new Subject("Matematik");
        AddSubject(mathematics);

        Topic orderOfOperations = new Topic("Rækkefølgen af regneoperationer");
        mathematics.AddTopic(orderOfOperations);

        string orderOfOperationsText = 
        "Det virker til, at matematik kan være misvisende til tider. "
		+ "Jeg har opdaget at rækkefølgen af regneoperationer er meget vigtig.\n\n"

		+ "Her er et eksempel:\n"
		+ "Vi har 2 pinde og så har vi 4 sæt af 3 pinde.\n"
		+ "|| +(||| + ||| + ||| + |||)\n\n"

		+ "Den matematiske udregning for antallet af pinde kunne man tro ville være:\n\n"

		+ "2+3x4\n"
		+ "2+3 = 5, så har vi 5x4\n"
		+ "5x4 = 20 pinde i alt, ikke? Forkert. Prøv at tælle pindene selv, "
		+ "er der 20 pinde i alt?\n"
		+ "Nej, vel? Den korrekte udregning vil være:\n\n"

		+ "2+3x4\n"
		+ "3x4 = 12, og til sidst er der 2+12 = 14.\n"
		+ "14 pinde i alt, ligesom du talte før.\n\n"

		+ "Det virker til at man skal gange og dividere for man ligger til og "
		+ "trækker fra, for at få det korrekte svar. "
		+ "Derudover ser det ud til, at parenteser burde blive beregnet som det "
		+ "aller første i en udregning. "
		+ "Efter parenteser burde man beregne kvadratrødder og exponenter, så "
		+ "gange og dividere, og til sidst ligger man til og trækker fra.\n\n"

		+ "Jeg er kommet frem til en nemmere måde til at huske denne rækkefølge. "
		+ "Jeg kalder den for PEGDAS, som står for: "
		+ "Parenteser, eksponenter, gange og dividere, addere og subtrahere.\n\n"

		+ "Når man udregner regnestykker i denne rækkefølge, får man altid det korrekte svar.\n\n"

		+ "<i>--Prof. Jameson</i>";

        orderOfOperations.AddEntry(new JournalEntry(orderOfOperationsText));

        Topic geometry = new Topic("Geometri");
        mathematics.AddTopic(geometry);

		string geometryTextIntro = 
		"Over flere års undersøgelse har jeg endelig fundet forholdet mellem geometri "
		+ "og deres areal og volume - utroligt!\n\n"

		+ "At beregne en geometrisk figurs areal virker nemmere end at finde dens volume. "
		+ "Arealet er nemlig størrelsen af 'den flade overflade', hvor volumen er " 
		+ "'Størrelsen af pladsen inden i figuren'.";

		string geometryTextSquare = 
		"Lad mig starte med en af de basale geometriske figurer: Kvadratet. "
		+ "Kvadratet er simpel, fordi hver side har samme længde. Formlen for at "
		+ "finde arealet af et kvadrat ligger i navnet. Arealet er længden af 'a' "
		+ "ganget med længden af 'a'. Arealet af et kvadrat er altså længden af en side kvadreret.";

		string geometryTextRectangle = 
		"Arealet af en rektangel minder om arealet af en kvadrat. Udregningen er "
		+ "den samme som arealet af en kvadrat, undtagen at rektanglen har ikke "
		+ "samme længde på alle sider. Af denne grund er arealet af en rektangel "
		+ "'a' ganget med 'b', hvor 'b' og 'a' er samme længde.";

		string geometryTextTriangle = 
		"En anden beregning relateret til arealet af rektangler og kvadrater er "
		+ "arealet af en trekant. Arealet af en trekant er super simpel, hvis du "
		+ "ved hvordan man bestemmer arealet af en rektangel, da arealet af en "
		+ "trekant er halvdelen af arealet rektangel. Dette kan udregned med at "
		+ "dividere grundlinjen med 2 og gange det med højden af trekanten. Utroligt!";

		string geometryTextCircle = 
		" Cirkler er desværre ikke direkte relateret til trekanter, rektangler og kvadrater... "
		+ "Men jeg har dog opdaget at, når jeg har brug for at beregne noget med cirkler, "
		+ "skal jeg bruge noget jeg for sjovt har kaldt 'PI'. 'PI' er en matematisk konstant. "
		+ "og jeg har givet den et fancy symbol: π. det er et meget langt nummer, "
		+ "så jeg husker det bare rundt regnet som 3,14. \n\n"

		+ "Heldigvis, at beregne arealet af en cirkel er tilnærmelsesvis ligesom at beregne "
		+ "arealet af et kvadrat. Ligesom i et kvadrat, for vi ganger 'a' med 'a', ganger vi "
		+ "bare med PI på dette tal. Vi bruger dog 'R' (for radius) i stedet for 'a' "
		+ "Jeg har fundet ud af at PI har mange praktiske funktioner.";

        geometry.AddEntry(new JournalEntry(geometryTextIntro));
        geometry.AddEntry(new JournalEntry(geometryTextSquare, "Area"));
        geometry.AddEntry(new JournalEntryImage(geometrySquare, "Arealet af et kvadrat"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle));
        geometry.AddEntry(new JournalEntryImage(geometryRectangle, "Arealet af en rektangle"));
        geometry.AddEntry(new JournalEntry(geometryTextTriangle));
        geometry.AddEntry(new JournalEntryImage(geometryTriangle, "Arealet af en trekant"));
        geometry.AddEntry(new JournalEntry(geometryTextCircle));
        geometry.AddEntry(new JournalEntryImage(geometryCircle, "Arealet af en cirkel"));

        string geometryTextCube =
        "Volumen, også kaldet rumfang, er størrelsen af den plads et objekt udgør "
        + "og at udregne volumen, bygger på arealberegninger. Men lad us starte simpelt.\n\n"

        + "Beregning af volumen af en terning er simpelt. Det er det samme som at beregne "
        + "arealet af et kvadrat, og derefter gange med 'a' igen. Dette gør at beregningen "
        + "går fra to-dimensionel(2D) til tre-dimensionel(3D), og kun 3D objekter har en volumen. De har nemlig en bredde, en "
        + "dybde og en højde, hvor 2D objekter kun har en bredde og en højde.";

        string geometryTextRectangle3D =
        "At beregne volumen af et 3D rektangel er det samme som at beregne arealet af et rektangel, "
        + "hvorefter man ganger med dybden af det 3D rektangel.";

        string geometryTextPyramid = "Der skal bruges to ting for at kunne beregne rumfanget af en pyramide: Arealet af basen, som er kvadratet i bunden, og pyramidens højde. "
        + "Højden af pyramiden er den <i>retvinklede</i> højde fra basen af pyramiden til toppen af pyramiden. Arealet af basen udregnes på samme måde som man beregner arealet af et rektangel. "
        + "Formlen brugt til at udregne volumen af en pyramide er derfor højden ganget med basens areal, og derefter ganget med 1/3.";

        string geometryTextCylinder = "At udregne volumen af en cylinder er relativt simpelt. En cylinder er i princippet bare en cirkel der har en højde, hvilket gør at en cylinders volumen "
        + "kan udregnes ved at gange basens areal, altså cirklens areal, med højden af cylinderen.";

        string geometryTextCone = "Volumen af en kegle er næsten ens med volumen af en pyramide, med kun en enkel ændring. "
        + "Basen for en kegle er cirkulær, hvor basen for en pyramide er kvadratisk. Dette gør at volumen for en kegle kan udregnes ved at gange højden af keglen med cirklens areal, og derefter gange dette med 1/3.";

        geometry.AddEntry(new JournalEntry(geometryTextCube, "Volumen"));
        geometry.AddEntry(new JournalEntryImage(geometryCube, "Volumen af en terning\n"));
        geometry.AddEntry(new JournalEntry(geometryTextRectangle3D));
        geometry.AddEntry(new JournalEntryImage(geometry3DRectangle, "Volumen af et 3D rektangel\n"));
        geometry.AddEntry(new JournalEntry(geometryTextPyramid));
        geometry.AddEntry(new JournalEntryImage(geometryPyramid, "Volumen af en pyramide\n"));
        geometry.AddEntry(new JournalEntry(geometryTextCylinder));
        geometry.AddEntry(new JournalEntryImage(geometryCylinder, "Volumen af en cylinder\n"));
        geometry.AddEntry(new JournalEntry(geometryTextCone));
        geometry.AddEntry(new JournalEntryImage(geometryCone, "Volumen af en kegle\n"));
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
        + "\n<b> E = m * c * ΔT</b>\n"
        + "\nm is the mass of what we wan't to heat, also, 1 Kg of water = i liter of water.\n"
        + "\nc is the specific heat capacity of water, this means that to heat 1 Kg of water by 1 degree celsius "
        + "you will need 4186 joule.\n "
        + "\nΔT is the temperature change we wish to achieve. the triangle Δ (called delta) is the symbol to show "
        + "a difference. And T is the temperature, so when we write ΔT we are talking about a difference in temperature.\n "
        + "\nE is the energy it takes to heat up something by a certain amount of degrees"
        + "\n\nWith this equation i can calculate the temperature difference ΔT = E/m * c "
        + "\n\nThe conversion from watts to joules/seconds is as follows 500w = 500 joule/seconds";

        waterDistillation.AddEntry(new JournalEntry(waterDistillationText, "Day: 37 - Distilling of saltwater"));
	}

	void CreatePhysicsDanish ()
	{
		Subject physics = new Subject("Fysik");
		AddSubject(physics);

        Topic fireTriangle = new Topic("Brændtrekant");
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
        + "Konversionen fra watt til joule/sekunder ser således ud 500w = 500 joule/sekunder"

        + "Jeg er sikker på at denne information kan blive brugbar på et tidspunkt.\n\n"

		+ "<i>-- Prof. Jameson</i>";

    	fireTriangle.AddEntry(new JournalEntry(fireTriangleText, "Dag: 34 - Analyse af ild"));;

        Topic waterDistillation = new Topic("Vand-destillering");
        physics.AddTopic(waterDistillation);

        string waterDistillationText =
		"Jeg tror jeg har fundet på en måde at lave drikkevand på! Jeg mangler kun en "
		+ "beholder der kan holde på vand. Ved at koge saltvand, og derefter køle dampen, "
		+ "kan jeg lave drikkevand.\n\n"

		+ "Jeg har lavet en ligning der gør det nemmere for mig at huske hvor meget energi "
		+ "der skal til for at varme en mængde vand op til kogepunktet.\n\n"

		+ "E = m * c * (delta)T\n\n"

		+ "m er massen af hvad der skal varmes op. Et eksempel kunne være en liter vand, "
		+ "hvilket cirka svarer til et kilo vand. \n\n"
        + "c er den specifikke varmekapacitet. Vand har en specifik varmekapacitet på "
		+ "4.186 J/Kg * (grader)celsius. \n\n"
        + "(delta)T er den temperatur-ændring man ønsker. \n\n"
        + " E er den energimængde der skal til for at varme noget op svarende til ændringen i temperatur (delta)T.\n\n"
        + "Med denne formel kan jeg udregne temperatur forskellen ΔT = E/m * c \n\n"

        + "<i>-- Prof. Jameson</i>";

        waterDistillation.AddEntry(new JournalEntry(waterDistillationText, "Dag: 37 - Distillering af saltvand"));
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