(function ($, Inheritance, Aquarium) {
    var defaultFishes = {
        ongoing: 'http_on_going',
        success: 'http_success',
        error: 'http_error',
        always: 'http_always'
    };

    Mica.Service.HttpService = function (localFishes) {
        var service = this;

        service.fishes = $.extend({}, defaultFishes, localFishes);
        service.ajax = function (url, data, type) {
            $.ajax({
                url: url,
                data: data,
                type: type,
                beforeSend: function () {
                    Aquarium.pet(service.fishes.ongoing);
                },
                success: function (data, textStatus, errorThrown) {
                    Aquarium.pet(service.fishes.success, data);
                },
                error: function (jqXHR) {
                    Aquarium.pet(service.fishes.error, jqXHR);
                },
                complete: function (jqXHR) {
                    Aquarium.pet(service.fishes.always, jqXHR);
                }
            });
        };
    };

    Mica.Service.HttpService.prototype.get = function (url, data) {
        this.ajax(url, data, 'GET');
    };

    Mica.Service.HttpService.prototype.post = function (url, data) {
        this.ajax(url, data, 'POST');
    };

    Mica.Service.HttpService.prototype.put = function (url, data) {
        this.ajax(url, data, 'PUT');
    };

    Mica.Service.HttpService.prototype.delete = function (url, data) {
        this.ajax(url, data, 'DELETE');
    };

    Mica.Service.JsonHttpService = function (localFishes) {
        var service = this;

        service.fishes = $.extend({}, defaultFishes, localFishes);
        service.ajax = function (url, data, type) {
            Aquarium.pet(service.fishes.ongoing);

            $.ajax({
                url: url,
                data: JSON.stringify(data),
                type: type,
                contentType: 'application/json; charset=utf-8',
                beforeSend: function () {
                    Aquarium.pet(service.fishes.ongoing);
                },
                success: function (data, textStatus, errorThrown) {
                    Aquarium.pet(service.fishes.success, data);
                },
                error: function (jqXHR) {
                    Aquarium.pet(service.fishes.error, jqXHR);
                },
                complete: function (jqXHR) {
                    Aquarium.pet(service.fishes.always, jqXHR);
                }
            });
        };
    };

    Inheritance.inheritsFrom(Mica.Service.JsonHttpService, Mica.Service.HttpService);

})(jQuery,
    Mica.Utils.Inheritance,
    Mica.Service.Aquariums['mica']);