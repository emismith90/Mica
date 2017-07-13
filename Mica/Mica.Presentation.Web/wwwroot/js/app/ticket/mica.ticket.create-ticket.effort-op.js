Mica.use('EffortOperation', ['jQuery', 'InMemoryTable', function ($, Table) {
    return function ($scope) {
        var effortOpTbl = new Table({
            $scope: $scope,
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
            },
            rowData: function ($row) {
                var effortId = parseInt($('select[name=EffortId]', $row).val());
                var quantity = parseFloat($('input[name=Quantity]', $row).val());

                if (effortId == 0 && quantity == 0) return null;
                return {
                    EffortId: effortId,
                    Quantity: quantity
                };
            },
            validateRow: function (dataRow) {
                return dataRow.EffortId > 0 && dataRow.Quantity > 0 ? null : "Xin nhập đầy đủ công và số lượng.";
            }
        });

        function updateEffortGrandTotal() {
            $('#effort-summary', effortOpTbl.$el).html(
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
}]);