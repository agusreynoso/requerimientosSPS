
$(function () {
    $("select").select2({
        width: "250px",
        placeholder: "Seleccionar..."
    });

    $(".tablaDatatable").closest(".container").removeClass("container");

    var table = $('.tablaDatatable').DataTable({
        "pageLength": 25,
        "columnDefs": [
            { "visible": false, "targets": "initialyDisabled" },
            { "type": 'date-ar', "targets": "date_ar" }
        ],
        //"dom": '<"pull-left"l><"pull-left"f>tip',
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningun dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Ultimo",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        buttons: [
            {
                extend: 'colvis',
                text: 'Columnas que se muestran'
            },
            {
                extend: 'csv',
                text: 'Exportar a CSV',
                className: 'exportButton',
                fieldSeparator: ";",
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'pdfHtml5',
                text: 'Exportar a PDF',
                className: 'exportButton',
                orientation: "landscape",
                pageSize: "A3",
                exportOptions: {
                    columns: ':visible'
                },
                customize: function (doc) {
                }
            }]
    });

    table.buttons().container().appendTo('#buttonsWrapper');

    })