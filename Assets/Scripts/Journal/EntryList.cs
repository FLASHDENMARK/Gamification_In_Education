﻿using UnityEngine;

// Creates every subjects, topic and entry for the Journal Manager
class EntryList : MonoBehaviour 
{
	JournalManager _manager;

	public void CreateEntries (JournalManager manager)
	{
		_manager = manager;

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
	}

    // This is only here to demonstrate how subjects, topics and entries are setup
    /*void HowToAddTopic ()
    {
        // Create a new subject if the subject doesn't already exist
        Subject newSubject = new Subject("New Subject");
        // Add the new subject to a list of all subjects
        _manager.AddSubject(newSubject);
        // Create a new topic
        Topic newTopic = new Topic("New Topic");
        // Add the topic to the subject
        newSubject.AddTopic(newTopic);

        // Add text(EntryText) / images(EntryImage) to the topic
        newTopic.AddEntry(new EntryText("This is a piece of text for the topic: <i>New Topic</i>", "This is a label for this text (optional)"));
        newTopic.AddEntry(new EntryImage(new Texture2D(100, 100), "This is a label for this image"));
        // The above can be done in any order no matter how many entries
    }*/

    void CreateIntroEnglish ()
    {
        Subject intro = new Subject("Intro");
        _manager.AddSubject(intro);

        Topic aboutThisJournal = new Topic("About this journal");
        intro.AddTopic(aboutThisJournal);

        string aboutThisJournalText =
        "<b>This journal belongs to Science Professor Jameson</b>\n\n "

        + "This journal contains the discoveries I have done, through various experiments."
        + "The finds are divided into chapters of their respective subjects.\n\n "

        + "If you are to find this book, please return it to me.\n\n"

        + "<i>-- Prof. Jameson</i>";

        aboutThisJournal.AddEntry(new EntryText(aboutThisJournalText));
    }

