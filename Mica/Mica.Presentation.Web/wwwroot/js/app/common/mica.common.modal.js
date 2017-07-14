Mica.use('DynamicModal', ['$aquarium', 'jQuery', 'document', 'HttpService', function ($aquarium, $, document, HttpService) {
    return function ($scope, options) {
        var currentTarget = null;
        var settings = {
            openModalBtn: '.js-open-modal',
            modalContentSelector: '.modal-content'
        };

        $.extend(settings, options);

        if (!$scope)
            $scope = $(document);

        var fishes = {
            ongoing: 'dynamic_modal_http_on_going',
            success: 'dynamic_modal_http_success',
            error: 'dynamic_modal_http_error',
            always: 'dynamic_modal_http_always'
        };

        var httpService = new HttpService(fishes);

        $aquarium
            .whenPet([fishes.ongoing], function (food) {
                if (!currentTarget) return;

                // clear modal content
                $(settings.modalContentSelector, currentTarget).html('');
            })
            .whenPet([fishes.success], function (food) {
                if (!currentTarget) return;

                $(settings.modalContentSelector, currentTarget).html(food);
                $(currentTarget).registerModal();
            });

        $(settings.openModalBtn, $scope).on('click', function () {
            var contentUrl = $(this).attr('mc-modal-content-url');
            currentTarget = $(this).attr('data-target');

            httpService.get(contentUrl);
        });
    };
}]);