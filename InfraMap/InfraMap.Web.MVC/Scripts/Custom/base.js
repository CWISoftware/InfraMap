$(function () {
    $('#carregar-usuario').keypress(function (e) {
        var key = e.which;
        if (key === 13) {
            var usuario = $("#carregar-usuario").val();
            $.ajax({
                type: "POST",
                url: '/Base/CarregarMapaDoUsuarioPesquisado',
                data: { nome: usuario },
                dataType: "json",
                success: function (data) {
                    window.location.href = "/Mapa/" + data.sede + "/" + data.idAndar;
                },
                error: function (xhr, status, error) {
                    $("#carregar-usuario").val('');
                    $('#erroUsuarioEmNenhumaMesa').modal('show');
                }
            });
        }
    });
});