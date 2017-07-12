(function () {
    Mica.Service.Aquarium = function (name, debug) {
        var fishes = {};
        var aquariumName = name || (new Date().getTime()).toString(36);
        var enableLog = debug || false;

        var pet = function (fishName, food) {
            if (enableLog)
                console.log('Fed [' + food + '] to [' + fishName + '] at [' + aquariumName + ']');

            if (!fishes[fishName]) return;

            fishes[fishName].forEach(function (eating) {
                eating(food);
            });
        };

        var whenPet = function (fishName, eatingCb) {
            if (!fishes[fishName]) fishes[fishName] = [];

            fishes[fishName].push(eatingCb);

            return this;
        };

        return {
            pet: pet,
            whenPet: whenPet
        };
    };

    Mica.Service.Aquariums = {};
    Mica.Service.Aquariums['mica'] = new Mica.Service.Aquarium('mica', true);

    //USAGE
    //Mica.Service.Aquariums['mica']
    //    .whenPet('shark', function (food) {
    //        console.log(food);
    //    })
    //    .whenPet('whale', function (food) {
    //        console.log(food);
    //    });

    //Mica.Service.Aquariums['mica']
    //    .whenPet('shark', function (food) {
    //        console.log('s2:' + food);
    //    })

    //Mica.Service.Aquariums['mica'].pet('shark', 'feeding sharks');
    //Mica.Service.Aquariums['mica'].pet('whale', 'feeding whales');
})();