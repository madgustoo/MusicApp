/* Favorite & Unfavorite */

$(".change-icon .fa").click(function () {

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
