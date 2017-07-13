Mica.use('QueryString', ['window', function (window) {
    function QueryString() {
        var getObject = function () {
            var vars = {};
            if (window.location.href.indexOf('?') < 0) return {};

            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                var hash = hashes[i].split('=');
                vars[hash[0]] = hash[1];
            }
            return vars;
        };

        var serialize = function (obj) {
            var str = [];
            for (var p in obj)
                if (obj.hasOwnProperty(p)) {
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                }

            if (str.length > 0) {
                return '?' + str.join('&');
            }

            return null;
        };

        return {
            getObject: getObject,
            serialize: serialize
        };
    };

    return new QueryString();
}]);

