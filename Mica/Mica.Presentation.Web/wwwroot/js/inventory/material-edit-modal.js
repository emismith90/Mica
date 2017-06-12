(function ($) {
    $.fn.registerAsEditModal = function () {
        var $modal = $(this);
        var $form = $('#edit-material', $modal);

        $('.js-save--material').click(function () {
            if (!$form.valid()) return;

            $.ajax({
                url: '/Material/Save/',
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