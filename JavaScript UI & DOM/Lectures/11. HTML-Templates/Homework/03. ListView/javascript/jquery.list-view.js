(function ($) {
    $.fn.listView = function (collection) {
        var $this = $(this),
            templateId = $this.data('template'),
            template;

        if (templateId === undefined) {
            throw 'Data template is not set';
        }

        template = Handlebars.compile($('#' + templateId).html());
        $this.append(template(collection));

        return $this;
    }
}($));