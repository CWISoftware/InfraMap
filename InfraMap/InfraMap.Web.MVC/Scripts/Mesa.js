function mesaClick(id) {
    RenderPartial(id);
};

function RenderPartial(id) {
    $.ajax({
        type: "POST",
        url: "/Mapa/RenderPartialViewSpotMesa",
        data: { id: id },
        datatype: "json",
        error: function (xhr, status, error) {
            DisplayError(xhr);
        }
    }).success(function (data) {
        $("#partial").html(data);
        $('#myModal').modal('show');
        $("#adicionaUsuario").click(function () {
            var idMesa = $("#idMesa").val();
            var login = $("#login").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/AdicionarColaborador",
                data: { id: idMesa, colaborador: login },
                datatype: "json",
                success: function(data) {
                    DisplaySuccess("Adicionado com sucesso!");
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#adicionaMaquina").click(function () {
            var idMesa = $("#idMesa").val();
            var maquina = $("#nomeMaquina").val();
            var tipo = $("#tipoMaquina").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/AdicionarMaquina",
                data: { id: idMesa, maquina: maquina, tipo: tipo },
                datatype: "json",
                success: function(data) {
                    DisplaySuccess("Adicionado com sucesso!");
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#adicionaRamal").click(function () {
            var idMesa = $("#idMesa").val();
            var numero = $("#numero").val();
            var tipoRamal = $("#tipoRamal").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/AdicionarRamal",
                data: { id: idMesa, ramal: numero, tipo: tipoRamal },
                datatype: "json",
                success: function(data) {
                    DisplaySuccess("Adicionado com sucesso!");
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });
    });
}

function DisplaySuccess(msg) {
    $("#success .modal-body").append("<h2>" + msg + "</h2>");
    $('#success').modal('show');
}

function DisplayError(xhr) {
    var msg = JSON.parse(xhr.responseText);
    $("#error .modal-body").append("<h2>" + msg.Message + "</h2>");
    $('#error').modal('show');
}