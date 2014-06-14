function Solve(input) {

    var dimensionsJumps = parseNumbers(input[0]);
    var startPosition = parseNumbers(input[1]);

    var rows = dimensionsJumps[0];
    var cols = dimensionsJumps[1];
    var jumpsNumber = dimensionsJumps[2];

    var currentRow = startPosition[0];
    var currentCol = startPosition[1];

    var field = initField();
    var jumps = readJumps();

    var executedJumps = 0;
    var count = 0;
    var sumOfNumbers = 0;

    while (true) {
        if (currentRow < 0 || currentCol < 0 || currentRow >= rows || currentCol >= cols) {
            return "escaped " + sumOfNumbers;
        }

        if (field[currentRow][currentCol] === 'X') {
            return "caught " + executedJumps;
        }

        if (count === jumpsNumber) {
            count = 0;
        }

        sumOfNumbers += field[currentRow][currentCol];
        field[currentRow][currentCol] = 'X';

        currentRow += jumps[count].row;
        currentCol += jumps[count].col;

        executedJumps++;
        count++;
    }


    function parseNumbers(input) {
        return input.split(' ').map(Number);
    }

    function initField() {
        var field = [];
        var counter = 1;
        for (var i = 0; i < rows; i++) {
            field[i] = [];
            for (var j = 0; j < cols; j++) {
                field[i][j] = counter++;
            }
        }
        return field;
    }

    function readJumps() {
        var jumps = [];
        for (var i = 2; i < 2 + jumpsNumber; i++) {
            var parsedJump = parseNumbers(input[i]);
            var currentJump = {
                row: parsedJump[0],
                col: parsedJump[1]
            }
            jumps.push(currentJump);
        }
        return jumps;
    }
}

//var input = [
//    '6 7 3',
//    '0 0',
//    '2 2',
//    '-2 2',
//    '3 -1'
//];
//console.log(Solve(input));
//Answer: escaped 89

//var input = [
//    '2 2 2',
//    '0 0',
//    '1 1',
//    '-1 1',
//];
//console.log(Solve(input));
//Answer: escaped 5

//var fs = require("fs");
//fs.readFile('Tests/test.000.001.in.txt', function (error, fileContent) {
//    var input = fileContent.toString().split('\n');
//    // use the input array
//    console.log(Solve(input));
//});