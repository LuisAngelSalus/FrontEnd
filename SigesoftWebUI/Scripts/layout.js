var ajaxLoader = null;

$(document).on("ready", function () {
    ajaxLoader = $('body').loadingIndicator({
        useImage: false,
        showOnInit: false,
        loadingText: ""
    }).data("loadingIndicator");

});

function ShowLoading() {
    if (ajaxLoader != null) {
        ajaxLoader.show();
    }
}

function CloseLoading() {
    if (ajaxLoader != null) {
        ajaxLoader.hide();
    }
}