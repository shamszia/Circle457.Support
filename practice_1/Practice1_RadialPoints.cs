using System.Text;
using Circle457;

/// <summary>
/// This code explains how to draw a radial point using Circle457 geometry design translation.
/// </summary>
public class Practice1_RadialPoints {

    /// <summary>
    /// Explains how to draw individual points using Circle457 and convert them into CSV or other text formats.
    /// This practice code only uses SymmetricHeight Y (or X) and Distance X or (Y) method.
    /// </summary>
    public string DrawIndividualRadialPoints()
    {
        Angle7 angle7 = new Angle7();

        //Switch between Pythagorean or Distance457 distance method translations
        //angle7.DistanceType = DistanceType.Distance457

        //Draw a point at angle 0 with radius 100
        Point7 point7_0 = angle7.GetRadialPointHeightDistance(0, 100);

        //Draw a point at angle 45 with radius 100
        Point7 point7_1 = angle7.GetRadialPointHeightDistance(45, 100);

        //Draw a point at angle 90 with radius 100
        Point7 point7_2 = angle7.GetRadialPointHeightDistance(90, 100);

        //Draw a point at angle 135 with radius 100
        Point7 point7_3 = angle7.GetRadialPointHeightDistance(135, 100);

        //Draw a point at angle 180 with radius 100
        Point7 point7_4 = angle7.GetRadialPointHeightDistance(180, 100);

        //Draw a point at angle 225 with radius 100
        Point7 point7_5 = angle7.GetRadialPointHeightDistance(225, 100);

        //Draw a point at angle 270 with radius 100
        Point7 point7_6 = angle7.GetRadialPointHeightDistance(270, 100);

        //Draw a point at angle 315 with radius 100
        Point7 point7_7 = angle7.GetRadialPointHeightDistance(315, 100);

        //Draw a point at angle 360 with radius 100
        Point7 point7_8 = angle7.GetRadialPointHeightDistance(360, 100);

        StringBuilder stringBuilder = new StringBuilder();

        //convert above points 1-9 into CSV or Other Text format for drawing
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_0.X, point7_0.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_1.X, point7_1.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_2.X, point7_2.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_3.X, point7_3.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_4.X, point7_4.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_5.X, point7_5.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_6.X, point7_6.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_7.X, point7_7.Y));
        stringBuilder.AppendLine(string.Format(",{0},{1},", point7_8.X, point7_8.Y));

        //csv format is supported by libreCAD ascii plugin 
        //for drawing radial points
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Explains how to draw angle points using Circle457 and convert them into CSV or other text formats.
    /// </summary>
    /// <param name="start_angle"></param>
    /// <param name="end_angle"></param>
    /// <param name="step"></param>
    /// <returns></returns>
    public string DrawRadialPoints(double start_angle = 0, double end_angle = 360, double step = 2)
    {   
        string csv_text = string.Empty;
        Angle7 angle7 = new Angle7();

        //Switch between Pythagorean or Distance457 distance method translations
        //angle7.DistanceType = DistanceType.Distance457

        double angleStepFraction = (1d / step);

        StringBuilder stringBuilder = new StringBuilder();

        double radius = 100;
        for (var a = start_angle; a <= end_angle; a += angleStepFraction)
        {
            //Gets radial point that symmetric height (y or x) and distance (Pythagorean or Distance457) x or y
            var radialPoint = angle7.GetRadialPointHeightDistance(a, radius);
            stringBuilder.AppendLine(string.Format(",{0},{1},", radialPoint.X, radialPoint.Y));
        }

        //csv format is supported by libreCAD ascii plugin 
        //for drawing radial points
        return stringBuilder.ToString();
    }
}