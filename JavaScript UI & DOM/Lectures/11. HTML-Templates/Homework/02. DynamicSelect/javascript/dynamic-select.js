(function () {
    var options,
        template;

    options = [
        {
            value: 1,
            text: 'One'
        },
        {
            value: 2,
            text: 'Two'
        },
        {
            value: 3,
            text: 'Three'
        },
        {
            value: 4,
            text: 'Four'
        },
        {
            value: 5,
            text: 'Five'
        }
    ];

    template = Handlebars.compile(document.getElementById('select-template').innerHTML);
    document.getElementById('container').innerHTML = template({options: options});
}());