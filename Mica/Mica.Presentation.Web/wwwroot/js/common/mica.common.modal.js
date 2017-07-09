(function ($) {
    Mica.Common.Modal = function ($scope, options) {
        var settings = {
            openModalBtn: '.js-open-modal',
            modalContentSelector: '.modal-content'
        };

        $.extend(settings, options);

        if (!$scope)
            $scope = $(document);

        $(settings.openModalBtn, $scope).on('click', function () {
            var contentUrl = $(this).attr('mc-modal-content-url');
            var target = $(this).attr('data-target');

            // clear modal content
            $(settings.modalContentSelector, target).html('');

            $.ajax({
                url: contentUrl,
                type: 'GET',
                success: function (data) {
                    $(settings.modalContentSelector, target).html(data);
                    $(target).registerModal();
                }
            });
        });
    };
})(jQuery);