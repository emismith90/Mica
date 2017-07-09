(function (window, $) {
    function M() {
        var setActive = function () {
            var pathname = window.location.pathname;
            if (!pathname) pathname = "/Home"

            $('#sidebar-collapse > ul.nav a[href="' + pathname + '"]').parent().addClass('active');
        };

        return {
            setActive: setActive
        };
    };

    Mica.Common.Menu = new M();
})(window, jQuery);