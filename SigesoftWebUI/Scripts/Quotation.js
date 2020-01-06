﻿
    var obj = {};
$(document).ready(function () {

    CalculateTotals();
        $('.table-main').on('change paste keyup', '.salePrice', function (e) {
        CalculateTotals();
    });

    $('.tables-profile').on('change paste keyup', '.salepriceValue', function (e) {
        let componentId = $($(this).parent().parent().get(0)).find('input').get(0).id;
        var component = obj.profileComponents.find(p => p.componentId == componentId);
            if (component != undefined) {    
            RemoveItemObj(componentId);    
            AddItemObj(componentId, $(this).parent().parent().get(0));    
        }

    });

    $('.modal-content').on('change', '.checkbox', function (event) {
            if (event.target.checked) {
        ProcessObj(event.target.id, $(this).parent().parent().get(0), true);
            } else {
        ProcessObj(event.target.id, $(this).parent().parent().get(0), false);
        }
    });

    $('#txtRuc').change(function () {
        let ruc = $('#txtRuc').val();
        $('#ddlSede').empty();
        SearchCompany(ruc);
    });

});

$('#profile').change(function () {
        $("#tbody-profile").text("obteniendo información");
    $("#tbody-profile-unselectd").text("obteniendo información");
    var idProfile = $("#profile option:selected").val();
        APIController.GetProfile(idProfile).then((res) => {
        LoadObj(res);
    var data = res.Data.categories;
    var unselectedData = res.Data.UnselectedCategories;

    //---------------Table-Profile---------------------------
    var content = "";
            for (var i = 0; i < data.length; i++) {
        content += '<tr id="cat-' + data[i].CategoryId + '">';
                content += '<td style="width:20px;"></th><i class="fa fa-plus text-inverse m-r-10" onclick=showComponets("cat-' + data[i].CategoryId + '")></i></td > ';
content += '<td>' + data[i]["CategoryName"] + '</td>';
content += '</tr>'

content += '<tr class="cat-' + data[i].CategoryId + '" style="display:none">';
content += '<td colspan="2">';
content += '<table class="table-examenes-profile">';
content += '<thead><th></th><th style="display:none"></th><th style="display:none"></th><th>Examen</th><th>Precio Min</th><th>Precio Lista</th> <th>Precio Venta</th></thead>';
content += '<tboby>';
for (var ii = 0; ii < data[i].Detail.length; ii++) {
    content += '<tr>';

    if (data[i].Detail[ii].Active) {
        content += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="' + data[i].Detail[ii].ComponentId + '" value="check" checked> <label for="' + data[i].Detail[ii].ComponentId + '"></label></div></td>'
    } else {
        content += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="' + data[i].Detail[ii].ComponentId + '" value="check"> <label for="' + data[i].Detail[ii].ComponentId + '"></label></div></td>'
    }
    content += '<td class="catId" style="display:none">';
    content += data[i].Detail[ii].CategoryId;
    content += '</td>';

    content += '<td class="catname" style="display:none">';
    content += data[i].CategoryName;
    content += '</td>';

    content += '<td class="compname">';
    content += data[i].Detail[ii].ComponentName;
    content += '</td>';
    content += '<td class="minprice" style="text-align: center;"><label>' + data[i].Detail[ii].MinPrice + '</label></td>';
    content += '<td class="listprice" style="text-align: center;"><label>' + data[i].Detail[ii].ListPrice + '</label></td>';
    content += '<td class="saleprice" style="text-align: center;"><input class="salepriceValue" type="text" value="' + data[i].Detail[ii].SalePrice + '" style="width:80px"> </td>';
    content += '</tr>';
}
content += '</tboby>';
content += '</table>';
content += '</td>';
content += '</tr>';
            }

$("#tbody-profile").empty();
$("#tbody-profile").append(content);
//-----------------------------------------------

//---------------UnSelectd-----------------------
var contentUn = "";
for (var i = 0; i < unselectedData.length; i++) {
    contentUn += '<tr id="uncat-' + unselectedData[i].CategoryId + '">';
    contentUn += '<td  style="width:20px;"><i class="fa fa-plus text-inverse m-r-10" onclick=showComponets("uncat-' + unselectedData[i].CategoryId + '")></i></td>';
    contentUn += '<td>' + unselectedData[i]["CategoryName"] + '</td>';
    contentUn += '</tr>'

    contentUn += '<tr class="uncat-' + unselectedData[i].CategoryId + '" style="display:none">';
    contentUn += '<td colspan="2">';
    contentUn += '<table class="table-examenes-profile-UnSelected">';
    contentUn += '<thead><th></th><th style="display:none"></th><th style="display:none"></th><th>Examen</th><th>Precio Min</th><th>Precio Lista</th> <th>Precio Venta</th></thead>';
    contentUn += '<tboby>';
    for (var ii = 0; ii < unselectedData[i].Detail.length; ii++) {
        contentUn += '<tr>';
        if (unselectedData[i].Detail[ii].Active) {
            contentUn += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="' + unselectedData[i].Detail[ii].ComponentId + '" value="check" checked> <label for="' + unselectedData[i].Detail[ii].ComponentId + '"></label></div></td>'
        } else {
            contentUn += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="' + unselectedData[i].Detail[ii].ComponentId + '" value="check"> <label for="' + unselectedData[i].Detail[ii].ComponentId + '"></label></div></td>'
        }
        contentUn += '<td class="catId" style="display:none">';
        contentUn += unselectedData[i].Detail[ii].CategoryId;
        contentUn += '</td>';

        contentUn += '<td class="catname" style="display:none">';
        contentUn += unselectedData[i].CategoryName;
        contentUn += '</td>';

        contentUn += '<td class="compname">';
        contentUn += unselectedData[i].Detail[ii].ComponentName;
        contentUn += '</td>';
        contentUn += '<td class="minprice" style="text-align: center;"><label>' + unselectedData[i].Detail[ii].MinPrice + '</label></td>';
        contentUn += '<td class="listprice" style="text-align: center;"><label>' + unselectedData[i].Detail[ii].ListPrice + '</label></td>';
        contentUn += '<td class="saleprice" style="text-align: center;"><input class="salepriceValue" type="text" value="' + unselectedData[i].Detail[ii].SalePrice + '" style="width:80px"> </td>';
        contentUn += '</tr>';
    }

    contentUn += '</tboby>';
    contentUn += '</table>';


    contentUn += '</td>';
    contentUn += '</tr>';
}
$("#tbody-profile-unselectd").empty();
$("#tbody-profile-unselectd").append(contentUn);
            //-----------------------------------------------


        });

    });

