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
        numbersCount = numbers[0];
    
    return nonDecreasingSequencesCount(numbers.slice(1));

    function nonDecreasingSequencesCount(numbersArray) {
        var sequencesCount = 1,
            i,
            previousNumber = numbersArray[0],
            currentNumber;

        for (i = 1; i < numbersArray.length; i++) {
            currentNumber = numbersArray[i];

            // end of non-decreasing sequence
            if (currentNumber < previousNumber) {
                sequencesCount++;
            }

            previousNumber = currentNumber;
        }

        return sequencesCount;
    }
}

var zeroTestOne = [7, 1, 2, -3, 4, 4, 0, 1]; // Answer: 3
var zeroTestTwo = [6, 1, 3, -5, 8, 7, -6]; // Answer: 4
var zeroTestThree = [9, 1, 8, 8, 7, 6, 5, 7, 7, 6]; // Answer: 5

console.log(Solve(zeroTestOne));
console.log(Solve(zeroTestTwo));
console.log(Solve(zeroTestThree));
