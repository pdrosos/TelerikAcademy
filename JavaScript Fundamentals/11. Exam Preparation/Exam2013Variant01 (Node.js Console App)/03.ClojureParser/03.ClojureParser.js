function Solve(input) {

    var finalResult;
    var functions = [];

    for (var i = 0; i < input.length; i++) {
        var currentRow = input[i].trim();

        var operator = '';
        var nestedOperator = '';
        var currentDigit = '';
        var currentFunctionName = '';
        var currentNewFunction = '';

        var parameters = [];
        var nestedParameters = [];

        var inCommand = false;
        var inNestedCommand = false;
      

        for (var j = 0; j < currentRow.length; j++) {
            var currentSymbol = currentRow[j];

            if (currentSymbol == '(') {
                if (inCommand) {
                    inNestedCommand = true;
                } else {
                    inCommand = true;
                }
                continue;
            }

            if (currentSymbol === ' ' || currentSymbol === ')') {
                
                if (currentFunctionName !== '') {

                    if (functions[currentFunctionName] || functions[currentFunctionName] === 0) {
                        var functionResult = functions[currentFunctionName];

                        if (inNestedCommand) {
                            nestedParameters.push(functionResult);
                        } else {
                            parameters.push(functionResult);
                        }
                    } else {
                        currentNewFunction = currentFunctionName;
                    }
                    currentFunctionName = '';
                }

                if (currentDigit !== '') {

                    if (inNestedCommand) {
                        nestedParameters.push(parseInt(currentDigit));
                    } else {
                        parameters.push(parseInt(currentDigit));
                    }

                    currentDigit = '';
                }

                if (currentSymbol == ')' && currentNewFunction !==  '') {
                    var result;

                    if (inNestedCommand) {
                        result = calculate(nestedOperator, nestedParameters);
                    } else {
                        result = calculate(operator, parameters);
                    }

                    functions[currentNewFunction] = result;
                    currentNewFunction = '';
                }

                if (inNestedCommand && currentSymbol == ')') {
                    var nestedResult = calculate(nestedOperator, nestedParameters);
                    parameters.push(nestedResult);

                    nestedOperator = '';
                    nestedParameters = [];
                    inNestedCommand = false;
                }

                continue;
            }

            if (isMathOperator(currentSymbol)) {

                if (currentSymbol == '-'
                        && j + 1 < currentRow.length
                        && isNumber(currentRow[j + 1])) {
                    currentDigit += currentSymbol;
                } else {
                    if (inNestedCommand) {
                        nestedOperator = currentSymbol;
                    } else {
                        operator = currentSymbol;
                    }
                }
                continue;
            }

            if (isNumber(currentSymbol)) {

                if (currentFunctionName !== '') {
                    currentFunctionName += currentSymbol;
                } else {
                    currentDigit += currentSymbol;
                }
                continue;
            }

            currentFunctionName += currentSymbol;
        }

        finalResult = calculate(operator, parameters);

        if (finalResult === 'Error') {
            return 'Division by zero! At Line:' + (i + 1);
        }
    }

    return finalResult;


    function isMathOperator(symbol) {
        if (symbol === '+' || symbol === '-' || symbol === '*' || symbol === "/") {
            return true;
        }
        return false;
    }

    function isNumber(symbol) {
        if (symbol === ' ') {
            return false;
        }
        if (isFinite(symbol)) {
            return true;
        }
        return false;
    }

    function calculate(operator, parameters) {
        if (parameters.length === 1) {
            return parameters[0];
        }

        var result = parameters[0];
        for (var i = 1; i < parameters.length; i++) {
            switch (operator) {
                case '+':
                    result += parameters[i];
                    break;
                case '-':
                    result -= parameters[i];
                    break;
                case '*':
                    result *= parameters[i];
                    break;
                case '/':
                    if (parameters[i] === 0) {
                        return 'Error';
                    }
                    result = parseInt(result / parameters[i]);
                    break;
                default:
            }
        }
        return result;
    }
}

//var firstTest = [
//    '(     +     1    2  )',
//    '(+ 50 2 7 1)',
//    '(- 42 -2)',
//    '(- 4)',
//    '(/ 454654 0)',
//    '(* 5 7)',
//    '(/ 10 3 2)'
//];
//console.log(Solve(firstTest));

//var secondTest = [
//    '(     +     1    2 (* -3 2 1 1) 7 )  ',
//    '(+ 50 (- 2 7) 1)',
//    '(- 42 -2)',
//    '(- 4)',
//    '(/ 454654 0)',
//    '(* 5 7)',
//    '(/ 10 3 2)'
//];
//console.log(Solve(secondTest));

//var thirdTest = [
//    '(def myFunc 5)',
//    '(def myNewFunc (+ myFunc myFunc 2))',
//    '(def MyFunc (* 2 myNewFunc))',
//    '(/ MyFunc myFunc)'
//];
//console.log(Solve(thirdTest));
//Answer: 4

//var fourthTest = [
//    '(def func 10)',
//    '(def newFunc (+  func 2))',
//    '(def sumFunc (+ func func newFunc 0 0 0))',
//    '(* sumFunc 2)'];

//console.log(Solve(fourthTest));
//Answer: 64

//var fifthTest = [
//    '(def func (+ 5 2))',
//    '(def func2 (/  func 5 2 1 0))',
//    '(def func3 (/ func 2))',
//    '(+ func3 func)'];

//console.log(Solve(fifthTest));
//Answer: Division by zero! At Line:2

//var fs = require("fs");
//fs.readFile('Tests/test.001.in.txt', function (error, fileContent) {
//    var input = fileContent.toString().split('\n');
//    // use the input array
//    console.log(Solve(input));
//});
//Answer: Division by zero! At Line:3


//var fs = require("fs");
//fs.readFile('Tests/test.002.in.txt', function (error, fileContent) {
//    var input = fileContent.toString().split('\n');
//    // use the input array
//    console.log(Solve(input));
//});
//Answer: 6


//var input = [
//    '(def pesho 0)',
//    '(/ 4 2 pesho)'
//];
//console.log(Solve(input));