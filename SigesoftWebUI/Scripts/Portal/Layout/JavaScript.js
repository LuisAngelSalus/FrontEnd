var index;

$(document).on("ready", function () {
    'use strict';
    var Home;

    Home = function () {
        var me = this;

        me.Variables = {
            animacion: 0,
            scrollY: $(window).scrollLeft(),
            sinFiltroAutomatico: false,
            entornoHome: {
                CodigoPais: null,
                CodigoRegion: null,
                ResponsableRegion: null,
                CodigoZona: null,
                ResponsableZona: null,
                CodigoSeccion: null,
                ResponsableSeccion: null,
                Fase: null,
                CampaniaActual: null,
                CampaniaNombreCorto: null,
                NivelActual: null,
                CodigoRol: null,
                ABValor: null,
                EsPaisUnete: null
            }
        };

        me.Eventos = {
            IpUnicoReportClick: function () {
                var url = window.location.origin + "/Reportes/IpUnico";
                location.href = url;
            },
            ExportarExcel: function () {
                me.Funciones.ExportarExcel();
                //descargaVirtualIndicador(me.Constantes.codIndicador, me.Variables.tipoTab, me.Constantes.formatoExcel);
            },
            ComboRegionChange: function () {
                var strComboRegion = "#" + $(this).attr("id");
                me.Funciones.SeleccionarRegion(strComboRegion);
            },
            ComboRegionMobileChange: function () {
                var strComboRegionMobile = "#" + $(this).attr("id");
                me.Funciones.SeleccionarRegion(strComboRegionMobile);
            },
            LnkRegionMobileClick: function () {
                var codregion = "-1";

                $("#cbo-home-region-mobile>option[value='" + codregion + "']").prop('selected', true);
                $("#cbo-home-region-mobile").trigger("change");
            },
            ComboZonaChange: function () {
                var strComboZona = "#" + $(this).attr("id");
                me.Funciones.SeleccionarZona(strComboZona);
            },
            ComboZonaMobileChange: function () {
                var strComboZonaMobile = "#" + $(this).attr("id");
                me.Funciones.SeleccionarZona(strComboZonaMobile);
            },
            LnkZonaMobileClick: function () {
                var codzona = "-1";

                $("#cbo-home-zona-mobile>option[value='" + codzona + "']").prop('selected', true);
                $("#cbo-home-zona-mobile").trigger("change");
            },
            ComboSeccionChange: function () {
                var strComboSeccion = "#" + $(this).attr("id");
                me.Funciones.SeleccionarSeccion(strComboSeccion);
            },
            ComboSeccionMobileChange: function () {
                var strComboSeccionMobile = "#" + $(this).attr("id");
                me.Funciones.SeleccionarSeccion(strComboSeccionMobile);
            },
            LnkSeccionMobileClick: function () {
                var codseccion = "-1";

                $("#cbo-home-seccion-mobile>option[value='" + codseccion + "']").prop('selected', true);
                $("#cbo-home-seccion-mobile").trigger("change");
            },
            NodoSeccionClick: function () {
                var codigoSeccion = $(this).attr("value");
                var responsableSeccion = $(this).attr("responsable");
                var nivel = $(this).attr("nivel");

                if (me.Variables.entornoHome.CodigoSeccion == codigoSeccion) {
                    return false;
                }

                ShowLoading();
                me.Variables.entornoHome.CodigoSeccion = codigoSeccion;
                me.Variables.entornoHome.ResponsableSeccion = responsableSeccion;
                me.Variables.entornoHome.NivelActual = nivel;
                me.Funciones.DesactivarNodoBase();

                virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar', me.Variables.entornoHome.CodigoRegion, me.Variables.entornoHome.CodigoZona, codigoSeccion, false);

                var actualizarEntornoAjax = me.Funciones.ActualizarEntorno();

                actualizarEntornoAjax.done(function () {
                    me.Funciones.CargarIndicadores();
                    me.Funciones.ActivarNodoSeccion();
                    me.Funciones.ActualizarBreadCrumb();
                });
            },
            NodoBaseClick: function () {
                var codigo = $("#a-home-nodobase").attr("codigo");
                var nivel = $("#a-home-nodobase").attr("nivel");

                if (me.Variables.entornoHome.NivelActual == nivel) {
                    return false;
                }

                ShowLoading();

                if (nivel == "P") {
                    me.Variables.entornoHome.CodigoRegion = null;
                    me.Variables.entornoHome.ResponsableRegion = null;
                    me.Variables.entornoHome.CodigoZona = null;
                    me.Variables.entornoHome.ResponsableZona = null;
                    me.Variables.entornoHome.CodigoSeccion = null;
                    me.Variables.entornoHome.ResponsableSeccion = null;
                }

                if (nivel == "R") {
                    me.Variables.entornoHome.CodigoZona = null;
                    me.Variables.entornoHome.ResponsableZona = null;
                    me.Variables.entornoHome.CodigoSeccion = null;
                    me.Variables.entornoHome.ResponsableSeccion = null;
                }

                if (nivel == "Z") {
                    me.Variables.entornoHome.CodigoSeccion = null;
                    me.Variables.entornoHome.ResponsableSeccion = null;
                }

                me.Variables.entornoHome.NivelActual = nivel;
                me.Funciones.LimpiarDatosCampania();

                virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar', me.Variables.entornoHome.CodigoRegion, me.Variables.entornoHome.CodigoZona, null, false);
                me.Variables.sinFiltroAutomatico = true;

                var obtenerCampaniaActualAjax = me.Funciones.ObtenerCampaniaActual(false);

                obtenerCampaniaActualAjax.done(function (result) {
                    me.Funciones.CargarInicio();
                    me.Funciones.CargarIndicadores();
                    me.Funciones.ActualizarBreadCrumb();
                });
            },
            NodoBaseMobileClick: function () {
                var nivel = $(this).attr("nivel");

                if (me.Variables.entornoHome.NivelActual == nivel) {
                    return false;
                }

                ShowLoading();

                if (nivel == "P") {
                    me.Variables.entornoHome.CodigoRegion = null;
                    me.Variables.entornoHome.ResponsableRegion = null;
                    me.Variables.entornoHome.CodigoZona = null;
                    me.Variables.entornoHome.ResponsableZona = null;
                    me.Variables.entornoHome.CodigoSeccion = null;
                    me.Variables.entornoHome.ResponsableSeccion = null;
                }

                if (nivel == "R") {
                    me.Variables.entornoHome.CodigoZona = null;
                    me.Variables.entornoHome.ResponsableZona = null;
                    me.Variables.entornoHome.CodigoSeccion = null;
                    me.Variables.entornoHome.ResponsableSeccion = null;
                }

                if (nivel == "Z") {
                    me.Variables.entornoHome.CodigoSeccion = null;
                    me.Variables.entornoHome.ResponsableSeccion = null;
                }

                me.Variables.entornoHome.NivelActual = nivel;
                me.Funciones.LimpiarDatosCampania();

                virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar', me.Variables.entornoHome.CodigoRegion, me.Variables.entornoHome.CodigoZona, null, false);
                me.Variables.sinFiltroAutomatico = true;

                var obtenerCampaniaActualAjax = me.Funciones.ObtenerCampaniaActual(false);

                obtenerCampaniaActualAjax.done(function (result) {
                    me.Funciones.CargarInicio();
                    me.Funciones.CargarIndicadores();
                    me.Funciones.ActualizarBreadCrumb();
                });
            },
            BreadCrumbRegionClick: function () {
                var strComboRegion = "#cbo-region-home";
                me.Funciones.SeleccionarRegion(strComboRegion);
            },
            BreadCrumbZonaClick: function () {
                var strComboZona = "#cbo-zona-home";
                me.Funciones.SeleccionarZona(strComboZona);
            },
            ResumenClick: function () {
                me.Funciones.CargarResumen();
            },
            DataReportClick: function () {
                me.Funciones.CargarDataReport();
            },
            IndicadoresClick: function () {
                $('#lnk-resumen').removeClass('active');
                $('#lnk-indicadores').addClass('active');
                $('#lnk-datareport').removeClass('active');
                paginaVirtual('/Home/indicadores/', 'Indicadores – Home');
                me.Funciones.ActivarTab("tab-indicadores");
            },
            CambiarPerfilClick: function () {
                $('.content-usuario-sac-option').css('display', 'block');
                $('.usuario-sac-option').css('display', 'none');
            },
            CancelarClick: function () {
                $('.content-usuario-sac-option').css('display', 'none');
                $('.usuario-sac-option').css('display', 'block');
            },
            ActualizarSacClick: function () {
                me.Funciones.CargarUsuarioSAC();
            },
            RightClick: function (e, data) {
                var sy = $(this).parents(".table-controls").data('scroll');
                var tselect = $(this).parents(".table-controls");
                me.Variables.scrollY = $("." + tselect.data('fortable')).scrollLeft() + sy;
                if (me.Variables.animacion == 0) {
                    me.Variables.scrollY = $("." + tselect.data('fortable')).scrollLeft() + sy;
                    me.Variables.animacion = 1;
                }
                else {
                    me.Variables.scrollY = $("." + tselect.data('fortable')).scrollLeft() + sy + 350;
                    me.Variables.animacion = 0;
                }
                $("." + tselect.data('fortable')).animate({ scrollLeft: "+=300px" }, 800);
            },
            LeftClick: function (e, data) {
                var sy = $(this).parents(".table-controls").data('scroll');
                var tselect = $(this).parents(".table-controls");

                me.Variables.scrollY = $("." + tselect.data('fortable')).scrollLeft() - sy;

                $("." + tselect.data('fortable')).animate({ scrollLeft: "-=300px" }, 800);
            },
            FinalizarAjax: function () {
                CloseLoading();
            },
            MarcacionesDataReportClick: function () {
                var label = this.title;
                descargaVirtual("Data report", label);
            },
            MarcacionesNuevoDataReportClick: function () {
                menuTabVirtual("Home", 'Reportes de Campaña');
            },
            RedireccionarIndicadorUneteClick: function () {
                window.location.href = baseUrl + 'Home/Index/INDICADORUNETE';
            }
        };

        me.Funciones = {
            ExportarExcel: function () {
                // ShowLoading();
                $.UnifiedExportFile(
                    {
                        action: '/Home/ExportarResumenXls',
                        data: null,
                        downloadType: 'Progress',
                        ajaxLoadingSelector: ''
                    });
            },
            //activarSaludoNavidenio: function () {
            //    setTimeout(me.Funciones.pararAnimacion, 20000);

            //},
            //pararAnimacion: function () {
            //    $('.contenedor_estrellas').fadeOut(800);
            //    setTimeout(function () {
            //        $('.contenedor_estrellas').remove();
            //    }, 5000);

            //},
            InicializarEventos: function () {
                $("body").on("change", "#cbo-home-region", me.Eventos.ComboRegionChange);
                $("body").on("change", "#cbo-home-zona", me.Eventos.ComboZonaChange);
                $("body").on("change", "#cbo-home-seccion", me.Eventos.ComboSeccionChange);
                $("body").on("change", "#cbo-home-region-mobile", me.Eventos.ComboRegionMobileChange);
                $("body").on("change", "#cbo-home-zona-mobile", me.Eventos.ComboZonaMobileChange);
                $("body").on("change", "#cbo-home-seccion-mobile", me.Eventos.ComboSeccionMobileChange);
                $("body").on("click", "#a-home-nodobase, #bc-home", me.Eventos.NodoBaseClick);
                $("body").on("click", "#a-home-nodobase-mobile", me.Eventos.NodoBaseMobileClick);
                $("body").on("click", "#bc-home-region", me.Eventos.BreadCrumbRegionClick);
                $("body").on("click", "#bc-home-zona", me.Eventos.BreadCrumbZonaClick);
                $("body").on("click", "#lnk-region-mobile", me.Eventos.LnkRegionMobileClick);
                $("body").on("click", "#lnk-zona-mobile", me.Eventos.LnkZonaMobileClick);
                $("body").on("click", "#lnk-seccion-mobile", me.Eventos.LnkSeccionMobileClick);
                $("body").on("click", "#tr-home-seccion a", me.Eventos.NodoSeccionClick);
                $("body").on("click", "#lnk-datareport", me.Eventos.DataReportClick);
                $("body").on("click", "#lnk-resumen", me.Eventos.ResumenClick);
                $("body").on("click", "#lnk-indicadores", me.Eventos.IndicadoresClick);

                $("body").on("click", "#lnk-ipunicoreport", me.Eventos.IpUnicoReportClick);
                $("body").on("click", "#lnk-comprasdigital", me.Eventos.VentasDigitalReportClick);
                //JGR
                //$("body").on("click", "#UneteDetalle", me.Eventos.RedireccionarIndicadorUneteClick);
                $("body").on("click", '.table-right', me.Eventos.RightClick);
                $("body").on("click", '.table-left', me.Eventos.LeftClick);
                $("body").on("click", ".dataReportMarcaciones", me.Eventos.MarcacionesDataReportClick);
                $('body').on('click', '.excel', me.Eventos.ExportarExcel);

                $("body").on("click", "#ver-mas-data-report", me.Funciones.MostrarMasDataReport);
                $("body").on("click", "#ver-menos-data-report", me.Funciones.MostrarMenosDataReport);

                $("body").on("click", "#ver-mas-data-planificacion", me.Funciones.MostrarMasDataPlanificacion);
                $("body").on("click", "#ver-menos-data-planificacion", me.Funciones.MostrarMenosDataPlanificacion);

                $("body").on("click", ".marcacionDescarga", me.Funciones.MarcacionesDescargaReporteCierre);

                $("body").on("click", ".navegacion-reporte-cierre", me.Eventos.MarcacionesNuevoDataReportClick);

                $(document).ajaxStop(me.Eventos.FinalizarAjax);
            },
            MarcacionesDescargaReporteCierre: function () {
                var labelFinal = $(this).attr('subseccion') + ' | ' + $(this).attr('title');

                virtualEventFFVV('Reportes de Cierre', 'Descargar', labelFinal);
            },

            OcultarFilasDataReport: function () {
                var id = "#table-data-report";
                var table = id + " tbody tr";
                var numOfrows = $(table).length;
                var start = 3;
                var end = numOfrows;
                if (numOfrows > 3) {
                    $(table).slice(3, numOfrows).hide();
                    $("#ver-mas-data-report").removeClass("hide")
                    $("#ver-menos-data-report").addClass("hide");
                }
                else {
                    $("#ver-mas-data-report").addClass("hide")
                    $("#ver-menos-data-report").addClass("hide");
                }
            },
            OcultarFilasDataPlanificacion: function () {
                var id = "#table-data-planificacion";
                var table = id + " tbody tr";
                var numOfrows = $(table).length;
                var start = 3;
                var end = numOfrows;
                if (numOfrows > 3) {
                    $(table).slice(3, numOfrows).hide();
                    $("#ver-mas-data-planificacion").removeClass("hide")
                    $("#ver-menos-data-planificacion").addClass("hide");
                }
                else {
                    $("#ver-mas-data-planificacion").addClass("hide");
                    $("#ver-menos-data-planificacion").addClass("hide");
                }
            },
            MostrarMenosDataPlanificacion: function () {
                me.Funciones.OcultarFilasDataPlanificacion();
            },
            MostrarMasDataPlanificacion: function () {
                virtualEventFFVV('Reportes de Cierre', 'Ver más', 'Datos para planificación');

                var id = "#table-data-planificacion";
                var table = id + " tbody tr";
                var numOfrows = $(table).length;
                var actNumOfRows = numOfrows - 1;
                var numOfnoneRows = $(table).filter(function () {
                    return $(this).css('display') == 'none';
                }).length;

                var numOfblockRows = $(table).filter(function () {
                    return $(this).css('display') != 'none';
                }).length;

                var visible = actNumOfRows;
                var ini, fin;
                if (numOfnoneRows > 3) {
                    ini = numOfblockRows;
                    fin = ini + 3;
                    $(table).slice(ini, fin).show();
                }
                else {
                    ini = numOfblockRows;
                    fin = ini + (numOfrows - ini);
                    $(table).slice(ini, fin).show();

                    $("#ver-mas-data-planificacion").addClass("hide")
                    $("#ver-menos-data-planificacion").removeClass("hide");
                }
            },
            MostrarMenosDataReport: function () {
                me.Funciones.OcultarFilasDataReport();
            },
            MostrarMasDataReport: function () {
                virtualEventFFVV('Reportes de Cierre', 'Ver más', 'Data Report');

                var id = "#table-data-report";
                var table = id + " tbody tr";
                var numOfrows = $(table).length;
                var actNumOfRows = numOfrows - 1;

                var numOfnoneRows = $(table).filter(function () {
                    return $(this).css('display') == 'none';
                }).length;

                var numOfblockRows = $(table).filter(function () {
                    return $(this).css('display') != 'none';
                }).length;

                var visible = actNumOfRows;
                var ini, fin;
                if (numOfnoneRows > 3) {
                    ini = numOfblockRows;
                    fin = ini + 3;
                    $(table).slice(ini, fin).show();
                }
                else {
                    ini = numOfblockRows;
                    fin = ini + (numOfrows - ini);
                    $(table).slice(ini, fin).show();

                    $("#ver-mas-data-report").addClass("hide")
                    $("#ver-menos-data-report").removeClass("hide");
                }
            },

            CargarInicio: function () {
                me.Funciones.ActivarTab("tab-indicadores");

                var obtenerDatosSessionAjax = me.Funciones.ObtenerDatosSession();

                obtenerDatosSessionAjax.done(function (result) {
                    if (me.Variables.sinFiltroAutomatico)
                        me.Variables.sinFiltroAutomatico = false;
                    else
                        virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar-Automático', me.Variables.entornoHome.CodigoRegion, me.Variables.entornoHome.CodigoZona, me.Variables.entornoHome.CodigoSeccion, true);

                    if (me.Variables.entornoHome.CodigoRol == "DV")
                        me.Funciones.CargarInicioDV();

                    if (me.Variables.entornoHome.CodigoRol == "GR")
                        me.Funciones.CargarInicioGR();

                    if (me.Variables.entornoHome.CodigoRol == "GZ")
                        me.Funciones.CargarInicioGZ();

                    me.Funciones.ActualizarBreadCrumb();

                    var opcionUrlDataReport = window.location.pathname.split('?')[0].split('/').filter(function (i) { return i !== "" }).slice(-1)[0] || "";

                    if (opcionUrlDataReport.toUpperCase() == "DATAREPORT") {
                        me.Eventos.DataReportClick();
                    }
                    if (opcionUrlDataReport.toUpperCase() == "CONSULTACREDITICIA") {
                        me.Funciones.MostrarConsultaCrediticia();
                    }

                    if (me.Variables.entornoHome.EsPaisUnete && me.Variables.entornoHome.CodigoRol == "GZ") {
                        //JGR
                        // me.Funciones.CargarIndicadorUnete();
                    }
                });
            },
            CargarInicioDV: function () {
                var nivelBase = $("#a-home-nodobase").attr("nivel");

                me.Funciones.DesactivarNodoBase();
                me.Funciones.EstablecerRegion();
                me.Funciones.ActivarComboRegionMobile();
                me.Funciones.MostrarLinkRegionMobile();
                me.Funciones.DesactivarComboZona();
                me.Funciones.DesactivarComboZonaMobile();
                me.Funciones.LimpiarComboZona();
                $("#lnk-zona-mobile").empty();
                var cargarZonasAjax = me.Funciones.CargarZonas();

                if (cargarZonasAjax) {
                    cargarZonasAjax.done(function () {
                        me.Funciones.EstablecerZona();
                        me.Funciones.ActivarComboZonaMobile();
                        me.Funciones.MostrarLinkZonaMobile();
                    });
                }

                me.Funciones.DesactivarComboSeccion();
                me.Funciones.DesactivarComboSeccionMobile();
                me.Funciones.LimpiarComboSeccion();
                $("#lnk-seccion-mobile").empty();
                var cargarSeccionesAjax = me.Funciones.CargarSecciones();

                if (cargarSeccionesAjax) {
                    cargarSeccionesAjax.done(function () {
                        me.Funciones.EstablecerSeccion();
                        me.Funciones.ActivarComboSeccionMobile();
                        me.Funciones.MostrarLinkSeccionMobile();
                    });
                }

                if (me.Variables.entornoHome.NivelActual != nivelBase) {
                    me.Funciones.MostrarDatosCampania();
                }

                if (me.Variables.entornoHome.NivelActual == nivelBase) {
                    me.Funciones.ActivarNodoBase();
                }
            },
            CargarInicioGR: function () {
                var nivelBase = $("#a-home-nodobase").attr("nivel");

                me.Funciones.DesactivarNodoBase();
                me.Funciones.EstablecerZona();
                me.Funciones.ActivarComboZonaMobile();
                me.Funciones.MostrarLinkZonaMobile();
                me.Funciones.DesactivarComboSeccion();
                me.Funciones.DesactivarComboSeccionMobile();
                me.Funciones.LimpiarComboSeccion();
                $("#lnk-seccion-mobile").empty();
                var cargarSeccionesAjax = me.Funciones.CargarSecciones();

                if (cargarSeccionesAjax) {
                    cargarSeccionesAjax.done(function (result) {
                        me.Funciones.EstablecerSeccion();
                        me.Funciones.ActivarComboSeccionMobile();
                        me.Funciones.MostrarLinkSeccionMobile();
                    });
                }

                if (me.Variables.entornoHome.NivelActual != nivelBase) {
                    me.Funciones.MostrarDatosCampania();
                }

                if (me.Variables.entornoHome.NivelActual == nivelBase) {
                    me.Funciones.ActivarNodoBase();
                }
            },
            CargarInicioGZ: function () {
                var nivelBase = $("#a-home-nodobase").attr("nivel");
                me.Funciones.DesactivarNodoBase();
                me.Funciones.ActivarNodoSeccion();

                if (me.Variables.entornoHome.NivelActual == nivelBase) {
                    me.Funciones.ActivarNodoBase();
                }
            },
            CargarIndicadores: function () {
                $.ajax({
                    url: "/Home/Indicadores",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    data: null,
                    success: function (result) {
                        $('#div-contenido-indicadores').html(result);
                        //JGR
                        //if (me.Variables.entornoHome.EsPaisUnete && me.Variables.entornoHome.CodigoRol == "GZ") {
                        //    me.Funciones.CargarIndicadorUnete();
                        //}
                    },
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                });
            },
            CargarDataReport: function () {
                me.Funciones.ActivarTab("tab-datareport");
                ShowLoading();
                $.ajax({
                    url: "/Home/DataReport",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    data: null,
                    success: function (result) {
                        paginaVirtual('/home/reportes-de-cierre/', 'Reportes de Cierre – Home');
                        $('#div-contenido-datareport').html(result);
                        me.Funciones.OcultarFilasDataReport();
                        me.Funciones.OcultarFilasDataPlanificacion();
                    },
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                });
                // window.location.href = "Reportes/DataReport";
            },
            CargarResumen: function () {
                me.Funciones.ActivarTab("tab-resumen");
                ShowLoading();
                $.ajax({
                    url: "/Home/Resumen",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    data: null,
                    success: function (result) {
                        var x = result;
                        paginaVirtual('/Home/resumen/', 'Resumen – Home');
                        $('#div-contenido-resumen').html(result);
                    },
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                });
            },
            ObtenerCampaniaActual: function (renderizaDatosCampania) {
                var data = JSON.stringify(me.Variables.entornoHome);

                var obtenerCampaniaActualAjax = $.ajax({
                    url: "/Home/ObtenerCampaniaActual",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: data,
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                });

                obtenerCampaniaActualAjax.done(function (result) {
                    if (result) {
                        var campania = result.Hits[0];
                        if (!campania)
                            return false;
                        me.Variables.entornoHome.CampaniaActual = campania.Codigo;
                        me.Variables.entornoHome.Fase = campania.Fase;
                        me.Variables.entornoHome.CampaniaNombreCorto = campania.NombreCorto;

                        if (renderizaDatosCampania) {
                            me.Funciones.MostrarDatosCampania();
                        }
                    }
                });

                return obtenerCampaniaActualAjax;
            },
            CargarZonas: function () {
                if (!me.Variables.entornoHome.CodigoRegion) {
                    return false;
                }

                var cargarZonasAjax = $.ajax({
                    url: "/Home/ObtenerZonas",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: null,
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                }).done(function (result) {
                    if (result) {
                        if (result.Hits) {
                            $.each(result.Hits, function (ind, obj) {
                                var responsable = obj.GerenteZona ? obj.GerenteZona : "NO COBERTURADA";
                                var strZona = "<option value='" + obj.Codigo + "' responsable ='" + responsable + "' nivel='Z'>" + obj.Codigo + ": " + responsable + "</option>";
                                $("#cbo-home-zona").append(strZona);
                                $("#cbo-home-zona-mobile").append(strZona);
                            });
                            me.Funciones.ActivarComboZona();
                            me.Funciones.ActivarComboZonaMobile();
                        }
                    }
                });

                return cargarZonasAjax;
            },
            MostrarDatosCampania: function () {
                var nombreCorto = me.Funciones.ObtenerFormatoCampania(me.Variables.entornoHome.CampaniaActual);
                //me.Variables.entornoHome.CampaniaNombreCorto ? me.Variables.entornoHome.CampaniaNombreCorto : '';

                $("#lbl-home-campania").html("CAMPAÑA: " + nombreCorto);
                var faseDescripcion = null;

                if (me.Variables.entornoHome.Fase == "F") {
                    faseDescripcion = "FACTURACIÓN";
                }

                if (me.Variables.entornoHome.Fase == "V") {
                    faseDescripcion = "VENTA";
                }

                $("#lbl-home-fase").html("ETAPA: " + faseDescripcion);
            },
            ObtenerDatosSession: function () {
                var obtenerDatosSessionAjax = $.ajax({
                    url: "/Home/ObtenerDatosSession",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: null,
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                }).done(function (result) {
                    if (result) {
                        me.Variables.entornoHome.CodigoPais = result.Entorno.CodigoPais;
                        me.Variables.entornoHome.CodigoRegion = result.Entorno.CodigoRegion;
                        me.Variables.entornoHome.ResponsableRegion = result.Entorno.ResponsableRegion;
                        me.Variables.entornoHome.CodigoZona = result.Entorno.CodigoZona;
                        me.Variables.entornoHome.ResponsableZona = result.Entorno.ResponsableZona;
                        me.Variables.entornoHome.CodigoSeccion = result.Entorno.CodigoSeccion;
                        me.Variables.entornoHome.ResponsableSeccion = result.Entorno.ResponsableSeccion;
                        me.Variables.entornoHome.CampaniaActual = result.Entorno.CampaniaActual;
                        me.Variables.entornoHome.Fase = result.Entorno.Fase;
                        me.Variables.entornoHome.CodigoRol = result.Usuario.CodRol;
                        me.Variables.entornoHome.NivelActual = result.Entorno.NivelActual;
                        me.Variables.entornoHome.ABValor = result.Entorno.ABValor;
                        me.Variables.entornoHome.EsPaisUnete = result.Usuario.EsPaisUnete;
                    }
                });

                return obtenerDatosSessionAjax;
            },
            CargarSecciones: function () {
                if (!me.Variables.entornoHome.CodigoZona) {
                    return false;
                }

                var cargarSeccionesAjax = $.ajax({
                    url: "/Home/ObtenerSecciones",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: null,
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                }).done(function (result) {
                    if (result) {
                        if (result.Hits) {
                            $.each(result.Hits, function (ind, obj) {
                                var responsable = obj.SociaEmpresaria ? obj.SociaEmpresaria : "NO COBERTURADA";
                                var strSeccion = "<option value='" + obj.Codigo + "' responsable ='" + responsable + "' nivel='S'>" + obj.Codigo + ": " + responsable + "</option>";
                                $("#cbo-home-seccion").append(strSeccion);
                                $("#cbo-home-seccion-mobile").append(strSeccion);
                            });
                            me.Funciones.ActivarComboSeccion();
                            me.Funciones.ActivarComboSeccionMobile();
                        }
                    }
                });

                return cargarSeccionesAjax;
            },
            CargarRegiones: function () {
                var cargarRegionesAjax = $.ajax({
                    url: "/Home/ObtenerRegiones",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: null,
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                }).done(function (result) {
                    if (result) {
                        if (result.Hits) {
                            $.each(result.Hits, function (ind, obj) {
                                var responsable = obj.GerenteRegion ? obj.GerenteRegion : "NO COBERTURADA";
                                var strRegion = "<option value='" + obj.Codigo + "' responsable ='" + responsable + "' nivel='R'>" + obj.Codigo + ": " + responsable + "</option>";
                                $("#cbo-home-region").append(strRegion);
                            });
                            me.Funciones.ActivarComboRegion();
                        }
                    }
                });

                return cargarRegionesAjax;
            },
            SeleccionarRegion: function (elem) {
                ShowLoading();
                var codigoRegion = $(elem).val();
                var responsableRegion = $(elem).children(":selected").attr("responsable");
                var nivelActual = $(elem).children(":selected").attr("nivel");
                var nivelBase = $("#a-home-nodobase").attr("nivel");
                var cargarZonas = true;
                var desactivarComboZona = false;
                var renderizaDatosCampania = true;

                if (codigoRegion == "-1") {
                    codigoRegion = null;
                    responsableRegion = null;
                    cargarZonas = false;
                    desactivarComboZona = true;
                    renderizaDatosCampania = false;
                    nivelActual = nivelBase;
                }

                me.Variables.entornoHome.CodigoRegion = codigoRegion;
                me.Variables.entornoHome.ResponsableRegion = responsableRegion;
                me.Variables.entornoHome.NivelActual = nivelActual;
                me.Variables.entornoHome.CodigoZona = null;
                me.Variables.entornoHome.ResponsableZona = null;
                me.Variables.entornoHome.CodigoSeccion = null;
                me.Variables.entornoHome.ResponsableSeccion = null;

                me.Funciones.EstablecerRegion();
                me.Funciones.ActivarComboRegionMobile();
                me.Funciones.MostrarLinkRegionMobile();
                me.Funciones.LimpiarDatosCampania();
                me.Funciones.LimpiarComboZona();
                $("#lnk-zona-mobile").empty();
                me.Funciones.LimpiarComboSeccion();
                $("#lnk-seccion-mobile").empty();
                me.Funciones.DesactivarComboSeccion();
                me.Funciones.DesactivarComboSeccionMobile();
                me.Funciones.DesactivarNodoBase();

                if (desactivarComboZona) {
                    me.Funciones.DesactivarComboZona();
                    me.Funciones.DesactivarComboZonaMobile();
                }

                var obtenerCampaniaActualAjax = me.Funciones.ObtenerCampaniaActual(renderizaDatosCampania);

                virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar', codigoRegion, null, null, false);

                obtenerCampaniaActualAjax.done(function () {
                    me.Funciones.CargarIndicadores();

                    if (cargarZonas)
                        me.Funciones.CargarZonas();

                    if (me.Variables.entornoHome.NivelActual == nivelBase) {
                        me.Funciones.ActivarNodoBase();
                    }

                    me.Funciones.ActualizarBreadCrumb();
                });
            },
            SeleccionarZona: function (elem) {
                ShowLoading();
                var codigoZona = $(elem).val();
                var responsableZona = $(elem).children(":selected").attr("responsable");
                var nivelActual = $(elem).children(":selected").attr("nivel");
                var nivelBase = $("#a-home-nodobase").attr("nivel");
                var cargarSecciones = true;
                var desactivarComboSeccion = false;
                var renderizaDatosCampania = true;

                if (codigoZona == "-1") {
                    codigoZona = null;
                    responsableZona = null;
                    cargarSecciones = false;
                    desactivarComboSeccion = true;
                    nivelActual = "R";
                    if (me.Variables.entornoHome.CodigoRol == "GR") {
                        renderizaDatosCampania = false;
                        nivelActual = nivelBase;
                    }
                }

                me.Variables.entornoHome.CodigoZona = codigoZona;
                me.Variables.entornoHome.ResponsableZona = responsableZona;
                me.Variables.entornoHome.NivelActual = nivelActual;
                me.Variables.entornoHome.CodigoSeccion = null;
                me.Variables.entornoHome.ResponsableSeccion = null;

                me.Funciones.EstablecerZona();
                me.Funciones.ActivarComboZonaMobile();
                me.Funciones.MostrarLinkZonaMobile();
                me.Funciones.LimpiarDatosCampania();
                me.Funciones.LimpiarComboSeccion();
                $("#lnk-seccion-mobile").empty();
                me.Funciones.DesactivarNodoBase();

                virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar', me.Variables.entornoHome.CodigoRegion, codigoZona, null, false);

                if (desactivarComboSeccion) {
                    me.Funciones.DesactivarComboSeccion();
                    me.Funciones.DesactivarComboSeccionMobile();
                }

                var obtenerCampaniaActualAjax = me.Funciones.ObtenerCampaniaActual(renderizaDatosCampania);

                obtenerCampaniaActualAjax.done(function () {
                    me.Funciones.CargarIndicadores();

                    if (cargarSecciones)
                        me.Funciones.CargarSecciones();

                    if (me.Variables.entornoHome.NivelActual == nivelBase) {
                        me.Funciones.ActivarNodoBase();
                    }

                    me.Funciones.ActualizarBreadCrumb();
                });
            },
            SeleccionarSeccion: function (elem) {
                ShowLoading();
                var codigoSeccion = $(elem).val();
                var responsableSeccion = $(elem).children(":selected").attr("responsable");
                var nivelActual = $(elem).children(":selected").attr("nivel");

                if (codigoSeccion == "-1") {
                    nivelActual = "Z";
                    codigoSeccion = null;
                    responsableSeccion = null;
                }

                me.Variables.entornoHome.CodigoSeccion = codigoSeccion;
                me.Variables.entornoHome.ResponsableSeccion = responsableSeccion;
                me.Variables.entornoHome.NivelActual = nivelActual;

                me.Funciones.EstablecerSeccion();
                me.Funciones.ActivarComboSeccionMobile();
                me.Funciones.MostrarLinkSeccionMobile();

                virtualEventFiltros(me.Variables.entornoHome.CodigoRol, 'Home', 'Filtrar', me.Variables.entornoHome.CodigoRegion, me.Variables.entornoHome.CodigoZona, codigoSeccion, false);

                var actualizarEntornoAjax = me.Funciones.ActualizarEntorno();

                actualizarEntornoAjax.done(function () {
                    me.Funciones.CargarIndicadores();
                    me.Funciones.ActualizarBreadCrumb();
                });
            },
            EstablecerRegion: function () {
                var codregion = me.Variables.entornoHome.CodigoRegion ? me.Variables.entornoHome.CodigoRegion : "-1";
                $("#cbo-home-region>option[value='" + codregion + "']").prop('selected', true);
                $("#cbo-home-region-mobile>option[value='" + codregion + "']").prop('selected', true);
            },
            EstablecerZona: function () {
                var codzona = me.Variables.entornoHome.CodigoZona ? me.Variables.entornoHome.CodigoZona : "-1";
                $("#cbo-home-zona>option[value='" + codzona + "']").prop('selected', true);
                $("#cbo-home-zona-mobile>option[value='" + codzona + "']").prop('selected', true);
            },
            EstablecerSeccion: function () {
                var codseccion = me.Variables.entornoHome.CodigoSeccion ? me.Variables.entornoHome.CodigoSeccion : "-1";
                $("#cbo-home-seccion>option[value='" + codseccion + "']").prop('selected', true);
                $("#cbo-home-seccion-mobile>option[value='" + codseccion + "']").prop('selected', true);
            },
            MostrarLinkRegionMobile: function () {
                var codregion = me.Variables.entornoHome.CodigoRegion ? me.Variables.entornoHome.CodigoRegion : "-1";
                $("#lnk-region-mobile").empty();

                if (codregion != "-1") {
                    var responsable = me.Variables.entornoHome.ResponsableRegion.length > 20 ? me.Variables.entornoHome.ResponsableRegion.substring(0, 20) : me.Variables.entornoHome.ResponsableRegion;

                    $("#lnk-region-mobile").html("<b>REGIÓN " + codregion + ":</b> " + responsable + ">");
                    me.Funciones.DesactivarComboRegionMobile();
                }
            },
            MostrarLinkZonaMobile: function () {
                var codzona = me.Variables.entornoHome.CodigoZona ? me.Variables.entornoHome.CodigoZona : "-1";
                $("#lnk-zona-mobile").empty();

                if (codzona != "-1") {
                    var responsable = me.Variables.entornoHome.ResponsableZona.length > 20 ? me.Variables.entornoHome.ResponsableZona.substring(0, 20) : me.Variables.entornoHome.ResponsableZona;

                    $("#lnk-zona-mobile").html("<b>ZONA " + codzona + ":</b> " + responsable + ">");
                    me.Funciones.DesactivarComboZonaMobile();
                }
            },
            MostrarLinkSeccionMobile: function () {
                var codseccion = me.Variables.entornoHome.CodigoSeccion ? me.Variables.entornoHome.CodigoSeccion : "-1";
                $("#lnk-seccion-mobile").empty();

                if (codseccion != "-1") {
                    var responsable = me.Variables.entornoHome.ResponsableSeccion.length > 20 ? me.Variables.entornoHome.ResponsableSeccion.substring(0, 20) : me.Variables.entornoHome.ResponsableSeccion;

                    $("#lnk-seccion-mobile").html("<b>SECCIÓN " + codseccion + ":</b> " + responsable + ">");
                    me.Funciones.DesactivarComboSeccionMobile();
                }
            },
            LimpiarDatosCampania: function () {
                $("#lbl-home-campania").empty();
                $("#lbl-home-fase").empty();
            },
            LimpiarComboZona: function () {
                $("#cbo-home-zona>option[value!=-1]").remove();
                $("#cbo-home-zona-mobile>option[value!=-1]").remove();
            },
            LimpiarComboSeccion: function () {
                $("#cbo-home-seccion>option[value!=-1]").remove();
                $("#cbo-home-seccion-mobile>option[value!=-1]").remove();
            },
            ActivarComboZona: function () {
                $("#cbo-home-zona").attr("disabled", false);
                $("#cbo-home-zona").removeClass("bloqueoselectFFVV");
            },
            ActivarComboSeccion: function () {
                $("#cbo-home-seccion").attr("disabled", false);
                $("#cbo-home-seccion").removeClass("bloqueoselectFFVV");
            },
            ActivarComboRegion: function () {
                $("#cbo-home-region").attr("disabled", false);
                $("#cbo-home-region").removeClass("bloqueoselectFFVV");
            },
            ActivarComboZonaMobile: function () {
                $("#cbo-home-zona-mobile").css("display", "inline-block");
            },
            ActivarComboSeccionMobile: function () {
                $("#cbo-home-seccion-mobile").css("display", "inline-block");
            },
            ActivarComboRegionMobile: function () {
                $("#cbo-home-region-mobile").css("display", "inline-block");
            },
            ActivarNodoSeccion: function () {
                $("#tr-home-seccion a").removeClass("active");
                if (me.Variables.entornoHome.CodigoSeccion) {
                    $("#tr-home-seccion a[value='" + me.Variables.entornoHome.CodigoSeccion + "']").addClass("active");
                }
            },
            ActivarNodoBase: function () {
                $(".nodo-base").addClass("active");
            },
            DesactivarNodoBase: function () {
                $(".nodo-base").removeClass("active");
            },
            DesactivarNodoSeccion: function () {
                $("#tr-home-seccion a").removeClass("active");
            },
            DesactivarComboRegion: function () {
                $("#cbo-home-region").attr("disabled", true);
                $("#cbo-home-region").addClass("bloqueoselectFFVV");
            },
            DesactivarComboZona: function () {
                $("#cbo-home-zona").attr("disabled", true);
                $("#cbo-home-zona").addClass("bloqueoselectFFVV");
            },
            DesactivarComboSeccion: function () {
                $("#cbo-home-seccion").attr("disabled", true);
                $("#cbo-home-seccion").addClass("bloqueoselectFFVV");
            },
            DesactivarComboZonaMobile: function () {
                $("#cbo-home-zona-mobile").css("display", "none");
            },
            DesactivarComboSeccionMobile: function () {
                $("#cbo-home-seccion-mobile").css("display", "none");
            },
            DesactivarComboRegionMobile: function () {
                $("#cbo-home-region-mobile").css("display", "none");
            },
            ActualizarEntorno: function () {
                var data = JSON.stringify(me.Variables.entornoHome);

                var actualizarEntornoAjax = $.ajax({
                    url: "/Home/ActualizarEntornoSession",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: data,
                    error: function (rqh, status, error) {
                        MostrarMensajeError(rqh);
                    }
                });

                return actualizarEntornoAjax;
            },
            ActivarTab: function (activeTab) {
                $("#tab-indicadores").removeClass('active');
                $("#tab-resumen").removeClass('active');
                $("#tab-datareport").removeClass('active');

                switch (activeTab) {
                    case "tab-indicadores":
                        $("#lnk-prin-inicio").parent("li").addClass("active");
                        $("#lnk-prin-reportes").parent("li").removeClass("active");
                        $('#indicadores-breadcrumb').show();
                        $('#lnk-indicadores').addClass('active');
                        $('#lnk-resumen').removeClass('active');
                        $('#lnk-datareport').removeClass('active');
                        $("#tab-indicadores").addClass('active');
                        break;
                    case "tab-resumen":
                        $("#lnk-prin-inicio").parent("li").addClass("active");
                        $("#lnk-prin-reportes").parent("li").removeClass("active");
                        $('#indicadores-breadcrumb').hide();
                        $('#lnk-indicadores').removeClass('active');
                        $('#lnk-resumen').addClass('active');
                        $('#lnk-datareport').removeClass('active');
                        $("#tab-resumen").addClass('active');
                        break;
                    case "tab-datareport":
                        $("#lnk-prin-inicio").parent("li").removeClass("active");
                        $("#lnk-prin-reportes").parent("li").addClass("active");
                        $('#indicadores-breadcrumb').hide();
                        $('#lnk-indicadores').removeClass('active');
                        $('#lnk-resumen').removeClass('active');
                        $('#lnk-datareport').addClass('active');
                        $("#tab-datareport").addClass('active');
                        break;
                }
            },
            ActualizarBreadCrumb: function () {
                var html = "";

                switch (me.Variables.entornoHome.CodigoRol) {
                    case "DV":
                        if (me.Variables.entornoHome.CodigoRegion != null && me.Variables.entornoHome.CodigoZona == null && me.Variables.entornoHome.CodigoSeccion == null) {
                            html += '<span id="bc-home" class="hidden-xs _pointer">MI PAÍS</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span class="hidden-xs">';
                            html += '<b>REGIÓN ' + me.Variables.entornoHome.CodigoRegion + '</b> : ' + me.Variables.entornoHome.ResponsableRegion;
                            html += '</span>';
                        }

                        if (me.Variables.entornoHome.CodigoRegion != null && me.Variables.entornoHome.CodigoZona != null && me.Variables.entornoHome.CodigoSeccion == null) {
                            html += '<span id="bc-home" class="hidden-xs _pointer">MI PAÍS</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span id="bc-home-region" class="hidden-xs _pointer">REGIÓN ' + me.Variables.entornoHome.CodigoRegion + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span class="hidden-xs">';
                            html += '<b>ZONA ' + me.Variables.entornoHome.CodigoZona + '</b> : ' + me.Variables.entornoHome.ResponsableZona;
                            html += '</span>';
                        }

                        if (me.Variables.entornoHome.CodigoRegion != null && me.Variables.entornoHome.CodigoZona != null && me.Variables.entornoHome.CodigoSeccion != null) {
                            html += '<span id="bc-home" class="hidden-xs _pointer">MI PAÍS</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span id="bc-home-region" class="hidden-xs _pointer">REGIÓN ' + me.Variables.entornoHome.CodigoRegion + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span id="bc-home-zona" class="hidden-xs _pointer">ZONA ' + me.Variables.entornoHome.CodigoZona + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span class="hidden-xs">';
                            html += '<b>SECCIÓN ' + me.Variables.entornoHome.CodigoSeccion + '</b> : ' + me.Variables.entornoHome.ResponsableSeccion;
                            html += '</span>';
                        }
                        break;
                    case "GR":
                        if (me.Variables.entornoHome.CodigoZona != null && me.Variables.entornoHome.CodigoSeccion == null) {
                            html += '<span id="bc-home" class="hidden-xs _pointer">REGIÓN ' + me.Variables.entornoHome.CodigoRegion + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span class="hidden-xs">';
                            html += '<b>ZONA ' + me.Variables.entornoHome.CodigoZona + '</b> : ' + me.Variables.entornoHome.ResponsableZona;
                            html += '</span>';
                        }

                        if (me.Variables.entornoHome.CodigoZona != null && me.Variables.entornoHome.CodigoSeccion != null) {
                            html += '<span id="bc-home" class="hidden-xs _pointer">REGIÓN ' + me.Variables.entornoHome.CodigoRegion + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span id="bc-home-zona" class="hidden-xs _pointer">ZONA ' + me.Variables.entornoHome.CodigoZona + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span class="hidden-xs">';
                            html += '<b>SECCIÓN ' + me.Variables.entornoHome.CodigoSeccion + '</b> : ' + me.Variables.entornoHome.ResponsableSeccion;
                            html += '</span>';
                        }
                        break;
                    case "GZ":
                        if (me.Variables.entornoHome.CodigoSeccion != null) {
                            html += '<span id="bc-home" class="hidden-xs _pointer">ZONA ' + me.Variables.entornoHome.CodigoZona + '</span> ';
                            html += '<img class="separador-1 hidden-xs" src="/Content/images/Path-34.png" /> ';
                            html += '<span class="hidden-xs">';
                            html += '<b>SECCIÓN ' + me.Variables.entornoHome.CodigoSeccion + '</b> : ' + me.Variables.entornoHome.ResponsableSeccion;
                            html += '</span>';
                        }
                        break;
                }
                $("#indicadores-breadcrumb").html(html);
            },
            CargarIndicadorUnete: function () {
                var info = {
                    Region: me.Variables.entornoHome.CodigoRegion,
                    Zona: me.Variables.entornoHome.CodigoZona,
                    CampaniaActual: me.Variables.entornoHome.CampaniaActual,
                    Pais: me.Variables.entornoHome.CodigoPais
                };

                $.ajax({
                    url: "/Unete/GetZonaUneteService",
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: info,
                    success: function (result) {
                        result.EnEvaluacion = result.EnEvaluacion != null ? result.EnEvaluacion : 0;
                        result.PreAprobadas = result.PreAprobadas != null ? result.PreAprobadas : 0;
                        result.Aprobadas = result.Aprobadas != null ? result.Aprobadas : 0;

                        $("#UneteCampaniaActual").text(ObtenerFormatoCampania(me.Variables.entornoHome.CampaniaActual));

                        $("#UneteCantidadEnEvaluacion").text(result.EnEvaluacion);
                        $("#UneteCantidadPreAprobada").text(result.PreAprobadas);
                        $("#UneteCantidadAprobada").text(result.Aprobadas);

                        $("#UneteCantidadEnEvaluacionSeccion").text(result.EnEvaluacion);
                        $("#UneteCantidadPreAprobadaSeccion").text(result.PreAprobadas);
                        $("#UneteCantidadAprobadaSeccion").text(result.Aprobadas);
                    },
                    error: function (xhr, status, error) {
                        MostrarMensajeError(xhr);
                    }
                });
            },
            ObtenerFormatoCampania: function (campania) {
                if (!campania) {
                    return "";
                }

                if (campania.length < 6) {
                    return "";
                }

                return "C-" + campania.substr(4);
            },
            MostrarConsultaCrediticia: function () {
                $("#modal-crediticia").modal("show");
            }
        };

        me.Inicializar = function () {
            me.Funciones.InicializarEventos();
            me.Funciones.CargarInicio();

            //var verSaludoNavidad = ($('#VerSaludoNavidad').val() == "True" ? true : false);

            //if (verSaludoNavidad) {
            //    me.Funciones.activarSaludoNavidenio();
            //}
        };
    }

    index = new Home();

    index.Inicializar();
});