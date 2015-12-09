$(function () {
    $('.searchFechaDesde').datetimepicker({
        format: 'DD/MM/YYYY',
        locale: 'es_ar',
        showClear: true
    });

    $('.searchFechaHasta').datetimepicker({
        format: 'DD/MM/YYYY',
        locale: 'es_ar',
        showClear: true,
        useCurrent: false
    });

    $('.searchFecha').datetimepicker({
        format: 'DD/MM/YYYY',
        locale: 'es_ar',
        showClear: true
    });

    $(".searchFechaDesde").on("dp.change", function (e) {
        $(this).closest('div.row').find('.searchFechaHasta').data("DateTimePicker").minDate(e.date);
    });
    $(".searchFechaHasta").on("dp.change", function (e) {
        $(this).closest('div.row').find('.searchFechaDesde').data("DateTimePicker").maxDate(e.date);
    });

    if (tablaResultados = $("#tablaResultadosBuscador")) {
        tablaResultados.closest(".row").css("overflow", "auto");
    }
});