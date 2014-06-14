jQuery(document).ready(function ($) {
    var autoPlayIntervalId,
        slideCount = $('#slider > ul > li').length,
        slideWidth = $('#slider > ul > li').width(),
        slideHeight = $('#slider > ul > li').height(),
        sliderUlWidth = slideCount * slideWidth;

    $('#auto-play').on('change', function() {
        if ($(this).is(':checked')) {
            autoPlayIntervalId = setInterval(function () {
                moveRight();
            }, 5000);
        } else {
            clearInterval(autoPlayIntervalId);
        }
    });

    $('#slider').css({ width: slideWidth, height: slideHeight });

    $('#slider > ul').css({ width: sliderUlWidth, marginLeft: - slideWidth });

    $('#slider > ul > li:last-child').prependTo('#slider > ul');

    function moveLeft() {
        $('#slider > ul').animate({
            left: + slideWidth
        }, 200, function () {
            $('#slider > ul > li:last-child').prependTo('#slider > ul');
            $('#slider > ul').css('left', '');
        });
    };

    function moveRight() {
        $('#slider > ul').animate({
            left: - slideWidth
        }, 200, function () {
            $('#slider > ul > li:first-child').appendTo('#slider > ul');
            $('#slider > ul').css('left', '');
        });
    };

    $('a.control-prev').click(function () {
        moveLeft();
    });

    $('a.control-next').click(function () {
        moveRight();
    });
});