This practice code demonstrates:

1. Circle457 Radial Point Drawing
2. Start .NET 8/10 Console Project
3. Install Nuget Package "dotnet add package Circle457 --version 2.1.0.23"
4. Import (or Copy Paste) Practice Code File
5. Write Practice Code Ouput to Text Files in (Program.cs)

Example:
var csv_text = new Practice1_RadialPoints().DrawRadialPoints();
var textFile1 = System.IO.File.CreateText("radialpoint.csv");
textFile1.Write(csv_text);
textFile1.Close();

6. Open radialpoint.csv in LibreCAD (using ascii plugin).


Circle457 is a new geometrical solution to 2D radial points translations. It is an alternative technology with different heights design. 
https://www.researchgate.net/publication/381800443_Circle_457_Theory_Research_Book
and Implementation
https://www.nuget.org/packages/Circle457

Circle 45 /7 (Features)
*one of its unique points is its capacity to translate symmetric heights (y) to slope displacement (x) forming coordinates without specialized translators (like COS and SINE functions). i.e. provide angle height direct translation with correct coordinate resolutions.
*its angles or not translation dependent
*angle originating source circle theory and design that is directly propotional to symmetric height and vice versa.
