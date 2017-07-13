Mica.use('SmartLink', ['window', 'document', 'jQuery', 'QueryString', function (window, document, $, q) {
    return function ($scope, options) {
        var settings = {
            hrefDefault: ''
        };

        $.extend(settings, options);

        if (!$scope)
            $scope = $(document);

        var $links = $('a[mc-sl-to]', $scope);

        // clickable look & feel
        $links.each(function (index, element) {
            element.href = settings.hrefDefault;
        });

        $links.click(function (event) {
            var $link = $(this);
            var canRedirect = $link.attr('mc-sl-can-redirect');
            if (canRedirect && canRedirect !== "True") return;

            var target = $link.attr('mc-sl-to');

            var attrs = $link.attrs();

            var localQueryString = {};
            Object.keys(attrs).forEach(function (attr) {
                if (attr.startsWith('mc-sl-route')) {
                    localQueryString[attr.substring(12)] = $link.attr(attr);
                }
            });

            var currentQueryString = q.getObject();
            $.extend(currentQueryString, localQueryString);

            window.location.href = target + q.serialize(currentQueryString);
            event.preventDefault();
        });
    };
}]);