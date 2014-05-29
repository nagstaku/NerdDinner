var map;
var markers = [];
function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(37.09024, -96.712891),
        zoom: 3
    };
    map = new google.maps.Map(document.getElementById("map-canvas"),
        mapOptions);

    markers.push(new google.maps.Marker({
        position: new google.maps.LatLng(
            Number(document.getElementById("address-0-Lat").value),
            Number(document.getElementById("address-0-Lng").value)
            ),
        map: map
    }));

    markers.push(new google.maps.Marker({
        position: new google.maps.LatLng(
            Number(document.getElementById("address-1-Lat").value),
            Number(document.getElementById("address-1-Lng").value)
            ),
        map: map,
        icon: 'http://maps.gstatic.com/mapfiles/markers2/icon_green.png'
    }));

    markers.push(new google.maps.Marker({
        position: new google.maps.LatLng(
            Number(document.getElementById("address-2-Lat").value),
            Number(document.getElementById("address-2-Lng").value)
            ),
        map: map,
        icon: 'http://maps.gstatic.com/mapfiles/markers2/boost-marker-mapview.png'
    }));
}

function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function clearMarkers() {
    setAllMap(null);
}

function deleteMarkers() {
    clearMarkers();
    markers = [];
}

function findEvent(lat, lng) {
    map.panTo(new google.maps.LatLng(lat, lng));
    map.setZoom(4);
}
google.maps.event.addDomListener(window, 'load', initialize);