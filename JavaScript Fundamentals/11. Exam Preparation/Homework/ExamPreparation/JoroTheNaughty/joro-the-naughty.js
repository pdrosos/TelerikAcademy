/**
 * Joro is a naughty rabbit. He wants to jump around all day and night. 
 * Yet his mother is not so happy about that, she doesn't let him out. 
 * Of course Joro tried many times to escape, but his mother used to be the National Rabbit jump champion, 
 * so she can jump faster and higher than him. Still she is not that smart, so Joro decided 
 * that he can trick her by jumping using a sequence of jumps.
 * Your task is to calculate if Joro can escape from his mother, using the given sequence of jumps.
 * You are given a field of size N x M where the values are as follows:
 * On the first row the numbers are from 1 to M, 
 * on the second row – from M+1 to 2*M, 
 * on the third – from 2*M +1 to 3*M, etc…
 * By given position in the field, and using the patterns given, calculate if Joro can escape from his mother.
 * You are also given a sequence of jumps over the field. 
 * The jumps are described with change to the row and column, 
 * i.e. when on position (R, C) with jump (-2, 3), Joro will go to position (R-2, C+3).
 * When the sequence of jumps is over, Joro must start from the start of the jumps sequence.
 * If Joro goes outside the field, he has escaped, if Joro goes to a previously visited position, he is caught.
 */
function Solve(arguments) {
    var data,
        rows,
        columns,
        jumpsCount,
        currentPosition = {},
        jumpsPositions = [],
        currentJumpPositionIndex = 0,
        currentCellSum,
        visited = {},
        sumOfNumbers = 0,
        numberOfJumps = 0,
        i;

    // playfield
    data = arguments[0].split(' ').map(Number);
    rows = data[0];
    columns = data[1];
    jumpsCount = data[2];

    // start position
    data = arguments[1].split(' ').map(Number);
    currentPosition.row = data[0];
    currentPosition.column = data[1];

    // jumps positions
    for (i = 2; i < jumpsCount + 2; i++) {
        data = arguments[i].split(' ').map(Number);
        jumpsPositions.push({ row: data[0], column: data[1] })
    }

    while (true) {
        currentCellSum = currentPosition.row * columns + currentPosition.column + 1;

        // we must check escaped before caught, otherwise test #5 in bgcoder fails
        // because currentCellSum can be equal for cells inside the fields and cells outside the field
        // if string keys are used for the visited array (associative array) this order does not matter
        if (isOutsideField(currentPosition)) {
            return 'escaped ' + sumOfNumbers;
        }

        if (visited[currentCellSum] === true) {
            return 'caught ' + numberOfJumps;
        }
        
        // mark position as visited 
        // numeric keys must be used instead of string keys (associative array)
        // otherwise we have memory limit in bgcoder
        visited[currentCellSum] = true;

        // calculate sum
        sumOfNumbers += currentCellSum;

        // jump to next position
        currentPosition.row += jumpsPositions[currentJumpPositionIndex].row;
        currentPosition.column += jumpsPositions[currentJumpPositionIndex].column;
        numberOfJumps++;        

        currentJumpPositionIndex++;
        if (currentJumpPositionIndex == jumpsPositions.length) {
            currentJumpPositionIndex = 0;
        }
    }

    function isOutsideField(position) {
        if (position.row < 0 || position.row >= rows ||
            position.column < 0 || position.column >= columns) {
            return true;
        }

        return false;
    }
}

var zeroTestOne = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1']; // escaped 89
console.log(Solve(zeroTestOne));

/*
var fs = require("fs");
fs.readFile('test.005.in.txt', function (err, f) {
    var array = f.toString().split('\n');
    // use the array
    console.log(Solve(array));
});
*/