$('.textarea_editor').wysihtml5();

function InfoSunat(ruc) {
    APIController.GetInfoSunat(ruc).then((res) => {
        console.log("res", res);
        swal("Búsqueda correcta");
        SaveCompany(res.Data);

    }).catch((res) => {
        swal.close();
        $('#txtCompanyName').val("");
        $('#txtDistric').val("");
        $('#txtAddress').val("");
        $('#txtCompanyName').attr('readonly', false);
        $('#txtDistric').attr('readonly', false);
        $('#txtAddress').attr('readonly', false);
    });
}

function show(value) {
    var td = $($("#" + value + " td")[0]).find("i");

    let pClass = '.' + value;
    if ($(pClass).css("display") == "none") {
        $(pClass).fadeIn(1000);
        $(pClass).show();
        td.addClass('fa-minus');
        td.removeClass('fa-plus');
    }
    else {
        $(pClass).hide();
        td.removeClass('fa-minus');
        td.addClass('fa-plus');
    }
}

function openModal() {
    $('#chkProfile').prop('checked', false);
    $('#profile').empty();

    APIController.GetddlProtocolProfile().then((resp) => {
        let content = "";
        content += "<option value='-1'>--Seleccionar--</option>";
        for (var i = 0; i < resp.Data.length; i++) {
            content += "<option value='" + resp.Data[i].Id + "'>" + resp.Data[i].Value + "</option>";
        }

        $('#profile').append(content);
    });

    $('#profile').val(-1).trigger('change');
    $('#tbody-profile').empty();
    $('#tbody-profile-unselectd').empty();
    $("#perfilModal").modal("show");
}

