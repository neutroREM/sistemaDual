

$(document).ready(function () {

    $(".card-body").LoadingOverlay("show");
    fetch("/Universidades/Obtener")   
        .then(response => {
            $(".card-body").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })  
        .then(responseJson => {
            if (responseJson.estado) {
                const d = responseJson.objeto

                $("#txtCct").val(d.cct)
                $("#txtNombreU").val(d.nombreU)
                $("#txtDomicilioID").val(d.domicilioID)
                $("#txtDireccion").val(d.direccion)
                $("#txtColonia").val(d.colonia)
                $("#txtMunicipio").val(d.municipio)
                $("#txtCodigoPostal").val(d.codigoPostal)

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
        universidadID: $("#txtDomicilioID").val(),
        cct: $("#txtCct").val(),
        nombreU: $("#txtNombreU").val(),
        direccion: $("#txtDireccion").val(),
        colonia: $("#txtColonia").val(),
        municipio: $("#txtMunicipio").val(),
        codigoPostal: $("#txtCodigoPostal").val(),
    }

    const formData = new FormData();
    formData.append("modelo", JSON.stringify(modelo))

    $(".card-body").LoadingOverlay("show");
    fetch("/Universidades/Editar", {
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
                swal("Correcto", "Universidad Registrada", "success")
            } else {
                swal("Problema", responseJson.mensaje, "error")
            }
        })
})




