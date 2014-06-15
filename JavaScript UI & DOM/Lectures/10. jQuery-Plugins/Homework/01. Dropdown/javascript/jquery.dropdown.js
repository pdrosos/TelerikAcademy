/**
 * A basic select box plugin
 */
(function($) {
    $.fn.dropdown = function() {
        var $this = $(this);

        if (!$($this).is('select')) {
            return $this;
        }

        $($this).hide();
        $($this).after(renderDropdown($this));

        function renderDropdown(selectBox) {
            var dropdownContainer,
                dropdown,
                option;

            dropdownContainer = $('<div>').addClass('dropdown-list-container');
            $(dropdownContainer).append($('<a>').attr('href', '#').addClass('dropdown-list-toggle'));
            dropdown = $('<ul>').addClass('dropdown-list-options');

            $(selectBox).find('option').each(function() {
                option = $('<li>')
                    .addClass('dropdown-list-option')
                    .attr('data-value', $(this).attr('value'))
                    .html($(this).html());

                // if the corresponding select option is not selected, hide the li
                if (!$(this).is(':selected')) {
                    $(option).hide();
                    $(dropdown).append(option); // put selected element at the top of the list
                } else {
                    $(option).addClass('selected');
                    $(dropdown).prepend(option);
                }
            });

            $(dropdownContainer).append(dropdown);

            return dropdownContainer;
        }

        // open dropdown arrow
        $(document).on('click', '.dropdown-list-container a.dropdown-list-toggle', function(event) {
            $(this).removeClass('dropdown-list-toggle').addClass('dropdown-list-toggle-open');
            $(this).next('ul.dropdown-list-options').find('li').show();
            event.preventDefault();
        });

        // close dropdown arrow
        $(document).on('click', '.dropdown-list-container a.dropdown-list-toggle-open', function(event) {
            $(this).removeClass('dropdown-list-toggle-open').addClass('dropdown-list-toggle');
            $(this).next('ul.dropdown-list-options').find('li:not(.selected)').hide();
            event.preventDefault();
        });

        // click on not selected li
        $(document).on('click', '.dropdown-list-container li:not(.selected)', function() {
            // mark it as selected and move in at the top of the list
            $(this).siblings().removeClass('selected');
            $(this).addClass('selected');
            $(this).prependTo($(this).parent());

            // change the selected value of the real select element
            $(this).parents('.dropdown-list-container').prev().val($(this).attr('data-value'));

            // close dropdown
            $(this).parents('.dropdown-list-container').find('a').trigger('click');
        });

        // click on selected li
        $(document).on('click', '.dropdown-list-container li.selected', function() {
            // close dropdown
            $(this).parents('.dropdown-list-container').find('a').trigger('click');
        });

        return $this;
    }
}(jQuery));
