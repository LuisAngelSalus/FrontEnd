var index;

$(document).ready(function () {
    'use strict';
    var Layout;
    Layout = function () {
        var me = this;
        me.Variables = {
            objData: null
        };
        me.Eventos = {};
        me.Funciones = {
            InicializarEventos: function () {
                $("body").on("click", "#configuration-account", me.Funciones.openModal);
            },
            baseUrl: function () {
                var href = window.location.href.split('/');
                return href[0] + '//' + href[2] + '/';
            },
            openModal: function () {
                //$("#AccountSettingModal").modal("show");
                alert('entro');
            },
            CargaInicio: function () {
                var getAccessUserAjax = me.Funciones.GetAccessUser();
                getAccessUserAjax.done(function (result) {
                    console.log(result);
                    me.Funciones.VerifyDefaultCompany();
                });
            },
            GetAccessUser: function () {
                var getAccessUserAjax = $.ajax({
                    url: "/Generals/GetAccess",
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: null,
                    error: function (rqh, status, error) {
                        console.log(rqh);
                    }
                }).done(function (result) {
                    me.Variables.objData = result;
                });
                return getAccessUserAjax;
            },
            VerifyDefaultCompany: function () {
                let username = $("#username").html();
                if (localStorage.getItem('configdefault' + username) == null) {
                    console.log('no entro :c');
                } else {
                    let obj = JSON.parse(localStorage.getItem('configdefault' + username));
                    me.Funciones.buildSideBar(obj);
                }
            },
            buildSideBar: function (obj) {
                let company = me.Variables.objData.Companies.filter((res) => {
                    return res.CompanyId == obj.OwnerCompanyId;
                });
                let roles = company[0].Roles.filter((res) => {
                    return res.RolId == obj.RoleId
                });
                let modules = roles[0].Modules;
                let content = "";
                for (var i = 0; i < modules.length; i++) {
                    content += "<li>";
                    content += "<a href='#'>";
                    content += "<i class='demo-pli-home'></i>";
                    content += "<span class='menu-title'>" + modules[i].ModuleName + "</span>";
                    content += "<i class='arrow'></i>";
                    content += "</a>";
                    content += "<ul class='collapse in'>";
                    for (var ii = 0; ii < modules[i].Options.length; ii++) {
                        content += "<li><a href='" + me.Funciones.baseUrl() + modules[i].Options[ii].Path + "'>" + modules[i].Options[ii].OptionName + "</a></li>";
                    }
                    content += "</ul>";
                    content += "</li>";
                }
                $("#mainnav-menu").empty();
                $("#mainnav-menu").append(content);
            }
        };
        me.Inicializar = function () {
            me.Funciones.InicializarEventos();
            me.Funciones.CargaInicio();
        };
    };
    index = new Layout();
    index.Inicializar();
});