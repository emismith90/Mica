(function ($) {
    $(document).ready(function () {
        var $links = $('.js-smart-pager a[sr-to]');

        $links.each(function (index, element) {
            element.href = 'javascript:void(0);';
        }); // clickable look & feel

        $links.click(function () {
            var $link = $(this);
            var canRedirect = $link.attr('sr-can-redirect');
            if (canRedirect !== "True") return;

            var target = $link.attr('sr-to');

            var attrs = $link.attrs();

            var localQueryString = {};
            Object.keys(attrs).forEach(function (attr) {
                if (attr.startsWith('sr-route')) {
                    localQueryString[attr.substring(9)] = $link.attr(attr);
                }
            });

            var currentQueryString = getQueryStringObject();
            $.extend(currentQueryString, localQueryString);

            window.location.href = target + serializeToQueryString(currentQueryString);
        });
    });
})(jQuery);