/*
    Circle 45 /7 is new theory to circle geometry and/or angle radial points. Circle 45 /7 design 
    and constants are copyright material of Shams Zia. Circle 45 /7 is patent applied at IPO Pakistan.

    Circle 45 /7 is published research:
    Zia, Shams, (Oct, 2023). Circle 45 /7 Theory Research Book, Eliva Press (ISBN: 978-99993-1-170-0)
*/

//Circle 45 /7 design and angle constants. 
const H71 = 0.707107; //In XY Plane, Angle 45 Unit Height PI-45 (0-45) degrees or vice versa.
const D29 = 0.292893; //In XY Plane, Angle 45 Unit Height PI-90 (45-90) degrees or vice versa.
const H71C = 0.01571348888889; //In XY Plane, PI-45 Y Height Constant or PI-90 X Height Constant
const D29C = 0.00650873333333; //In XY Plane, PI-90 Y Height Constant or PI-45 X Height Constant

function draw_pixel(x=0, y=0, status=null) {
    //initializes canvas 2d context
    const canvas = document.getElementById("circle457-canvas");
    const context = canvas.getContext("2d");
    const imageData = context.createImageData(1,1);
    const data = imageData.data;
    
    var statusColorR = 0;
    var statusColorG = 0;
    var statusColorB = 0;

    if (status !== null && status !== undefined) {
        
        if (status === "Skipped") {

            statusColorR = 255;
        }
        else if (status === "Red") {

            statusColorR = 255;
        }
        else if (status === "Green") {

            statusColorG = 255;
        }
        else if (status === "Blue") {
            
            statusColorB = 255;
        }
        else if (status === "Random") {

            var randomColorValue = Math.random() * 255;
            
            statusColorR = randomColorValue;
            statusColorG = randomColorValue;
            statusColorB = randomColorValue;
        }
    }

    //pixel color profile
    data[0] = statusColorR;
    data[1] = statusColorG;
    data[2] = statusColorB;
    data[3] = 255;

    context.putImageData(imageData, x, y);
}

function load_and_parse_data() {

    document.getElementById("data-stats").innerHTML = "";
    
    var jsonData = document.getElementById('json-text-data').value;
    var jsonObject = JSON.parse(jsonData);

    if (jsonObject !== null && jsonObject !== undefined) {
        if (jsonObject.objects !== null && jsonObject.objects !== undefined) {

            var dataObjects = jsonObject.objects;
            dataObjects.forEach(circle45Object => {

                if (circle45Object.id === "Angle7") {
                    
                    var width = undefined;
                    var height = undefined;
                    var deltaY = Math.abs(circle45Object.data.y2 - circle45Object.data.y1);
                    var deltaX = Math.abs(circle45Object.data.x2 - circle45Object.data.x1);
                    var radius = Math.sqrt(Math.pow(deltaX, 2) + Math.pow(deltaY, 2));

                    width = deltaX;
                    height = deltaY;
                    if (width < height) {
                        width = height;
                        height = deltaX;

                        var data = 90 - (height/(radius * H71C));
                        document.getElementById("data-stats").innerHTML += "<div>Angle7: " + data + "</div>";
                    }
                    else {

                        var data = height/(radius * H71C);
                        document.getElementById("data-stats").innerHTML += "<div>Angle7: " + data + "</div>";
                    }
                }
                else if (circle45Object.id === "ComputedPoint7Line") { 

                    if (circle45Object.data !== null && circle45Object.data !== undefined) {

                        document.getElementById("data-stats").innerHTML += "<div><b>" + circle45Object.id + "</b></div>";
                        document.getElementById("data-stats").innerHTML += "<div>Object Angle: " + circle45Object.angle + "</div>";
                        document.getElementById("data-stats").innerHTML += "<div>Object Radius: " + circle45Object.radius + "</div>";

                        circle45Object.data.forEach(point => {

                            //X7Angle Y7Angle RadiusDistance X7Fraction Y7Fraction

                            draw_pixel(point.x, point.y, point.Status);
                            document.getElementById("data-stats").innerHTML += "<div><b>x:</b>&nbsp;&nbsp;" + point.x + ", <b>y:</b>&nbsp;&nbsp;" + point.y + ", <b>Status:</b>&nbsp;&nbsp;" + point.Status + "</div>";
                            document.getElementById("data-stats").innerHTML += "<div>x7:&nbsp;&nbsp;" + point.X7Angle + ", y7:&nbsp;&nbsp;" + point.Y7Angle + ", d:&nbsp;&nbsp;" + point.RadiusDistance + "</div>";
                            document.getElementById("data-stats").innerHTML += "<div>x7f:&nbsp;&nbsp;" + point.X7Fraction + ", y7f:&nbsp;&nbsp;" + point.Y7Fraction + "</div>";
                        });
                    }
                }
                else {

                    if (circle45Object.data !== null && circle45Object.data !== undefined) {

                        document.getElementById("data-stats").innerHTML += "<div><b>" + circle45Object.id + "</b></div>";
                        circle45Object.data.forEach(point => {

                            draw_pixel(point.x, point.y);
                            document.getElementById("data-stats").innerHTML += "<div>Point7: x:" + point.x + ", y:" + point.y + "</div>";
                        });
                    }
                }
            });
        }
    }
}

function script_app() {
    
    load_and_parse_data();
}