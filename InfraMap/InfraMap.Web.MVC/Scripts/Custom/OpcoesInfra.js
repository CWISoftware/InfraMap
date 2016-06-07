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
                    MemoriaRamGB1: $("#MemoriaRamGB1").val(),
                    MemoriaRamGB2: $("#MemoriaRamGB2").val(),
                    MemoriaRamGB3: $("#MemoriaRamGB3").val(),
                    MemoriaRamGB4: $("#MemoriaRamGB4").val(),
                    Ssd: $("#ssd").val(),
                    Hd: $("#hd").val()
                }
            },
            function (response) {

            },
            function (jqXHR, textStatus, errorThrown) { DisplayError(JSON.parse(jqXHR.responseText).Message); }
        );
    }
);

function TrocaModeloMaquina(id) {
    window.location.href = "/Maquina/EditarModeloMaquina/" + id;
}

function MostrarModal(label, info) {
    $("#selectcolor").empty();
    $("#modalGeral .modal-body").empty().append("<h2>" + info + "</h2>");
    $("#SalvarCorGerente").addClass("hide");
    $("#modalGeralLabel").empty().append(label);
    $('#modalGeral').modal('show');
};
