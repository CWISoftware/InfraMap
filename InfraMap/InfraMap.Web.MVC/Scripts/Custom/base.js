function CarregarUsuario()
{
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
};

var usuarioAutoComplete = {
    url: "/Base/UsuarioAutoComplete",
    getValue: "label",
    list: {
        match: {
            enabled: true
        },

        onClickEvent: function () {
            CarregarUsuario();
        },

        onKeyEnterEvent: function () {
            CarregarUsuario();
        }
    }
};
$("#carregar-usuario").easyAutocomplete(usuarioAutoComplete);