Mica.Utils.NavItem = {
    setActive: function () {
        var pathname = window.location.pathname;
        if (!pathname) pathname = "/Home"

        $('#sidebar-collapse > ul.nav a[href="' + pathname + '"]').parent().addClass('active');
    }
}
