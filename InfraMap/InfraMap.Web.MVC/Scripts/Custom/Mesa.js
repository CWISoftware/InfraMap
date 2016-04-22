var podeExecutar = true;
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
        $('#InfraModal').modal('show');
        $('#GerenteModal').modal('show');
        $("#login").easyAutocomplete(usuarioAutoComplete);
        $("#adicionaUsuario").click(function () {
            var idMesa = $("#idMesa").val();
            var login = $("#login").val();
            $.ajax({
                type: "POST",
                url: "/Colaborador/AdicionarColaborador",
                data: { id: idMesa, colaborador: login },
                datatype: "json",
                success: function (data) {
                    if (data.trocar) {
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
                url: "/Colaborador/TrocarMesaColaborador",
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
                url: "/Colaborador/RemoverColaborador",
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

        $("#btnAdicionarMaquina").click(function () {
            $.ajax({
                type: "GET",
                url: "/Maquina/NomesModelosPadrao",
                success: function (data) {
                    var options = "<option value='0'>Selecione um modelo</option>";
                    data.forEach(function (modelo) {
                        options += '<option value="' + modelo.Id + '">' + modelo.Name + '</option>';
                    })
                    $("#dropdown-modeloMaquina").empty().append(options);
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            });
        });

        $("#dropdown-modeloMaquina").change(function () {
            var idModeloEscolhido = $(this).val();
            if (idModeloEscolhido == 0) {
                return;
            }
            $.ajax({
                type: "GET",
                url: "/Maquina/MaquinaDoModelo",
                data: { idModelo: idModeloEscolhido },
                success: function (data) {
                    $("#processador").prop('disabled', false).val(data.Processador);
                    $("#placaMae").prop('disabled', false).val(data.PlacaMae);
                    $("#unidadesMemoriaRam").prop('disabled', false).val(data.UnidadesMemoriaRam);
                    $("#penteMemoriaRamGB").prop('disabled', false).val(data.PenteMemoriaRamGB);
                    $("#ssd").prop('disabled', false).val(data.SSD);
                    $("#hd").prop('disabled', false).val(data.HD);
                    $("#fonte").prop('disabled', false).val(data.Fonte);
                    $("#placaRede").prop('disabled', false).val(data.PlacaRede);
                    $("#driverOtico").prop('disabled', false).val(data.DriverOtico);
                },
                error: function (xhr, status, error) {
                    DisplayError(xhr);
                }
            })
        });

        $("#adicionaMaquina").click(function () {
            var maquinaPessoal = {
                EtiquetaServico: $("#etiquetaServico").val(),
                Patrimonio: $("#patrimonio").val(),
                IdMesa: $("#idMesa").val(),
                Maquina: {
                    IdModeloMaquina: $("#dropdown-modeloMaquina").val(),
                    Processador: $("#processador").val(),
                    PlacaMae: $("#placaMae").val(),
                    UnidadesMemoriaRam: $("#unidadesMemoriaRam").val(),
                    PenteMemoriaRamGB: $("#penteMemoriaRamGB").val(),
                    Ssd: $("#ssd").val(),
                    Hd: $("#hd").val(),
                    Fonte: $("#fonte").val(),
                    PlacaRede: $("#placaRede").val(),
                    DriverOtico: $("#driverOtico").val()
                }
            };
            $.ajax({
                type: "POST",
                url: "/Maquina/AdicionarMaquina",
                data: JSON.stringify(maquinaPessoal),
                contentType: "application/json",
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
                url: "/Maquina/RemoverMaquina",
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
                url: "/Ramal/AdicionarRamal",
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
                url: "/Ramal/RemoverRamal",
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

var reload = function () {
    var myUrl = window.location.href;
    var newUrl = myUrl.substr(0, window.location.href.length - (window.location.href.length - myUrl.lastIndexOf("/")));
    if ((newUrl[window.location.href.length]) != "/")
        newUrl = newUrl + "/";
    window.location.href = newUrl;
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
