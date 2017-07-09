(function ($, Table) {
    Mica.Ticket.CreateTicket.EffortOperation = function ($scope) {
        var effortOpTbl = new Table({
            $scope: $scope,
            tableSelector: '#effort-tbl',
            addButtonSelector: '.js-imt-add-effort',
            onRowAdded: function ($row) {
                var $effort = $('select[name=EffortId]', $row);
                var $quantity = $('input[name=Quantity]', $row);
                var $unitPrice = $('input[name=UnitPrice]', $row);
                var $total = $('input[name=Total]', $row);

                $('select[name=EffortId]', $row).change(function () {
                    $unitPrice.val($effort.selectedValue().rate).change();
                });

                $('input[name=Quantity], input[name=UnitPrice]', $row).change(function () {
                    var total = parseFloat($quantity.val()) * parseFloat($unitPrice.val());
                    $total.val(total.toFixed(1));

                    updateEffortGrandTotal(effortOpTbl);
                });
            },
            onRowDeleted: function ($row) {
                updateEffortGrandTotal();
            }
        });

        function updateEffortGrandTotal() {
            $('#imt-summary', effortOpTbl.$el).html(
                effortOpTbl
                    .getData()
                    .find('input[name=Total]')
                    .sum()
                    .toFixed(1));
        }

        return {
            handler: effortOpTbl
        };
    };
})(jQuery, Mica.Common.InMemoryTable);