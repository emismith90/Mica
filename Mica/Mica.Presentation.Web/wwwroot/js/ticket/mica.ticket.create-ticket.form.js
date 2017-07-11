(function ($, InventoryOp, EffortOp) {
    Mica.Ticket.CreateTicket.Form = function () {
        var $form = $('#create-ticket-form');

        var inventoryOp = new InventoryOp($form.find('#inventory-area'));
        var effortOp = new EffortOp($form.find('#effort-area'));

        $form.find('.js-ticket-create').click(function () {

        //    var d = $form.serializeData();
        //    d.InventoryOperations = inventoryOp.handler.serializeData();
        //    d.EffortOperations = effortOp.handler.serializeData();
        //    //d.Name = 'ffff';
        //    //d.SaleById = '99';
        //    d.ClientId = '1';
        ////d.StatusId = '1';
        ////d.PersonInChargeId = '';
        ////d.Deadline = new Date();
        ////d.Quantity = '1';
        ////d.Note = '';

            if ($form[0].checkValidity() && inventoryOp.handler.checkValidity() && effortOp.handler.checkValidity()) {

                var formData = $form.serializeData();
                formData.InventoryOperations = inventoryOp.handler.serializeData();
                formData.EffortOperations = effortOp.handler.serializeData();

                $.ajax({
                    url: '/Ticket/Save',
                    data: JSON.stringify(formData),
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        window.location.href = '/Ticket';
                    }
                });
            }
        });
    };
})(jQuery,
   Mica.Ticket.CreateTicket.InventoryOperation,
   Mica.Ticket.CreateTicket.EffortOperation);