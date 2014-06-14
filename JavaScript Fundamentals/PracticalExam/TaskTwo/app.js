function Solve(arguments) {
    var data,
        rows,
        columns,
        currentPosition = {},
        visited = {},
        currentCellIndex,
        currentCellSum,
        sumOfNumbers = 0,
        numberOfSteps = 0;

    // playfield size
    data = arguments[0].split(' ').map(Number);
    rows = data[0];
    columns = data[1];

    // start position
    currentPosition.row = (rows - 1);
    currentPosition.column = (columns - 1);

    // initialize playfield
    playfield = arguments.slice(1);

    while (true) {
        currentCellIndex = currentPosition.row * columns + currentPosition.column;
        currentCellSum = Math.pow(2, currentPosition.row) - currentPosition.column;

        if (isOutsideField(currentPosition)) {
            return 'Go go Horsy! Collected ' + sumOfNumbers + ' weeds';
        }

        if (visited[currentCellIndex] === true) {
            return 'Sadly the horse is doomed in ' + numberOfSteps + ' jumps';
        }

        // mark position as visited
        visited[currentCellIndex] = true;

        // calculate sum
        sumOfNumbers += currentCellSum;

        // move to next position
        move(currentPosition, playfield[currentPosition.row][currentPosition.column]);
        numberOfSteps++;
    }

    function move(position, direction) {
        switch (direction) {
            case '1':
                position.row = position.row - 2;
                position.column = position.column + 1;
                break;
            case '2':
                position.row = position.row - 1;
                position.column = position.column + 2;
                break;
            case '3':
                position.row = position.row + 1;
                position.column = position.column + 2;
                break;
            case '4':
                position.row = position.row + 2;
                position.column = position.column + 1;
                break;
            case '5':
                position.row = position.row + 2;
                position.column = position.column - 1;
                break;
            case '6':
                position.row = position.row + 1;
                position.column = position.column - 2;
                break;
            case '7':
                position.row = position.row - 1;
                position.column = position.column - 2;
                break;
            case '8':
                position.row = position.row - 2;
                position.column = position.column - 1;
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

var zeroTestOne = [
'3 5',
'54561',
'43328',
'52388',
];
var zeroTestTwo = [
'3 5',
'54361',
'43326',
'52888',
];

console.log(Solve(zeroTestOne));
console.log(Solve(zeroTestTwo));