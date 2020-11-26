var $checkboxes = $('input[type="checkbox"]'),
    $flowers = $('.filter');

$checkboxes.on('change', function () {

    var selectedOptions = {};

    $checkboxes.filter(':checked').each(function () {

        if (typeof selectedOptions[this.name] == 'undefined') {
            selectedOptions[this.name] = [];
        }

        selectedOptions[this.name].push(this.value);

    });

    var $filtered = $flowers;

    $.each(selectedOptions, function (type, selectedOption) {

        $filtered = $filtered.filter(function () {

            var matched = false,
                currentFilters = $(this).data('category').split(' ');

            $.each(currentFilters, function (_, currentFilter) {
                if ($.inArray(currentFilter, selectedOption) != -1) {
                    matched = true;
                    return false;
                }
            });

            if (matched) {
                return true;
            }

        });

    });

    $flowers.hide().filter($filtered).show();

});