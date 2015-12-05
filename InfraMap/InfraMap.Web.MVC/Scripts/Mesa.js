$("#adicionaUsuario").click(function () {
    var idMesa = $("#idMesa").val();
    var login = $("#login").val();
    $.ajax({
        type: "POST",
        url: "/SaoLeopoldo/MesaAdicionarColaborador",
        data: { id: idMesa, colaborador: login },
        datatype: "json",
        success: function (data) { },
        error: function (xhr, status, error) {
            DisplayError(xhr);
        }
    });
});

$("#adicionaMaquina").click(function () {
    var idMesa = $("#idMesa").val();
    var idMaquina = $("#maquina").val();
    $.ajax({
        type: "POST",
        url: "/SaoLeopoldo/MesaAdicionarMaquina",
        data: { id: idMesa, maquina: idMaquina },
        datatype: "json",
        success: function (data) { },
        error: function (xhr, status, error) {
            DisplayError(xhr);
        }
    });
});

$("#adicionaRamal").click(function () {
    var idMesa = $("#idMesa").val();
    var idRamal = $("#ramal").val();
    $.ajax({
        type: "POST",
        url: "/SaoLeopoldo/MesaAdicionarRamal",
        data: { id: idMesa, ramal: idRamal },
        datatype: "json",
        success: function (data) { },
        error: function (xhr, status, error) {
            DisplayError(xhr);
        }
    });
});

function DisplayError(xhr) {
    var msg = JSON.parse(xhr.responseText);
    alert(msg.Message);
}