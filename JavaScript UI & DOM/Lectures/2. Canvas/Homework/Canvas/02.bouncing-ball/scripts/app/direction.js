define(function () {
    'use strict';

    var Direction = {
        'Down': 0,
        'DownRight': 1,
        'Right': 2,
        'UpRight': 3,
        'Up': 4,
        'UpLeft': 5,
        'Left': 6,
        'DownLeft': 7
    };
    Object.freeze(Direction);

    return Direction;
});