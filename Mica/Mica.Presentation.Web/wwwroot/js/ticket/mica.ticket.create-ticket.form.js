(function ($, InventoryOp, EffortOp, Aquarium, JsonHttpService) {
    Mica.Ticket.CreateTicket.Form = function () {
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

        Aquarium
            .whenPet(fishes.success, function (food) {
                window.location.href = '/Ticket';
            });

        $form.find('.js-ticket-create').click(function () {
            if ($form[0].checkValidity() && inventoryOp.handler.checkValidity() && effortOp.handler.checkValidity()) {

                var formData = $form.serializeData();
                formData.InventoryOperations = inventoryOp.handler.serializeData();
                formData.EffortOperations = effortOp.handler.serializeData();

                httpService.post('/Ticket/Save', formData);

                //$.ajax({
                //    url: '/Ticket/Save',
                //    data: JSON.stringify(formData),
                //    type: 'POST',
                //    contentType: 'application/json; charset=utf-8',
                //    dataType: 'json',
                //    success: function (data) {
                //        window.location.href = '/Ticket';
                //    }
                //});
            }
        });
    };
})(jQuery,
   Mica.Ticket.CreateTicket.InventoryOperation,
   Mica.Ticket.CreateTicket.EffortOperation,
   Mica.Service.Aquariums['mica'],
   Mica.Service.JsonHttpService);