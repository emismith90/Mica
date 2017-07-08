$(document).ready(function () {
    var inventoryOpTbl = new InMemoryTable({
        tableSelector: '#inventory-tbl',
        addButtonSelector: '.js-imt-add-inventory',
        onRowAdded: inventoryOnRowAdded,
        onRowDeleted: inventoryOnRowDeleted,
    });

    var effortOpTbl = new InMemoryTable({
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

function InMemoryTable(options) {
    var defaults = {
        tableSelector: '#imt-table',
        addButtonSelector: '.js-imt-add',
        deleteButtonSelector: '.js-imt-delete',
        onRowAdded: function ($row) { },
        onRowDeleted: function ($row) { },
    };

    var settings = $.extend({}, defaults, options);
    var $table = $(settings.tableSelector);

    function initialize() {
        $(settings.addButtonSelector).click(addClick);

        var $blueprint = $table.find('tbody tr[imt-data]:first');
        registerEvents($blueprint);
        settings.onRowAdded($blueprint);
    }

    function registerEvents($scope) {
        $(settings.deleteButtonSelector, $scope).click(deleteClick);
    }

    function addClick(event) {
        // clone blue print
        var $bluePrint = $table.find('tbody tr[imt-data]').first();
        var $newRow = $($bluePrint.clone());
        resetRow($newRow);
        $table.find('tbody tr[imt-data]:last').after($newRow);

        registerEvents($newRow);
        settings.onRowAdded($newRow);
    };

    function deleteClick(event) {
        var $bluePrints = $table.find('tbody tr[imt-data]');
        if ($bluePrints.length == 1) { // not allow to delete blueprint row
            resetRow($bluePrints);
            settings.onRowDeleted($bluePrints);
            return;
        };

        var $this = $(this);
        var $deleteRow = $this.closest('tr');
        $deleteRow.remove();

        settings.onRowDeleted($deleteRow);
    }

    function getData() {
        return $table.find('tbody tr[imt-data]');
    }

    function resetRow(row) {
        $('input, select, textarea', row).each(function (index, elem) {
            var $element = $(elem);
            $element.val($element.attr('imt-default-value'));
        });
    }

    initialize();

    return {
        $el: $table,
        getData: getData
    };
}