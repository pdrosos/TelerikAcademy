(function ($) {
    $.fn.listView = function (collection) {
        var $this = $(this),
            templateContent,
            template;

        // {{#each collection}} can not be put directly in the html because of browser parsing issues
        // http://stackoverflow.com/questions/20613352/handlebars-does-not-fill-table
        templateContent = '{{#each collection}}';
        templateContent += $this.html();
        templateContent += '{{/each}}';

        template = Handlebars.compile(templateContent);
        $this.html(template({collection: collection}));

        return $this;
    }
}($));