﻿$("#btn-AdicionarMaquinas").click(function () {
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



function CarregaMaquinas() {
    ReceivesServer(
        "/Maquina/NomesModelosPadrao",
        {},
        function (data) {
            var options = "<option value='0'>Selecione um modelo</option>";
            data.forEach(
                function (modelo) {
                    options += '<option value="' + modelo.Id + '">' + modelo.Name + '</option>';
                }
            )
            $("#dropdown-EditarMaquina").empty().append(options);
            $("#DeletaMaquina").hide();
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
    );
}

$("#dropdown-EditarMaquina").change(
    function () {
        var idModeloEscolhido = $(this).val();
        if (idModeloEscolhido == 0) {
            $("#EditaModelo").prop("disabled", true).val();
            $("#Editaprocessador").prop("disabled", true).val();
            $("#EditaplacaMae").prop("disabled", true).val();
            $("#EditaeunidadesMemoriaRam").prop("disabled", true).val();
            $("#EditapenteMemoriaRamGB").prop("disabled", true).val();
            $("#Editassd").prop("disabled", true).val();
            $("#Editahd").prop("disabled", true).val();
            $("#Editafonte").prop("disabled", true).val();
            $("#EditaplacaRede").prop("disabled", true).val();
            $("#EditadriverOtico").prop("disabled", true).val();
            $("#MaquinadoTipo").prop("disabled", true).val();
            $("#DeletaMaquina").hide();

            return;
        }
        $("#DeletaMaquina").show();
        ReceivesServer(
            "/Maquina/MaquinaDoModelo",
            { idModelo: idModeloEscolhido },
            function (data) {
                $("#EditaModelo").prop("disabled", false).val(data.ModeloMaquina.Name);
                $("#Editaprocessador").prop("disabled", false).val(data.Processador);
                $("#EditaplacaMae").prop("disabled", false).val(data.PlacaMae);
                $("#EditaeunidadesMemoriaRam").prop("disabled", false).val(data.UnidadesMemoriaRam);
                $("#EditapenteMemoriaRamGB").prop("disabled", false).val(data.PenteMemoriaRamGB);
                $("#Editassd").prop("disabled", false).val(data.SSD);
                $("#Editahd").prop("disabled", false).val(data.HD);
                $("#Editafonte").prop("disabled", false).val(data.Fonte);
                $("#EditaplacaRede").prop("disabled", false).val(data.PlacaRede);
                $("#EditadriverOtico").prop("disabled", false).val(data.DriverOtico);
                $("#MaquinadoTipo").prop("disabled", false).val(data.TipoMaquina);
            },
            function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
        );
    }
);

$("#adicionaMaquina").click(
    function () {
        SendsServer(
            "/Maquina/AdicionarMaquina",
            {
                EtiquetaServico: $("#etiquetaServico").val(),
                Patrimonio: $("#patrimonio").val(),
                IdMesa: $("#idMesa").val(),
                Maquina: {
                    IdModeloMaquina: $("#dropdown-modeloMaquina").val(),
                    Processador: $("#processador").val(),
                    PlacaMae: $("#placaMae").val(),
                    UnidadesMemoriaRam: $("#unidadesMemoriaRam").val(),
                    PenteMemoriaRamGB: $("#penteMemoriaRamGB").val(),
                    Ssd: $("#ssd").val(),
                    Hd: $("#hd").val(),
                    Fonte: $("#fonte").val(),
                    PlacaRede: $("#placaRede").val(),
                    DriverOtico: $("#driverOtico").val()
                }
            },
            function (response) { RetiraDestaqueMesa(); },
            function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
        );
    }
);

$("#SalvaEdicaoMaquina").click(function () {
    SendsServer(
        "/Maquina/SalvaEdicaoMaquina",
        {
            model: {
                ModeloMaquina: {
                    Name: $("#EditaModelo").val()
                },
                TipoMaquina: $("#MaquinadoTipo").val(),
                Processador: $("#Editaprocessador").val(),
                PlacaMae: $("#EditaplacaMae").val(),
                UnidadesMemoriaRam: $("#EditaunidadesMemoriaRam").val(),
                PenteMemoriaRamGB: $("#EditapenteMemoriaRamGB").val(),
                Ssd: $("#Editassd").val(),
                Hd: $("#Editahd").val(),
                Fonte: $("#Editafonte").val(),
                PlacaRede: $("#EditaplacaRede").val(),
                DriverOtico: $("#EditadriverOtico").val(),
                ModeloMaquina_Id: $("#dropdown-EditarMaquina").val()
            }
        },
        function (response) { GoBack(); },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
        );
});

$("#DeletaMaquina").click(function () {
    SendsServer(
    "/Maquina/DeletaMaquina",
    {
        model: {
            ModeloMaquina: {
                Name: $("#EditaModelo").val()
            },
            TipoMaquina: $("#MaquinadoTipo").val(),
            Processador: $("#Editaprocessador").val(),
            PlacaMae: $("#EditaplacaMae").val(),
            UnidadesMemoriaRam: $("#EditaunidadesMemoriaRam").val(),
            PenteMemoriaRamGB: $("#EditapenteMemoriaRamGB").val(),
            Ssd: $("#Editassd").val(),
            Hd: $("#Editahd").val(),
            Fonte: $("#Editafonte").val(),
            PlacaRede: $("#EditaplacaRede").val(),
            DriverOtico: $("#EditadriverOtico").val(),
            ModeloMaquina_Id: $("#dropdown-EditarMaquina").val()
        }
    },
    function (response) { GoBack(); },
    function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
    );
});