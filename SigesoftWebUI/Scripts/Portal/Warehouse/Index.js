var index;

$(document).ready(function () {
    'use strict';
    var Warehouse;
    Warehouse = function () {
        var me = this;
        me.Variables = {
            objData: null
        };
        me.Eventos = {
            CreateModal: function (e) {
                //$('#warehouseCreateContent').load(this.href, function () {
                //    $('#warehouseCreate').modal({
                //        keyboard: true
                //    }, 'show');
                //});
                //return false;      
                var url = $(this).attr('href');
                $("#warehouseCreate").dialog({
                    title: 'Add New Warehouse',
                    autoOpen: false,
                    resizable: false,
                    height: 455,
                    width: 550,
                    show: { effect: 'drop', direction: "up" },
                    modal: true,
                    draggable: true,
                    open: function (event, ui) {
                        $(this).load(url);

                    },
                    close: function (event, ui) {
                        $(this).dialog('close');
                    }
                });

                $("#warehouseCreate").dialog('open');
                return false;
            }
        };
        me.Funciones = {
            InicializarEventos: function () {
                $("body").live("click", "#AddWarehouse", me.Eventos.CreateModal);
            }
        };
        me.Inicializar = function () {
            me.Funciones.InicializarEventos();
        };
    };
    index = new Warehouse();
    index.Inicializar();

});