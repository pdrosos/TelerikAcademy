/**
 * http://jsfiddle.net/mpetrovich/wMmHS/
 *
 * var rendered = Handlebars.compile(
 *     '{{#each values}}' +
 *     'i={{@index}}: ' +
 *     'i+1 = {{math @index "+" 1}}, ' +
 *     'i-0.5 = {{math @index "+" "-0.5"}}, ' +
 *     'i/2 = {{math @index "*" 2}}, ' +
 *     'i%2 = {{math @index "%" 2}}, ' +
 *     'i*i = {{math @index "*" @index}}\n' +
 *     '{{/each}}'
 * )({
 *     values : [ 'a', 'b', 'c', 'd', 'e' ]
 * });
 */
Handlebars.registerHelper("math", function(lvalue, operator, rvalue, options) {
    lvalue = parseFloat(lvalue);
    rvalue = parseFloat(rvalue);

    return {
        "+": lvalue + rvalue,
        "-": lvalue - rvalue,
        "*": lvalue * rvalue,
        "/": lvalue / rvalue,
        "%": lvalue % rvalue
    }[operator];
});