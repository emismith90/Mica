(function ($) {
    $.fn.registerAsDeleteModal = function () {
        var $modal = $(this);
        var $form = $('#delete-material', $modal);

        $('.js-delete--material').click(function () {
            if (!$form.valid()) return;

            $.ajax({
                url: '/Material/Delete/',
                data: $form.getFormData(),
                type: 'POST',
                success: function (data) {
                    location.reload();
                }
            });
        });
    }
})(jQuery);