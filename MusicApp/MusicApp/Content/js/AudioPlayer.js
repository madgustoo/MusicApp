// Playlist events
$("#topTracks tbody tr").on("click", "a", function () {
    $(this).parent().parent().siblings().removeClass("active");
    $(this).parent().parent().addClass("active");

    // Play
    // $("playButton").removeClass();

});


/*
// Audio Player
$("#topTracks tbody tr").on("click", "a", function (event) {
    event.preventDefault();
    $("#audioPlayer")[0].src = this;
    $("#audioPlayer")[0].play();
});

var currentTrack = 0;
// Plays till the end no matter which track is chosen/played first 
$("#audioPlayer")[0].addEventListener("ended", function () {
    // var nextTrack = $("#topTracks tbody tr:eq(" + currentTrack + ")").attr("title");
    currentTrack++;
    
    if (currentTrack == $("#topTracks tbody tr a").length) {
        // restart playlist if end is reached
        currentTrack = 0;
    }
    $("#topTracks tbody tr").removeClass("active");
    // target the current track
    $("#topTracks tbody tr:eq(" + currentTrack + ")").addClass("active");
    $("#audioPlayer")[0].src = $("#topTracks tbody tr a")[currentTrack].href;
    $("#audioPlayer")[0].play();
});
*/

    // index = where the track is right now
    var index = 0,
        playing = false,
        trackItem,
        tracks = [],
        trackCount = 0;

    // Makes an array of tracks
    $("#topTracks tbody tr").each(function (index, value) {
        trackItem = {};
        trackItem["id"] = parseInt($(this).find("td:first-child #trackNo").text()) - 1;
        trackItem["name"] = $(this).find("td:nth-child(2) a").text();
        trackItem["trackUrl"] = $(this).find("td:nth-child(2) a").attr("href");
        tracks.push(trackItem);
    })

    var trackCount = tracks.length,
        npAction = $("#npAction"),
        npTitle = $("#npTitle");

    // Event listeners
    var audio = $('#audioPlayer').bind('play', function () {
        playing = true;
        npAction.text('Now Playing...');
    }).bind('pause', function () {
        playing = false;
        npAction.text('Paused...');
    }).bind('ended', function () {
        // ended == ended by itself and was not the user who ended the track (that's why clicking on next runs the same code e.g index++ )
        npAction.text('Paused...');
        if ((index + 1) < trackCount) {
            index++;
            loadTrack(index);
            audio.play();
        } else {
            audio.pause();
            npAction.text("Click play to restart the playlist");
            // restart the playlist when end is reached
            index = 0;
            loadTrack(index);
        }
    }).get(0);

    function loadTrack(trackId) {
        // toggle active class
        $("#topTracks tbody tr").removeClass("active");
        $("#topTracks tbody tr:eq(" + index + ")").addClass("active");
        npTitle.text(tracks[trackId].name);
        index = trackId;
        audio.src = tracks[trackId].trackUrl;
    }

    function playTrack (trackId) {
        loadTrack(trackId);
        audio.play();
    };

    // Onclick [TopTrack Playlist]
    $("#topTracks tbody tr").on("click", "a", function(event) {
        event.preventDefault();
        // get tr
        var id = parseInt($(this).parent().parent().index());
        playTrack(id);
        // toggle active
        $(this).parent().parent().siblings().removeClass("active");
        $(this).parent().parent().addClass("active");
    });



