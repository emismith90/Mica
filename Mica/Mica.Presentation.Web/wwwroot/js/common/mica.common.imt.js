(function ($) {
    Mica.Common.InMemoryTable = function (options) {
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
            if ($bluePrints.length === 1) { // not allow to delete blueprint row
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
    };
})(jQuery);