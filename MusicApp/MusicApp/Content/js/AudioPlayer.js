// Playlist events
$("#topTracks tbody tr").on("click", "a", function () {
    $(this).parent().parent().siblings().removeClass("active");
    $(this).parent().parent().addClass("active");

    // Play
    // $("playButton").removeClass();

});



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
