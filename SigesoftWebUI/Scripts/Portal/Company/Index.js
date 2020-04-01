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
            },
            PreviewImage: function (input) {
                console.log(input);
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('#imgPreview')
                            .attr('src', e.target.result);
                    };

                    reader.readAsDataURL(input.files[0]);
                }
            },
            ValidateNumber: function () {
                var element = $("#IdentificationNumber").val();
                var button = document.getElementById('btnSearchIdentification');
                if (element.length === 11) {
                    button.disabled = false;
                }
                else {
                    button.disabled = true;
                }
            },
            BuscarClick: function () {
                me.Funciones.ObtenerRuc();
            }
        };
        me.Funciones = {
            InicializarEventos: function () {
                $("body").on("click", "a[data-modal]", me.Eventos.ContactModal);
                $("body").on("keyup", "#IdentificationNumber", me.Eventos.ValidateNumber);
                $("body").on("click", "#btnSearchIdentification", me.Eventos.BuscarClick);
                document.querySelector("#File").addEventListener('change', function () {
                    me.Eventos.PreviewImage(this);
                });
            },
            ObtenerRuc: function () {

            }
        };
        me.Inicializar = function () {
            me.Funciones.InicializarEventos();
        };
    };
    index = new Company();
    index.Inicializar();
});