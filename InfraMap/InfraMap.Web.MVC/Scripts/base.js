$("#btn-procurar").click(function () {
    var usuario = $("#carregar-usuario").val();
    $.ajax({
        type: "POST",
        url: '/Base/CarregarMapaDoUsuario',
        data: { nome: usuario },
        dataType: "json",
        success: function (data) { }
    });
});