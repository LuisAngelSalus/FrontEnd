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
                $("body").on("click", "#btn-configuration-save", me.Funciones.SaveConfig);
            },
            baseUrl: function () {
                var href = window.location.href.split('/');
                return href[0] + '//' + href[2] + '/';
            },
            CargaInicio: function () {
                var getAccessUserAjax = me.Funciones.GetAccessUser();
                getAccessUserAjax.done(function (result) {
                    console.log(result);
                    me.Funciones.ddlConfCompanyChange();
                    me.Funciones.VerifyDefaultCompany();
                    //me.Funciones.SwEnabled();
                });
            },
            SaveAccountSetting: function (parameters) {
                var saveAccountSettingAjax = $.ajax({
                    url: "/AccountSetting/Save",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(parameters),
                    error: function (rqh, status, error) {
                        console.log(rqh);
                    }
                }).done(function (result) {
                    console.log(result);
                });
                return saveAccountSettingAjax;
            },
            UpdateAccountSetting: function (parameters) {
                var updateAccountSettingAjax = $.ajax({
                    url: "/AccountSetting/Update",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(parameters),
                    error: function (rqh, status, error) {
                        console.log(rqh);
                    }
                }).done(function (result) {
                    console.log(result);
                });
                return updateAccountSettingAjax;
            },
            AccountSettingBySystemUserId: function () {
                var accountSettingBySystemUserIdAjax = $.ajax({
                    url: "/AccountSetting/GetAccountSettingBySystemUserId",
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: null,
                    error: function (rqh, status, error) {
                        console.log(rqh);
                    }
                }).done(function (result) {
                    console.log(result);
                });
                return accountSettingBySystemUserIdAjax;
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
                    var accountSettingBySystemUserIdAjax = me.Funciones.AccountSettingBySystemUserId();
                    accountSettingBySystemUserIdAjax.done(function (result) {
                        let data = result;
                        if (data == null) {
                            $("#AccountSettingModal").modal("show");
                        } else {
                            $('#ddlConfCompany').val(data.OwnerCompanyId).trigger('change');
                            $("#ddlConfRole").val(data.RoleId);
                            buildSideBar({
                                "OwnerCompanyId": data.OwnerCompanyId,
                                "RoleId": data.RoleId,
                            });
                            me.Variables.SaveConfigAccountCache();
                        }
                    });
                } else {
                    let obj = JSON.parse(localStorage.getItem('configdefault' + username));
                    $('#ddlConfCompany').val(obj.OwnerCompanyId);
                    $('#ddlConfCompany').val(obj.OwnerCompanyId).trigger('change');
                    $("#ddlConfRole").val(obj.RoleId);
                    me.Funciones.buildSideBar(obj);
                }
            },
            ddlConfCompanyChange: function () {
                $('#ddlConfCompany').change(function () {
                    var id = $("#ddlConfCompany option:selected").val();
                    let content = "";

                    let company = me.Variables.objData.Companies.filter((rep) => {
                        return rep.CompanyId == id;
                    });
                    let roles = company[0].Roles;
                    content += "<option value='-1'>--Seleccionar--</option>";
                    for (const index in roles) {
                        content += "<option value='" + roles[index].RolId + "'>" + roles[index].RolName + "</option>";
                    }
                    $("#ddlConfRole").empty();
                    $("#ddlConfRole").append(content);
                });
            },
            buildSideBar: function (obj) {
                let company = me.Variables.objData.Companies.filter((res) => {
                    return res.CompanyId == obj.OwnerCompanyId;
                });
                let roles = company[0].Roles.filter((res) => {
                    return res.RolId == obj.RoleId;
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
                    content += "<ul class='collapse'>";
                    for (var ii = 0; ii < modules[i].Options.length; ii++) {
                        content += "<li><a href='" + me.Funciones.baseUrl() + modules[i].Options[ii].Path + "'>" + modules[i].Options[ii].OptionName + "</a></li>";
                    }
                    content += "</ul>";
                    content += "</li>";
                }
                // $("#mainnav-menu").empty();
                //$("#mainnav-menu").append(content);
            },
            SaveConfigAccountCache: function () {
                let username = $("#username").html();
                var obj = {
                    "OwnerCompanyId": $("#ddlConfCompany option:selected").val(),
                    "RoleId": $("#ddlConfRole option:selected").val(),
                };
                localStorage.setItem('configdefault' + username, JSON.stringify(obj));
            },
            SaveConfig: function () {
                let username = $("#username").html();
                let data = {
                    OwnerCompanyId: $("#ddlConfCompany option:selected").val(),
                    RoleId: $("#ddlConfRole option:selected").val()
                }

                if (localStorage.getItem('configdefault' + username) == null) {
                    var saveAccountSettingAjax = me.Funciones.SaveAccountSetting(data);
                    saveAccountSettingAjax.done(function (result) {
                        me.Funciones.buildSideBar(result.Data);
                    });
                } else {
                    var updateAccountSettingAjax = me.Funciones.UpdateAccountSetting(data);
                    updateAccountSettingAjax.done(function (result) {
                        me.Funciones.SaveConfigAccountCache();
                        me.Funciones.buildSideBar(result.Data);
                    });
                }
            },
            SwEnabled: function () {
                if (navigator.serviceWorker) {
                    window.addEventListener("load", function () {
                        navigator.serviceWorker.register("/sw.js").then(function (reg) {
                            swReg = reg;
                            swReg.pushManager.getSubscription().then(verifySubscription);
                        });
                    });
                }
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