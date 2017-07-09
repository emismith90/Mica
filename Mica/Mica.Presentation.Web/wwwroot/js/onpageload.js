(function ($, SmartLink, Modal, Menu) {
    $(document).ready(function () {
        new SmartLink();
        new Modal();

        Menu.setActive();
    });
})(jQuery,
   Mica.Common.SmartLink,
   Mica.Common.Modal,
   Mica.Common.Menu);