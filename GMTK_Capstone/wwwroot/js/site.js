// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    
var map;
var InforObj = [];
var centerCords = {
    lat: 39.5501,
    lng: 105.7821
};
var markersOnMap = [{
    placeName: "Australia (Uluru)",
    LatLng: [{
        lat: -25.344,
        lng: 131.036
    }]
}
];

window.onload = function () {
    initMap();
};

function addMarker(location) {
    var contentString = '<div id="content"><h1>' +
        '</h1><p>Lorem ipsum dolor sit amet, vix mutat posse suscipit id, vel ea tantas omittam detraxit.</p></div>';

    const marker = new google.maps.Marker({
        position: new google.maps.LatLng(location),
        map: map
    });

    const infowindow = new google.maps.InfoWindow({
        content: contentString,
        maxWidth: 200
    });

    marker.addListener('click', function () {
        closeOtherInfo();
        infowindow.open(marker.get('map'), marker);
        InforObj[0] = infowindow;
    });
}
function closeOtherInfo() {
    if (InforObj.length > 0) {
        /* detach the info-window from the marker ... undocumented in the API docs */
        InforObj[0].set("marker", null);
        /* and close it */
        InforObj[0].close();
        /* blank the array */
        InforObj.length = 0;
    }
}

function initMap() {
    map = new google.maps.Map(document.getElementById('map'),{
        zoom: 4,
        center: centerCords
    });
}


function geocode(location) {
    axios.get('https://maps.googleapis.com/maps/api/geocode/json', {
        params: {
            address: location,
            key: 'AIzaSyBVV2TYOJm5Z8KmSI8ygu8zoRdaTzDYqxo'
        }
    })
        .then(function (response) {
            addMarker(location);
        })
        .catch(function (error) {
            consol.log(error)
        });
}
//.latlngbounds
//Postman tests
//What object is coming back from query
//Iterate through databse in JS to use locations as pins
//