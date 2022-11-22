

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

    fetch("/CatalagoProyectos/ListaAsesores")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboAsesorI").append(
                        $("<option>").val(item.asesorInstitucionalID).text(item.nombreA)
                    )
                })
            }
        })

    fetch("/CatalagoProyectos/ListaResponsables")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboResponsableI").append(
                        $("<option>").val(item.responsableInstitucionalID).text(item.nombreR)
                    )
                })
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
            processResults: function (data,) {
                return {
                    results: data.map((item) => (
                        {
                            id: item.empresaID,
                            text: item.rfc,

                            razonS: item.sectorS,
                            nombreC: item.nombreC,
                            sectorS: item.razonS,
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
                   <p style="margin:2px">${data.sectorS}</p>
                   <p style="margin:2px">${data.nombreC}</p>
                   <p style="margin:2px">${data.razonS}</p>
                   <p style="font-weight: bolder;margin:2px">${data.text}</p> 
                </td>
            </tr>
        </table>`
    );
    return contenedor;
}


$(document).on("select2:open", function () {
    document.querySelector(".select2-search__field").focus();
})


let empresasProyecto = [];
$("#cboBuscarEmpresa").on("select2:select", function (e) {
    const data = e.params.data;

    let empresa_encontrada = empresasProyecto.filter(p => p.empresaID == data.id)
    if (empresa_encontrada.length > 0) {
        $("#cboBuscarEmpresa").val("").trigger("change")
        toastr.warning("", "La empresa ya fue selecionada")
        return false
    }

    swal({
        title: data.razonS,
        text: data.text,
        type: "input",
        showCancelButton: true,
        closeOnConfirm: false,
        inputPlaceholder:"Catidad???"
    },
        function (valor) {

            if (valor === false) return false;

            if (valor === "") {
                toastr.warning("", "necesita agradgasas")
                return false;
            }

            if (isNaN(parseInt(valor))) {
                toastr.warning("", "necesita agradgasas numero")
                return false;
            }

            let empresa = {
                empresaID: data.id,
                sectorS: data.sectorS,
                nombreC: data.nombreC,
                razonS: data.razonS,
                representanteL: data.representanteL
            }
            empresasProyecto.push(empresa)

            mostrarEmpresa_Datos();

            $("#cboBuscarEmpresa").val("").trigger("change")
            swal.close()
        }
    )
    
})


function mostrarEmpresa_Datos() {

    $("#tbEmpresa tbody").html("")

    empresasProyecto.forEach((item) => {
        $("#tbEmpresa tbody").append(
            $("<tr>").append(
                $("<td>").append(
                    $("<button>").addClass("btn btn-danger btn-eliminar btn-sm").append(
                        $("<i>").addClass("fas fa-trash-alt")
                    ).data("empresaID", item.empresaID)
                ),
                $("<td>").text(item.sectorS),
                $("<td>").text(item.nombreC),
                $("<td>").text(item.razonS),
                $("<td>").text(item.representanteL)
            )
        )
    })


}

$(document).on("click", "button.btn-eliminar", function () {

    const _empresaID = $(this).data("empresaID")


    empresasProyecto = empresasProyecto.filter(p => p.empresaID != _empresaID);
    mostrarEmpresa_Datos();
})

$("#btnAsignarProyecto").click(function () {


    if (empresasProyecto.length < 1) {
        toastr.warning("", "Debe ingresar una empresa")
        return;
    }

    const proyectoVM =
    {

        ///
        empresaID: empresasProyecto[0].empresaID
    }

    console.log(proyectoVM)

    $("#btnAsignarProyecto").LoadingOverlay("show");

    fetch("/CatalagoProyectos/RegistrarProyecto", {
        method: "POST",
        headers: { "Content-Type": "applications(json; charset=utf-8" },
        body: JSON.stringify(proyectoVM)
    })
        .then(response => {
            $("#btnAsignarProyecto").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {
                empresasProyecto = [];
                mostrarEmpresa_Datos();

                swal("Asginado", `Numero Proyecto: ${responseJson.objeto.numeroProyecto}`, "success")
            } else {
                swal("No asignado", "no", "error")
            }
        })
})