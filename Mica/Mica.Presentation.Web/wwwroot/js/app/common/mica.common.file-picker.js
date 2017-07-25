Mica.use('FilePicker', ['jQuery', 'document', 'FileUploadHttpService', function ($, document, FileUploadHttpService) {
    return function (context) {
        var scope = context || document;
        var $scope = $(scope);
        var fileUploadHttpService = new FileUploadHttpService();

        var $filePickers = $scope.find('input[type="file"][mc-file-picker]');

        $filePickers.each(function (index, elm) {
            var $filePicker = $(elm);
            var name = $filePicker.attr('name');

            var fishes = {
                ongoing: 'file_picker_' + name + '_http_on_going',
                success: 'file_picker_' + name + '_http_success',
                error: 'file_picker_' + name + '_http_error',
                always: 'file_picker_' + name + '_http_always'
            };

            $filePicker.data('local-fishes', fishes);
        });

        $filePickers.change(function () {
            var $filePicker = $(this);
            var url = $filePicker.attr('post-to');
            var fishes = $filePicker.data('local-fishes');

            var data = new FormData();
            for (var i = 0; i < this.files.length; i++) {
                data.append('files', this.files[i]);
            }

            fileUploadHttpService.upload(url, data, fishes);
        });
    };
}]);

