function Solve(input) {
    var result = 1;
    input = input.map(Number);

    for (var i = 1; i < input.length - 1; i++) {
        if (input[i + 1] < input[i]) {
            result++;
        }
    }
    return result;
}

var input = [7, 1, 2, -3, 4, 4, 0, 1];
//var input = [6, 1, 3, -5, 8, 7, -6];
//var input = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6];

console.log(Solve(input));