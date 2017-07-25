Mica.use('FileUploadHttpService', ['$aquarium', 'jQuery', 'DefaultHttpFishes',
    function ($aquarium, $, DEFAULT_FISHES) {
        return function FileUploadHttpService() {
            this.upload = function (endpoint, formData, localFishes) {
                var fishes = $.extend({}, DEFAULT_FISHES, localFishes);

                $.ajax({
                    type: "POST",
                    url: endpoint,
                    contentType: false,
                    processData: false,
                    data: formData,
                    beforeSend: function () {
                        $aquarium.pet([fishes.ongoing]);
                    },
                    success: function (data, textStatus, errorThrown) {
                        $aquarium.pet([fishes.success], data);
                    },
                    error: function (jqXHR) {
                        $aquarium.pet([fishes.error], jqXHR);
                    },
                    complete: function (jqXHR) {
                        $aquarium.pet([fishes.always], jqXHR);
                    }
                });
            };
        };
    }]);