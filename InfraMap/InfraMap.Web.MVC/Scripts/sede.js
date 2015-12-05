$("#sede-sao-leo").click(function () {
    alert("É um botão");
    var id_sede = $("sede-sao-leo").val();
    $.ajax({
        type: "GET",
        url: '/Sede/PegarAndaresDasSedes',        
        dataType: "json",
        success: function (json) {
            var options = "";
            $.each(json, function (key, value) {
                options += '<option value="' + key + '">' + value + '</option>';
            });
            $("#dropdown-andar").html(options);
        }
    });
});