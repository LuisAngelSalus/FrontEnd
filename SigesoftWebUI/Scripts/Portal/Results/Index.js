var index;

$(document).ready(function () {
    'use strict';
    var Result;
    Result = function () {
        var me = this;
        me.Variables = {
            objData: null
        };
        me.Eventos = {
            DetailModal: function (e) {
                $('#resultsDetailContent').load(this.href, function () {
                    $('#resultsDetail').modal({
                        keyboard: true
                    }, 'show');
                });
                return false;
            }
        };
        me.Funciones = {
            InicializarEventos: function () {
                $("body").on("click", "a[data-modal]", me.Eventos.DetailModal);
            }
        };
        me.Inicializar = function () {
            me.Funciones.InicializarEventos();
        };
    };
    index = new Result();
    index.Inicializar();

});