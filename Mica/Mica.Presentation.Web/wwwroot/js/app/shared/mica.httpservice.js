Mica.use('DefaultHttpFishes', function () {
    return {
        ongoing: 'http_on_going',
        success: 'http_success',
        error: 'http_error',
        always: 'http_always'
    }
});

Mica.use('HttpService', ['$aquarium', 'jQuery', 'DefaultHttpFishes',
    function ($aquarium, $, DEFAULT_FISHES) {
        var HttpService = function (localFishes) {
            var service = this;

            service.fishes = $.extend({}, DEFAULT_FISHES, localFishes);
            service.ajax = function (url, data, type) {
                $.ajax({
                    url: url,
                    data: data,
                    type: type,
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

        HttpService.prototype.get = function (url, data) {
            this.ajax(url, data, 'GET');
        };

        HttpService.prototype.post = function (url, data) {
            this.ajax(url, data, 'POST');
        };

        HttpService.prototype.put = function (url, data) {
            this.ajax(url, data, 'PUT');
        };

        HttpService.prototype.delete = function (url, data) {
            this.ajax(url, data, 'DELETE');
        };

        return HttpService;
    }]);
