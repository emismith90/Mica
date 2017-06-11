(function ($) {
    $(document).ready(function () {
        $('.js-open-modal').on('click', function () {
            var contentUrl = $(this).data('modal-content-url');
            var target = $(this).data('target');
            var formType = $(this).data('form-type');

            // clear modal content
            $('.modal-content', target).html('');

            $.ajax({
                url: contentUrl,
                type: 'GET',
                success: function (data) {
                    $('.modal-content', target).html(data);
                    
                    registerFormSubmitEvent(formType, target);
                }
            });
        });
    })

    function registerFormSubmitEvent(formType, modalSelector) {
        var $modal = $(modalSelector);
        switch (formType) {
            case 'add':
            case 'edit':
                $modal.registerAsEditModal();
                break;
            case 'delete':
                $modal.registerAsDeleteModal();
                break;
        }
    }
})(jQuery);