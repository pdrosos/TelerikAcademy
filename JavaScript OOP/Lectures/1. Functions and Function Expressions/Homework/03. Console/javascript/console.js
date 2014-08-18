window.onload = (function () {
    extendedConsole.writeLine('{0} {1} {2}', 'Just', 'a', 'notice');
    extendedConsole.writeError('Error: A {0} error occured', 'Fatal');
    extendedConsole.writeWarning('Warning: {0} hardware {1}', 'New', 'detected');
}());