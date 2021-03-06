﻿var APIController = (function () {

    var saveCompany = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Company/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });



    }

    

    var viewContactsByCompany = function (id) {
        return new Promise((resolve, reject) => {
            let url = '/Company/Contacts?companyId=' + id
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveQuotation = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var updateQuotation = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/Update', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var newVersionQuotation = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/NewVersion', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var profile = function (id) {
        return new Promise((resolve, reject) => {
            let url = '/Quotation/GetProfile?profileId=' + id
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    //var infoSunat = function (ruc) {
    //    return new Promise((resolve, reject) => {
    //        let url = '/InfoSunat/Info?ruc=' + ruc
    //        fetch(url, {
    //            headers: { 'Content-Type': 'application/json' }
    //        })
    //            .then(res => res.json())
    //            .then(data => {
    //                return resolve(data);
    //            }).catch(err => { console.log(err); reject() });

    //    });



    //}

    var infoSunat = function (parameter) {

        var data = {
            ruc: parameter
        };

        var infoSunatAjax = $.ajax({
            url: "/InfoSunat/Info",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            error: function (rqh, status, error) {
                console.log(rqh);
            }
        }).done(function (result) {
            console.log(result);
        });
        return infoSunatAjax;
    }

    var CompanyByRuc = function (ruc) {
        return new Promise((resolve, reject) => {

            let url = '/Company/CompanyByRuc?ruc=' + ruc
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var saveProtocolProfile = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/ProtocolProfile/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var ddlProtocolProfile = function () {
        return new Promise((resolve, reject) => {

            fetch('/ProtocolProfile/DropdownList', {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var autocompleteProtocolProfile = function (value) {
        return new Promise((resolve, reject) => {

            fetch('/ProtocolProfile/Autocomplete?value=' + value, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var secuential = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Secuential/GetSecuential', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var filterQuotation = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/Filter', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var getQuotation = function (id) {
        return new Promise((resolve, reject) => {
            let url = '/Quotation/GetQuotation?id=' + id;
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var saveQuoteTracking = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/QuoteTracking/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var updateQuoteTracking = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/QuoteTracking/Update', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var quotationtracking = function (id) {
        return new Promise((resolve, reject) => {
            let url = '/QuoteTracking/GetQuoteTracking?id=' + id
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var components = function () {
        return new Promise((resolve, reject) => {
            fetch('/Quotation/GetComponents', {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var versions = function (code) {
        return new Promise((resolve, reject) => {
            let url = '/Quotation/GetVersions?code=' + code
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var updateProccessQuotation = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/UpdateProccess', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var AccessUser = function () {
        return new Promise((resolve, reject) => {
            fetch('/Generals/GetAccess', {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var Dashboard = function (roleId) {
        return new Promise((resolve, reject) => {
            fetch('/Generals/Index?RoleId=' + roleId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res)
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var PriceList = function (companyId) {
        return new Promise((resolve, reject) => {
            fetch('/Quotation/ListPrice?CompanyId=' + companyId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var setPrice = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/SetPrice', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var systemUsers = function () {
        return new Promise((resolve, reject) => {
            fetch('/SystemUser/GetAllSystemUser', {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var roles = function () {
        return new Promise((resolve, reject) => {
            fetch('/Role/Roles', {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var ownerCompanies = function () {
        return new Promise((resolve, reject) => {
            fetch('/OwnerCompany/GetAll', {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var user = function (userId) {
        return new Promise((resolve, reject) => {
            fetch('/SystemUser/GetUser?userId=' + userId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var person = function (personId) {
        return new Promise((resolve, reject) => {
            fetch('/Person/GetPerson?personId=' + personId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var savePerson = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Person/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var updatePerson = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Person/Update', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var saveUSer = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/SystemUser/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var updateUser = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/SystemUser/Update', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveAccess = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/SystemUser/SaveAccess', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var CompanyByName = function (value) {
        return new Promise((resolve, reject) => {
            fetch('/Company/AutocompleteByName?value=' + value, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var ProtocolsByCompany = function (companyId) {
        return new Promise((resolve, reject) => {
            fetch('/Protocol/GetProtocolsByCompany?id=' + companyId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var ProtocolDetailByProtocolId = function (protocolId) {
        return new Promise((resolve, reject) => {
            fetch('/ProtocolDetail/GetProtocolDetailByProtocol?id=' + protocolId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveProtocol = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Protocol/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveProtocolDetail = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/ProtocolDetail/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var migrateQuotationToProtocols = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Quotation/MigrateQuotationToProtocols', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getKeyPublic = function () {
        return new Promise((resolve, reject) => {
            fetch('/Suscription/GetKeyPublic', {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveSuscription = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Suscription/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var pushNotification = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Suscription/Push', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var accountSettingBySystemUserId = function () {
        return new Promise((resolve, reject) => {
            fetch('/AccountSetting/GetAccountSettingBySystemUserId', {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveAccountSetting = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/AccountSetting/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var updateAccountSetting = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/AccountSetting/Update', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var trackingChart = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Quotation/Trackingchart', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
    }

    var sendMail = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Email/SendMail', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var migrateToProtocolSIGESoftWin = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Quotation/MigrateProtocolToSIGESoftWin', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getWorkerData = function () {
        return new Promise((resolve, reject) => {
            fetch('/Worker/GetDataWorker', {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var updateWorkerData = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/Worker/UpdateWorkerData', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var clientsUsersForCompany = function () {
        return new Promise((resolve, reject) => {
            fetch('/ClientUser/ClientsUsersForCompany', {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var saveClientUser = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/ClientUser/Save', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var updateClientUser = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/ClientUser/Update', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getClientUser = function (clientUserId) {
        return new Promise((resolve, reject) => {
            fetch('/ClientUser/GetById?clientUserId=' + clientUserId, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var changePassClientUser = function (parameters) {
        return new Promise((resolve, reject) => {
            fetch('/ClientUser/ChangePassword', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var updateCompanyClientUser = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/ClientUser/UpdateCompany', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });

    }

    var uploadExcelSchedule = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Schedule/Upload', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getComponentsByName = function (value) {
        return new Promise((resolve, reject) => {
            fetch('/Schedule/GetComponentsByName?value=' + value, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getAdditionalComponents = function (id) {
        return new Promise((resolve, reject) => {
            fetch('/Schedule/GetAdditionalComponents?protocolId=' + id, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var validateUserCompany = function (ruc) {
        return new Promise((resolve, reject) => {
            fetch('/Company/ValidateUserCompany?ruc=' + ruc, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var schedule = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Schedule/Schedule', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getAttachForQuotation = function (parameters) {        
        return new Promise((resolve, reject) => {
            fetch('/Quotation/getAttachForQuotation?id=' + parameters.id, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var searchReception = function (parameters) {
        return new Promise((resolve, reject) => {

            fetch('/Reception/Search', {
                method: 'POST',
                body: JSON.stringify(parameters),
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    var getDataSchedule = function (idSchedule) {
        return new Promise((resolve, reject) => {
            fetch('/Reception/GetDataSchedule?scheduleId=' + idSchedule, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });
        });
    }

    return {
        SaveCompany: function (parameters) {
            return new Promise((resolve, reject) => {
                saveCompany(parameters).then(res => resolve(res));
            });
        },

        SaveLogoCompany: function (data, myID) {
            return saveLogoCompany(data, myID);
        },

        GetContacts: function (companyId) {
            return new Promise((resolve, reject) => {
                viewContactsByCompany(companyId).then(res => resolve(res));
            });
        },

        GetProfile: function (ProfileId) {
            return new Promise((resolve, reject) => {
                profile(ProfileId).then(res => resolve(res));
            });
        },

        GetInfoSunat: function (ruc) {
            return new Promise((resolve, reject) => {
                infoSunat(ruc)
                    .then(res => resolve(res))
                    .catch(err => { reject(err); });
            });
        },

        GetCompanyByRuc: function (ruc) {
            return new Promise((resolve, reject) => {
                CompanyByRuc(ruc)
                    .then(res => resolve(res))
                    .catch(err => { reject(err); });
            });
        },

        SaveProtocolProfile: function (parameters) {
            return new Promise((resolve, reject) => {
                saveProtocolProfile(parameters).then(res => resolve(res));
            });
        },

        GetddlProtocolProfile: function () {
            return new Promise((resolve, reject) => {
                ddlProtocolProfile().then(res => resolve(res));
            });
        },

        AutocompleteProtocolProfile: function (value) {
            return new Promise((resolve, reject) => {
                autocompleteProtocolProfile(value).then(res => resolve(res));
            });
        },

        SaveQuotation: function (parameters) {
            return new Promise((resolve, reject) => {
                saveQuotation(parameters).then(res => resolve(res));
            });
        },

        NewVersionQuotation: function (parameters) {
            return new Promise((resolve, reject) => {
                newVersionQuotation(parameters).then(res => resolve(res));
            });
        },

        UpdateQuotation: function (parameters) {
            return new Promise((resolve, reject) => {
                updateQuotation(parameters).then(res => resolve(res));
            });
        },

        GetSecuential: function (parameters) {
            return new Promise((resolve, reject) => {
                secuential(parameters).then(res => resolve(res));
            });
        },

        FilterQuotation: function (parameters) {
            return new Promise((resolve, reject) => {
                filterQuotation(parameters).then(res => resolve(res));
            });
        },

        GetQuotation: function (id) {
            return new Promise((resolve, reject) => {
                getQuotation(id).then(res => resolve(res));
            });
        },

        SaveQuoteTracking: function (parameters) {
            return new Promise((resolve, reject) => {
                saveQuoteTracking(parameters).then(res => resolve(res));
            });
        },

        GetQuotationtracking: function (id) {
            return new Promise((resolve, reject) => {
                quotationtracking(id).then(res => resolve(res));
            });
        },

        UpdateQuoteTracking: function (parameters) {
            return new Promise((resolve, reject) => {
                updateQuoteTracking(parameters).then(res => resolve(res));
            });
        },

        GetComponents: function () {
            return new Promise((resolve, reject) => {
                components().then(res => resolve(res));
            });
        },

        GetVersions: function (code) {
            return new Promise((resolve, reject) => {
                versions(code).then(res => resolve(res));
            });
        },

        UpdateProccessQuotation: function (parameters) {
            return new Promise((resolve, reject) => {
                updateProccessQuotation(parameters).then(res => resolve(res));
            });
        },

        GetAccessUser: function () {
            return new Promise((resolve, reject) => {
                AccessUser().then(res => resolve(res));
            });
        },

        GetDashboard: function (roleId) {
            return new Promise((resolve, reject) => {
                Dashboard(roleId).then(res => resolve(res));
            });
        },

        GetPriceList: function (companyId) {
            return new Promise((resolve, reject) => {
                PriceList(companyId).then(res => resolve(res));
            });
        },

        SetPrice: function (parameters) {
            return new Promise((resolve, reject) => {
                setPrice(parameters).then(res => resolve(res));
            });
        },

        GetAllSystemUser: function () {
            return new Promise((resolve, reject) => {
                systemUsers().then(res => resolve(res));
            });
        },

        GetRoles: function () {
            return new Promise((resolve, reject) => {
                roles().then(res => resolve(res));
            });
        },

        GetOwnerCompanies: function () {
            return new Promise((resolve, reject) => {
                ownerCompanies().then(res => resolve(res));
            });
        },

        GetUser: function (userId) {
            return new Promise((resolve, reject) => {
                user(userId).then(res => resolve(res));
            });
        },

        GetPerson: function (personId) {
            return new Promise((resolve, reject) => {
                person(personId).then(res => resolve(res));
            });
        },

        SavePerson: function (parameters) {
            return new Promise((resolve, reject) => {
                savePerson(parameters).then(res => resolve(res));
            });
        },

        UpdatePerson: function (parameters) {
            return new Promise((resolve, reject) => {
                updatePerson(parameters).then(res => resolve(res));
            });
        },

        SaveUser: function (parameters) {
            return new Promise((resolve, reject) => {
                saveUSer(parameters).then(res => resolve(res));
            });
        },

        UpdateUser: function (parameters) {
            return new Promise((resolve, reject) => {
                updateUser(parameters).then(res => resolve(res));
            });
        },

        SaveAccess: function (parameters) {
            return new Promise((resolve, reject) => {
                saveAccess(parameters).then(res => resolve(res));
            });
        },

        AutocompleteCompanyByName: function (value) {
            return new Promise((resolve, reject) => {
                CompanyByName(value).then(res => resolve(res));
            });
        },

        GetAllProtocolsByCompany: function (id) {
            return new Promise((resolve, reject) => {
                ProtocolsByCompany(id).then(res => resolve(res));
            });
        },

        GetProtocolDetailByProtocolId: function (id) {
            return new Promise((resolve, reject) => {
                ProtocolDetailByProtocolId(id).then(res => resolve(res));
            });
        },

        SaveProtocol: function (parameters) {
            return new Promise((resolve, reject) => {
                saveProtocol(parameters).then(res => resolve(res));
            });
        },

        SaveProtocolDetail: function (parameters) {
            return new Promise((resolve, reject) => {
                saveProtocolDetail(parameters).then(res => resolve(res));
            });
        },

        MigrateQuotationToProtocols: function (parameters) {
            return new Promise((resolve, reject) => {
                migrateQuotationToProtocols(parameters).then(res => resolve(res));
            });
        },

        GetKeyPublic: function () {
            return new Promise((resolve, reject) => {
                getKeyPublic().then(res => resolve(res));
            });
        },

        SaveSuscription: function (parameters) {
            return new Promise((resolve, reject) => {
                saveSuscription(parameters).then(res => resolve(res));
            });
        },

        PushNotification: function (parameters) {
            return new Promise((resolve, reject) => {
                pushNotification(parameters).then(res => resolve(res));
            });
        },

        GetAccountSettingBySystemUserId: function () {
            return new Promise((resolve, reject) => {
                accountSettingBySystemUserId().then(res => resolve(res));
            });
        },

        SaveAccountSetting: function (parameters) {
            return new Promise((resolve, reject) => {
                saveAccountSetting(parameters).then(res => resolve(res));
            });
        },

        UpdateAccountSetting: function (parameters) {
            return new Promise((resolve, reject) => {
                updateAccountSetting(parameters).then(res => resolve(res));
            });
        },

        TrackingChart: function (parameters) {
            return new Promise((resolve, reject) => {
                trackingChart(parameters).then(res => resolve(res));
            });
        },

        MigrateToProtocolSIGESoftWin: function (parameters) {
            return new Promise((resolve, reject) => {
                migrateToProtocolSIGESoftWin(parameters).then(res => resolve(res));
            });
        },

        GetWorkerData: function () {
            return new Promise((resolve, reject) => {
                getWorkerData().then(res => resolve(res));
            });
        },

        UpdateWorkerData: function (parameters) {
            return new Promise((resolve, reject) => {
                updateWorkerData(parameters).then(res => resolve(res));
            });
        },

        SendMail: function (parameters) {
            return new Promise((resolve, reject) => {
                sendMail(parameters).then(res => resolve(res));
            });
        },

        ClientsUsersForCompany: function () {
            return new Promise((resolve, reject) => {
                clientsUsersForCompany().then(res => resolve(res));
            });
        },

        SaveClientUser: function (parameters) {
            return new Promise((resolve, reject) => {
                saveClientUser(parameters).then(res => resolve(res));
            });
        },

        UpdateClientUser: function (parameters) {
            return new Promise((resolve, reject) => {
                updateClientUser(parameters).then(res => resolve(res));
            });
        },

        GetClientUser: function (clientUserId) {
            return new Promise((resolve, reject) => {
                getClientUser(clientUserId).then(res => resolve(res));
            });
        },

        ChangePassClientUser: function (parameters) {
            return new Promise((resolve, reject) => {
                changePassClientUser(parameters).then(res => resolve(res));
            });
        },

        UpdateCompanyClientUser: function (parameters) {
            return new Promise((resolve, reject) => {
                updateCompanyClientUser(parameters).then(res => resolve(res));
            });
        },

        UploadExcelSchedule: function (parameters) {
            return new Promise((resolve, reject) => {
                uploadExcelSchedule(parameters).then(res => resolve(res));
            });
        },

        GetComponentsByName: function (parameters) {
            return new Promise((resolve, reject) => {
                getComponentsByName(parameters).then(res => resolve(res));
            });
        },

        GetAdditionalComponents: function (parameters) {
            return new Promise((resolve, reject) => {
                getAdditionalComponents(parameters).then(res => resolve(res));
            });
        },

        ValidateUserCompany: function (parameters) {
            return new Promise((resolve, reject) => {
                validateUserCompany(parameters).then(res => resolve(res));
            });
        },

        Schedule: function (parameters) {
            return new Promise((resolve, reject) => {
                schedule(parameters).then(res => resolve(res));
            });
        },

        GetAttachForQuotation: function (parameters) {
            return new Promise((resolve, reject) => {
                getAttachForQuotation(parameters).then(res => resolve(res));
            });
        },

        SearchReception: function (parameters) {
            return new Promise((resolve, reject) => {
                searchReception(parameters).then(res => resolve(res));
            });
        },

        GetDataSchedule: function (idSchedule) {
            return new Promise((resolve, reject) => {
                getDataSchedule(idSchedule).then(res => resolve(res));
            });
        }
    }

})();