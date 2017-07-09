(function ($, Table) {
    $(document).ready(function () {
        var inventoryOpTbl = new Table({
            tableSelector: '#inventory-tbl',
            addButtonSelector: '.js-imt-add-inventory',
            onRowAdded: inventoryOnRowAdded,
            onRowDeleted: inventoryOnRowDeleted,
        });

        var effortOpTbl = new Table({
            tableSelector: '#effort-tbl',
            addButtonSelector: '.js-imt-add-effort',
            onRowAdded: effortOnRowAdded,
            onRowDeleted: effortOnRowDeleted,
        });

        function inventoryOnRowAdded($row) {
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

                updateGrandTotal(inventoryOpTbl);
            });
        }

        function inventoryOnRowDeleted($row) {
            updateGrandTotal(inventoryOpTbl);
        }

        function effortOnRowAdded($row) {
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

                updateGrandTotal(effortOpTbl);
            });
        }

        function effortOnRowDeleted($row) {
            updateGrandTotal(effortOpTbl);
        }

        function updateGrandTotal(inMemoryTable) {
            $('#imt-summary', inMemoryTable.$el).html(
                inMemoryTable
                    .getData()
                    .find('input[name=Total]')
                    .sum()
                    .toFixed(1));
        }
    });
})(jQuery, Mica.Common.InMemoryTable);
