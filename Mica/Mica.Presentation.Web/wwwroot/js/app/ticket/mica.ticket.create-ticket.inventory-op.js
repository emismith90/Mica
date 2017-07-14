Mica.use('InventoryOperation', ['jQuery', 'InMemoryTable', function ($, Table) {
    return function ($scope) {
        var inventoryOpTbl = new Table({
            $scope: $scope,
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
            },
            rowData: function ($row) {
                var materialId = parseInt($('select[name=MaterialId]', $row).val());
                var quantity = parseFloat($('input[name=Quantity]', $row).val());

                if (materialId == 0 && quantity == 0) return null;
                return {
                    MaterialId: materialId,
                    Quantity: quantity
                };
            },
            validateRow: function (dataRow) {
                return dataRow.MaterialId > 0 && dataRow.Quantity > 0 ? null : "Xin nhập đầy đủ vật liệu và số lượng.";
            }
        });

        function updateInventoryGrandTotal() {
            $('#inventory-summary', inventoryOpTbl.$el).html(
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
}]);