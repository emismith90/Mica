Mica.use('CreateTicketForm', ['$aquarium', 'jQuery', 'InventoryOperation', 'EffortOperation', 'JsonHttpService',
    function ($aquarium, $, InventoryOp, EffortOp, JsonHttpService) {
        return function () {
            var fishes = {
                success: 'ticket_http_success',
            };

            var httpService = new JsonHttpService(fishes);

            var $form = $('#create-ticket-form');

            var $fileList = $form.find('ul[mc-file-list]');
            $fileList.find('i.js-remove-file').click(removeFileClick);

            var fileUploadFishes = {
                success: 'file_picker_ticket-attachment_http_success',
            };

            var inventoryOp = new InventoryOp($form.find('#inventory-area'));
            var effortOp = new EffortOp($form.find('#effort-area'));

            $aquarium
                .whenPet([fishes.success], function (food) {
                    window.location.href = '/Ticket';
                })
                .whenPet([fileUploadFishes.success], function (food) {
                    food.forEach(function (item) {
                        var $item = $('<li><a href="/resources/' + item + '">' + item + '</a> <i class="glyphicon glyphicon-remove js-remove-file"></i></li>');
                        $fileList.append($item);

                        $item.find('i.js-remove-file').click(removeFileClick);
                    });
                });

            $form.find('.js-ticket-create').click(function () {
                if ($form[0].checkValidity() && inventoryOp.handler.checkValidity() && effortOp.handler.checkValidity()) {

                    var formData = $form.serializeData();
                    formData.InventoryOperations = inventoryOp.handler.serializeData();
                    formData.EffortOperations = effortOp.handler.serializeData();
                    formData.Attachments = $fileList.find('a').map(function () {
                        return $(this).text();
                    }).get();

                    httpService.post('/Ticket/Save', formData);
                }
            });

            var removeFileClick = function () {
                $(this).closest('li').remove();
            };
        };
    }]);