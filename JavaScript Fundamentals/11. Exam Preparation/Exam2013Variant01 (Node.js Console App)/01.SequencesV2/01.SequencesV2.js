function Solve(input) {
    var result = 0;
    input = input.map(Number);

    for (var i = 1; i < input.length - 2; i++) {

        //if the first subsequence is non-decreasing increments the count with 1
        if (i === 1 && input[i] <= input[i + 1]) {
            result++;
        }
        if (input[i] > input[i + 1] && input[i + 1] <= input[i + 2]) {
            result++;
        }
    }
    return result;
}

var input = [7, 1, 2, -3, 4, 4, 0, 1]; //Answer: 3
    //var input = [6, 1, 3, -5, 8, 7, -6]; //Answer: 2
    //var input = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6]; //Answer: 2
    //var input = [3, 5, 3, 2]; //Answer: 0
    //var input = [6, 5, 3, 2, 4, 3, 5]; //Answer: 2
    //var input = [6, 6, 5, 4, 3, 2, 1]; //Answer: 0
    //var input = [1, 1]; //Answer: 0
    //var input = [7, 1, 1, 1, 1, 1, -1, -2]; //Answer: 1
    //var input = [7, 1, 1, 1, 3, 4, -3, 5]; //Answer: 2
    //var input = [4, 3, -2, 3, -2]; //Answer: 1
    //var input = [4, -5, 3, 1, -3, -5]; //Answer: 1
    //var input = [7, 7, 5, 4, 6, 8, 7, 5]; //Answer: 1
    //var input = [7, 7, 5, 4, 6, 8, 7, 8]; //Answer: 2
    //var input = [5, -3, 2, 2, -3, -5]; //Answer: 1
    //var input = [5, -3, 2, 2, -3, 5]; //Answer: 2
    //var input = [4, 4, 3, 2, 5]; //Answer: 1
    //var input = [10, 3, 2, 1, 5, 7, 9, 4, 2, 1, 5]; //Answer: 2

console.log(Solve(input));