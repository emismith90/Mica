Mica.Common = {};
Mica.Common.SmartLink = {
    bindEvent: function ($scope) {
        if (!$scope)
            $scope = $(document);

        var $links = $('a[sr-to]', $scope);

        // clickable look & feel
        $links.each(function (index, element) {
            element.href = 'javascript:void(0);';
        });

        $links.click(function () {
            var $link = $(this);
            var canRedirect = $link.attr('sr-can-redirect');
            if (canRedirect && canRedirect !== "True") return;

            var target = $link.attr('sr-to');

            var attrs = $link.attrs();

            var localQueryString = {};
            Object.keys(attrs).forEach(function (attr) {
                if (attr.startsWith('sr-route')) {
                    localQueryString[attr.substring(9)] = $link.attr(attr);
                }
            });

            var currentQueryString = Mica.Utils.QueryString.getObject();
            $.extend(currentQueryString, localQueryString);

            window.location.href = target + Mica.Utils.QueryString.serialize(currentQueryString);
        });
    }
};