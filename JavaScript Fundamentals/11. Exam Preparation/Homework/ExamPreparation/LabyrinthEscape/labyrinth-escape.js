/**
 * You are given a rectangular field of size NxM, filled with numbers and directions. 
 * On each cell on the field there will be a direction marked with the letters l, r, u, d.
 * By given position (R, C) (Rth row and Cth column) the directions are as follows:
 * From (R, C) go l => (R, C-1)
 * From (R, C) go r => (R, C+1)
 * From (R, C) go u => (R-1, C)
 * From (R, C) go d => (R+1, C)
 * The numbers in the field are always as follows:
 * On the first row the values are from 1 to M, 
 * on the second row – from M+1 to 2*M, 
 * on the third row – from 2*M +1 to 3*M, 
 * on the Nth row – from (N-1)*M to N*M.
 * By given start position, find the path outside of the field, or print if you are lost.
 */
function Solve(arguments) {
    var data,
        rows,
        columns,
        currentPosition = {},
        currentCellSum,
        visited = {},
        currentCellSum,
        sumOfNumbers = 0,
        numberOfSteps = 0;

    // playfield size
    data = arguments[0].split(' ').map(Number);
    rows = data[0];
    columns = data[1];

    // start position
    data = arguments[1].split(' ').map(Number);
    currentPosition.row = data[0];
    currentPosition.column = data[1];

    // initialize playfield
    playfield = arguments.slice(2);

    while (true) {
        currentCellSum = currentPosition.row * columns + currentPosition.column + 1;
        
        if (isOutsideField(currentPosition)) {
            return 'out ' + sumOfNumbers;
        }

        if (visited[currentCellSum] === true) {
            return 'lost ' + numberOfSteps;
        }
        
        // mark position as visited
        visited[currentCellSum] = true;

        // calculate sum
        sumOfNumbers += currentCellSum;

        // move to next position
        move(currentPosition, playfield[currentPosition.row][currentPosition.column]);
        numberOfSteps++;
    }

    function move(position, direction) {
        switch (direction) {
            case 'l':
                position.column--;
                break;
            case 'r':
                position.column++;
                break;
            case 'u':
                position.row--;
                break;
            case 'd':
                position.row++;
                break;
            default:
                break;
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

var zeroTestOne = ["3 4", "1 3", "lrrd", "dlll", "rddd"]; // out 45
var zeroTestTwo = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "durlddud", "urrrldud", "ulllllll"]; // lost 21
var zeroTestThree = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "lurlddud", "urrrldud", "ulllllll"]; // out 442

console.log(Solve(zeroTestOne));
console.log(Solve(zeroTestTwo));
console.log(Solve(zeroTestThree));