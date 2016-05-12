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
                    Name: $("#InsereModelo").val().toUpperCase()
                },
                TipoMaquina: '0', //0-Padrão 1-Pessoal
                Processador: $("#Insereprocessador").val().toUpperCase(),
                UnidadesMemoriaRam: $("#InsereunidadesMemoriaRam").val(),
                PenteMemoriaRamGB: $("#InserepenteMemoriaRamGB").val(),
                Ssd: $("#Inseressd").val(),
                Hd: $("#Inserehd").val()
            }
        },
        function (response) {
            $("#modalGeralLabel").append("Edição de modelo");
            $('#modalGeral').modal('show');
            if (response.success == true) {
                $("#modalGeral .modal-body").empty();
                $("#selectcolor").empty();
                $("#modalGeral .modal-body").append("<h2>Configuração salva com sucesso!</h2>");
                $("#SalvarCorGerente").addClass("hide");
                $("#fecharRetiraDestaqueMesa").addClass("hide");
                $("#fecharGoBack").removeClass("hide");
            }
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
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
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
    );
}

$("#dropdown-EditarMaquina").change(
    function () {
        var idModeloEscolhido = $(this).val();
        if (idModeloEscolhido == 0) {
            $("#EditaModelo").prop("disabled", true).val();
            $("#Editaprocessador").prop("disabled", true).val();
            $("#EditaunidadesMemoriaRam").prop("disabled", true).val();
            $("#EditapenteMemoriaRamGB").prop("disabled", true).val();
            $("#Editassd").prop("disabled", true).val();
            $("#Editahd").prop("disabled", true).val();
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
                $("#EditaunidadesMemoriaRam").prop("disabled", false).val(data.UnidadesMemoriaRam);
                $("#EditapenteMemoriaRamGB").prop("disabled", false).val(data.PenteMemoriaRamGB);
                $("#Editassd").prop("disabled", false).val(data.SSD);
                $("#Editahd").prop("disabled", false).val(data.HD);
            },
            function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
        );
    }
);

$("#adicionaMaquina").click(
    function () {
        SendsServer(
            "/Maquina/AdicionarMaquina",
            {
                EtiquetaServico: $("#etiquetaServico").val().toUpperCase(),
                Patrimonio: $("#patrimonio").val().toUpperCase(),
                IdMesa: $("#idMesa").val(),
                Maquina: {
                    IdModeloMaquina: $("#dropdown-modeloMaquina").val(),
                    Processador: $("#processador").val().toUpperCase(),
                    UnidadesMemoriaRam: $("#unidadesMemoriaRam").val(),
                    PenteMemoriaRamGB: $("#penteMemoriaRamGB").val(),
                    Ssd: $("#ssd").val(),
                    Hd: $("#hd").val()
                }
            },
            function (response) {

            },
            function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
        );
    }
);

$("#SalvaEdicaoMaquina").click(function () {
    SendsServer(
        "/Maquina/SalvaEdicaoMaquina",
        {
            model: {
                ModeloMaquina: {
                    Name: $("#EditaModelo").val().toUpperCase()
                },
                TipoMaquina: '0', //0-Padrão 1-Pessoal
                Processador: $("#Editaprocessador").val().toUpperCase(),
                UnidadesMemoriaRam: $("#EditaunidadesMemoriaRam").val(),
                PenteMemoriaRamGB: $("#EditapenteMemoriaRamGB").val(),
                Ssd: $("#Editassd").val(),
                Hd: $("#Editahd").val(),
                ModeloMaquina_Id: $("#dropdown-EditarMaquina").val()
            }
        },
        function (response) {
            $("#modalGeralLabel").append("Edição de modelo");
            $('#modalGeral').modal('show');
            if (response.success == true)
            {
                $("#modalGeral .modal-body").empty();
                $("#selectcolor").empty();
                $("#modalGeral .modal-body").append("<h2>Configuração salva com sucesso!</h2>");
                $("#SalvarCorGerente").addClass("hide");
                $("#fecharRetiraDestaqueMesa").addClass("hide");
                $("#fecharGoBack").removeClass("hide");
            }
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
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
            TipoMaquina: '0', //0-Padrão 1-Pessoal
            Processador: $("#Editaprocessador").val(),
            UnidadesMemoriaRam: $("#EditaunidadesMemoriaRam").val(),
            PenteMemoriaRamGB: $("#EditapenteMemoriaRamGB").val(),
            Ssd: $("#Editassd").val(),
            Hd: $("#Editahd").val(),
            ModeloMaquina_Id: $("#dropdown-EditarMaquina").val()
        }
    },
    function (response) {
        $("#modalGeralLabel").append("Excluir modelo");
        $('#modalGeral').modal('show');
        if (response.success == true) {
            $("#modalGeral .modal-body").empty();
            $("#selectcolor").empty();
            $("#modalGeral .modal-body").append("<h2>Configuração apagada com sucesso!</h2>");
            $("#SalvarCorGerente").addClass("hide");
            $("#fecharRetiraDestaqueMesa").addClass("hide");
            $("#fecharGoBack").removeClass("hide");
        }
    },
    function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
    );
});
