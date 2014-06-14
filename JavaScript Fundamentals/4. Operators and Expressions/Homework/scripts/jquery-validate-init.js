/*jslint browser: true*/
/*global $, jQuery*/

$(document).ready(function () {
    'use strict';

    /**
     * Integrate jquery validate error messages with twitter bootstrap 
     */
    jQuery.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    /**
     * Custom validator for positive or negative integers
     */
    jQuery.validator.addMethod('integer', function (value) {
        var integerRegExp = /(^-?\d\d*$)/;

        return integerRegExp.test(value);
    }, 'Please enter a valid integer');
});
