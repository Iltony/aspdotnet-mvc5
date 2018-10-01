var map;
var directionsManager;

function GetLocation(theMap) {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition((position) => {
            theMap.center = new Microsoft.Maps.Location(position.coords.longitude, position.coords.latitude);
            
            var center = theMap.getCenter();
            //Create custom Pushpin
            var pin = new Microsoft.Maps.Pushpin(center, { text: ' pochichion ' });
            //Add the pushpin to the map
            theMap.entities.push(pin);
        });
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

async function GetMap() {

    map = new Microsoft.Maps.Map('#testMap', {});
    //Load the directions module.
    Microsoft.Maps.loadModule('Microsoft.Maps.Directions', function () {
        //Create an instance of the directions manager.
        directionsManager = new Microsoft.Maps.Directions.DirectionsManager(map);
        //Create waypoints to route between.
        var seattleWaypoint = new Microsoft.Maps.Directions.Waypoint({ address: 'Seattle, WA' });
        directionsManager.addWaypoint(seattleWaypoint);
        var workWaypoint = new Microsoft.Maps.Directions.Waypoint({ address: 'Work', location: new Microsoft.Maps.Location(47.64, -122.1297) });
        directionsManager.addWaypoint(workWaypoint);
        //Specify the element in which the itinerary will be rendered.
        directionsManager.setRenderOptions({ itineraryContainer: '#directionsItinerary' });
        //Calculate directions.
        directionsManager.calculateDirections();
    });


    await GetLocation(new Microsoft.Maps.Map('#testCoords', { mapTypeId: Microsoft.Maps.MapTypeId.birdseye }));
}
