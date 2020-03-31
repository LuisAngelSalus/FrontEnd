$(".tab-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "fade"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Iniciar"
    }
    , onFinished: function (event, currentIndex) {       
        swal({
            title: "Importante",
            text: "Seguro de iniciar circuito?",
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            setTimeout(function () {
                //swal("Circuito Iniciado!");
                //backSchedule();
                location.reload();
            }, 2000);
        });
    }
});

