// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    
    var map;
    var InforObj = [];
        var centerCords = {
            lat: -25.344,
            lng: 131.036
        };
        var markersOnMap = [{
            placeName: "Australia (Uluru)",
            LatLng: [{
                lat: -25.344,
                lng: 131.036
            }]
        },
        {
            placeName: "Australia (Melbourne)",
            LatLng: [{
                lat: -37.852086,
                lng: 504.985963
            }]
        },
        {
            placeName: "Australia (Canberra)",
            LatLng: [{
                lat: -35.299085,
                lng: 509.109615
            }]
        },
        {
            placeName: "Australia (Gold Coast)",
            LatLng: [{
                lat: -28.013044,
                lng: 513.425586
            }]
        },
        {
            placeName: "Australia (Perth)",
            LatLng: [{
                lat: -31.951994,
                lng: 475.858081
            }]
        }
        ];

        window.onload = function () {
            initMap();
        };

        function addMarker() {
            for (var i = 0; i < markersOnMap.length; i++) {
                var contentString = '<div id="content"><h1>' + markersOnMap[i].placeName +
                    '</h1><p>Lorem ipsum dolor sit amet, vix mutat posse suscipit id, vel ea tantas omittam detraxit.</p></div>';

                const marker = new google.maps.Marker({
                    position: markersOnMap[i].LatLng[0],
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
                // marker.addListener('mouseover', function () {
                //     closeOtherInfo();
                //     infowindow.open(marker.get('map'), marker);
                //     InforObj[0] = infowindow;
                // });
                // marker.addListener('mouseout', function () {
                //     closeOtherInfo();
                //     infowindow.close();
                //     InforObj[0] = infowindow;
                // });
            }
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
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 4,
                center: centerCords
            });
            addMarker();
        }