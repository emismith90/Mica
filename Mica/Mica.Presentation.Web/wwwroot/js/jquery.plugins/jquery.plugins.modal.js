(function ($) {
    var defaults = {
        formSelector: '#form',
        submitBtnSelector: '.js-save-btn'
    };

    $.fn.registerModal = function (options) {
        var settings = $.extend({}, defaults, options);

        var $modal = $(this);
        var $form = $(settings.formSelector, $modal);

        $(settings.submitBtnSelector).click(function () {
            var $button = $(this);
            if (!$form.valid()) return;
            $.ajax({
                url: $button.attr('mc-modal-post-url'),
                data: $form.getFormData(),
                type: 'POST',
                success: function (data) {
                    location.reload();
                }
            });
        });

        $("input[type='checkbox']", $form).on("click", function () {
            if ($(this).prop('checked')) {
                $(this).attr('value', true);
            } else {
                $(this).attr('value', false);
            }
        });
    }
})(jQuery);