function showComponets(value) {
    var td = $($("#" + value + " td")[0]).find("i");

    let pClass = '.' + value;
    //console.log(pClass);
    if ($(pClass).css("display") == "none") {
        $(pClass).fadeIn(1000);
        $(pClass).show();
        td.addClass('fa-minus');
        td.removeClass('fa-plus');
    }
    else {
        $(pClass).hide();
        td.removeClass('fa-minus');
        td.addClass('fa-plus');
    }
}

function CalculateTotals() {
    var sumTotal = 0;
    var compTotal = 0;
    $(".table-main > tbody > .child").each(function (index, tr) {
        var sumSubTotal = 0;
        var sales = $(tr).find('.salePrice');
        $(sales).each(function () {
            var value = $(this).get(0).value;
            //obtener el SUBTOTAL
            if (!isNaN(value) && value.length != 0) {
                sumSubTotal += parseFloat(value);
            }
        });

        var parent = $(tr).prev().get(0);
        $(parent).find('.subTotal').text(sumSubTotal);
        $(parent).find('.counterComp').text(sales.length);

        //obtener el TOTAL
        if (!isNaN(sumSubTotal)) {
            sumTotal += parseFloat(sumSubTotal);
        }

        compTotal += parseFloat($(sales).length);
    });
    $('.Total').text(sumTotal);
    $('.nroTotalComp').text(compTotal);

}

function SaveProfile() {
    swal({
        title: "Crear nuevo perfil",
        text: "Escriba el nombre del perfil",
        type: "input",
        showCancelButton: true,
        closeOnConfirm: false,
        inputPlaceholder: "nonbre de perfil"
    }, function (inputValue) {
        if (inputValue === false) return false;
        if (inputValue === "") {
            swal.showInputError("El nombre de perfil es obligatorio!");
            return false
        } else {
            var parameters = LoadParametersProtocolProfile(inputValue);
            APIController.SaveProtocolProfile(parameters).then((res) => {
                swal("Bien", "El perfil creado es: " + inputValue, "success");
            });
        }

    });

}

function LoadParametersProtocolProfile(nameProfile) {
    let objPro = {
        "Name": nameProfile,
        "ProfileDetail": []
    }

    var detail = obj.profileComponents;
    for (var i = 0; i < detail.length; i++) {
        var component = {};

        component.ComponentId = detail[i].componentId;
        component.CategoryId = detail[i].categoryId;
        component.CategoryName = detail[i].categoryName;
        component.MinPrice = detail[i].minPrice;
        component.ListPrice = detail[i].listPrice;
        component.SalePrice = detail[i].salePrice;
        objPro.ProfileDetail.push(component);
    }

    return objPro;
}


function AddProfile() {

    if ($("#chkProfile").is(":checked")) {
        SaveProfile();
    }

    let data = obj;
    let idPerfil = "perfil-" + Math.random().toString(36).substring(7);
    var content = "";
    content += "<tr id='" + idPerfil + "' class='parent'>";
    content += "<td><i class='fa fa-plus text-inverse m-r-10' onclick=show('" + idPerfil + "')></i></td>";
    content += "<td class='profileId' style='display:none'>" + data.profileId + "</td>";
    content += "<td>" + data.profileName + "</td>";
    content += "<td>";

    content += "<select class='form-control form-white' data-placeholder='Seleccione un servicio...' id='ddlService'>";
    content += "<option value='-1'>--Seleccionar--</option>";
    content += "<option value='1'>Preocupacional</option>";
    content += "<option value='2'>Periodico</option>";
    content += "<option value='3'>Anual</option>";
    content += "</select>";

    content += "</td>";
    content += "<td class='counterComp col-center'>0</td>";
    content += "<td class='subTotal col-center'>0</td>";
    content += "<td class='col-center'><i class='fa fa-close text-danger m-r-10' ></i></td>";
    content += "</tr>";

    content += "<tr class='" + idPerfil + " child' >";
    content += "<td colspan='6'>";
    content += "<table class='table-examenes'>";

    content += "<thead>";
    content += "<tr>";
    content += "<th></th>";
    content += "<th style='display:none'>CatId</th>";
    content += "<th style='display:none'>CompId</th>";
    content += "<th>EXAMENES - PERFIL</th>";
    content += "<th class='col-center'>PRECIO MÍNIMO</th>";
    content += "<th class='col-center'>PRECIO LISTA</th>";
    content += "<th class='col-center'>PRECIO VENTA</th>  ";
    content += "</tr>";
    content += "</thead>";

    content += "<tbody>";



    var valor = "";
    var components = data.profileComponents;
    let quotationProfileId = "perfil-" + Math.random().toString(36).substring(7);
    for (let i = 0; i < components.length; i++) {
        let valorAntiguo = components[i].categoryName;

        if (valor != valorAntiguo) {
            valor = valorAntiguo;
            content += "<tr id='" + quotationProfileId + "-" + components[i].categoryName + "'>";
            content += "<td><i class='fa fa-minus text-inverse m-r-10' onclick=show('" + quotationProfileId + "-" + components[i].categoryName + "')></i></td>";
            content += "<td colspan='4'>" + components[i].categoryName + "</td>";
            content += "</tr>";
            i--;
        } else {
            content += "<tr class=" + quotationProfileId + "-" + components[i].categoryName + ">";
            content += "<td></td>";

            content += "<td style='display:none'>" + components[i].categoryId + "</td>";
            content += "<td style='display:none'>" + components[i].componentId + "</td>";

            content += "<td>" + components[i].componentName + "</td>";
            content += "<td class='col-center'>" + components[i].minPrice + "</td>";
            content += "<td class='col-center'>" + components[i].listPrice + "</td>";
            content += "<td class='col-center'><input type='text' class='salePrice input-numeric' value=" + components[i].salePrice + "> </td>";
            content += "</tr>";
        }

    }

    content += "</tbody>";
    content += "</table>";
    content += "</td>";
    content += "</tr>";
    $('#tbody-main').append(content);

    CalculateTotals();
}

