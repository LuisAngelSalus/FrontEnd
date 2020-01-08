var APIController = (function () {

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

    var infoSunat = function (ruc) {
        return new Promise((resolve, reject) => {            
            let url = '/InfoSunat/Info?ruc=' + ruc
            fetch(url, {
                headers: { 'Content-Type': 'application/json' }
            })
                .then(res => res.json())
                .then(data => {
                    return resolve(data);
                }).catch(err => { console.log(err); reject() });

        });
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

    var secuential = function (parameters){
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

    return {
        SaveCompany: function (parameters) {
            return new Promise((resolve, reject) => {
                saveCompany(parameters).then(res => resolve(res));
            });
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

        SaveQuotation: function (parameters) {
            return new Promise((resolve, reject) => {                
                saveQuotation(parameters).then(res => resolve(res));
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
        }
    }

})();