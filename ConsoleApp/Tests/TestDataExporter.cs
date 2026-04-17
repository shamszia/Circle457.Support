using Circle457;
using System.IO;
namespace ConsoleApp;
public class TestDataExporter
{
    private StreamWriter dataStream = null;

    public void OpenStream(string filename)
    {
        dataStream = new StreamWriter(String.Format("{0}.{1}", filename, "txt"));
    }

    public void CloseStream()
    {
        dataStream.Close();
    }

    public void WriteData(double angle, Point7 point1, Point7 point2, bool endDelimeter=true)
    {
        string textData = (new TestDataInformation { id = "Angle7", angle7 = angle, point1Data = point1, point2Data = point2 }).ToString();
        dataStream.WriteLine(string.Format("{0}{1}", textData, endDelimeter ? "," : "" ));
    }
    
    public void WriteData(string id, Point7 point, bool endDelimeter=true)
    {
        dataStream.WriteLine(string.Format("{0}{1}", (new TestDataInformation { id = id, point1Data = point }).ToString(), endDelimeter ? "," : ""));
    }

    public void WriteData(string id, double angle, double radius, 
    Point7[] arcPoints, bool hx9045 = false, bool hx450 = false, bool endDelimeter=true)
    {
        var dataInformation = new TestDataInformation
        {
            id = id,
            angle7 = angle,
            radius = radius,
            pointsData = arcPoints,
            print9045 = hx9045,
            print450 = hx450
        };

        dataStream.WriteLine(string.Format("{0}{1}", dataInformation.ToString(), endDelimeter ? "," : ""));
    }

    public void ExecuteTests()
    {
        System.Console.WriteLine("Executing Circle 45/7 Tests.");

        OpenStream("circle457-tests");
        dataStream.WriteLine("{ \"id\": \"\", \"title\": \"Circle 45 /7 Geometry Data File\", \"source\": \"Circle 45 /7 Theory\", \"objects\":[ ");

        //ExecutePoint7NewPointTests();
        //ExecutePoint7SetPointTests();
        //ExecuteAngle7Tests();
        //ExecuteBasicLineTests();
        //ExecuteLineTests();
        //ExecuteGetRadialPointHeightDistanceTests();
        //ExecuteArcTests();
        //ExecuteArc45Tests();

        //ExecuteArc45Region45Tests();
        //ExecuteArc45Region45Tests(2);
        //ExecuteArc45Region45Tests(3);
        //ExecuteArc45Region45Tests(4);

        //ExecuteOctetArcPointTests();
        //ExecuteOctetArcLineTests(1);
        //ExecuteOctetArc45Region45Tests(1);
        //ExecuteCircle45Tests(1);
        ExecuteOctet45Tests(1);

        dataStream.WriteLine(" ]}");
        CloseStream();

        System.Console.WriteLine("Completed Circle 45/7 Tests Successfully.");
    }

