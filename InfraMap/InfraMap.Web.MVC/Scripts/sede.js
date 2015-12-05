$("#sede-sao-leo").click(function () {
    alert("É um botão");
    var id_sede = $("#sede-sao-leo").children("input").attr("value");
    $.ajax({
        type: "GET",
        url: '/Sede/PegarAndaresDasSedes',        
        dataType: "json"
    }).done(
        function (json) {
            var options = "";
            options += '<option value="' + json[id_sede-1].Andares[0].Id + '">' + json[id_sede-1].Andares[0].Descricao + '</option>';
            $("#btn-ir").addClass("show");
            $("#dropdown-andar").append(options);
        }
    );
});

$("#btn-ir").click(function () {
    $.ajax({
        url: '@Url.Action("IrParaMapa","Sede")',
        data: { descricaoAndar: $("#dropdown-andar").find(":selected").text(), idAndar: $("#dropdown-andar").val() }
    });
    }
);