    void CreateIntroDanish ()
    {
        Subject intro = new Subject("Intro");
        _manager.AddSubject(intro);

        Topic aboutThisJournal = new Topic("Om denne notesbog");
        intro.AddTopic(aboutThisJournal);

        string aboutThisJournalText =
        "<b>Denne notesbog tilhører videnskabsprofesseren Jameson.</b>\n\n"

        + "Denne notesbog indeholder mine opdagelser fra forskellige experimenter. "
        + "Mine noter er delt ind i hver sin kategori.\n\n"

        + "Hvis du finder denne bog, bedes du returnere den til mig.\n\n"

        + "<i>-- Prof. Jameson.</i>";

        aboutThisJournal.AddEntry(new EntryText(aboutThisJournalText));
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
    public Texture pyhtagoreanTheoremImage = null;

    void CreateMathematicsEnglish ()
    {
        Subject mathematics = new Subject("Mathematics");
        _manager.AddSubject(mathematics);

        Topic orderOfOperations = new Topic("Order of operations");
        mathematics.AddTopic(orderOfOperations);

        string orderOfOperationsText = 
        "It seems that math can be misleading at times. "
        + "I have discovered that the order of operations is quite important.\n\n"

        + "Here's an example:\n"
        + "We have two sticks, and then 4 sets of 3 sticks.\n"
        + "|| +(||| + ||| + ||| + |||)\n\n"

        + "Some would think that the mathematical equation would be:\n\n"

        + "<b>2+3×4</b>\n"
        + "2+3 = 5, that leaves us with 5×4.\n"
        + "5×4 = 20 right? Wrong. Count the sticks for yourself. Are there 20 sticks above?\n"
        + "No. The correct equation would be:\n\n"

        + "<b>2+3×4</b>\n"
        + "3×4 = 12, which leaves us with: 2 + 12 = 14.\n"
        + "14 sticks, just as above.\n\n"

        + "It seems that you have to multiply and divide, before adding and subtracting, to get the right result. "
        + "Furthermore it seems that parenthesis should be calculated as the very first thing of an equation. "
        + "Then we should calculate roots and exponents, then multiplication and division, and lastly addition and subtraction. "
        + "I have come up with an easier way to remember this order. I call it PEMDAS and it stands for"
        + "Parentheses, exponents, multiplication, devision, addition and subtraction. "
        + "As long as equations are calculated in this order, then the result will always be correct.\n\n"

        + "<i>-- Prof. Jameson</i>";

        orderOfOperations.AddEntry(new EntryText(orderOfOperationsText));

        Topic pyhtagoreanTheorem = new Topic("Pyhtagorean Theorem");
        mathematics.AddTopic(pyhtagoreanTheorem);

        string pyhtagoreanTheoremText =
        "I have been able to make great use of something called the Pythagorean Theorem. It is especially useful "
        + "for finding the length of one side of an <i>orthogonal</i> triangle if the two other sides are known. The "
        + "Pythagorean Theorem is as follows: \n\n"
        
        + "a² + b² = c²\n\n"

        + "Raising the length of two sides, called the cathetus, to the power of two yields the square of the third missing length called the hypotinuse. In order to find "
        + "the precise length of c I use the square root of c². This results in c, which is the missing length of the triangle.\n\n"

        + "Here is an example:\n\n"

        + "c² = 6² + 8² - This example shows the two known sides being of length 6 and 8. To calculate the missing length we "
        + "first calculate 6² and 8²:\n\n"

        + "6² = 36(6 * 6) and 8² = 64(8 * 8) - This results in c² being equal to 36 + 64 = 100.\n\n"

        + "c² = 100 - To find c we calculate the square root of 100 (since the square root is the opposite of raising to a power of two). "
        + "The square of 100 is simply the number we have to multiply by itself to equal 100. In this case 10 * 10 is equal to 100. This "
        + "means that 10 = √10² = √(6² + 8²).";

        pyhtagoreanTheorem.AddEntry(new EntryText(pyhtagoreanTheoremText, "Length of the sides of triangles"));
        pyhtagoreanTheorem.AddEntry(new EntryImage(pyhtagoreanTheoremImage, "The lengths A, B and C"));
        pyhtagoreanTheorem.AddEntry(new EntryText("<i>-- Prof. Jameson</i>"));

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

        geometry.AddEntry(new EntryText(geometryTextIntro));
        geometry.AddEntry(new EntryText(geometryTextSquare, "Area"));
        geometry.AddEntry(new EntryImage(geometrySquare, "The area of a square"));
        geometry.AddEntry(new EntryText(geometryTextRectangle));
        geometry.AddEntry(new EntryImage(geometryRectangle, "The area of a rectangle"));
        geometry.AddEntry(new EntryText(geometryTextTriangle));
        geometry.AddEntry(new EntryImage(geometryTriangle, "The area of a triangle"));
        geometry.AddEntry(new EntryText(geometryTextCircle));
        geometry.AddEntry(new EntryImage(geometryCircle, "The area of a circle"));

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

        geometry.AddEntry(new EntryText(geometryTextCube, "Volume"));
        geometry.AddEntry(new EntryImage(geometryCube, "The volume of a cube\n"));
        geometry.AddEntry(new EntryText(geometryTextRectangle3D));
        geometry.AddEntry(new EntryImage(geometry3DRectangle, "The volume of a 3D rectangle\n"));
        geometry.AddEntry(new EntryText(geometryTextPyramid));
        geometry.AddEntry(new EntryImage(geometryPyramid, "The volume of a pyramid\n"));
        geometry.AddEntry(new EntryText(geometryTextCylinder));
        geometry.AddEntry(new EntryImage(geometryCylinder, "The volume of a cylinder\n"));
        geometry.AddEntry(new EntryText(geometryTextCone));
        geometry.AddEntry(new EntryImage(geometryCone, "The volume of a cone"));
        geometry.AddEntry(new EntryText("\n<i>-- Prof. Jameson</i>"));

        Topic miscOperations = new Topic("Miscellaneous operations");
        mathematics.AddTopic(miscOperations);

        string miscOperationsDecimal =
        "If I am given a percentage or fraction I can calculate the decimal by these simple formulas. "
        + "If I am given a percentage (0 - 100%) then all I have to do is devide by 100 and I have "
        + "the result. This is the same as moving the comma two spaces to the left. "
        + "If I am given a fraction (a number above another number) I can calculate the decimal by "
        + "deviding the numerator(top number) with the denominator(lower number). \n\n"

        + "This calls for an example: \n\n"

        + "How is 76% converted to decimal? We simply devide by 100. I have "
        + "discovered that if you devide by 10 we move the comma one place to the left. If we devide by "
        + "100 we move it 2 places to the left and so on. This is useful for quickly deviding numbers "
        + "by 10, 100, 1000 or even larger numbers. \n\n"

        + "To demonstrate this behavior: \n\n"
        + "76 is equal to 76.0. If we want to devide by 100 we move the comma two places "
        + "to the left, like so: 0.76.\n\n"

        + "However, if I am given a fraction, calculating the decimal value is a bit more complicated. "
        + "I have to devide the top number with the lower number. Like so: \n\n"

        + "29\n"
        + "---\n"
        + "34\n\n"

        + "The decimal number of the above is 29 / 34 = 0.85.";

        miscOperations.AddEntry(new EntryText(miscOperationsDecimal, "Decimal calculation"));

        string miscOperationsMissingAngle = 
        "I have discovered that triangles always have 3 points with a total of 180 degrees. So if I am ever "
        + "in a situation where I am missing one angle of a triangle, I can easily calculate it by subtracting "
        + "the sum of the known angles from 180.\n\n"

        + "To illustrate:\n\n"

        + "I am given two known angles. One with a 35 degree angle and the other with a 45 degree angle. The degree "
        + "of the third and missing angle is simply 180 - (35 + 45) = 100 degrees.\n\n"
        + "<i>-- Prof. Jameson</i>";

        miscOperations.AddEntry(new EntryText(miscOperationsMissingAngle, "Missing angle of a triangle"));
    }

    void CreateMathematicsDanish ()
    {
        Subject mathematics = new Subject("Matematik");
        _manager.AddSubject(mathematics);

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

        + "Det virker til at man skal gange og dividere før man ligger til og "
        + "trækker fra, for at få det korrekte svar. "
        + "Derudover ser det ud til, at parenteser burde blive beregnet som det "
        + "allerførste i en udregning. "
        + "Efter parenteser burde man beregne kvadratrødder og eksponenter, så "
        + "gange og dividere, og til sidst ligger man til og trækker fra.\n\n"

        + "Jeg er kommet frem til en nemmere måde at huske denne rækkefølge. "
        + "Jeg kalder den for PEGDAS, som står for: "
        + "Parenteser, eksponenter, gange og dividere, addere og subtrahere.\n\n"

        + "Når man udregner regnestykker i denne rækkefølge, får man altid det korrekte svar.\n\n"

        + "<i>--Prof. Jameson</i>";

        orderOfOperations.AddEntry(new EntryText(orderOfOperationsText));

        Topic pyhtagoreanTheorem = new Topic("Phytagoras Sætning");
        mathematics.AddTopic(pyhtagoreanTheorem);

        string pyhtagoreanTheoremText = 
        "Jeg har gjort god brug af Pythagoras Sætning. Denne sætning er særligt nyttig "
        + "til at finde længden af en side af en retvinklet-trekant, hvis de andre to "
        + "sider er kendte. Pythagoras Sætning er som følger:\n\n"

        + "a² + b² = c²\n\n"

        + "Hvis to vilkårlige sider kendes, kaldet kateterne, kan Pythagoras Sætning udnyttes til at udregne den ukendte side, kaldet hypotenusen. "
        + "For at finde den præcise længde af c benytter jeg kvadratroden på c². Dette resulterer i c, hvilket er "
        + "lægden af den ukendte længde af trekanten.\n\n"

        + "Her er et eksempel: "

        + "c² = 6² + 8² - Dette eksempel viser længden af de to kendte sider som 6 og 8. For at udregne "
        + "den manglende længde udregner vi først 6² + 8².\n\n"

        + "6² = 36(6 * 6) og 8² = 64(8 * 8) - Dette resulterer i at c² er lig med 36 + 64 = 100.\n\n"

        + "c² = 100 - For at finde c skal vi udregne kvadratroden af 100, da kvadratroden er det modsatte "
        + "af at opløfte i anden. Kvadratroden af 100 er det tal som skal ganges med sig selv for at få 100. "
        + "I dette tilfælde er 10 * 10 lig med 100. Dette betyder at 10 = √10² = √(6² + 8²).";

        pyhtagoreanTheorem.AddEntry(new EntryText(pyhtagoreanTheoremText, "Længden af en trekants side"));
        pyhtagoreanTheorem.AddEntry(new EntryImage(pyhtagoreanTheoremImage, "Længderne A, B og C"));
        pyhtagoreanTheorem.AddEntry(new EntryText("<i>--Prof. Jameson</i>"));

        Topic geometry = new Topic("Geometri");
        mathematics.AddTopic(geometry);

        string geometryTextIntro = 
        "Over flere års undersøgelse har jeg endelig fundet forholdet mellem geometri "
        + "og deres areal og volume - fascinerende!\n\n"

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
        + "trekant er halvdelen af arealet rektangel. Dette kan udregnes ved at "
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

        geometry.AddEntry(new EntryText(geometryTextIntro));
        geometry.AddEntry(new EntryText(geometryTextSquare, "Areal"));
        geometry.AddEntry(new EntryImage(geometrySquare, "Arealet af et kvadrat"));
        geometry.AddEntry(new EntryText(geometryTextRectangle));
        geometry.AddEntry(new EntryImage(geometryRectangle, "Arealet af en rektangle"));
        geometry.AddEntry(new EntryText(geometryTextTriangle));
        geometry.AddEntry(new EntryImage(geometryTriangle, "Arealet af en trekant"));
        geometry.AddEntry(new EntryText(geometryTextCircle));
        geometry.AddEntry(new EntryImage(geometryCircle, "Arealet af en cirkel"));

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

        geometry.AddEntry(new EntryText(geometryTextCube, "Volumen"));
        geometry.AddEntry(new EntryImage(geometryCube, "Volumen af en terning\n"));
        geometry.AddEntry(new EntryText(geometryTextRectangle3D));
        geometry.AddEntry(new EntryImage(geometry3DRectangle, "Volumen af et 3D rektangel\n"));
        geometry.AddEntry(new EntryText(geometryTextPyramid));
        geometry.AddEntry(new EntryImage(geometryPyramid, "Volumen af en pyramide\n"));
        geometry.AddEntry(new EntryText(geometryTextCylinder));
        geometry.AddEntry(new EntryImage(geometryCylinder, "Volumen af en cylinder\n"));
        geometry.AddEntry(new EntryText(geometryTextCone));
        geometry.AddEntry(new EntryImage(geometryCone, "Volumen af en kegle"));
        geometry.AddEntry(new EntryText("\n<i>-- Prof. Jameson</i>"));

        Topic miscOperations = new Topic("Diverse operationer");
        mathematics.AddTopic(miscOperations);

        string miscOperationsDecimal =
        "Hvis jeg er givet et procenttal eller brøk kan jeg udregne decimaltallet via disse simple udregninger. "
        + "Hvis jeg er givet et procenttal (0 - 100%) skal jeg blot dividere med 100 og jeg har resultatet. "
        + "Dette er det samme som at flytte kommaet to pladser til venstre. Hvis jeg er givet en brøk (et "
        + "tal over et andet tal) kan jeg udregne decimaltallet ved at dividere tælleren(øverste tal) med "
        + "nævneren(nederste tal).\n\n"

        + "Dette kræver et eksempel: \n\n"

        + "Hvordan er 76% udregnet til et decimaltal? Da dette er et procenttal kan vi blot dividere med 100. "
        + "Jeg har opdaget at hvis man vil dividere med 10 flytte man blot kommaet en plads til venstre. Hvis "
        + "man vil dividere med 100 flytte man kommaet 2 pladser til venstre og så viderer. Dette er brugbart "
        + "til hurtigt at dividere tal med 10, 100, 1000 eller endda større tal.\n\n"

        + "For at demonstrere dette: \n\n"

        + "76 er lig med 76.0. Hvis vi vil dividere med 100 flytter vi blot kommaet 2 pladser til venstre, sådan "
        + "her: 0.76.\n\n"

        + "Men, er jeg givet en brøk bliver udregningen af decimaltallet lidt sværere. Jeg skal dividere tælleren "
        + "med nævneren. Sådan her:\n\n"

        + "29\n"
        + "---\n"
        + "34\n\n"

        + "Decimaltallet af ovenstående er 29 / 34 = 0.85.";

        miscOperations.AddEntry(new EntryText(miscOperationsDecimal, "Udregning af decimaltal"));

        string miscOperationsMissingAngle = 
        "Jeg har opdaget at alle trekanter altid har 3 vinkler med ialt 180 grader. Skulle jeg nogensinde stå i "
        + "en situation hvor jeg mangler <i>en</i> vinkel, kan jeg let udregne den ved at subtrahere summen af "
        + "kendte vinkler fra 180.\n\n"

        + "For at illustrere:\n\n"

        + "Jeg er givet to kendte vinkler. En med en 35 graders vinkel og en anden med en 45 graders vinkel. "
        + "Vinklen af den ukendte udregnes ved 180 - (35 + 45) = 100 grader."
        + "\n\n<i>--Prof. Jameson</i>";

        miscOperations.AddEntry(new EntryText(miscOperationsMissingAngle, "Ukendt vinkel af en trekant"));
    }

    void CreatePhysicsEnglish ()
    {
        Subject physics = new Subject("Physics");
        _manager.AddSubject(physics);

        Topic fireTriangle = new Topic("Fire Triangle");
        physics.AddTopic(fireTriangle);

        string fireTriangleText =
        "I have spend the entire day, analyzing the behaviour of fire, and I think I have figured it out. "
        + "It seems that the ability to create a fire is based on three primary factors. "
        + "I have not been able to produce a fire without these components, so they seem essential in creating a fire.\n\n"

        + "Firstly to create a fire, I need something that can serve as a fuel, something that can burn. \n\n"

        + "I have also found that creating a fire in an oxygenless environment is impossible. It seems that oxygen is a key "
        + "component too. \n\nLastly I have found that the reaction, that is fire, can be started by raising the fuel to it's "
        + "ignition temperature, as long as the other two components are present. It seems that most wood ignites at around 300 degrees.\n\n"

        + "It seems one can create thermal energy from kinetic energi through friction. If I rub my hands together I "
        + "can feel the heat. This is the kinetic energy turning into thermal energy.\n\n"

        + "I am fairly certain this information will come in handy at some point.\n\n "

        + "<i>-- Prof. Jameson</i>";

        fireTriangle.AddEntry(new EntryText(fireTriangleText, "Day: 34 - Analysis of fire"));;

        Topic waterDistillation = new Topic("Water Distillation");
        physics.AddTopic(waterDistillation);

        string waterDistillationText =
        "I have though of a way to make drinkable water! If I have a container to hold the water "
        + "then I can boil it and cool the steam to turn it into drinkable water.\n\n"

        + "I've made an equation to make it easier to remember:\n"
        + "<b> E = m * c * ΔT</b>\n\n"

        + "m is the mass of what we wan't to heat, also, 1 Kg of water = 1 liter of water.\n\n"

        + "c is the specific heat capacity of water, this means that to heat 1 Kg of water by 1 degree celsius "
        + "you will need 4186 joule.\n\n"

        + "ΔT is the temperature change we wish to achieve. the triangle Δ (called delta) is the symbol to show "
        + "a difference. And T is the temperature, so when we write ΔT we are talking about a difference in temperature.\n\n"

        + "E is the energy it takes to heat up something by a certain amount of degrees.\n\n"

        + "With this equation i can calculate the temperature difference ΔT = E/m * c.\n\n"

        + "The conversion from watts to joules/seconds is as follows 500w = 500 joule/seconds. \n\n"

        + "<i>--Prof. Jameson</i>";

        waterDistillation.AddEntry(new EntryText(waterDistillationText, "Day: 37 - Distilling of saltwater"));
    }

    void CreatePhysicsDanish ()
    {
        Subject physics = new Subject("Fysik");
        _manager.AddSubject(physics);

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
        + "stede. Det virker til at træ kan antændes ved en temperatur på ca. 300 grader celsius. \n\n"

        + "Det lader til at man kan lave varmeenergi fra kinetisk energi, igennem friktion. Hvis jeg "
        + "gnider mine hænder mod hinanden, kan jeg mærke varme. Dette er den kinetiske energi der bliver til varmeenergi.\n\n"

        + "Jeg er sikker på at denne information kan blive brugbar på et tidspunkt.\n\n"

        + "<i>-- Prof. Jameson</i>";

        fireTriangle.AddEntry(new EntryText(fireTriangleText, "Dag: 34 - Analyse af ild"));;

        Topic waterDistillation = new Topic("Vand-destillering");
        physics.AddTopic(waterDistillation);

        string waterDistillationText =
        "Jeg tror jeg har fundet på en måde at lave drikkevand på! Man skal kun have en "
        + "beholder der kan holde på vand. Ved at koge saltvand, og derefter køle dampen, "
        + "kan jeg lave drikkevand.\n\n"

        + "Jeg har lavet en ligning der gør det nemmere for mig at huske hvor meget energi "
        + "der skal til for at varme en mængde vand op til kogepunktet.\n\n"

        + "E = m * c * ΔT\n\n"

        + "m er massen af hvad der skal varmes op. Et eksempel kunne være en liter vand, "
        + "hvilket cirka svarer til et kilo vand. \n\n"

        + "c er den specifikke varmekapacitet. Vand har en specifik varmekapacitet på "
        + "4.186 J/Kg * (grader)celsius. \n\n"

        + "ΔT er den temperatur-ændring man ønsker. \n\n"

        + "E er den energimængde der skal til for at varme noget op svarende til ændringen i temperatur ΔT.\n\n"
        + "Med denne formel kan jeg udregne temperatur forskellen ΔT = E/m * c \n\n"
        
        + "Konversionen fra watt til joule/sekunder ser således ud 500w = 500 joule/sekunder. \n\n"

        + "<i>-- Prof. Jameson</i>";

        waterDistillation.AddEntry(new EntryText(waterDistillationText, "Dag: 37 - Distillering af saltvand"));
    }

}
