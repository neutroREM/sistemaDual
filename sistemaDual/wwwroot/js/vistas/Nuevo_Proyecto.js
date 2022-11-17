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
})