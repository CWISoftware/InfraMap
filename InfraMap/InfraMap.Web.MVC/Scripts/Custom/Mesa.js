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
                        { id: $("#idMesa").val(), colaborador: $("#login").val() },
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

            $("#dropdown-modeloMaquina").change(
                function () {
                    var idModeloEscolhido = $(this).val();
                    if (idModeloEscolhido == 0) {
                        $("#processador").prop("disabled", true).val(data.Processador);
                        $("#placaMae").prop("disabled", true).val(data.PlacaMae);
                        $("#unidadesMemoriaRam").prop("disabled", true).val(data.UnidadesMemoriaRam);
                        $("#penteMemoriaRamGB").prop("disabled", true).val(data.PenteMemoriaRamGB);
                        $("#ssd").prop("disabled", true).val(data.SSD);
                        $("#hd").prop("disabled", true).val(data.HD);
                        $("#fonte").prop("disabled", true).val(data.Fonte);
                        $("#placaRede").prop("disabled", true).val(data.PlacaRede);
                        $("#driverOtico").prop("disabled", true).val(data.DriverOtico);
                        return;
                    }
                    ReceivesServer(
                        "/Maquina/MaquinaDoModelo",
                        { idModelo: idModeloEscolhido },
                        function (data) {
                            $("#processador").prop("disabled", false).val(data.Processador);
                            $("#placaMae").prop("disabled", false).val(data.PlacaMae);
                            $("#unidadesMemoriaRam").prop("disabled", false).val(data.UnidadesMemoriaRam);
                            $("#penteMemoriaRamGB").prop("disabled", false).val(data.PenteMemoriaRamGB);
                            $("#ssd").prop("disabled", false).val(data.SSD);
                            $("#hd").prop("disabled", false).val(data.HD);
                            $("#fonte").prop("disabled", false).val(data.Fonte);
                            $("#placaRede").prop("disabled", false).val(data.PlacaRede);
                            $("#driverOtico").prop("disabled", false).val(data.DriverOtico);
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
                                PlacaMae: $("#placaMae").val().toUpperCase(),
                                UnidadesMemoriaRam: $("#unidadesMemoriaRam").val(),
                                PenteMemoriaRamGB: $("#penteMemoriaRamGB").val(),
                                Ssd: $("#ssd").val(),
                                Hd: $("#hd").val(),
                                Fonte: $("#fonte").val().toUpperCase(),
                                PlacaRede: $("#placaRede").val().toUpperCase(),
                                DriverOtico: $("#driverOtico").val().toUpperCase()
                            }
                        },
                        function (response) {
                            if (response.message == "true") {
                                RetiraDestaqueMesa();
                            }
                            else {
                                document.getElementById("TextException").innerHTML = response.message;
                                $('#modalTrocarMaquina').modal('show');
                            }
                        },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
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
                            $("#verplacaMae").val(data.Maquina.PlacaMae);
                            $("#verunidadesMemoriaRam").val(data.Maquina.UnidadesMemoriaRam);
                            $("#verpenteMemoriaRamGB").val(data.Maquina.PenteMemoriaRamGB);
                            $("#verssd").val(data.Maquina.SSD);
                            $("#verhd").val(data.Maquina.HD);
                            $("#verfonte").val(data.Maquina.Fonte);
                            $("#verplacaRede").val(data.Maquina.PlacaRede);
                            $("#verdriverOtico").val(data.Maquina.DriverOtico);
                            $("#idMaquina").val(data.Maquina.ModeloMaquina_Id);
                            $("#MaquinaTipo").val(data.Maquina.TipoMaquina);
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
                    $("#verprocessador").prop("disabled", false).val();
                    $("#verplacaMae").prop("disabled", false).val();
                    $("#verunidadesMemoriaRam").prop("disabled", false).val();
                    $("#verpenteMemoriaRamGB").prop("disabled", false).val();
                    $("#verssd").prop("disabled", false).val();
                    $("#verhd").prop("disabled", false).val();
                    $("#verfonte").prop("disabled", false).val();
                    $("#verplacaRede").prop("disabled", false).val();
                    $("#verdriverOtico").prop("disabled", false).val();
                }
            );

            $("#CancelaConfigMaquina").click(
                function () {
                    $("#SalvaConfigMaquina").removeClass("show");
                    $("#CancelaConfigMaquina").removeClass("show");
                    $("#EditarMaquinaPessoal").show();
                    $("#FechaModal").show();
                    $("#verprocessador").prop("disabled", true).val();
                    $("#verplacaMae").prop("disabled", true).val();
                    $("#verunidadesMemoriaRam").prop("disabled", true).val();
                    $("#verpenteMemoriaRamGB").prop("disabled", true).val();
                    $("#verssd").prop("disabled", true).val();
                    $("#verhd").prop("disabled", true).val();
                    $("#verfonte").prop("disabled", true).val();
                    $("#verplacaRede").prop("disabled", true).val();
                    $("#verdriverOtico").prop("disabled", true).val();

                    $("#veretiquetaServico").val(dadosMaquina.EtiquetaServico);
                    $("#verpatrimonio").val(dadosMaquina.Patrimonio);
                    $("#verModelo").val(dadosMaquina.Maquina.ModeloMaquina.Name);
                    $("#verprocessador").val(dadosMaquina.Maquina.Processador);
                    $("#verplacaMae").val(dadosMaquina.Maquina.PlacaMae);
                    $("#verunidadesMemoriaRam").val(dadosMaquina.Maquina.UnidadesMemoriaRam);
                    $("#verpenteMemoriaRamGB").val(dadosMaquina.Maquina.PenteMemoriaRamGB);
                    $("#verssd").val(dadosMaquina.Maquina.SSD);
                    $("#verhd").val(dadosMaquina.Maquina.HD);
                    $("#verfonte").val(dadosMaquina.Maquina.Fonte);
                    $("#verplacaRede").val(dadosMaquina.Maquina.PlacaRede);
                    $("#verdriverOtico").val(dadosMaquina.Maquina.DriverOtico);
                    $("#idMaquina").val(dadosMaquina.Maquina.ModeloMaquina_Id);
                    $("#MaquinaTipo").val(dadosMaquina.Maquina.TipoMaquina);
                    $("#IdPessoal").val(dadosMaquina.Maquina.Id);
                }
            );

            $("#SalvaConfigMaquina").click(
                function () {
                    SendsServer(
                    "/Maquina/SalvaEdicaoMaquinaPessoal",
                    {
                       model: {
                           ModeloMaquina_Id: $("#idMaquina").val(),
                           Id: $("#IdPessoal").val(),

                           ModeloMaquina: {
                               Name: $("#verModelo").val().toUpperCase(),
                               Id: $("#IdPessoal").val()
                            },
                            TipoMaquina: $("#MaquinaTipo").val(),
                            Processador: $("#verprocessador").val().toUpperCase(),
                            PlacaMae: $("#verplacaMae").val().toUpperCase(),
                            UnidadesMemoriaRam: $("#verunidadesMemoriaRam").val(),
                            PenteMemoriaRamGB: $("#verpenteMemoriaRamGB").val(),
                            Ssd: $("#verssd").val(),
                            Hd: $("#verhd").val(),
                            Fonte: $("#verfonte").val().toUpperCase(),
                            PlacaRede: $("#verplacaRede").val().toUpperCase(),
                            DriverOtico: $("#verdriverOtico").val().toUpperCase()
                        }
                    },
                    function (response) { RetiraDestaqueMesa(); },
                    function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
                    );
                }
            );
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
     );
}