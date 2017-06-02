$(function () {
    var d = new Date();

    var month = d.getMonth() + 1;
    var day = d.getDate();

    var output =
        (('' + day).length < 2 ? '0' : '') + day + '/' +
        (('' + month).length < 2 ? '0' : '') + month + '/' +
        d.getFullYear();

    console.log(output);

    $("#datepicker").datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        todayHighlight: true,

    });

    $("#datepicker").datepicker('setDate', output);

})
