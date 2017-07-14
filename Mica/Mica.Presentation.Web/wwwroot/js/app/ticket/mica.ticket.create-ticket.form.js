Mica.use('CreateTicketForm', ['$aquarium', 'jQuery', 'InventoryOperation', 'EffortOperation', 'JsonHttpService',
    function ($aquarium, $, InventoryOp, EffortOp, JsonHttpService) {
        return function () {
            var fishes = {
                ongoing: 'ticket_http_on_going',
                success: 'ticket_http_success',
                error: 'ticket_http_error',
                always: 'ticket_http_always'
            };

            var httpService = new JsonHttpService(fishes);

            var $form = $('#create-ticket-form');

            var inventoryOp = new InventoryOp($form.find('#inventory-area'));
            var effortOp = new EffortOp($form.find('#effort-area'));

            $aquarium
                .whenPet([fishes.success], function (food) {
                    window.location.href = '/Ticket';
                });

            $form.find('.js-ticket-create').click(function () {
                if ($form[0].checkValidity() && inventoryOp.handler.checkValidity() && effortOp.handler.checkValidity()) {

                    var formData = $form.serializeData();
                    formData.InventoryOperations = inventoryOp.handler.serializeData();
                    formData.EffortOperations = effortOp.handler.serializeData();

                    httpService.post('/Ticket/Save', formData);
                }
            });
        };
    }]);