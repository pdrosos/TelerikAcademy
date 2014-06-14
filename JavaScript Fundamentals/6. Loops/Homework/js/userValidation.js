/*exported isInputValid*/

function isInputValid(expectedType, inputElementId) {

    var inputString = document.getElementById(inputElementId).value,
        input;  

    if (inputString === "" || inputString === undefined) {
        return false;
    } else {
        input = Number(document.getElementById(inputElementId).value);
    }

    var actualType;

    if (!isNaN(input)) {
        if (expectedType === "number") {
            return true;
        }
        if (isInt(input)) {
            actualType = "int";
        } else {
            actualType = "float";
        }
    } else {
        actualType = "string";
    }

    if (expectedType === actualType) {
        return true;
    } else {
        return false;
    }
}

function isInt(n) {
    return (typeof n === 'number' && n % 1 === 0);
}