(function ($, InventoryOp, EffortOp) {
    Mica.Ticket.CreateTicket.Form = function () {
        var $form = $('#create-ticket-form');

        var inventoryOp = new InventoryOp($form);
        var effortOp = new EffortOp($form);

        $form.find('.js-ticket-create').click(function () {

        });
    };
})(jQuery,
   Mica.Ticket.CreateTicket.InventoryOperation,
   Mica.Ticket.CreateTicket.EffortOperation);