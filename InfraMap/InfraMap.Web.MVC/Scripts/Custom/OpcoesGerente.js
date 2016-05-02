$("#btn-selecionarColaboradores").click(function () {
    $("#btn-mudarCor").addClass("hide");
    $(".fileira").addClass("selectable");
    $("#btn-selecionarColaboradores").addClass("hide");
    $("#btn-salvarColaboradores").removeClass("hide");
    $("#btn-cancelar").removeClass("hide");
    $(".mesa").attr("onclick", null);
    $(".mesa").addClass("ui-widget-content");
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
            $("#btn-salvarColaboradores").addClass("hide");
            $("#btn-cancelar").addClass("hide");
            RetiraDestaqueMesa();
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
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
            $("#modalGeral .modal-body").append("<h2> Sua cor é: </h2>" + "<h2 style=color:" + response.message + ">" + response.message + "</h2>");
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
    );
    $('#modalGeral').modal('show');
});


$("#SalvarCorGerente").click(function () {
    var index = document.getElementById("choosecolor").value;
    var text = document.getElementById("choosecolor").options[index].text;
    SendsServer(
        "/Mapa/SalvaCorGerente",
        { color: text },
        function (mensagem) {
            if (mensagem.response != "")
            {
                $("#modalGeral .modal-body").empty();
                $("#selectcolor").empty();
                $("#modalGeral .modal-body").append("<h2>" + mensagem.response + "</h2>");
                $("#SalvarCorGerente").addClass("hide");
            }
            else
            {
                $("#modalGeral .modal-body").empty();
                $("#selectcolor").empty();
                $("#modalGeral .modal-body").append("<h2>Cor trocada com sucesso! </h2>");
                $("#SalvarCorGerente").addClass("hide");
            }
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
    );
});

$("#CancelaModal").click(function () {
    RetiraDestaqueMesa();
});


