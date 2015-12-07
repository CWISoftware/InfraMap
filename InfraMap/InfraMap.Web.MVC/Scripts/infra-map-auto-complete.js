    var usuarioAutoComplete = {
        url: "/Base/UsuarioAutoComplete",
        getValue: "label",
        list: {
            match: {
                enabled: true
            }
        }
    };
    $("#carregar-usuario").easyAutocomplete(usuarioAutoComplete);