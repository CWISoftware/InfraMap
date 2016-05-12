$("#btn-selecionarColaboradores").click(function () {
    $("#btn-mudarCor").addClass("hide");
    $(".fileira").addClass("selectable");
    $("#btn-selecionarColaboradores").addClass("hide");
    $("#btn-salvarColaboradores").removeClass("hide");
    $("#btn-cancelar").removeClass("hide");
    $(".mesa").attr("onclick", null);
    $(".mesa").addClass("ui-widget-content");
    $("#btn-mudarCor").addClass("hide");
    startSelectable();
});

$("#btn-salvarColaboradores").click(function () {
    var listId = [];
    $(".mesa.ui-selected").find('.nome').each(function () {
        listId.push($(this).attr("id_usuario"));
    });
    SendsServer(
        "/Mapa/SalvarCorDosColaboradores",
        { listaIdColaborador: listId },
        function (response) {
            $("#btn-selecionarColaboradores").removeClass("hide");
            $("#btn-mudarCor").removeClass("hide");
            $("#btn-salvarColaboradores").addClass("hide");
            $("#btn-cancelar").addClass("hide");
            RetiraDestaqueMesa();
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
    );
});

function startSelectable() {
    $(".selectable").selectable({
        selected: function (event, ui) {
            var temclassecolaborador = $(ui.selected).find("span").hasClass("usuario");
            if (!temclassecolaborador) {
                $(ui.selected).removeClass("ui-selected");
                return;
            }
        }
    });
};

$("#btn-cancelar").click(function () {
    $("#btn-selecionarColaboradores").removeClass("hide");
    $("#btn-salvarColaboradores").addClass("hide");
    $("#btn-mudarCor").removeClass("hide");
    $("#btn-cancelar").addClass("hide");
    RetiraDestaqueMesa();
});

$("#btn-mudarCor").click(function () {
    $("#btn-salvarColaboradores").addClass("hide");
    $("#btn-selecionarColaboradores").addClass("hide");
    $("#btn-cancelar").removeClass("hide");
    ReceivesServer(
        "/Mapa/RetornaCorGerente",
        { } ,
        function (response) {
            if (response.message != null) {
                $("#modalGeral .modal-body").append("<h2> Sua cor atual é: </h2><div class=\"box-cor center-block\" style=background-color:" + response.message + "></div><h2>Nova cor:</h2>");

            }
            else {
                $("#modalGeral .modal-body").append("<h2> Ainda não possui uma cor</h2>");
            }
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
    );
    $("#modalGeralLabel").append("Mudar cor");
    $('#modalGeral').modal('show');
});

$("#selectcolor").change(function () {
    $('#choosecolor').css('background-color', document.getElementById("choosecolor").value);
});

$("#SalvarCorGerente").click(function () {
    var cor = document.getElementById("choosecolor").value;
    if (cor.lenght) {
        SendsServer(
            "/Mapa/SalvaCorGerente",
            { color: cor },
            function (mensagem) {
                if (mensagem.response != "") {
                    $("#modalGeral .modal-body").empty();
                    $("#selectcolor").empty();
                    $("#modalGeral .modal-body").append("<h2>" + mensagem.response + "</h2>");
                    $("#SalvarCorGerente").addClass("hide");
                }
                else {
                    $("#modalGeral .modal-body").empty();
                    $("#selectcolor").empty();
                    $("#modalGeral .modal-body").append("<h2>Cor trocada com sucesso! </h2>");
                    $("#SalvarCorGerente").addClass("hide");
                }
            },
            function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
        );
    }
    else {
        DisplayError("Nenhuma cor foi escolhida")
    }
});