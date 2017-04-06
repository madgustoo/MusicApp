// index = where the track is right now
var index = 0,
    trackItem,
    tracks = [],
    trackCount = 0;

// Makes an array of tracks TOPTRACKS
$("#topTracks tbody tr").each(function (index, value) {
    trackItem = {};
    trackItem["id"] = parseInt($(this).find("td:first-child .trackNo").text()) - 1;
    trackItem["name"] = $(this).find("td:nth-child(2) a").text();
    trackItem["trackUrl"] = $(this).find("td:nth-child(2) a").attr("href");
    tracks.push(trackItem);
})

var trackCount = tracks.length,
    npAction = $("#npAction"),
    npTitle = $("#npTitle");

// Event listeners
var audio = $('#audioPlayer').bind('play', function () {
    npAction.text('Now Playing...');
}).bind('pause', function () {
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
        npAction.text("Paused...");
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
$("#topTracks tbody tr").on("click", "#trackName", function (event) {
    event.preventDefault();
    // get tr [table row]
    var id = parseInt($(this).parent().index());
    playTrack(id);
    // toggle active class
    $(this).parent().siblings().removeClass("active");
    $(this).parent().addClass("active");
});

// Next and Previous
$("#btnNext").click(function () {
    if ((index + 1) < trackCount) {
        index++;
        loadTrack(index);
        audio.play();
    } else {
        audio.pause();
        npAction.text("Paused...");
        // restart the playlist when end is reached
        index = 0;
        loadTrack(index);
    }
});

$("#btnPrev").click(function () {
    if ((index - 1) > -1) {
        index--;
        loadTrack(index);
        audio.play();
    } else {
        audio.pause();
        npAction.text("Paused...");
        // goes to the last track
        index = trackCount - 1;
        loadTrack(index);
    }
});



