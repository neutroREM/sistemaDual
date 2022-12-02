$(document).ready(function () {

    $("div.container-fluid").LoadingOverlay("show")
    fetch("/Dashboard/ObtenerResumen")
        .then(response => {
            $("div.container-fluid").LoadingOverlay("hide")
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {

                let d = responseJson.objeto
                //mostrar datos en tarjetas
                $("#totalAlumnos").text(d.totalAlumnos)
                $("#totalProgramas").text(d.totalProgramas)
                $("#totalEmpresas").text(d.totalEmpresas)
                $("#totalProyectos").text(d.totalProyectos)


                //obtener valores para la grafica

                let barchart_labels;
                let barchart_data;

                if (d.proyectoSemana.length > 0) {
                    barchart_labels = d.proyectoSemana.map((item) => { return item.fecha })
                    barchart_data = d.proyectoSemana.map((item) => { return item.total })
                } else {
                    barchart_labels = ["sin resultados"]
                    barchart_data = [0]
                }

                //textos y valores para la grafica

                let piechar_labels;
                let piechar_data;

                if (d.alumnosSemana.length > 0) {
                    piechar_labels = d.alumnosSemana.map((item) => { return item.alumno })
                    piechar_data = d.alumnosSemana.map((item) => { return item.cantidad })
                } else {
                    piechar_labels = ["sin resultados"]
                    piechar_data = [0]
                }


                //Barchar
                let controlProyecto = document.getElementById("chartProyectos");
                let myBarChart = new Chart(controlProyecto, {
                    type: 'bar',
                    data: {
                        labels: barchart_labels,
                        datasets: [{
                            label: "Cantidad",
                            backgroundColor: "#4e73df",
                            hoverBackgroundColor: "#2e59d9",
                            borderColor: "#4e73df",
                            data: barchart_data,
                        }],
                    },
                    options: {
                        maintainAspectRatio: false,
                        legend: {
                            display: false
                        },
                        scales: {
                            xAxes: [{
                                gridLines: {
                                    display: false,
                                    drawBorder: false
                                },
                                maxBarThickness: 50,
                            }],
                            yAxes: [{
                                ticks: {
                                    min: 0,
                                    maxTicksLimit: 5
                                }
                            }],
                        },
                    }
                });


                // Pie Chart Example
                let controlAlumno = document.getElementById("chartAlumnos");
                let myPieChart = new Chart(controlAlumno, {
                    type: 'doughnut',
                    data: {
                        labels: piechar_labels,
                        datasets: [{
                            data: piechar_data,
                            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', "#FF785B"],
                            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf', "#FF5733"],
                            hoverBorderColor: "rgba(234, 236, 244, 1)",
                        }],
                    },
                    options: {
                        maintainAspectRatio: false,
                        tooltips: {
                            backgroundColor: "rgb(255,255,255)",
                            bodyFontColor: "#858796",
                            borderColor: '#dddfeb',
                            borderWidth: 1,
                            xPadding: 15,
                            yPadding: 15,
                            displayColors: false,
                            caretPadding: 10,
                        },
                        legend: {
                            display: true
                        },
                        cutoutPercentage: 80,
                    },
                });

            }

        })
})