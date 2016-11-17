var ViewModel = function () {
    var self = this;
    self.guids = ko.observableArray(); // this is used in index.cshtml for databinding
    self.newGuid = {
        Id: ko.observable(),
        FQDN: ko.observable(),
        DSCGuid: ko.observable()
    }
    self.error = ko.observable();

    var guidsUri = '/api/myguids/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllGuids() {
        ajaxHelper(guidsUri, 'GET').done(function (data) {
            self.guids(data);
        });
    }


    self.addGuid = function (formElement) {
        var DSCguid = {
            ID: self.newGuid.Id(),
            FQDN: self.newGuid.FQDN(),
            DSCGuid: self.newGuid.DSCGuid()
        };

        ajaxHelper(guidsUri, 'POST', DSCguid).done(function (item) {
            self.guids.push(item);
        });
    }

    // Fetch the initial data. Show all GUIDs from Nodes
    getAllGuids();

};

ko.applyBindings(new ViewModel());