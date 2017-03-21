﻿$(document).ready(function () {
    alert("JavaScript loaded");

    var getSearchData = function (request, response) {
        var artistName = request.term;
        artistName += "*";
        $.ajax({
            type: "GET",
            url: "https://api.spotify.com/v1/search",
            dataType: "json",
            data: {
                type: "artist",
                q: artistName,
                limit: 1
            },
            success: function (data) {
                // $.map: Creates with the JSONArray an array with the stuff we need e.g name, id and image
                var searchArray = $.map(data.artists.items, function (item) {
                    // Gets an existing image
                    var image = "http://www.nugget.ca/assets/img/default/contributor.jpg"
                    if (item.images.length > 0) {
                        image = item.images[0].url;
                    }

                    return {
                        id: item.id,
                        name: item.name,
                        imageSrc: image
                    }
                });
                response(searchArray);
            }
        });
    }

    $("#MySearch").autocomplete({
        source: getSearchData,
        select: function (event, ui) {
            // alert(ui.item.name);
            // window.location.href = ui.item.id;
            $("ul.ui-autocomplete").hide();
        }
    }).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li></li>")
        .append("<a>" + "<img class='rounded-circle img-responsive' height='80' width='80'style='margin:1%' src='" + item.imageSrc + "' />" + item.name + "</a>")
        .appendTo(ul);
    };

});
