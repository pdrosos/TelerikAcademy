var paper = Raphael(10, 10, 400, 155);
var rect = paper.rect(10, 10, 384, 141);

rect.attr({
    stroke: '#DFFEA4',
    'stroke-width': 3
});

var path = paper.path("M87 42, L75 31 44 63 58 79 74 63 42 31 28 44");
path.attr({
    stroke: '#59E51A',
    'stroke-width': 9
});

paper.setStart();

var companyName = paper.text(95, 60, "Telerik");
companyName.attr({
    
    'font-size': 70,
    'font-weight': 'bold'
});

var registeredSign = paper.text(320, 50, "®");

registeredSign.attr({
    'font-size': 22,
    'font-weight': 'bold'
});


var description = paper.text(110, 105, "Develop experiences");
description.attr({
    'font-size': 28
});

//Group containing all the text in the logo
var text = paper.setFinish();

text.attr({
    fill: '#272727',
    'text-anchor': 'start'
})