    public void ExecuteAngle7Tests()
    {
        System.Console.WriteLine("Starting Angle7 Tests.");

        var angle1 = new Angle7();
        WriteData(angle1.GetHeightAngle(0, 0.0000001), angle1.Origin, new Point7(0, 0.0000001));
        WriteData(angle1.GetHeightAngle(0.0000001, 0), angle1.Origin, new Point7(0.0000001, 0));
        WriteData(angle1.GetHeightAngle(0.0000001, 0.0000001), angle1.Origin, new Point7(0.0000001, 0.0000001));
        
        WriteData(angle1.GetHeightAngle(0, 0.00001), angle1.Origin, new Point7(0, 0.00001));
        WriteData(angle1.GetHeightAngle(0.00001, 0), angle1.Origin, new Point7(0.00001, 0));
        WriteData(angle1.GetHeightAngle(0.00001, 0.00001), angle1.Origin, new Point7(0.00001, 0.00001));

        WriteData(angle1.GetHeightAngle(0, 0.001), angle1.Origin, new Point7(0, 0.001));
        WriteData(angle1.GetHeightAngle(0.001, 0), angle1.Origin, new Point7(0.001, 0));
        WriteData(angle1.GetHeightAngle(0.001, 0.001), angle1.Origin, new Point7(0.001, 0.001));
        
        WriteData(angle1.GetHeightAngle(0, 0.1), angle1.Origin, new Point7(0, 0.1));
        WriteData(angle1.GetHeightAngle(0.1, 0), angle1.Origin, new Point7(0.1, 0));
        WriteData(angle1.GetHeightAngle(0.1, 0.1), angle1.Origin, new Point7(0.1, 0.1));
        
        WriteData(angle1.GetHeightAngle(0, 5), angle1.Origin, new Point7(0, 5));
        WriteData(angle1.GetHeightAngle(1, 5), angle1.Origin, new Point7(1, 5));
        WriteData(angle1.GetHeightAngle(2, 5), angle1.Origin, new Point7(2, 5));

        WriteData(angle1.GetHeightAngle(3, 5), angle1.Origin, new Point7(3, 5));
        WriteData(angle1.GetHeightAngle(4, 5), angle1.Origin, new Point7(4, 5));
        WriteData(angle1.GetHeightAngle(5, 5), angle1.Origin, new Point7(5, 5));

        WriteData(angle1.GetHeightAngle(6, 5), angle1.Origin, new Point7(6, 5));
        WriteData(angle1.GetHeightAngle(7, 5), angle1.Origin, new Point7(7, 0));
        WriteData(angle1.GetHeightAngle(8, 5), angle1.Origin, new Point7(8, 1));

        WriteData(angle1.GetHeightAngle(9, 5), angle1.Origin, new Point7(9, 5));
        WriteData(angle1.GetHeightAngle(10, 5), angle1.Origin, new Point7(10, 5));
        WriteData(angle1.GetHeightAngle(11, 5), angle1.Origin, new Point7(11, 5));

        WriteData(angle1.GetHeightAngle(12, 5), angle1.Origin, new Point7(12, 5));
        WriteData(angle1.GetHeightAngle(13, 4), angle1.Origin, new Point7(13, 4));
        WriteData(angle1.GetHeightAngle(14, 3), angle1.Origin, new Point7(14, 3));

        WriteData(angle1.GetHeightAngle(15, 2), angle1.Origin, new Point7(15, 2));
        WriteData(angle1.GetHeightAngle(16, 1), angle1.Origin, new Point7(16, 1));
        WriteData(angle1.GetHeightAngle(17, 0), angle1.Origin, new Point7(17, 0));

        WriteData(angle1.GetHeightAngle(18, -1), angle1.Origin, new Point7(18, -1));
        WriteData(angle1.GetHeightAngle(19, -2), angle1.Origin, new Point7(19, -2));
        WriteData(angle1.GetHeightAngle(20, -3), angle1.Origin, new Point7(20, -3));

        WriteData(angle1.GetHeightAngle(21, -11), angle1.Origin, new Point7(21, -11));
        WriteData(angle1.GetHeightAngle(21, -21), angle1.Origin, new Point7(21, -21));
        WriteData(angle1.GetHeightAngle(21, -22), angle1.Origin, new Point7(21, -22));

        WriteData(angle1.GetHeightAngle(21, -300), angle1.Origin, new Point7(21, -300));
        WriteData(angle1.GetHeightAngle(-10, -10), angle1.Origin, new Point7(-10, -10));
        WriteData(angle1.GetHeightAngle(-50, -50), angle1.Origin, new Point7(-51, -51), false);

        System.Console.WriteLine("Completed Angle7 Tests Successfully.");
    }

