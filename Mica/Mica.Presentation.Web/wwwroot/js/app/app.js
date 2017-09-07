Mica.run('main', ['jQuery', 'document', 'SmartLink', 'DynamicModal', 'Menu', 'FilePicker',
    function ($, document, SmartLink, Modal, Menu, FilePicker) {
        $(document).ready(function () {
            new SmartLink();
            new Modal();
            new FilePicker();

            Menu.setActive();
        });
    }]);