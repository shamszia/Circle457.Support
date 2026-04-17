using Circle457;
using System.IO;
namespace ConsoleApp;
public class TestDataInformation
{
    public string id;
    public double angle7;
    public double radius;
    public Point7 point1Data;
    public ComputedPoint7 computedPoint7;
    public Point7 point2Data;
    public Point7[] pointsData;
    public bool print9045 = true;
    public bool print450 = true;

    public override string ToString()
    {
        if (!string.IsNullOrEmpty(id))
        {
            if (id.Equals("Angle7"))
            {
                return string.Format("{{ \"id\": \"Angle7\", \"value\": {0}, \"data\": {{ \"x1\": {1}, \"y1\": {2}, \"x2\": {3}, \"y2\": {4} }} }}", 
                angle7, point1Data.X, point1Data.Y, point2Data.X, point2Data.Y);
            }
            else if (id.Equals("Point7"))
            {
                return string.Format("{{ \"id\": \"Point7\", \"angle\": {0}, \"radius\": {1}, \"data\": [ {{ \"x\": {2}, \"y\": {3} }} ] }}", 
                angle7, radius, point1Data.X, point1Data.Y);
            }
            else if (id.Equals("ComputedPoint7"))
            {
                return string.Format("{{ \"id\": \"ComputedPoint7\", \"angle\": {0}, \"radius\": {1}, \"data\": [ {{ \"X7Angle\": {2}, \"Y7Angle\": {3}, \"RadiusDistance\": {4}, \"X7Fraction\": {5}, \"Y7Fraction\": {6}, \"x\": {7}, \"y\": {8} }} ] }}", 
                angle7, radius, 
                computedPoint7.AssociatedXHeightAngle, 
                computedPoint7.AssociatedYHeightAngle, 
                computedPoint7.AssociatedRadiusDistance, 
                computedPoint7.AssociatedXHeightAngleFraction, 
                computedPoint7.AssociatedYHeightAngleFraction, 
                computedPoint7.X, 
                computedPoint7.Y);
            }
            else
            {
                //[ { \"x\": {0}, \"y\": {1} } ]
                string pointsText = string.Empty;
                if (pointsData != null)
                {
                    foreach(var pointData in pointsData)
                    {
                        if (pointData != null)
                        {
                            if (pointData.GetType().ToString().EndsWith("ComputedPoint7"))
                            {
                                var computedPoint7 = (ComputedPoint7)pointData;

                                System.Console.WriteLine("print9045 = {0}, print450 = {1}, <X = {2}", print9045, print450, computedPoint7.AssociatedXHeightAngle);

                                //x90 toward x45, 0 is x90 90 and 45 is x90 45.
                                if (print9045 && computedPoint7.AssociatedXHeightAngle >= 0 && computedPoint7.AssociatedXHeightAngle <= 45)
                                {
                                    pointsText += string.Format("{{ \"X7Angle\": {0}, \"Y7Angle\": {1}, \"RadiusDistance\": {2}, \"X7Fraction\": {3}, \"Y7Fraction\": {4}, \"x\": {5}, \"y\": {6} }},", 
                                    computedPoint7.AssociatedXHeightAngle, 
                                    computedPoint7.AssociatedYHeightAngle, 
                                    computedPoint7.AssociatedRadiusDistance, 
                                    computedPoint7.AssociatedXHeightAngleFraction, 
                                    computedPoint7.AssociatedYHeightAngleFraction, 
                                    computedPoint7.X, 
                                    computedPoint7.Y);
                                }
                                else if (!print9045 && computedPoint7.AssociatedXHeightAngle >= 0 && computedPoint7.AssociatedXHeightAngle <= 45)
                                {
                                    pointsText += string.Format("{{ \"Status\": \"Skipped\",  \"X7Angle\": {0}, \"Y7Angle\": {1}, \"RadiusDistance\": {2}, \"X7Fraction\": {3}, \"Y7Fraction\": {4}, \"x\": {5}, \"y\": {6} }},", 
                                    computedPoint7.AssociatedXHeightAngle, 
                                    computedPoint7.AssociatedYHeightAngle, 
                                    computedPoint7.AssociatedRadiusDistance, 
                                    computedPoint7.AssociatedXHeightAngleFraction, 
                                    computedPoint7.AssociatedYHeightAngleFraction, 
                                    computedPoint7.X, 
                                    computedPoint7.Y);
                                }

                                //x90 toward x45, 44 is x45 44 and 90 is x45 0.
                                if (print450 && computedPoint7.AssociatedXHeightAngle > 45 && computedPoint7.AssociatedXHeightAngle <= 90)
                                {
                                    pointsText += string.Format("{{ \"X7Angle\": {0}, \"Y7Angle\": {1}, \"RadiusDistance\": {2}, \"X7Fraction\": {3}, \"Y7Fraction\": {4}, \"x\": {5}, \"y\": {6} }},", 
                                    computedPoint7.AssociatedXHeightAngle, 
                                    computedPoint7.AssociatedYHeightAngle, 
                                    computedPoint7.AssociatedRadiusDistance, 
                                    computedPoint7.AssociatedXHeightAngleFraction, 
                                    computedPoint7.AssociatedYHeightAngleFraction, 
                                    computedPoint7.X, 
                                    computedPoint7.Y);
                                }
                                else if (!print450 && computedPoint7.AssociatedXHeightAngle > 45 && computedPoint7.AssociatedXHeightAngle <= 90)
                                {
                                    pointsText += string.Format("{{ \"Status\": \"Skipped\", \"X7Angle\": {0}, \"Y7Angle\": {1}, \"RadiusDistance\": {2}, \"X7Fraction\": {3}, \"Y7Fraction\": {4}, \"x\": {5}, \"y\": {6} }},", 
                                    computedPoint7.AssociatedXHeightAngle, 
                                    computedPoint7.AssociatedYHeightAngle, 
                                    computedPoint7.AssociatedRadiusDistance, 
                                    computedPoint7.AssociatedXHeightAngleFraction, 
                                    computedPoint7.AssociatedYHeightAngleFraction, 
                                    computedPoint7.X, 
                                    computedPoint7.Y);
                                }
                            }
                            else
                            {
                                pointsText += string.Format("{{ \"x\": {0}, \"y\": {1} }},", pointData.X, pointData.Y);
                            }
                        }
                    }

                    if (pointsText.Length > 0)
                    {
                        pointsText = pointsText.Remove(pointsText.Length - 1, 1);
                    }
                }

                return string.Format("{{ \"id\": \"{0}\", \"angle\": \"{1}\", \"radius\": \"{2}\", \"data\": [{3}] }}", id, 
                angle7, radius,
                pointsText);
            }
        }

        return null;
    }
}