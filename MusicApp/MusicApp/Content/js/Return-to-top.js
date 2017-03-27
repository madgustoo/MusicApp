$(window).scroll(function () {
    // If page is scrolled more than 50px
    if ($(this).scrollTop() >= 50) {
        // Fade in the arrow
        $('#return-to-top').fadeIn(200);    
    } else {
        // Else fade out the arrow
        $('#return-to-top').fadeOut(200);  
    }
});

// When arrow is clicked
$('#return-to-top').click(function () {
    // Scroll to top of body
    $('body,html').animate({
        scrollTop : 0                      
    }, 500);
});