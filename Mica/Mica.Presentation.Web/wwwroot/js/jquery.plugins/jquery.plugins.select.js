(function ($) {
    $.fn.selectedValue = function () {
        var selected = $(this).find('option:selected');
        if (!selected || selected.length != 1) return null;

        var value = { value: selected.attr('value') };

        var attrs = selected.attrs();
        Object.keys(attrs).forEach(function (attr) {
            if (attr.startsWith('data-')) {
                value[attr.substring(5)] = selected.attr(attr);
            }
        });

        return value;
    };
})(jQuery);