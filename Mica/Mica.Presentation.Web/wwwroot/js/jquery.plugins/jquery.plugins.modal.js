(function ($) {
    var defaults = {
        formSelector: '#form',
        submitBtnSelector: '.js-save-btn'
    };

    $.fn.registerModal = function (options) {
        var settings = $.extend({}, defaults, options);

        var $modal = $(this);
        var $form = $(settings.formSelector, $modal);

        var smartSerialize = $form.attr('mc-smart-serialize') === "true";
        
        $(settings.submitBtnSelector).click(function () {
            var $button = $(this);
            if (!$form[0].checkValidity()) return;

            var formData = smartSerialize ? $form.serializeData() : $form.getFormData();

            $.ajax({
                url: $button.attr('mc-modal-post-url'),
                data: formData,
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