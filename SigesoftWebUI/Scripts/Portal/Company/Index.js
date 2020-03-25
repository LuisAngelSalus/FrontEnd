var index;

$(document).ready(function () {
    'use strict';
    var Company;
    Company = function () {
        var me = this;
        me.Variables = {
            objData: null
        };
        me.Eventos = {
            ContactModal: function (e) {
                $('#companyContactsContent').load(this.href, function () {
                    $('#companyContacts').modal({
                        keyboard: true
                    }, 'show');

                    //bindForm(this);
                });
                return false;
            }
        };
        me.Funciones = {
            InicializarEventos: function () {
                $("body").on("click", "a[data-modal]", me.Eventos.ContactModal);
            },

        };
        me.Inicializar = function () {
            me.Funciones.InicializarEventos();
        };
    };
    index = new Company();
    index.Inicializar();
});