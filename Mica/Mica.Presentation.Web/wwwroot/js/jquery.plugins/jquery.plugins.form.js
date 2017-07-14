(function ($) {
    $.fn.getFormData = function () {
        var data = {};
        var dataArray = $(this).serializeArray();
        for (var i = 0; i < dataArray.length; i++) {
            data[dataArray[i].name] = dataArray[i].value;
        }

        return data;
    };

    $.fn.serializeData = function (modelPrefix) {

        modelPrefix = modelPrefix || 'Model.';

        var data = {};
        var dataArray = $(this).serializeArray();
        for (var i = 0; i < dataArray.length; i++) {
            if (dataArray[i].name && dataArray[i].name.indexOf(modelPrefix) > -1) {
                var propName = dataArray[i].name.replace(modelPrefix, '');
                data[propName] = dataArray[i].value;
            }
        }

        return data;
    };
})(jQuery);