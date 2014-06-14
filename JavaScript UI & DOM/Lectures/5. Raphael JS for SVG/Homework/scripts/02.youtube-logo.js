window.onload = function () {
    var paper = Raphael(10, 10, 250, 100);

    var container = paper.rect(10, 10, 200, 80);

    container.attr({
        stroke: '#D9ECF1',
        'stroke-width': 3
    });

    var leftPartText = paper.text(53, 48, 'You');
    leftPartText.attr({
        fill: '#4A4A4A',
        'font-size': 42,
        'font-weight': 'bold'
    });

    leftPartText.transform('s0.8, 1.4, 70, 47');

    var rect = paper.rect(93, 20, 102, 60, 10);
    rect.attr({
        fill: '#EB2827',
        stroke: '#EB2827'
    });

    var rightPartText = paper.text(157, 48, 'Tube');
    rightPartText.attr({
        'font-size': 42,
        fill: 'white',
        'font-weight': 'bold'
    });

    rightPartText.transform('s0.8, 1.4, 95, 47');
};