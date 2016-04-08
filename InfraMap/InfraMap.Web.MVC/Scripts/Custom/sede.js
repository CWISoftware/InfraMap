$("#sede-sao-leo").click(function () {
    var id_sede = $(this).children("input").attr("value");
    $.ajax({
        type: "GET",
        url: '/Sede/PegarAndaresDasSedes',        
        dataType: "json"
    }).done(
        function (json) {
            var options = "";
            json[id_sede - 1].Andares.forEach(function (andar) {
                options += '<option value="' + andar.Id + '">' + andar.Descricao + '</option>';
            })
            $("#btn-ir").addClass("show");
            $("#dropdown-andar").addClass("show");
            $("#dropdown-andar").empty().append(options);
        }
    );
});

$("#btn-ir").click(function () {
    var idAndar = $("#dropdown-andar").find(":selected").val();
    var id_sede = $("#sede-sao-leo").children("input").attr("value");
    $.ajax({
        type: "POST",
        url: '/Sede/PegarNomeSede',
        data: { idSede: id_sede },
        datatype: "json",
        success: function (data) { }
    }).done(function (nomeSede) {
        window.location.href = "/Mapa/"+nomeSede+"/" + idAndar;
    }
    );
    }
);