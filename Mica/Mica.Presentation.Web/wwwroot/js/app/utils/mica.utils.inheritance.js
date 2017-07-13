Mica.use('Inheritance', function () {
    function Inheritance() {
        var inheritsFrom = function (child, parent) {
            child.prototype = Object.create(parent.prototype);
        };

        return { inheritsFrom: inheritsFrom };
    };

    return new Inheritance();
});
