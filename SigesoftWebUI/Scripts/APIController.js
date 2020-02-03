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

        GetComponents: function() {
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
    }

})();