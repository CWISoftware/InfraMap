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
        $("#login").easyAutocomplete(usuarioLoginAutoComplete);
        $("#adicionaUsuario").click(function () {
            var idMesa = $("#idMesa").val();
            var login = $("#login").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/AdicionarColaborador",
                data: { id: idMesa, colaborador: login },
                datatype: "json",
                success: function(data) {
                    reload();
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#removerColaborador").click(function () {
            var idMesa = $("#idMesa").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/RemoverColaborador",
                data: { id: idMesa },
                datatype: "json",
                success: function (data) {
                    reload();
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
                    reload();
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#removerMaquina").click(function () {
            var idMesa = $("#idMesa").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/RemoverMaquina",
                data: { id: idMesa },
                datatype: "json",
                success: function (data) {
                    reload();
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
                    reload();
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#removerRamal").click(function () {
            var idMesa = $("#idMesa").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/RemoverRamal",
                data: { id: idMesa },
                datatype: "json",
                success: function (data) {
                    reload();
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });       
    });
}

function reload() {
    location.reload();
}

function DisplayError(xhr) {
    var msg = JSON.parse(xhr.responseText);
    $("#error .modal-body").append("<h2>" + msg.Message + "</h2>");
    $('#error').modal('show');
}

var usuarioLoginAutoComplete = {
    url: "/Base/UsuarioLoginAutoComplete",
    getValue: "label",
    list: {
        match: {
            enabled: true
        }
    }
};

$("#btn-selecionarColaboradores").click(function () {
    $(".fileira").addClass("selectable");
    $("#btn-selecionarColaboradores").addClass("hide");
    $("#btn-salvarColaboradores").addClass("show");
    window.listaDeIdECor = [];
});

$("#btn-salvarColaboradores").click(function () {
    $.ajax({
        type: "POST",
        url: "/Mapa/SalvarCoresDosColaboradores",
        data: { lista: listaDeIdECor },
        datatype: "json",
        success: function (data) {
            reload();
        }
    });
});

$(function () {
    $(".selectable").selectable({
        selected: function (event, ui) {
            var idMesa = $(ui.selected).children().attr("id");
            var temClasseColaborador = $(ui.selected).hasClass("colaborador");
            if (!temClasseColaborador) {
                $(ui.selected).css("background", "white");
            }
            var corMesa = $(ui.selected).css("background");
            var idECor = { id: idMesa, cor: corMesa }

            listaDeIdECor.push(idECor);
        }
    });
});