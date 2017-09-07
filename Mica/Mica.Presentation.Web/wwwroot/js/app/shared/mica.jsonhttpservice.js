Mica.use('JsonHttpService', ['$aquarium', 'jQuery', 'DefaultHttpFishes', 'HttpService', 'Inheritance', 
    function ($aquarium, $, DEFAULT_FISHES, HttpService, Inheritance) {
        var JsonHttpService = function (localFishes) {
            var service = this;

            service.fishes = $.extend({}, DEFAULT_FISHES, localFishes);
            service.ajax = function (url, data, type) {
                $.ajax({
                    url: url,
                    data: JSON.stringify(data),
                    type: type,
                    contentType: 'application/json; charset=utf-8',
                    beforeSend: function () {
                        $aquarium.pet([service.fishes.ongoing]);
                    },
                    success: function (data, textStatus, errorThrown) {
                        $aquarium.pet([service.fishes.success], data);
                    },
                    error: function (jqXHR) {
                        $aquarium.pet([service.fishes.error], jqXHR);
                    },
                    complete: function (jqXHR) {
                        $aquarium.pet([service.fishes.always], jqXHR);
                    }
                });
            };
        };

        Inheritance.inheritsFrom(JsonHttpService, HttpService);

        return JsonHttpService;
    }]);