using Circle457;

namespace ConsoleApp;

public partial class Program
{
    static void Main(string[] args)
    {
        /*
        Angle7 angle7 = new Angle7();
        System.Console.WriteLine("X: {0}, Y:{1}", angle7.GetRadialPointXY(45, 10).X, angle7.GetRadialPointXY(45, 10).Y);
        System.Console.WriteLine("Height Angle: {0}", angle7.GetHeightAngle(5, 3));*/

        TestDataExporter testDataExporter = new TestDataExporter();

        testDataExporter.ExecuteTests();

        System.Console.Read();
    }
}
