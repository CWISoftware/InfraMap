﻿var podeExecutar = true;
function mesaClick(id) {
    if (podeExecutar) {
        podeExecutar = false;
        RenderPartial(id);
    }   
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
        podeExecutar = true;
        $("#partial").html(data);
        $('#myModal').modal('show');
        $('#modalUsuario').modal('show');
        $("#login").easyAutocomplete(usuarioLoginAutoComplete);
        $("#adicionaUsuario").click(function () {
            var idMesa = $("#idMesa").val();
            var login = $("#login").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/AdicionarColaborador",
                data: { id: idMesa, colaborador: login },
                datatype: "json",
                success: function (data) {
                    if (data.trocar){
                        $('#modalTrocarUsuario').modal('show');
                    }
                    else {
                        reload();
                    }       
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#trocarUsuario").click(function () {
            var idMesa = $("#idMesa").val();
            var login = $("#login").val();
            $.ajax({
                type: "POST",
                url: "/Mapa/TrocarMesaColaborador",
                data: { id: idMesa, colaborador: login },
                datatype: "json",
                success: function (data) {
                    reload();
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#removeColaborador").click(function () {
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

        $("#removeMaquina").click(function () {
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

        $("#removeRamal").click(function () {
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

// feature de gerente escolher colaboradores não 100% funcional
$("#btn-selecionarColaboradores").click(function () {
    $(".fileira").addClass("selectable");
    $("#btn-selecionarColaboradores").addClass("hide");
    $("#btn-salvarColaboradores").addClass("show");
    $(".mesa").attr("onclick", null);
    $(".mesa").addClass("ui-widget-content");
    startSelectable();
});

$("#btn-salvarColaboradores").click(function () {
    var listId = [];
    $(".mesa.ui-selected").find('.numeroMesa').each(function () {
        listId.push($(this).attr("id"));
    });
    $.ajax({
        type: "POST",
        url: "/Mapa/SalvarCorDosColaboradores",
        data: { listaIdMesa: listId },
        datatype: "json",
        success: function (data) {
            reload();
        }
    });
});

function startSelectable() {
    $(".selectable").selectable({
        selected: function (event, ui) {
            var temclassecolaborador = $(ui.selected).find("span").hasClass("usuario");
            if (!temclassecolaborador) {
                $(ui.selected).removeClass("ui-selected");
                return;
            }
        }
    });
};