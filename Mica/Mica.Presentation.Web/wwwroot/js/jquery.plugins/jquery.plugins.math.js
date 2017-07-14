(function ($) {
    $.fn.sum = function () {
        var sum = 0;
        $(this).each(function (index, element) {
            sum += parseFloat($(element).val());
        });

        return sum;
    };
})(jQuery);