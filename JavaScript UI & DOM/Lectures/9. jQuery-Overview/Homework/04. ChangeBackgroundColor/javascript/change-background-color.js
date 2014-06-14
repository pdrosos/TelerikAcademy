jQuery(document).ready(function ($) {
    $('#colorPicker').on('change', function() {
        $('body').css('background-color', $(this).val());
    });
});