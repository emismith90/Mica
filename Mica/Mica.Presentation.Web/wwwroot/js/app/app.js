Mica.run('main', ['jQuery', 'document', 'SmartLink', 'DynamicModal', 'Menu',
    function ($, document, SmartLink, Modal, Menu) {
        $(document).ready(function () {
            new SmartLink();
            new Modal();

            Menu.setActive();
        });
    }]);