var podeExecutar = true;
function mesaClick(id) {
    if (podeExecutar) {
        podeExecutar = false;
        RenderPartial(id);
    }
};

function RenderPartial(id) {
    SendsServer(
        "/Mapa/RenderPartialViewSpotMesa",
        { id: id },
        function (data) {
            podeExecutar = true;
            $("#partial").html(data);
            $('#InfraModal').modal('show');
            $('#GerenteModal').modal('show');
            $("#login").easyAutocomplete(usuarioAutoComplete);
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
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#trocarUsuario").click(
                function () {
                    SendsServer(
                        "/Colaborador/TrocarMesaColaborador",
                        { id: $("#idMesa").val(), colaborador: $("#login").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#removeColaborador").click(
                function () {
                    SendsServer(
                        "/Colaborador/RemoverColaborador",
                        { id: $("#idMesa").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
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
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#dropdown-modeloMaquina").change(
                function () {
                    var idModeloEscolhido = $(this).val();
                    if (idModeloEscolhido == 0) {
                        return;
                    }

                    ReceivesServer(
                        "/Maquina/MaquinaDoModelo",
                        { idModelo: idModeloEscolhido },
                        function (data) {
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
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#adicionaMaquina").click(
                function () {
                    SendsServer(
                        "/Maquina/AdicionarMaquina",
                        {
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
                        },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#removeMaquina").click(
                function () {
                    SendsServer(
                        "/Maquina/RemoverMaquina",
                        { id: $("#idMesa").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#adicionaRamal").click(
                function () {
                    SendsServer(
                        "/Ramal/AdicionarRamal",
                        { id: $("#idMesa").val(), ramal: $("#numero").val(), tipo: $("#tipoRamal").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );

            $("#removeRamal").click(
                function () {
                    SendsServer(
                        "/Ramal/RemoverRamal",
                        { id: $("#idMesa").val() },
                        function (response) { RetiraDestaqueMesa(); },
                        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
                    );
                }
            );
        },
        function (jqXHR, textStatus, errorThrown) { DisplayError(jqXHR); }
     );
}