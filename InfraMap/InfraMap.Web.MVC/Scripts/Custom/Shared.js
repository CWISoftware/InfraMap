var RetiraDestaqueMesa = function () {
    //Primeiro caso testa se a página está em index
    //Ex: http://localhost:64464/Mapa/CWISL/5/
    console.log("[DEBUG] " + window.location.href);
    var url = window.location.href.match(/([https]+\:\/\/)?([\dA-Za-z\.\-\:]+)\/([\dA-Za-z]+)\/([\dA-Za-z]+)\/([\d\/])/g);
    console.log("[DEBUG] " + url);
    if (url === null) {
        //Segundo caso testa se url está em algum mapa
        //Ex: http://localhost:64464/Sede/Index
        //    http://localhost:64464/Sede
        url = window.location.href.match(/([https]+\:\/\/)?([\dA-Za-z\.\-\:]+)\/([\dA-Za-z]+)/g);
        console.log("[DEBUG] " + url);
    }
    window.location.href = url;
};

var DisplayError = function (msg) {
    $("#error .modal-body").append("<h2>" + msg + "</h2>");
    $('#error').modal('show');
};

var SendsServer = function (url, data, successFunc, errorFunc) {
    Request("POST", url, data, successFunc, errorFunc);
};

var ReceivesServer = function (url, data, successFunc, errorFunc) {
    Request("GET", url, data, successFunc, errorFunc);
};

function Request(typeRequest, urlRequest, dataRequest, successFunc, errorFunc) {
    $.ajax({
        type: typeRequest,
        url: urlRequest,
        data: dataRequest,
        success: successFunc,
        error: errorFunc
    });
};

function GoBack() {
    var newUrl = window.history.back();
}
