var RetiraDestaqueMesa = function () {
    var myUrl = window.location.href;
    var newUrl = myUrl.substr(0, window.location.href.length - (window.location.href.length - myUrl.lastIndexOf("/")));
    var UrlTest = newUrl.match("[a-zA-Z]$");
    if (UrlTest != null) {
        var andar = myUrl.substr(myUrl.lastIndexOf("/"), window.location.href.length);
        newUrl = newUrl + andar + "/";
    }
    if ((newUrl[window.location.href.length]) != "/")
        newUrl = newUrl + "/";
    window.location.href = newUrl;
}

var DisplayError = function (xhr) {
    var msg = JSON.parse(xhr.responseText);
    $("#error .modal-body").append("<h2>" + msg.Message + "</h2>");
    $('#error').modal('show');
}

var SendsServer = function (url, data, successFunc, errorFunc) {
    console.log("[DEBUG] SendsServer");
    Request("POST", url, data, successFunc, errorFunc);
};

var ReceivesServer = function (url, data, successFunc, errorFunc) {
    console.log("[DEBUG] ReceivesServer");
    Request("GET", url, data, successFunc, errorFunc);
};

function Request(typeRequest, urlRequest, dataRequest, successFunc, errorFunc) {
    console.log("[DEBUG] request");
    $.ajax({
        type: typeRequest,
        url: urlRequest,
        data: JSON.stringify(dataRequest),
        contentType: "application/json",
        success: successFunc,
        error: errorFunc
    });
};
