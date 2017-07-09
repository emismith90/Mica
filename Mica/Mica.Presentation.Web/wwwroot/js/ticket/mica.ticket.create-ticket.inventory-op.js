(function ($, Table) {
    Mica.Ticket.CreateTicket.InventoryOperation = function ($scope) {
        var inventoryOpTbl = new Table({
            $scope: $scope,
            tableSelector: '#inventory-tbl',
            addButtonSelector: '.js-imt-add-inventory',
            onRowAdded: function ($row) {
                var $material = $('select[name=MaterialId]', $row);
                var $quantity = $('input[name=Quantity]', $row);
                var $unitPrice = $('input[name=UnitPrice]', $row);
                var $total = $('input[name=Total]', $row);

                $('select[name=MaterialId]', $row).change(function () {
                    $unitPrice.val($material.selectedValue().rate).change();
                });

                $('input[name=Quantity], input[name=UnitPrice]', $row).change(function () {
                    var total = parseFloat($quantity.val()) * parseFloat($unitPrice.val());
                    $total.val(total.toFixed(1));

                    updateInventoryGrandTotal();
                });
            },
            onRowDeleted: function ($row) {
                updateInventoryGrandTotal();
            }
        });

        function updateInventoryGrandTotal() {
            $('#imt-summary', inventoryOpTbl.$el).html(
                inventoryOpTbl
                    .getData()
                    .find('input[name=Total]')
                    .sum()
                    .toFixed(1));
        }

        return {
            handler: inventoryOpTbl
        };
    };
})(jQuery, Mica.Common.InMemoryTable);