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
                success: function (data) { }
            }).done(function (sedeEDescricao) {
                window.location.href = "/Mapa/" + sedeEDescricao[0] + "/" + sedeEDescricao[1];
            });
        }
    });
});