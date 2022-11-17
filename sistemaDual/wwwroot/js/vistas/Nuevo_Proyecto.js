
$(document).ready(function () {
    fetch("/CatalagoProyectos/ListaProgramas")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboProgramaE").append(
                        $("<option>").val(item.programaEducativoID).text(item.nombreP)
                    )
                })
            }
        })

    fetch("/AsesoresInstitucionales/Obtener")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {
                const d = responseJson.objeto;
                console.log(d)

                $("#inputGroupNombreA").text(`Nombre del Asesor`)
                $("#txtNombreA").val(d.nombreA)
                $("#inputCorreoA").text(`Correo del Asesor`)
                $("#txtCorreoA").val(d.correo)
                $("#inputGroupTelefonoA").text(`Teléfono del Asesor`)
                $("#txtTelefonoA").val(d.telefono)
            }
        })

    $("#cboBuscarEmpresa").select2({
        ajax: {
            url: "/CatalagoProyectos/ObtenerEmpresas",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            delay: 250,
            data: function (params) {
                return {
                    busqueda: params.term
                };
            },
            processResults: function (data) {
                return {
                    results: data.map((item) => ({
                        id: item.empresaID,
                        text: item.rfc,

                        razonS: item.razonS,
                        nombreC: item.nombreC,
                        sectorS: item.sectorS,
                        representanteL: item.representanteL

                    }
                    ))
                };
            },
        },
        language:"es",
        placeholder: 'Buscar Empresa',
        minimumInputLength: 1,
        templateResult: formatoEmpresas
    });
})

function formatoEmpresas(data) {
    if (data.loading)
        return data.text;

    var contenedor = $(
        `<table width="100%">
            <tr>
                <td>
                   <p style="margin:2px">${data.nombreC}</p>
                   <p style="margin:2px">${data.razonS}</p> 
                   <p style="margin:2px">${data.representanteL}</p>
                   <p style="font-weight: bolder;margin:2px">${data.text}</p> 
                </td>
            </tr>
        </table>`
    );
    return contenedor;
}

$("#cboBuscarEmpresa").on("select2:select", function (e) {
    const data = e.params.data;

    console.log(data);
})