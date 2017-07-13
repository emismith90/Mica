Mica = new AA();

Mica.use('window', function () { return window; })
    .use('document', function () { return document; })
    .use('jQuery', function () { return jQuery; });

(function ($) {
    $(document);
})(jQuery);