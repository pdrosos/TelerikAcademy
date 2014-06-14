function Solve(params) {
    var totalSum,
        cakeOnePrice,
        cakeTwoPrice,
        cakeThreePrice,
        maxSpentSum,
        currentSpentSum,
        cakeOneMaxCount,
        cakeTwoMaxCount,
        cakeThreeMaxCount,
        i, j, k;

    params = params.map(Number);
    totalSum = params[0];
    cakeOnePrice = params[1];
    cakeTwoPrice = params[2];
    cakeThreePrice = params[3];
    maxSpentSum = -Number.MAX_VALUE;
    currentSpentSum = 0;

    cakeOneMaxCount = parseInt(totalSum / cakeOnePrice);
    cakeTwoMaxCount = parseInt(totalSum / cakeTwoPrice);
    cakeThreeMaxCount = parseInt(totalSum / cakeThreePrice);

    for (i = 0; i <= cakeOneMaxCount; i++) {
        var cakeOneSpentSum = i * cakeOnePrice;

        for (j = 0; j <= cakeTwoMaxCount; j++) {
            var cakeTwoSpentSum = j * cakeTwoPrice;

            for (k = 0; k <= cakeThreeMaxCount; k++) {
                var cakeThreeSpentSum = k * cakeThreePrice;

                currentSpentSum = cakeOneSpentSum + cakeTwoSpentSum + cakeThreeSpentSum;

                if (currentSpentSum <= totalSum && currentSpentSum > maxSpentSum) {
                    maxSpentSum = currentSpentSum;
                }
            }
        }
    }

    return maxSpentSum;
}

console.log(Solve([110, 13, 15, 17]));