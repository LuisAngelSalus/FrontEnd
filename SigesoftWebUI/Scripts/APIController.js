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

    var quotation = function (id) {
        return new Promise((resolve, reject) => {
            let url = '/Quotation/RegisterQuotation?id=' + id
            fetch(url, {
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

        GetQuotation: function (quotationId) {
            return new Promise((resolve, reject) => {
                quotation(quotationId).then(res => resolve(res));
            });
        },

        GetProfile: function (ProfileId) {
            return new Promise((resolve, reject) => {
                profile(ProfileId).then(res => resolve(res));
            });
        }

    }

})();