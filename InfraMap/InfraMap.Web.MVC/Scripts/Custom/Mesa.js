var podeExecutar = true;
function mesaClick(id) {
    if (podeExecutar) {
        podeExecutar = false;
        RenderPartial(id);
    }
};

function RenderPartial(id) {
    var dadosMaquina;

    SendsServer(
        "/Mapa/RenderPartialViewSpotMesa",
        { id: id },
        function (data) {
            podeExecutar = true;
            $("#partial").html(data);
            $('#InfraModal').modal('show');
            $('#GerenteModal').modal('show');

            /* easyAutocomplete com Ajax POST
             * http://easyautocomplete.com/examples#examples-ddg
             */
            var options = {
                url: function (term) {
                    return "/Base/AdicionarUsuarioAutoComplete";
                },

                getValue: function (response) {
                    return response.nome;
                },

                ajaxSettings: {
                    dataType: "json",
                    method: "POST",
                    data: {
                        dataType: "json"
                    }
                },

                preparePostData: function (data) {
                    data.term = $("#login").val();
                    return data;
                },

                requestDelay: 400
            };
            $("#login").easyAutocomplete(options);

            $("#adicionaUsuario").click(
                function () {
                    SendsServer(
                        "/Colaborador/AdicionarColaborador",
                        { id: $("#idMesa").val(), colaborador: $("#login").val() },
                        function (response) {
                            if (response.trocar) {
                                $('#modalTrocarUsuario').modal('show');
                                $('#mensagemTrocarUsuario').empty().append(response.mensagemException + " Deseja mudá-lo de lugar?");

                                if (response.temRamal || response.temMaquina) {
                                    $('#caixaEscolhas').removeClass('hide');

                                    if (response.temRamal) $('#temRamal').removeClass('hide');
                                    if (response.temMaquina) $('#temMaquina').removeClass('hide');
                                }
                            }
                            else {
                                RetiraDestaqueMesa();
                            }
                        },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#trocarUsuario").click(
                function () {
                    SendsServer(
                        "/Colaborador/TrocarMesaColaborador",
                        { id: $("#idMesa").val(), colaborador: $("#login").val(), comMaquina: $('#chkMaquina').is(":checked"), comRamal: $('#chkRamal').is(":checked") },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#removeColaborador").click(
                function () {
                    SendsServer(
                        "/Colaborador/RemoverColaborador",
                        { id: $("#idMesa").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#btnAdicionarMaquina").click(
                function () {
                    ReceivesServer(
                        "/Maquina/NomesModelosPadrao",
                        { },
                        function (data) {
                            var options = "<option value='0'>Selecione um modelo</option>";
                            data.forEach(
                                function (modelo) {
                                    options += '<option value="' + modelo.Id + '">' + modelo.Name + '</option>';
                                }
                            )
                            $("#dropdown-modeloMaquina").empty().append(options);
                        },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#resetaFormMaquina").click(function () {
                $('.modal-body .form-group').find('input').val('');
                $("#btnAdicionarMaquina").click();
                $("#etiquetaServico").prop("disabled", false);
            });

            $("#btnPesquisaPatrimonio").click(function () {
                var numeroPatrimonio = $("#patrimonio").val();
                if (numeroPatrimonio && numeroPatrimonio.length == 6) {
                    ReceivesServer(
                        "/Maquina/PesquisaPorPatrimonio",
                        { patrimonio: numeroPatrimonio },
                        function (response) {
                            if (!response.Message) {
                                $("#etiquetaServico").val(response.EtiquetaServico).prop("disabled", true);

                                $("#dropdown-modeloMaquina").empty().html("<option value=" + response.Maquina.ModeloMaquina.Id + ">"+ response.Maquina.ModeloMaquina.Name +"</option>");

                                var maquina = response.Maquina;
                                $("#processador").prop("disabled", false).val(maquina.Processador);
                                $("#memoriaRamGB1").prop("disabled", false).val(maquina.MemoriaRamGB1);
                                $("#memoriaRamGB2").prop("disabled", false).val(maquina.MemoriaRamGB2);
                                $("#memoriaRamGB3").prop("disabled", false).val(maquina.MemoriaRamGB3);
                                $("#memoriaRamGB4").prop("disabled", false).val(maquina.MemoriaRamGB4);
                                $("#ssd").prop("disabled", false).val(maquina.SSD);
                                $("#hd").prop("disabled", false).val(maquina.HD);
                            } else {
                                //colocar mensagem dizendo que patrimonio ja esta em outra mesa
                                $("#patrimonio").parent().parent().append("<p>" + response.Message + "</p>");
                                setTimeout(function () {
                                    $('#patrimonio').parent().parent().find('p').empty();
                                }, 5000);
                            }
                        },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            });

            $("#dropdown-modeloMaquina").change(
                function () {
                    var idModeloEscolhido = $(this).val();
                    if (idModeloEscolhido == 0) {
                        $('.modal-body :input').not('[id="dropdown-modeloMaquina"],[id="patrimonio"]').prop('disabled', true).prop('value','');
                        return;
                    }
                    ReceivesServer(
                        "/Maquina/MaquinaDoModelo",
                        { idModelo: idModeloEscolhido },
                        function (data) {
                            $('#etiquetaServico').prop("disabled", false);
                            $("#processador").prop("disabled", false).val(data.Processador);
                            $("#memoriaRamGB1").prop("disabled", false).val(data.MemoriaRamGB1);
                            $("#memoriaRamGB2").prop("disabled", false).val(data.MemoriaRamGB2);
                            $("#memoriaRamGB3").prop("disabled", false).val(data.MemoriaRamGB3);
                            $("#memoriaRamGB4").prop("disabled", false).val(data.MemoriaRamGB4);
                            $("#ssd").prop("disabled", false).val(data.SSD);
                            $("#hd").prop("disabled", false).val(data.HD);
                        },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#adicionaMaquina").click(
                function () {
                    SendsServer(
                        "/Maquina/AdicionarMaquina",
                        {
                            EtiquetaServico: $("#etiquetaServico").val().toUpperCase(),
                            Patrimonio: $("#patrimonio").val().toUpperCase(),
                            IdMesa: $("#idMesa").val(),
                            Maquina: {
                                IdModeloMaquina: $("#dropdown-modeloMaquina").val(),
                                Processador: $("#processador").val().toUpperCase(),
                                MemoriaRamGB1: $("#memoriaRamGB1").val(),
                                MemoriaRamGB2: $("#memoriaRamGB2").val(),
                                MemoriaRamGB3: $("#memoriaRamGB3").val(),
                                MemoriaRamGB4: $("#memoriaRamGB4").val(),
                                Ssd: $("#ssd").val(),
                                Hd: $("#hd").val()
                            }
                        },
                        function (response) {
                            if (response.message == "true") {
                                RetiraDestaqueMesa();
                            }
                        },
                        function (jqXHR, textStatus, errorThrown) { console.log(JSON.parse(jqXHR.responseText)); DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#removeMaquina").click(
                function () {
                    SendsServer(
                        "/Maquina/RemoverMaquina",
                        { id: $("#idMesa").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#adicionaRamal").click(
                function () {
                    SendsServer(
                        "/Ramal/AdicionarRamal",
                        { id: $("#idMesa").val(), ramal: $("#numero").val(), tipo: $("#tipoRamal").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#removeRamal").click(
                function () {
                    SendsServer(
                        "/Ramal/RemoverRamal",
                        { id: $("#idMesa").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#veMaquina").click(
                function () {
                    ReceivesServer(
                        "/Maquina/VerMaquina",
                        { idMesa: $("#idMesa").val() },
                        function (data) {
                            $("#veretiquetaServico").val(data.EtiquetaServico);
                            $("#verpatrimonio").val(data.Patrimonio);
                            $("#verModelo").val(data.Maquina.ModeloMaquina.Name);
                            $("#verprocessador").val(data.Maquina.Processador);
                            $("#verMemoriaRamGB1").val(data.Maquina.MemoriaRamGB1);
                            $("#verMemoriaRamGB2").val(data.Maquina.MemoriaRamGB2);
                            $("#verMemoriaRamGB3").val(data.Maquina.MemoriaRamGB3);
                            $("#verMemoriaRamGB4").val(data.Maquina.MemoriaRamGB4);
                            $("#verssd").val(data.Maquina.SSD);
                            $("#verhd").val(data.Maquina.HD);
                            $("#idMaquina").val(data.Maquina.ModeloMaquina_Id);
                            $("#IdPessoal").val(data.Maquina.Id);
                            dadosMaquina = data;
                        },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );

            $("#EditarMaquinaPessoal").click(
                function () {
                    $("#SalvaConfigMaquina").addClass("show");
                    $("#CancelaConfigMaquina").addClass("show");
                    $("#EditarMaquinaPessoal").hide();
                    $("#FechaModal").hide();
                    $("#verMemoriaRamGB1").prop("disabled", false).val();
                    $("#verMemoriaRamGB2").prop("disabled", false).val();
                    $("#verMemoriaRamGB3").prop("disabled", false).val();
                    $("#verMemoriaRamGB4").prop("disabled", false).val();
                    $("#verprocessador").prop("disabled", false).val();
                    $("#verssd").prop("disabled", false).val();
                    $("#verhd").prop("disabled", false).val();
                }
            );

            $("#CancelaConfigMaquina").click(
                function () {
                    $("#SalvaConfigMaquina").removeClass("show");
                    $("#CancelaConfigMaquina").removeClass("show");
                    $("#EditarMaquinaPessoal").show();
                    $("#FechaModal").show();
                    $("#verprocessador").prop("disabled", true).val();
                    $("#verMemoriaRamGB1").prop("disabled", true).val();
                    $("#verMemoriaRamGB2").prop("disabled", true).val();
                    $("#verMemoriaRamGB3").prop("disabled", true).val();
                    $("#verMemoriaRamGB4").prop("disabled", true).val();
                    $("#verssd").prop("disabled", true).val();
                    $("#verhd").prop("disabled", true).val();

                    $("#veretiquetaServico").val(dadosMaquina.EtiquetaServico);
                    $("#verpatrimonio").val(dadosMaquina.Patrimonio);
                    $("#verModelo").val(dadosMaquina.Maquina.ModeloMaquina.Name);
                    $("#verprocessador").val(dadosMaquina.Maquina.Processador);
                    $("#verMemoriaRamGB1").val(dadosMaquina.Maquina.MemoriaRamGB1);
                    $("#verMemoriaRamGB2").val(dadosMaquina.Maquina.MemoriaRamGB2);
                    $("#verMemoriaRamGB3").val(dadosMaquina.Maquina.MemoriaRamGB3);
                    $("#verMemoriaRamGB4").val(dadosMaquina.Maquina.MemoriaRamGB4);
                    $("#verssd").val(dadosMaquina.Maquina.SSD);
                    $("#verhd").val(dadosMaquina.Maquina.HD);
                    $("#idMaquina").val(dadosMaquina.Maquina.ModeloMaquina_Id);
                    $("#IdPessoal").val(dadosMaquina.Maquina.Id);
                }
            );

            $("#SalvaConfigMaquina").click(
                function () {
                    var data = {
                        model: {
                            ModeloMaquina_Id: $("#idMaquina").val(),
                            Id: $("#IdPessoal").val(),

                            ModeloMaquina: {
                                Name: $("#verModelo").val().toUpperCase(),
                                Id: $("#IdPessoal").val()
                            },
                            TipoMaquina: '1', //0-Padrão 1-Pessoal
                            Processador: $("#verprocessador").val().toUpperCase(),
                            MemoriaRamGB1: $("#verMemoriaRamGB1").val(),
                            MemoriaRamGB2: $("#verMemoriaRamGB2").val(),
                            MemoriaRamGB3: $("#verMemoriaRamGB3").val(),
                            MemoriaRamGB4: $("#verMemoriaRamGB4").val(),
                            Ssd: $("#verssd").val(),
                            Hd: $("#verhd").val()
                        }
                    };

                    var model = data.model;

                    function displayMessage(message) {
                        $("#verMaquina .modal-body").prepend("<p>" + message + "</p>");
                        setTimeout(function () {
                            $("#verMaquina .modal-body").find('p').empty();
                        }, 5000);
                    }

                    if (model.Ssd === 0 && model.Hd === 0) {
                        displayMessage("É necessário preencher o ssd ou o hd");
                        return;
                    }

                    if (!model.Processador) {
                        displayMessage("É necessário preencher uma descrição para o processador");
                        return;
                    }

                    SendsServer(
                            "/Maquina/SalvaEdicaoMaquinaPessoal",
                            data,
                            function (response) { RetiraDestaqueMesa(); },
                            function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                        );
                }
            );
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
     );
}