    public void ExecutePoint7NewPointTests()
    {
        System.Console.WriteLine("Starting Point7 New Point Tests.");

        int x = 0;
        int y = 0;
        for(var i = 0; i < 20; i++)
        {
            for(var j = 0; j < 10; j++)
            {
                WriteData("Point7", new Point7(x, y), (i == 19 && j == 9) ? false : true);

                x++;
                if (i % 2 == 0)
                {
                    y++;
                }
                else
                {
                    y--;
                }
            }
        }

        System.Console.WriteLine("Completed Point7 New Point Tests Successfully.");
    }

    public void ExecutePoint7SetPointTests()
    {
        System.Console.WriteLine("Starting Point7 SetPoint Tests.");

        var point1 = new Point7(0,0);
        for(var i = 0; i < 20; i++)
        {
            for(var j = 0; j < 20; j++)
            {
                WriteData("Point7", point1);
                point1.SetPoint(i, j * 10);
            }
        }

        for(var i = 0; i < 20; i++)
        {
            for(var j = 0; j < 20; j++)
            {
                WriteData("Point7", point1, (i == 19 && j == 19) ? false : true);
                point1.SetPoint(j * 10, i);
            }
        }

        System.Console.WriteLine("Completed Point7 SetPoint Tests Successfully.");
    }

    public void ExecuteBasicLineTests()
    {
        System.Console.WriteLine("Starting Basic DrawLine Tests.");

        Angle7 angle7 = new Angle7();

        bool hx90_45 = false;
        bool hx45_0 = false;

        bool delta_x = false;
        bool delta_y = false;
        int steps = 1;

        Point7[] dyLine0 = angle7.DrawLine(new Point7(0, 0), new Point7(100, 0), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine0, hx90_45, hx45_0);
        Point7[] dyLine1 = angle7.DrawLine(new Point7(0, 0), new Point7(100, 50), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine1, hx90_45, hx45_0);
        Point7[] dyLine2 = angle7.DrawLine(new Point7(0, 0), new Point7(100, 100), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine2, hx90_45, hx45_0);
        Point7[] dyLine3 = angle7.DrawLine(new Point7(0, 0), new Point7(50, 100), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine3, hx90_45, hx45_0);
        Point7[] dyLine4 = angle7.DrawLine(new Point7(0, 0), new Point7(0, 100), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine4, hx90_45, hx45_0, false);

        System.Console.WriteLine("Completed Basic DrawLine Tests Successfully.");
    }