function LoadObj(res) {
    //console.log("RESP", res);
    obj = {};
    var data = res.Data;
    obj.profileId = data.ProtocolProfileId;
    obj.profileName = data.ProtocolProfileName;

    var categories = data.categories;
    var profileComponents = [];
    for (var i = 0; i < categories.length; i++) {

        var detail = categories[i].Detail;
        for (var ii = 0; ii < detail.length; ii++) {
            var profileComponent = {};
            profileComponent.categoryId = categories[i].CategoryId;
            profileComponent.categoryName = categories[i].CategoryName;
            profileComponent.componentId = detail[ii].ComponentId;
            profileComponent.componentName = detail[ii].ComponentName;

            profileComponent.minPrice = detail[ii].MinPrice;
            profileComponent.listPrice = detail[ii].ListPrice;
            profileComponent.salePrice = detail[ii].SalePrice;

            profileComponents.push(profileComponent);
        }
    }
    obj.profileComponents = profileComponents;
}

function ProcessObj(componentId, event, val) {
    //console.log(componentId, event, val, obj.profileComponents);
    //console.log($(event).find('.catId').get(0).innerText);
    //ADD
    if (val) {
        AddItemObj(componentId, event);
    }//DELETE
    else {
        RemoveItemObj(componentId);
    }
}

function AddItemObj(componentId, event) {
    var profileComponent = {};
    profileComponent.categoryId = parseInt($(event).find('.catId').get(0).innerText);
    profileComponent.categoryName = $(event).find('.catname').get(0).innerText;
    profileComponent.componentId = componentId;
    profileComponent.componentName = $(event).find('.compname').get(0).innerText;
    profileComponent.minPrice = parseFloat($(event).find('.minprice label').get(0).innerText);
    profileComponent.listPrice = parseFloat($(event).find('.listprice label').get(0).innerText);
    profileComponent.salePrice = parseFloat($(event).find('.saleprice input').get(0).value);

    obj.profileComponents.push(profileComponent);
}

function RemoveItemObj(componentId) {
    obj.profileComponents = obj.profileComponents.filter(function (res) {
        return res.componentId !== componentId;
    });
}

