/*
 * aquarium.js (1.0.0).
 *
 * Copyright (c) 2017 Hung.Le (emismith90@gmail.com)
 * Released under the MIT license
 */

(function (window) {
    if (!window) return;

    window.Aquarium = function Aquarium(name, debug) {
        this.fishes = {};
        this.aquariumName = name || (new Date().getTime()).toString(36);
        var enableLog = debug || false;

        this.pet = function () {
            if (arguments.length <= 1) return false;
            var food = arguments[arguments.length - 1];

            for (var i = 0; i < arguments.length - 1; i++) {
                var fishName = arguments[i];

                if (enableLog)
                    console.log('Feeding [' + food + '] to [' + fishName + '] at [' + this.aquariumName + ']');

                if (!this.fishes[fishName]) return;

                this.fishes[fishName].forEach(function (delivery) {
                    delivery(food);
                });
            }
        };

        this.whenPet = function () {
            if (arguments.length <= 1) return false;
            var delivery = arguments[arguments.length - 1];

            for (var i = 0; i < arguments.length - 1; i++) {
                var fishName = arguments[i];
                if (!this.fishes[fishName]) this.fishes[fishName] = [];

                this.fishes[fishName].push(delivery);
            }

            return this;
        };
    };

})(window);

////USAGE
//var aquarium = new Aquarium('mica', true);
//aquarium.whenPet('shark', 'whale', function (food) {
//    console.log(food);
//});

//aquarium.whenPet('shark', function (food) {
//    console.log('s2:' + food);
//})

//aquarium.pet('shark', 'feeding sharks');
//aquarium.pet('whale', 'feeding whales');