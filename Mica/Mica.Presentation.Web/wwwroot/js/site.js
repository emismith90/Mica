(function ($) {
    $.fn.getFormData = function () {
        var data = {};
        var dataArray = $(this).serializeArray();
        for (var i = 0; i < dataArray.length; i++) {
            data[dataArray[i].name] = dataArray[i].value;
        }

        return data;
    };

    $.fn.attrs = function (attrs) {
        var t = $(this);
        if (attrs) {
            // Set attributes
            t.each(function (i, e) {
                var j = $(e);
                for (var attr in attrs) {
                    j.attr(attr, attrs[attr]);
                }
            });
            return t;
        } else {
            // Get attributes
            var a = {},
                r = t.get(0);
            if (r) {
                r = r.attributes;
                for (var i in r) {
                    var p = r[i];
                    if (typeof p.nodeValue !== 'undefined') a[p.nodeName] = p.nodeValue;
                }
            }
            return a;
        }
    };
})(jQuery);

function getQueryStringObject() {
    var vars = {};
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        var hash = hashes[i].split('=');
        vars[hash[0]] = hash[1];
    }
    return vars;
};

function serializeToQueryString(obj) {
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