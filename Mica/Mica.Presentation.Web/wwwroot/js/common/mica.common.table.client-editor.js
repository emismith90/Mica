Mica.Common.ClientEditor = {
    addClick: function (event) {
        var $this = $(this);
        var $table = $($this.attr('tce-target-tbl'));

        var $newRow = $($table.find('tbody tr').first().clone());

        $('input, select, textarea', $newRow).each(function(index, elem) {
            var $element = $(elem);
            $element.val($element.attr('tce-default-value'));
        });

        $table.find('tbody tr:last').before($newRow);
    },

    deleteClick: function (event) {
        var $this = $(this);
        var $deleteRow = $this.closest('tr');
        $deleteRow.remove();
    },
}