$("#adicionaUsuario").click(function () {
    var idMesa = 1;
    var login = $("#login").val();
    $.ajax({
        type: "POST",
        url: "/SaoLeopoldo/MesaAdicionarColaborador",
        data: { id: idMesa, colaborador: login},
        datatype: "json",
        success: function (data) {}
    });
});

$("#adicionaMaquina").click(function () {
    var idMesa = 1;
    var idMaquina = $("#maquina").val();
    $.ajax({
        type: "POST",
        url: "/SaoLeopoldo/MesaAdicionarColaborador",
        data: { id: idMesa, maquina: idMaquina },
        datatype: "json",
        success: function (data) { }
    });
});

$("#adicionaRamal").click(function () {
    var idMesa = 1;
    var idRamal = $("#ramal").val();
    $.ajax({
        type: "POST",
        url: "/SaoLeopoldo/MesaAdicionarColaborador",
        data: { id: idMesa, ramal: idRamal },
        datatype: "json",
        success: function (data) { }
    });
});