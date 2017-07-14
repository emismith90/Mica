Mica.run('Ticket-Addedit', ['document', 'jQuery', 'CreateTicketForm', function (document, $, CreateTicketForm) {
    $(document).ready(function () {
        new CreateTicketForm();
    });
}]);
