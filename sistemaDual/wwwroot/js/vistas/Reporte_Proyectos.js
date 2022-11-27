
//
let tableData;
$(document).ready(function () {

     $.datepicker.setDefaults($.datepicker.regional["es"])

    $("#txtFechaInicio").datepicker({dateFormat: "dd/mm/yy"})
    $("#txtFechaFin").datepicker({ dateFormat: "dd/mm/yy" })

    //Mostrar Proyectos
    tableData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": '/CatalagoProyectos/ReporteProyecto?fechaInicio=01/01/2015&fechaFin=01/01/2015',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "catalagoProyectoID", "visible": false, "searchable": false },
            { "data": "numeroProyecto" },
            { "data": "nombreProyecto" },
            { "data": "etapa" },
            { "data": "areaConocimiento" },
            { "data": "numHoras" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "curp" },
            { "data": "nombreA" },
            { "data": "nombreC" },
            { "data": "nombreP" },
            { "data": "nombreAsesor" },
            { "data": "nombreResponsable" },
            {
                "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>'
                ,
                "orderable": false,
                "searchable": false,
                "width": "80px"
            }
        ],
        rowCallback: function (row, data, index) {
            if (data.programaEducativoID) {
                $(row).find('td:eq(5)').css('color', 'green', '!important');
            }
        },
        order: [[0, "desc"]],
        dom: "Bfrtip",
        buttons: [
            {
                text: 'Exportar Excel',
                extend: 'excelHtml5',
                title: '',
                filename: 'Reporte de Proyectos',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                }
            }, 'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        }
    });



})

$("#btnBuscar").click(function () {
    if ($("#txtFechaInicio").val().trim() == "" || $("#txtFechaFin").val().trim() == "") {
        toastr.warning("", "Debe ingresar fechas")
        return;
    }

    let fechaInicio = $("#txtFechaInicio").val().trim();
    let fechaFin = $("#txtFechaFin").val().trim();
    let nueva_url = `/CatalagoProyectos/ReporteProyecto?fechaInicio=${fechaInicio}&fechaFin=${fechaFin}`;
   
    tableData.ajax.url(nueva_url).load();

    
})