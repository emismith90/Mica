Mica.use('InMemoryTable', ['jQuery', 'document', function ($, document) {
    return function (options) {
        var defaults = {
            $scope: $(document),
            tableSelector: '#imt-table',
            addButtonSelector: '.js-imt-add',
            deleteButtonSelector: '.js-imt-delete',
            validationSummarySelector: '#imt-validation-summary',
            onRowAdded: function ($row) { },
            onRowDeleted: function ($row) { },
            rowData: function ($row) { return {}; },
            validateRow: function (dataRow) { return true; }
        };

        var settings = $.extend({}, defaults, options);
        var $table = settings.$scope.find(settings.tableSelector);
        var $validationSummary = settings.$scope.find(settings.validationSummarySelector);

        function initialize() {
            settings.$scope.find(settings.addButtonSelector).click(addClick);

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

        function checkValidity() {
            var data = serializeData();

            var validateMessage = '';
            var isValid = true;
            data.forEach(function (dataRow, index) {
                var msg = settings.validateRow(dataRow);
                if (msg) {
                    isValid = false;
                    validateMessage += (index + 1) + '. ' + msg + '<br/>';
                }
            });

            $validationSummary.html(validateMessage);
            return isValid;
        }

        function serializeData() {
            var data = [];
            var $rows = getData();
            $rows.each(function (index, row) {
                var rowData = settings.rowData($(row));
                if (rowData) data.push(rowData);
            });

            return data;
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
            getData: getData,
            serializeData: serializeData,
            checkValidity: checkValidity
        };
    };
}]);

