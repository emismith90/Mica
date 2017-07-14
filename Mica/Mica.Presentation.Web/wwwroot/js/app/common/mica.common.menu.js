Mica.use('Menu', ['window', 'jQuery', function (window, $) {
    function Menu() {
        var setActive = function () {
            var pathname = window.location.pathname;
            if (!pathname) pathname = "/Home"

            $('#sidebar-collapse > ul.nav a[href="' + pathname + '"]').parent().addClass('active');
        };

        return {
            setActive: setActive
        };
    };

    return new Menu();
}]);