$("#btn-selecionarColaboradores").click(function () {
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