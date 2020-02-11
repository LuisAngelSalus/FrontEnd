var objPriceListMigration = {}

function openMigrateProtocol() {
    if ($("#txtCompanyId").val() == 0) {
        swal("Validación", "¡Seleccione una empresa!", "error");
        return;
    }

    GetPriceListByCompany();

    $("#MigrateProtocolModal").modal("show");    
    $("#txtCompany").autocomplete({        
        minLength: 4,
        delay:1000,
        source: function (request, response) {            
            APIController.AutocompleteCompanyByName(request.term).then((data) => {
                var result = data.Data;
                var array = result.map((res) => {
                    return { "label": res.Name, "value": res.CompanyId }                     
                });                
                response(array);
            });
        },
        open: function () {
            $(this).autocomplete('widget').css('z-index', 8000);
            return false;   
        },
        select: function (event, ui) {
            console.log("UI", ui.item.value);  
            let idCompany = ui.item.value;
            APIController.GetAllProtocolsByCompany(idCompany).then((res) => {
                renderTableProtocols(res.Data);
            });
            $(this).val(ui.item.label);
            return false;
        }
    });   

}

function renderTableProtocols(data) {
    let content = "";
    for (var i = 0; i < data.length; i++) {
        content += "<tr>";
        content += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="protocol-' + data[i].ProtocolId + '" value="check"> <label for="protocol-' + data[i].ProtocolId +'"></label> </div></td>'
        content += "<td>" + data[i].ProtocolId + "</td>";
        content += "<td>" + data[i].ServiceTypeName + "</td>";
        content += "<td>" + data[i].ProtocolName + "</td>";
        content += "<td>" + data[i].TypeFormatName + "</td>";
        content += "<td></td>";
        content += "<td></td>";
        content += "</tr>";
    }
        
    $("#table-protocols tbody").empty();   
    $("#table-protocols tbody").append(content);
}

function GetPriceListByCompany() {
    APIController.GetPriceList($("#txtCompanyId").val()).then((res) => {       
        objPriceListMigration = res.Data;
    });
}

$('#table-protocols tbody').on('change', '.checkbox', function (event) {
    if (event.target.checked) {
        let protocolId = event.target.id;
        renderTableDetailProtocol(protocolId.split('-')[1]);
        console.log("protocolId", protocolId);
    } else {
        let protocolId = event.target.id;
        console.log("protocolId", protocolId);
    }
});

function renderTableDetailProtocol(idProtocol) {
    APIController.GetProtocolDetailByProtocolId(idProtocol).then((res) => {
        let data = res.Data;
        let content = "";
        for (var i = 0; i < data.length; i++) {
            content += "<tr>";            
            content += "<td>" + data[i].CategoryName + "</td>";
            content += "<td>" + data[i].ComponentName + "</td>";
            content += "<td>" + data[i].MinPrice + "</td>";
            content += "<td>" + data[i].PriceList + "</td>";
            content += "<td>" + data[i].SalePrice + "</td>";
            content += "<td>eliminar</td>";
            content += "<td></td>";
            content += "<td></td>";
            content += "</tr>";
        }

        $("#table-Protocol-Detail tbody").empty();
        $("#table-Protocol-Detail tbody").append(content);
    });
}