    public void ExecuteLineTests()
    {
        System.Console.WriteLine("Starting DrawLine Tests.");

        Angle7 angle7 = new Angle7();
        
        WriteData("Point7", new Point7(0,2));
        WriteData("Point7", new Point7(0,102));

        bool hx90_45 = true;
        bool hx45_0 = false;

        bool delta_x = false;
        bool delta_y = false;
        int steps = 1;

        Point7[] dyLine0 = angle7.DrawLine(new Point7(2, 2), new Point7(102, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine0, hx90_45, hx45_0);

        Point7[] dyLine1 = angle7.DrawLine(new Point7(4, 2), new Point7(114, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine1, hx90_45, hx45_0);

        Point7[] dyLine2 = angle7.DrawLine(new Point7(6, 2), new Point7(126, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine2, hx90_45, hx45_0);

        Point7[] dyLine3 = angle7.DrawLine(new Point7(8, 2), new Point7(138, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine3, hx90_45, hx45_0);

        Point7[] dyLine4 = angle7.DrawLine(new Point7(10, 2), new Point7(150, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine4, hx90_45, hx45_0);

        Point7[] dyLine5 = angle7.DrawLine(new Point7(12, 2), new Point7(162, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine5, hx90_45, hx45_0);

        Point7[] dyLine6 = angle7.DrawLine(new Point7(14, 2), new Point7(174, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine6, hx90_45, hx45_0);

        Point7[] dyLine7 = angle7.DrawLine(new Point7(16, 2), new Point7(186, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine7, hx90_45, hx45_0);

        Point7[] dyLine8 = angle7.DrawLine(new Point7(18, 2), new Point7(198, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine8, hx90_45, hx45_0);

        Point7[] dyLine9 = angle7.DrawLine(new Point7(20, 2), new Point7(210, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine9, hx90_45, hx45_0);

        Point7[] dyLine10 = angle7.DrawLine(new Point7(22, 2), new Point7(222, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine10, hx90_45, hx45_0);

        Point7[] dyLine11 = angle7.DrawLine(new Point7(24, 2), new Point7(254, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine11, hx90_45, hx45_0);

        Point7[] dyLine12 = angle7.DrawLine(new Point7(26, 2), new Point7(266, 102), steps, delta_x, delta_y);
        WriteData("ComputedPoint7Line", 0, 0, dyLine12, hx90_45, hx45_0, false);

        System.Console.WriteLine("Completed DrawLine Tests Successfully.");
    }
    
    public void ExecuteGetRadialPointHeightDistanceTests()
    {
        System.Console.WriteLine("Starting GetRadialPointHeightDistance Tests.");

        Angle7 angle7 = new Angle7();
        for (var r = 10; r <= 100; r += 10)
        {
            for (var a = 0; a <= 90; a++)
            {
                var radialPoint = angle7.GetRadialPointHeightDistance(a, r);
                WriteData("Point7", radialPoint, (r == 100 && a == 90) ? false : true);
            }
        }

        System.Console.WriteLine("Completed GetRadialPointHeightDistance Tests Successfully.");
    }

    public void ExecuteArcTests()
    {
        System.Console.WriteLine("Executing Arc Tests.");

        Angle7 angle7 = new Angle7();
        angle7.SetOrigin(300,300);

        var arcEndAngle = 45;
        for (var r = 50; r <= 210; r += 20)
        {
            System.Console.WriteLine("Radius = {0}.", r);
            var arcPoints = angle7.Arc(r, 0, arcEndAngle, 1);

            for(var i = 0; i < arcPoints.Length; i++)
            {
                WriteData("Point7", arcPoints[i], (r == 210 && (i == arcPoints.Length - 1)) ? false : true);
            }

            arcEndAngle += 45;
        }

        System.Console.WriteLine("Completed Arc Tests.");
    }

    public void ExecuteArc45Tests()
    {
        System.Console.WriteLine("Executing Arc45 Tests.");

        Angle7 angle7 = new Angle7();
        angle7.SetOrigin(300, 300);

        var radius = 50;
        var arcStartAngle = 0;
        var arcEndAngle = 45;
        for (var i = 0; i < 8; i++)
        {
            System.Console.WriteLine("Arc = {0}-{1}.", arcStartAngle, arcEndAngle);
            var arcPoints = angle7.Arc(radius, arcStartAngle, arcEndAngle, 1);

            for(var j = 0; j < arcPoints.Length; j++)
            {
                WriteData("Point7", arcPoints[j], (i == 7 && (j == (arcPoints.Length - 1))) ? false : true);
            }

            arcStartAngle += 45;
            arcEndAngle += 45;

            radius += 20;
        }

        System.Console.WriteLine("Completed Arc45 Tests.");
    }

    public void ExecuteArc45Region45Tests(int steps = 1)
    {
        System.Console.WriteLine("Executing Arc45 Region45 Tests.");

        Angle7 angle7 = new Angle7();
        angle7.SetOrigin(300, 300);

        var radius = 50;
        for (var i = 1; i <= 8; i++)
        {
            System.Console.WriteLine("Arc45 = {0}.", ((Region45)i).ToString());
            var arcPoints = angle7.Arc45(radius, (Region45)i, steps);

            for (var j = 0; j < arcPoints.Length; j++)
            {
                if (arcPoints[j] == null)
                {
                    System.Console.WriteLine("Arc45[{0}] = null.", j);
                }
                else
                {
                    WriteData("Point7", arcPoints[j], (i == 8 && (j == (arcPoints.Length - 1))) ? false : true);
                }
            }

            radius += 20;
        }

        System.Console.WriteLine("Completed Arc45 Region45 Tests.");
    }

    public void ExecuteCircle45Tests(int steps = 1)
    {
        System.Console.WriteLine("Executing Circle45 Tests.");
        int delimeterLength = 0;

        for (var r = 10; r <= 50; r += 10)
        {
            var circleArcPoints = new Circle457.Circle457(300, 300, r).GetCircle(steps);
            delimeterLength = 0;
            foreach (var arcPoint in circleArcPoints)
            {
                if (arcPoint != null)
                {
                    WriteData("Point7", arcPoint, (r == 50 && (delimeterLength == circleArcPoints.Length - 1)) ? false : true);
                }
                delimeterLength++;
            }
        }

        System.Console.WriteLine("Completed Circle45 Tests.");
    }

    public void ExecuteOctetArcPointTests()
    {
        System.Console.WriteLine("Executing Octet Arc Point Tests.");

        Angle7 angle7 = new Angle7();
        angle7.SetOrigin(300,300);

        for (var r = 50; r <= 150; r += 20)
        {
            System.Console.WriteLine("Drawing octet points with radius = {0}.", r);
            for (var a = 0; a <= 360; a++)
            {
                var octetPoint = angle7.GetOctetPointXY(a, r);
                WriteData("Point7", octetPoint, (r == 150 && a == 360) ? false : true);
            }
        }

        System.Console.WriteLine("Completed Octet Arc Point Tests.");
    }

    public void ExecuteOctetArcLineTests(int steps = 1)
    {
        System.Console.WriteLine("Executing Octet Arc Line Tests.");

        Angle7 angle7 = new Angle7();
        angle7.SetOrigin(300,300);

        var arcEndAngle = 45;
        for (var r = 50; r <= 210; r += 20)
        {
            System.Console.WriteLine("Radius = {0}.", r);
            var arcPoints = angle7.OctetArc(r, 0, arcEndAngle, steps);

            for(var i = 0; i < arcPoints.Length; i++)
            {
                WriteData("Point7", arcPoints[i], (r == 210 && i == (arcPoints.Length - 1)) ? false : true);
            }

            arcEndAngle += 45;
        }

        System.Console.WriteLine("Completed Octet Arc Line Tests.");
    }

    public void ExecuteOctetArc45Region45Tests(int steps = 1)
    {
        System.Console.WriteLine("Executing OctetArc45 Region45 Tests.");

        Angle7 angle7 = new Angle7();
        angle7.SetOrigin(300, 300);

        var radius = 50;
        for (var i = 1; i <= 8; i++)
        {
            System.Console.WriteLine("OctetArc45 = {0}.", ((Region45)i).ToString());
            var arcPoints = angle7.OctetArc45(radius, (Region45)i, steps);

            for (var j = 0; j < arcPoints.Length; j++)
            {
                if (arcPoints[j] == null)
                {
                    System.Console.WriteLine("OctetArc45[{0}] = null.", j);
                }
                else
                {
                    WriteData("Point7", arcPoints[j], (i == 8 && (j == (arcPoints.Length - 1))) ? false : true);
                }
            }

            radius += 20;
        }

        System.Console.WriteLine("Completed OctetArc45 Region45 Tests.");
    }

    public void ExecuteOctet45Tests(int steps = 1)
    {
        System.Console.WriteLine("Executing Octet45 Tests.");

        int delimeterLength = 0;

        for (var r = 10; r <= 50; r += 10)
        {
            var octetArcPoints = new Circle457.Octet457(300, 300, r).GetOctet(steps);
            delimeterLength = 0;
            foreach (var arcPoint in octetArcPoints)
            {
                if (arcPoint != null)
                {
                    WriteData("Point7", arcPoint, (r == 50 && (delimeterLength == (octetArcPoints.Length - 1))) ? false : true);
                }
                delimeterLength++;
            }
        }

        System.Console.WriteLine("Completed Octet45 Tests.");
    }
}