jQuery(document).ready(function ($) {
    $('#tasks-list .move-up').on('click', function() {
        $(this).parent().insertBefore($(this).parent().prev());
    });

    $('#tasks-list .move-down').on('click', function() {
        $(this).parent().insertAfter($(this).parent().next());
    });
});