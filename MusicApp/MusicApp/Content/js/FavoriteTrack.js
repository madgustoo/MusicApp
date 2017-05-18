/* Favorite & Unfavorite */

$("#topTracks td #favoriteMe").click(function (event) {
    event.preventDefault();
    // get the td
    var thisTrack = $(this).parent().parent();
    var thisFavorite = $(this);
    var data = JSON.parse(thisTrack.attr("name"));
    console.log(data.artistName);
    console.log(data.trackId);
    $.ajax({
        url: "/Profile/AddToFavorites/",
        type: 'POST',
        dataType: 'json',
        data: { trackId: data.trackId, artistName: data.artistName },
        success: function (result) {
            console.log(result);
            // var response = JSON.parse(result);
            if (result.success) {
                console.log("Nice");
                thisFavorite.siblings().remove();
            } else if (result.success == false) {
                //thisFavorite.remove();
                //thisTrack.chilren().append('<i class="fa fa-heart-o" aria-hidden="true"></i><i id="favoriteMe" class="fa fa-heart" aria-hidden="true"></i>');
                console.log("DELETED");
            }
        }
    });
});

$(".change-icon .fa").click(function (event) {
});

// Redirects to track's youtube video with ajax
$("#topTracks td #youtube").click(function (event) {
    // if ($(this).attr("href") == '') {
        event.preventDefault();
        var thisTrack = $(this);
        var data = JSON.parse(thisTrack.attr("name"));
        $.ajax({
            url: "/Profile/YoutubeRedirect/",
            type: 'GET',
            data: { trackName: data.trackName, artistName: data.artistName },
            success: function (result) {
                // thisTrack.attr("href", result);
                window.location.href = result;
            }
        });
    // } 
});
