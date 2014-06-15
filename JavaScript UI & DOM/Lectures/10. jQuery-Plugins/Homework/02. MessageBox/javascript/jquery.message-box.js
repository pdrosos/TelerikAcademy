/**
 * A very basic fadeIn and fadeOut message box plugin
 */
(function($) {
    $.fn.messageBox = function(options) {
        var $this = $(this);

        /* Default plugin settings */
        var defaults = {
            fadeInDuration: 1000,
            visibilityDuration: 3000,
            fadeOutDuration: 1000
        };

        /* merge defaults and options, without modifying defaults and options objects */
        var settings = $.extend({}, defaults, options);

        /* fadeIn and fadeOut the messages */
        $($this).fadeIn(settings.fadeInDuration).delay(settings.visibilityDuration).fadeOut(settings.fadeOutDuration);

        return $this;
    }
}(jQuery));
