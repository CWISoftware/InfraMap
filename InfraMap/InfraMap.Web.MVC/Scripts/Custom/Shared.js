var RetiraDestaqueMesa = function () {
    window.location.href = window.location.href.match(/([https]+\:\/\/)?([\dA-Za-z\.\-\:]+)\/([\dA-Za-z]+)\/([\dA-Za-z]+)\/([\dA-Za-z\/])/g);
};

var DisplayError = function (xhr) {
    var msg = JSON.parse(xhr.responseText);
    $("#error .modal-body").append("<h2>" + msg.Message + "</h2>");
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
