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

            if (response.success == true) {
                LimpaForm();
                MostrarModal("Edição de modelo", "Configuração salva com sucesso!");
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
            if (response.success == true) {
                MostrarModal("Edição de modelo", "Configuração salva com sucesso!");
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
        if (response.success == true) {
            LimpaForm();
            CarregaMaquinas();
            MostrarModal("Excluir modelo", "Configuração apagada com sucesso!");
        }
    },
    function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
    );
});

function validarEntrada(inputId) {
    var valor = $("#" + inputId).val();
    if (Number(valor))
    $("#" + inputId).val(valor);
else
    $("#" + inputId).val(1);
};

function LimpaForm() {
    $("dropdown-EditarMaquina").val(0);
    $("#InsereModelo").val("");
    $("#EditaModelo").val("");
    $("#Insereprocessador").val("");
    $("#Editaprocessador").val("");
    $("#InsereunidadesMemoriaRam").val(1);
    $("#EditaunidadesMemoriaRam").val(1);
    $("#InserepenteMemoriaRamGB").val(1);
    $("#EditapenteMemoriaRamGB").val(1);
    $("#Inseressd").val(1);
    $("#Editassd").val(1);
    $("#Inserehd").val(1);
    $("#Editahd").val(1);
};

function MostrarModal(label, info) {
    $("#selectcolor").empty();
    $("#modalGeral .modal-body").empty().append("<h2>" + info + "</h2>");
    $("#SalvarCorGerente").addClass("hide");
    $("#modalGeralLabel").empty().append(label);
    $('#modalGeral').modal('show');
};
