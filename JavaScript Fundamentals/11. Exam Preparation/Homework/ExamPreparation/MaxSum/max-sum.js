/**
 * You are given an integer array arr, consisting of N integers. 
 * Find the maximum possible sum of consecutive numbers in arr. 
 * For example: if the array arr consists of the numbers 1, 6, -9, 4, 4, -2, 10, -1, 
 * the maximum possible sum of consecutive numbers is 16 (the consecutive numbers are 4, 4, -2 and 10)  
 */
function Solve(numbersAsStrings) {
    var numbers = numbersAsStrings.map(Number),
        numbersCount = numbers[0];

    return maximalSum(numbers.slice(1));
        
    function maximalSum(numbersArray) {
        var maxSum = -Number.MAX_VALUE,
            currentSum = 0,
            i;            

        for (i = 0; i < numbersArray.length; i++) {
            currentSum += numbersArray[i];
            
            if (currentSum > maxSum) {
                maxSum = currentSum;
            }

            // if currentSum becomes negative number, a new sub-sequence starts
            if (currentSum < 0) {
                currentSum = 0;
            }
        }

        return maxSum;
    }
}

var zeroTestOne = ['8', '1', '6', '-9', '4', '4', '-2', '10', '-1']; // Answer: 16
var zeroTestTwo = ['6', '1', '3', '-5', '8', '7', '-6']; // Answer: 15
var zeroTestThree = ['9', '-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6']; // Answer: -1

console.log(Solve(zeroTestOne));
console.log(Solve(zeroTestTwo));
console.log(Solve(zeroTestThree));