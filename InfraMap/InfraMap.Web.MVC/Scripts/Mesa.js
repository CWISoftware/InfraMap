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