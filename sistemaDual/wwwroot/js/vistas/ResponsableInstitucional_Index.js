$(document).ready(function () {

    $(".card-body").LoadingOverlay("show");

    //Mostrar Universidades
    fetch("/ResponsablesInstitucionales/ListaUniversidades")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                responseJson.forEach((item) => {
                    $("#cboUniversidad").append(
                        $("<option>").val(item.universidadID).text(item.nombreU)
                    )
                })
            }
        })


    fetch("/ResponsablesInstitucionales/Obtener")
        .then(response => {
            $(".card-body").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {
                const d = responseJson.objeto

                $("#txtCurp").val(d.curp)
                $("#txtNombreR").val(d.nombreR)
                $("#txtApellidoP").val(d.apellidoP)
                $("#txtApellidoM").val(d.apellidoM)
                $("#txtCorreo").val(d.correo)
                $("#txtTelefono").val(d.telefono)
                $("#txtCargo").val(d.cargo)
                $("#cboUniversidad").val(d.universidadID == "" ? $("#cboUniversidad option:first").val() : d.universidadID)

            } else {
                swal("Problema", responseJson.mensaje, "error")
            }
        })
});

$("#btnGuardarCambios").click(function () {
    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")

    if (inputs_sin_valor.length > 0) {
        const mensaje = `Debe completar el campo : "${inputs_sin_valor[0].name}"`;
        toastr.warning("", mensaje)
        $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
        return;
    }

    const modelo = {
        responsableInstitucionalID: $("#txtResponsableInstitucionalID").val(),
        curp: $("#txtCurp").val(),
        nombreR: $("#txtNombreR").val(),
        apellidoP: $("#txtApellidoP").val(),
        apellidoM: $("#txtApellidoM").val(),
        correo: $("#txtCorreo").val(),
        telefono: $("#txtTelefono").val(),
        cargo: $("#txtCargo").val(),
        universidadID: $("#cboUniversidad").val(),
    }

    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $(".card-body").LoadingOverlay("show");
    fetch("/ResponsablesInstitucionales/GuardarCambios", {
        method: "POST",
        body: formData
    })
        .then(response => {
            $(".card-body").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {
                const d = responseJson.objeto
                swal("Correcto", "Responsable Actualizado", "success")
            } else {
                swal("Problema", responseJson.mensaje, "error")
            }
        })
})