function SaveCompany(resp) {

    var data = {
        "Name": resp.RazonSocial,
        "IdentificationNumber": resp.Ruc,
        "Address": resp.CodigoZona,
        "PhoneNumber": "",
        "ContactName": "",
        "Mail": "",
        "District": "",
        "PhoneCompany": "",
        "companyHeadquarter": new Array()
    }

    var detail = resp.details;
    for (var i = 0; i < detail.length; i++) {
        var headquarter = {
            "RecordType": "Temporal",
            "RecordStatus": "Agregado",
            "Name": detail[i].NombreVia,
            "Address": detail[i].TipoZona,
            "PhoneNumber": "",
        }
        data.companyHeadquarter.push(headquarter);
    }

    APIController.SaveCompany(data).then((res) => {

        //$("#txtRuc").focus();
        console.log("RES", res);
        SearchCompany(res.Data.IdentificationNumber);
        //$('#txtRuc').val(res.Data.IdentificationNumber);
        //$('#txtCompanyName').val(res.Data.Name);
        //$('#txtDistric').val();
        //$('#txtAddress').val(res.Data.Address);
        //    //let content = "";
        //    //for (var i = 0; i < res.Data.details.length; i++) {
        //    //    content += "<option value='"+res.Data.companyHeadquarter[i].CompanyHeadquarterId +"'>"+res.Data.companyHeadquarter[i].Address+"</option>";
        //    //}
        //$('#txtCompanyName').attr('readonly', true);
        //$('#txtDistric').attr('readonly', true);
        //$('#txtAddress').attr('readonly', true);

    });
}

function SearchCompany(ruc) {
    APIController.GetCompanyByRuc(ruc).then((res) => {
        $('#txtCompanyId').val(res.Data.CompanyId);
        $('#txtCompanyName').val(res.Data.Name);
        $('#txtDistric').val(res.Data.District);
        $('#txtAddress').val(res.Data.Address);

        let content = "";
        for (var i = 0; i < res.Data.companyHeadquarter.length; i++) {
            content += "<option value='" + res.Data.companyHeadquarter[i].CompanyHeadquarterId + "'>" + res.Data.companyHeadquarter[i].Address + "</option>";
        }

        $('#ddlSede').append(content);

        $('#txtCompanyName').attr('readonly', true);
        $('#txtDistric').attr('readonly', true);
        $('#txtAddress').attr('readonly', true);

        $("#txtFullName").focus();
    }).catch((err) => {
        swal({
            title: "Empresa no registrada",
            text: "¿Desea buscar en Sunat?",
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            InfoSunat(ruc);
        });

    });
}

function SaveQuotation(e) {
    if (ValidateQuotation(e)) {
        swal({
            title: "Registro de Cotización",
            text: "¿Está seguro de guardar está cotización?",
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            APISaveQuotation();
        });
    }    
}

function APISaveQuotation() {

    var data = {
        "Code": "",
        "Version": "",
        "UserCreatedId": 1,
        "UserName": "",
        "CompanyId": $("#txtCompanyId").val(),
        "CompanyHeadquarterId": $("#ddlSede option:selected").val(),
        "FullName": $("#txtFullName").val(),
        "Email": $("#txtEmail").val(),
        "ProfileComponents": []
    }

    $("#tbody-main tr").each(function (index, tr) {

        if ($(tr).hasClass('parent')) {
            var idParent = $(tr).attr('id');
            var oQuotationProfile = {};
            oQuotationProfile.ProfileId = $(this).find("td").eq(1).html();
            var serviceType = $(this).find("td").eq(3);
            oQuotationProfile.ServiceTypeId = $(serviceType.get(0)).find("#ddlService").val(),
                oQuotationProfile.ProfileComponents = [];

            $("#tbody-main tr").each(function (index, tr) {

                if ($(tr).hasClass(idParent)) {

                    //console.log($(this).find("tbody > tr").get(0));
                    //console.log($(tr).find("tbody > tr"));
                    $(tr).find("tbody > tr").each(function () {
                        var oProfileComponent = {};
                        //console.log($(this).find("td").eq(1).html());
                        oProfileComponent.CategoryId = $(this).find("td").eq(1).html();
                        oProfileComponent.ComponentId = $(this).find("td").eq(2).html();
                        oProfileComponent.MinPrice = $(this).find("td").eq(4).html();
                        oProfileComponent.PriceList = $(this).find("td").eq(5).html();
                        oProfileComponent.SalePrice = $(this).find("input").val();
                        //oProfileComponent.InsertUserId
                        oQuotationProfile.ProfileComponents.push(oProfileComponent);
                    });
                }
            });

            data.ProfileComponents.push(oQuotationProfile);
        }
    });

    console.log("data", data);


    setTimeout(function () {
        swal("Se grabó correctamente");
    }, 2000);
}