$(function () {
    $('#carregar-usuario').keypress(function (e) {
        var key = e.which;
        if (key === 13) {
            var usuario = $("#carregar-usuario").val();

            SendsServer(
                "/Base/CarregarMapaDoUsuarioPesquisado",
                { nome: usuario },
                function (response) {
                    window.location.href = "/Mapa/" + response.sede + "/" + response.idAndar + "/" + response.mesa;
                },
                function (jqXHR, textStatus, errorThrown) {
                    $("#carregar-usuario").val('');
                    $('#erroUsuarioEmNenhumaMesa').modal('show');
                }
            );
        }
    });
});