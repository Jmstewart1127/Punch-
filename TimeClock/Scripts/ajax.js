$(document).ready(function () {
    $('#clockIn').click(function () {
        $.ajax({
            type: 'GET',
            url: '@Url.Action("getCurrentTime", "TimeClock")',
            dataType: 'html',
            success: function (result) {
                $('#timeDisplay').html(result);
            }
        });

    });
});