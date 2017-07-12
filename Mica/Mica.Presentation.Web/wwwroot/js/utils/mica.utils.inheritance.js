(function () {
    function I() {
        var inheritsFrom = function (child, parent) {
            child.prototype = Object.create(parent.prototype);
        };

        return { inheritsFrom: inheritsFrom };
    };

    Mica.Utils.Inheritance = new I();
})();
