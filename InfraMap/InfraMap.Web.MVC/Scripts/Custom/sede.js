var id_sede;

function sedeClick(id) {
    id_sede = id;
    $.ajax({
        type: "GET",
        url: '/Sede/PegarAndaresDasSedes',
        dataType: "json",
        success: function (json) {
            console.log('sdasd');
            var options = "";
            if (json[id_sede - 1].Andares.length === 1) {
                $.ajax({
                    type: "POST",
                    url: '/Sede/PegarNomeSede',
                    data: { idSede: id_sede },
                    datatype: "json",
                    success: function (data) { }
                }).done(function (nomeSede) {
                    window.location.href = "/Mapa/" + nomeSede + "/1/";
                });
            }
            else {
                json[id_sede - 1].Andares.forEach(function (andar) {
                    options += '<option value="' + andar.Id + '">' + andar.Descricao + '</option>';
                })
                $("#dropdown-andar").empty().append(options);
                $('#modalSede').modal('show');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) { console.log(jqXHR + ' --- ' + textStatus + ' --- ' + errorThrown) }
    })
};

$("#btn-ir").click(function () {
    var idAndar = $("#dropdown-andar").find(":selected").val();
    $.ajax({
        type: "POST",
        url: '/Sede/PegarNomeSede',
        data: { idSede: id_sede },
        datatype: "json",
        success: function (data) { }
    }).done(function (nomeSede) {
        window.location.href = "/Mapa/" + nomeSede + "/" + idAndar + "/";
    });
});