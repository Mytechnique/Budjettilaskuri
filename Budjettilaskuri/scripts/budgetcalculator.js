$(function () {
    var d = new Date();

    var month = d.getMonth() + 1;
    var day = d.getDate();
    //  (('' + day).length < 2 ? '0' : '') + day + '/' +
    var output =
      
        (('' + month).length < 2 ? '0' : '') + month + '/' +
        d.getFullYear();

    console.log(output);

    $("#datepicker").datepicker({
        format: 'MM/yyyy',
        autoclose: true,
        todayHighlight: true,
        viewMode: 'months',
        minViewMode: 'months'

    });

    $("#datepicker").datepicker('setDate', output);

    console.log($("#lblSavings").innerText);
})
