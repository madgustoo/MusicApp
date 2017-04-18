/* Auto Search */
var getSearchData = function (request, response) {
    $.ajax({
        type: "GET",
        url: "https://api.spotify.com/v1/search",
        dataType: "json",
        data: {
            type: "artist",
            q: request.term + "*",
            limit: 20
        },
        success: function (data) {
            // $.map: Creates with the JSONArray an array with the stuff we need e.g name, id and image
            var searchArray = $.map(data.artists.items, function (item) {
                // Gets an default existing image first
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


$(".search-textbox").autocomplete({
    source: getSearchData,
    minLength: 2,
    select: function (event, ui) {
        window.location.href = "http://" + document.location.host + "/profile/" + ui.item.id;
        // $("ul.ui-autocomplete").hide();
    }
}).autocomplete("instance")._renderItem = function (ul, item) {
    return $("<li id='select-me'></li>")
    .append("<img class='img-circle' style='width:80px;height:80px;' src='" + item.imageSrc + "' /><span id='select-text'>" + item.name + "</span>")
    .appendTo(ul);
};

// Search request
$(".search-btn").click(function () {
    var searchterm = $("#searchArtist").val();
    console.log(searchterm);
    var searchResult = document.location.host + "/search/" + searchterm;
    window.location.href = "http://" + searchResult;
});


$(".search-textbox").on("keyup", function () {
    if (this.value.length > 1) {
        $("#searchOverlay").removeClass("hidden");
    } else {
        $("#searchOverlay").addClass("hidden");
    }
});