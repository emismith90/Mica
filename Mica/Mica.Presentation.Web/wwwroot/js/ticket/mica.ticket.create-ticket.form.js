(function ($, InventoryOp, EffortOp) {
    Mica.Ticket.CreateTicket.Form = function () {
        var $form = $('#create-ticket-form');

        var inventoryOp = new InventoryOp($form.find('#inventory-area'));
        var effortOp = new EffortOp($form.find('#effort-area'));

        $form.find('.js-ticket-create').click(function () {
            if ($form[0].checkValidity() && inventoryOp.handler.checkValidity() && effortOp.handler.checkValidity()) {

                var formData = $form.getFormData();
                formData['Model.InventoryOperations'] = inventoryOp.handler.getFormData();
                formData['Model.EffortOperations'] = effortOp.handler.getFormData();

                console.log(formData);

                $.ajax({
                    url: '/Ticket/Save',
                    data: JSON.stringify(formData),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: 'POST',
                    success: function(data) {
                        window.location.href = '/Ticket';
                    }
                });
            }
        });
    };
})(jQuery,
   Mica.Ticket.CreateTicket.InventoryOperation,
   Mica.Ticket.CreateTicket.EffortOperation);