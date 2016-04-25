$("#btn-AdicionarMaquinas").click(function () {
    window.location.href = "/Maquina/ConfigurarMaquina";
});

$("#btn-EditarMaquinas").click(function () {
    window.location.href = "/Maquina/EditarMaquina/";
});

$("#SalvaMaquina").click(function () {
    SendsServer(
        "/Maquina/SalvaMaquina",
        {
            model: {
                ModeloMaquina: {
                    Name: $("#InsereModelo").val()
                },
                TipoMaquina: $("#MaquinadoTipo").val(),
                Processador: $("#Insereprocessador").val(),
                PlacaMae: $("#InsereplacaMae").val(),
                UnidadesMemoriaRam: $("#InsereunidadesMemoriaRam").val(),
                PenteMemoriaRamGB: $("#InserepenteMemoriaRamGB").val(),
                Ssd: $("#Inseressd").val(),
                Hd: $("#Inserehd").val(),
                Fonte: $("#Inserefonte").val(),
                PlacaRede: $("#InsereplacaRede").val(),
                DriverOtico: $("#InseredriverOtico").val()
            }
        },
        function (response) { GoBack(); },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
        );
});