// IMPORTANT - DON'T TEST THIS IN BGCODER
// This solution DOES NOT solve the exam task Sequences correctly in all cases,
// because it assumes, that one number is not considered to be a sequence

/**
 * You are given an integer array arr, consisting of N integers. 
 * Find the number of non-decreasing consecutive subsequences in arr. 
 * Every sequence starts after the previous one. 
 * For example: if the array arr consists of the numbers 1, 2, -3, 4, 4, 0, 1, 
 * the number of non-decreasing consecutive subsequences is 3 
 * (the first is 1, 2, the second is -3, 4, 4 and the third is 0, 1) 
 */
function Solve(numbersAsStrings) {
    var numbers = numbersAsStrings.map(Number),
        numbersCount = numbers[0],
        nonDecreasingSequencesCount = 0,
        i,
        previousNumber = numbers[1],
        currentNumber,
        currentLength = 1;

    for (i = 2; i <= numbersCount; i++) {
        currentNumber = numbers[i];

        // end of non-decreasing sequence
        if (currentNumber < previousNumber) {
            // one number is not considered to be a sequence !!!
            if (currentLength > 1) {
                nonDecreasingSequencesCount++;
            }

            currentLength = 1;
        } else {
            // the sequence continues
            currentLength++;
        }

        previousNumber = currentNumber;
    }

    // we must also count the non-decreasing sequences, which is ends at the end of the array
    if (currentLength > 1) {
        nonDecreasingSequencesCount++;
    }

    return nonDecreasingSequencesCount;
}

var zeroTestOne = [7, 1, 2, -3, 4, 4, 0, 1]; // Answer: 3
var zeroTestTwo = [6, 1, 3, -5, 8, 7, -6]; // Answer: 2
var zeroTestThree = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6]; // Answer: 2

//var input = [3, 5, 3, 2]; // Answer: 0
//var input = [6, 5, 3, 2, 4, 3, 5]; // Answer: 2
//var input = [6, 6, 5, 4, 3, 2, 1]; // Answer: 0
//var input = [1, 1]; // Answer: 0
//var input = [7, 1, 1, 1, 1, 1, -1, -2]; // Answer: 1
//var input = [7, 1, 1, 1, 3, 4, -3, 5]; // Answer: 2
//var input = [4, 3, -2, 3, -2]; // Answer: 1
//var input = [4, -5, 3, 1, -3, -5]; // Answer: 1
//var input = [7, 7, 5, 4, 6, 8, 7, 5]; // Answer: 1
//var input = [7, 7, 5, 4, 6, 8, 7, 8]; // Answer: 2
//var input = [5, -3, 2, 2, -3, -5]; // Answer: 1
//var input = [5, -3, 2, 2, -3, 5]; // Answer: 2
//var input = [4, 4, 3, 2, 5]; // Answer: 1
//var input = [7, 4, 4, 2, 5, 1, 0, 3]; // Answer: 3

console.log(Solve(zeroTestOne));
console.log(Solve(zeroTestTwo));
console.log(Solve(zeroTestThree));
