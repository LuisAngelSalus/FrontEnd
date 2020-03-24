
var obj = {};
var objPriceList = {}

$(document).ready(function () {   

    checkQuoteState();

    addLocalStoragComponents();
    
    if ($("#txtQuotationId").val() != 0) {
        $(".select-StatusQuotation").attr("disabled", false);
        $("#txtRuc").attr("disabled", true);
    } else {
        $('#ddlStatusQuotation option[value=1]').attr('selected', 'selected');
    }

    if ($("#txtCompanyId").val() != 0) {
        SearchCompany($("#txtRuc").val());
    }

    CalculateTotals();

    $('.table-main').on('change paste keyup', '.salePrice', function (e) {
        let componentId = e.target.id;
        RefreshSalePrice(componentId, e.currentTarget.value);
        CalculateTotals();
    });

    $('.tables-profile').on('change paste', '.salepriceValue', function (e) {        
        let componentId = $(this).parent().next().html();
        let componentName = $(this).parent().parent().find('.compname').html();
        let params = { "CompanyId": $("#txtCompanyId").val(), "ComponentId": componentId, "Price": e.currentTarget.value}        
        UpdatePrice(params, componentName);
    });
    
    $(document).on('change paste keypress', '.onlyDecimal', function (e) {
        return isNumberKey(e);
    });

    $('.tables-profile').on('change paste keyup', '.salepriceValue', function (e) {
        let componentId = $($(this).parent().parent().get(0)).find('input').get(0).id;
        var component = obj.profileComponents.find(p => p.componentId == componentId);
        if (component != undefined) {
            RemoveItemObj(componentId);
            AddItemObj(componentId, $(this).parent().parent().get(0));
        }

    });

    $('.modal-content-profile').on('change', '.checkbox', function (event) {
        if (event.target.checked) {
            ProcessObj(event.target.id, $(this).parent().parent().get(0), true);
        } else {
            ProcessObj(event.target.id, $(this).parent().parent().get(0), false);
        }
    });

    $('#txtRuc').change(function () {
        //let ruc = $('#txtRuc').val();
        //$('#ddlSede').empty();
        //if (ruc.length == 11) {
        //    SearchCompany(ruc);
        //}
    });

    $('#tbody-Add-Examns').on('autocompletechange', '.tags', function (event) {
        getDataComponent(this.value, event);
    });
      
    $("#search").keyup(function () {
        var searchText = $(this).val();
        if (searchText.length < 4) { $("#show-list").empty(); return; }        
        var content = "";
        APIController.AutocompleteProtocolProfile(searchText).then((res) => {
            $("#show-list").empty();
            var data = res.Data;
            console.log("RES", res);
            for (var i = 0; i < data.length; i++) {

                let name = data[i].Value.toString().split('-')[0];

                if (name === "EMPO") 
                    content += "<a href='#' id='" + data[i].Id + "' class='list-group-item list-group-item-action border-1 EMPO autocompleteProfile'>" + data[i].Value + "</a>";
                 else if (name === "EMOP") 
                    content += "<a href='#' id='" + data[i].Id + "' class='list-group-item list-group-item-action border-1 EMOP autocompleteProfile'>" + data[i].Value + "</a>";
                 else if (name === "EMOR") 
                    content += "<a href='#' id='" + data[i].Id + "' class='list-group-item list-group-item-action border-1 EMOR autocompleteProfile'>" + data[i].Value + "</a>";
                else 
                    content += "<a href='#' id='" + data[i].Id + "' class='list-group-item list-group-item-action border-1  autocompleteProfile'>" + data[i].Value + "</a>";

            }
            $("#show-list").append(content);
        });
    });

    function updateControlStatusQuotation() {
        $('#ddlStatusQuotation option[value=1]').removeAttr("selected");
        $('#ddlStatusQuotation option[value=-1]').removeAttr("selected");        
        $('#ddlStatusQuotation option[value=4]').attr('selected', 'selected');
        
    }
    
    $("#perfilModal").on("click", ".autocompleteProfile", function () {
        $("#search").val($(this).text());
        $("#show-list").empty();
        $("#tbody-profile").text("obteniendo información");
        $("#tbody-profile-unselectd").text("obteniendo información");
        var idProfile = $(this).attr('id');
        
        if (idProfile == PROFILE_POTENCIAL) { 
        
            updateControlStatusQuotation();  
        }

        if (idProfile != undefined) {
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
                    content += '<thead><th></th><th style="display:none"></th><th style="display:none"></th><th>Examen</th><th>P.Min</th><th>P.Lista</th> <th>P.Venta</th></thead>';
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
                        content += '<td class="saleprice" style="text-align: center;"><input class="form-control salepriceValue onlyDecimal" type="text" value="' + SetPriceDB(data[i].Detail[ii].ComponentId) + '" style="width:80px"> </td>';
                        content += '<td style="display:none">' + data[i].Detail[ii].ComponentId+'</td>';
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
                    contentUn += '<thead><th></th><th style="display:none"></th><th style="display:none"></th><th>Examen</th><th>P.Min</th><th>P.Lista</th> <th>P.Venta</th></thead>';
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
                        contentUn += '<td class="saleprice" style="text-align: center;"><input class="form-control salepriceValue onlyDecimal" type="text" value="' + SetPriceDB(unselectedData[i].Detail[ii].ComponentId) + '" style="width:80px"> </td>';
                        contentUn += '<td style="display:none">' + unselectedData[i].Detail[ii].ComponentId + '</td>';
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
        }
    });

    $("#dialog_pdf").dialog({
        autoOpen: false,
        modal: true,
        title: "View Details"
    });

    $(".preview_quotation").click(function () {

        var content = "";
        var data = {
            "QuotationId": $("#txtQuotationId").val(),
            "Code": $("#spanCode").html(),
            "Version": parseInt($("#spanVersion").html()),            
            "UserName": "",
            "CompanyId": $("#txtCompanyId").val(),
            "CompanyHeadquarterId": $("#ddlSede option:selected").val(),
            "FullName": $("#txtFullName").val(),
            "Email": $("#txtEmail").val(),
            "CommercialTerms": $("#txtCommercialTerms").val(),            
            "TotalQuotation": $(".Total").html(),
            "StatusQuotationId": $(".select-StatusQuotation option:selected").val(),
            "QuotationProfile": [],
            "AdditionalComponentsQuote": []
        }

        $("#tbody-main tr").each(function (index, tr) {

            if ($(tr).hasClass('parent')) {
                var idParent = $(tr).attr('id');
                var oQuotationProfile = {};
                oQuotationProfile.QuotationProfileId = $(this).find("td").eq(8).html();
                oQuotationProfile.ProfileName = $(this).find("input").val();
                var serviceType = $(this).find("td").eq(5);
                oQuotationProfile.ServiceTypeId = $(serviceType.get(0)).find("#ddlService").val(),
                    oQuotationProfile.ProfileComponent = [];
                oQuotationProfile.RecordType = $(this).find(".RecordType").html();
                oQuotationProfile.RecordStatus = $(this).find(".RecordStatus").html();
                $("#tbody-main tr").each(function (index, tr) {

                    if ($(tr).hasClass(idParent)) {
                        $(tr).find("tbody > tr").each(function () {
                            if (GetNameCategory($(this).find("td").eq(1).html()) != "----") {

                                var oProfileComponent = {};
                                oProfileComponent.ProfileComponentId = $(this).find("td").eq(0).html();
                                oProfileComponent.CategoryName = GetNameCategory($(this).find("td").eq(1).html());
                                oProfileComponent.CategoryId = $(this).find("td").eq(1).html();
                                oProfileComponent.ComponentId = $(this).find("td").eq(2).html();
                                oProfileComponent.ComponentName = $(this).find("td").eq(5).html();
                                oProfileComponent.MinPrice = $(this).find("td").eq(6).html();
                                oProfileComponent.PriceList = $(this).find("td").eq(7).html();
                                oProfileComponent.SalePrice = $(this).find("input").val();
                                oProfileComponent.RecordType = $(this).find(".RecordType").html();
                                oProfileComponent.RecordStatus = $(this).find(".RecordStatus").html();
                                //oProfileComponent.InsertUserId
                                oQuotationProfile.ProfileComponent.push(oProfileComponent);
                            }
                        });
                    }
                });

                data.QuotationProfile.push(oQuotationProfile);
            }
        });

        $("#tbody-Add-Examns tr").each(function (index, tr) {
            var oAddExam = {};
            oAddExam.quotationId = $("#txtQuotationId").val();
            oAddExam.CategoryId = $(this).find("td").eq(4).html();
            oAddExam.CategoryName = $(this).find("td").eq(5).html();
            oAddExam.ComponentId = $(this).find("td").eq(6).html();
            oAddExam.ComponentName = $(this).find("td").eq(7).html();
            oAddExam.MinPrice = $(this).find("td").eq(9).html();
            oAddExam.PriceList = $(this).find("td").eq(10).html();
            oAddExam.SalePrice = $(this).parent().parent().find(".AddExamPreVen").val()
            oAddExam.RecordType = $(this).find(".RecordType").html();
            oAddExam.RecordStatus = $(this).find(".RecordStatus").html();
            oAddExam.InsertUserId = 1;
            data.AdditionalComponentsQuotes.push(oAddExam);
        });

        var info = {
            data: JSON.stringify(data)
        }

        //$.ajax({
        //    type: "POST",
        //    url: "/Quotation/ExportToPDF",
        //    data: info,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (response) {
        //        $('#dialog_pdf').html(response.PartialView);
        //        $('#dialog_pdf').dialog('open');
        //    },
        //    failure: function (response) {
        //        alert(response.responseText);
        //    },
        //    error: function (response) {
        //        alert(response.responseText);
        //    }
        //});


        //$.ajax({
        //    url: "/Quotation/ExportToPDF",
        //    type: "GET",
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    data: info,
        //    success: function (result) {
        //        window.location.href = '/Quotation/ExportToPDF';
        //    },
        //    error: function (xhr, status, error) {
        //        console.log(xhr);
        //    }
        //})

    });

});

function checkQuoteState() {
    let quotationState = $("#ddlStatusQuotation option:selected").val();    
    if (quotationState == STATUS_QUOTATION_ACEPTADA) {
        $("#msgStateQuotation").html("<span class='label label-primary label-rounded'>Cotización Aceptado. No se puede modificar</span>");
        $("#btnSaveQuotation").prop('disabled', true);
    } else if (quotationState == STATUS_QUOTATION_POTENCIAL) {
        $("#msgStateQuotation").html("<span class='label label-info label-rounded'>Cotización Potencial. Solo se permite versionamiento en estado seguimiento</span>");
        $("#btnSaveQuotation").prop('disabled', true);
    }

}

function addLocalStoragComponents() {
    if (localStorage.getItem('components') == null) {
        APIController.GetComponents().then((res) => {
            //ADD LOCALSTORAGE
            localStorage.setItem('components', JSON.stringify(res.Data));
        });
    }    
}

$('#profile').change(function () {
    $("#tbody-profile").text("obteniendo información");
    $("#tbody-profile-unselectd").text("obteniendo información");
    var idProfile = $("#profile option:selected").val();

    if (idProfile != undefined) {
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
                content += '<thead><th></th><th style="display:none"></th><th style="display:none"></th><th>Examen</th><th>P.Min</th><th>P.Lista</th> <th>P.Venta</th></thead>';
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
                    content += '<td class="saleprice" style="text-align: center;"><input class="form-control salepriceValue onlyDecimal" type="text" value="' + SetPriceDB(data[i].Detail[ii].ComponentId) + '" style="width:80px"> </td>';
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
                contentUn += '<thead><th></th><th style="display:none"></th><th style="display:none"></th><th>Examen</th><th>P.Min</th><th>P.Lista</th> <th>P.Venta</th></thead>';
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
                    contentUn += '<td class="saleprice" style="text-align: center;"><input class="form-control salepriceValue onlyDecimal" type="text" value="' + SetPriceDB(unselectedData[i].Detail[ii].ComponentId) + '" style="width:80px"> </td>';
                    
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
    }


});

$('.textarea_editor').wysihtml5();

function InfoSunat(ruc) {
    APIController.GetInfoSunat(ruc).then((res) => {
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
    if ($("#txtCompanyId").val() == 0) {
        swal("Validación", "¡Seleccione una empresa!", "error");
        return;
    }
    
    APIController.GetPriceList($("#txtCompanyId").val()).then((res) => {
        //console.log("OBJ", res.Data);
        objPriceList = res.Data;        
    });



    //$('#chkProfile').prop('checked', false);
    $('#profile').empty();

        //APIController.GetddlProtocolProfile().then((resp) => {
        //    let content = "";
        //    content += "<option value='-1'>--Seleccionar--</option>";
        //    for (var i = 0; i < resp.Data.length; i++) {
        //        content += "<option value='" + resp.Data[i].Id + "'>" + resp.Data[i].Value + "</option>";
        //    }

        //    $('#profile').append(content);
        //});

    //$('#profile').val(-1).trigger('change');
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
                        
            if ($(this).parent().parent().find(".RecordStatus").text() != "ELIMINADOLOGICO") {
                compTotal++;
                var value = $(this).get(0).value;
                //obtener el SUBTOTAL
                if (!isNaN(value) && value.length != 0) {
                    sumSubTotal += parseFloat(value);
                }
            }

        });

        var parent = $(tr).prev().get(0);
        sumSubTotal = Number(sumSubTotal.toFixed(2));
        $(parent).find('.subTotal').text(sumSubTotal);
        $(parent).find('.counterComp').text(sales.length);

        //obtener el TOTAL
        if (!isNaN(sumSubTotal)) {
            sumTotal += parseFloat(sumSubTotal);
        }
    
        sumTotal = Number(sumTotal.toFixed(2));
        
        
        
        
    })
        $('.nroTotalComp').text(compTotal);
        let tramite = parseFloat($(".Tramite").text());        
        sumTotal = sumTotal + tramite;
        $('.Total').text(sumTotal);
}

function SaveProfile() {
    swal({
        title: "IMPORTANTE",
        text: "¿Desea guardar este perfil como referencia?",
        type: "info",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    }, function (isConfirm) {
        let tipoEMO = $("#search").val().split('-')[0];
        if (isConfirm) {
            let nameProfile = $("#search").val() + "-" + $("#txtCompanyName").val();

            var parameters = LoadParametersProtocolProfile(nameProfile);
            APIController.SaveProtocolProfile(parameters).then((res) => {
                swal("Bien", "El perfil creado es: " + nameProfile, "success");
            });
        } else {
            swal("Bien", "Perfil agregado a la cotización ", "success");
        }

        let data = obj;
        let idPerfil = "perfil-" + Math.random().toString(36).substring(7);
        var content = "";
        content += "<tr id='" + idPerfil + "' class='parent'>";
        content += "<td><i class='fa fa-plus text-inverse m-r-10' onclick=show('" + idPerfil + "')></i></td>";
        content += "<td style='display:none' class='RecordType'>TEMPORAL</td>";
        content += "<td style='display:none' class='RecordStatus'>AGREGADO</td>";
        content += "<td class='profileId' style='display:none'>" + data.profileId + "</td>";

        content += "<td><input class='form-control input-perfil' type='text' value='" + $("#txtNameProfileQuotation").val() + "' disabled/></td>";
        content += "<td>";

        content += "<select class='form-control form-white select-Service' data-placeholder='Seleccione un servicio...' id='ddlService' disabled>";


        if (tipoEMO === "EMPO") {
            content += "<option value='1'>Preocupacional</option>";
        } else if (tipoEMO === "EMOP") {
            content += "<option value='2'>Periodico</option>";
        } else if (tipoEMO === "EMOR") {
            content += "<option value='3'>Retiro</option>";
        } else {
            content += "<option value='4'>Visita</option>";
        }

        content += "</select>";

        content += "</td>";

        content += "<td>";
        content += "<select class='form-control form-white select-TypeFormat' id='ddlTypeFormat'>";
        content += "<option value='-1'>--Seleccionar--</option>";
        content += "<option value='1'>RM 312</option>";
        content += "<option value='2'> Anexo 16</option >";
        content += "<option value='3'> Anexo 16.A</option >";
        content += "<option value='4'> Ambos</option >";
        content += "<option value='5'>Componente</option >";
        content += "</select>";
        content += "</td>";



        content += "<td class='counterComp col-center'>0</td>";
        content += "<td class='subTotal col-center'>0</td>";
        content += "<td class='col-center'>0</td>";
        content += "<td class='col-center'><i class='fa fa-close text-danger m-r-10' onclick='RemoveProfile(event)'></i></td>";
        content += "</tr>";

        content += "<tr class='" + idPerfil + " child' >";
        content += "<td colspan='8'>";
        content += "<table class='table-examenes'>";

        content += "<thead>";
        content += "<tr>";
        content += "<th></th>";
        content += "<th style='display:none'>CatId</th>";
        content += "<th style='display:none'>CompId</th>";
        content += "<th style='display:none'>RecordType</th>";
        content += "<th style='display:none'>RecordStatus</th>";
        content += "<th>EXAMENES - PERFIL</th>";
        content += "<th>CONDICIONAL EDAD</th>";
        content += "<th>EDAD</th> ";
        content += "<th>CONDICIONAL GÉNERO</th> ";
        content += "<th class='col-center'>PRECIO MÍNIMO</th>";
        content += "<th class='col-center'>PRECIO LISTA</th>";
        content += "<th class='col-center'>PRECIO VENTA</th>  ";
        content += "<th class='col-center'></th>";
        content += "</tr>";
        content += "</thead>";
        content += "<tbody>";

        var valor = "";
        var components = data.profileComponents;
        let quotationProfileId = "perfil-" + Math.random().toString(36).substring(7);
        for (let i = 0; i < components.length; i++) {
            let cateName = components[i].categoryName.replace(/\s/g, "_");
            let valorAntiguo = components[i].categoryName.replace(/\s/g, "_");

            if (valor != valorAntiguo) {
                valor = valorAntiguo;
                content += "<tr id='" + quotationProfileId + "-" + cateName + "'>";
                content += "<td><i class='fa fa-minus text-inverse m-r-10' onclick=show('" + quotationProfileId + "-" + cateName + "')></i></td>";
                content += "<td colspan='9'>" + cateName + "</td>";
                content += "</tr>";
                i--;
            } else {
                content += "<tr class=" + quotationProfileId + "-" + cateName + ">";
                content += "<td style='color:white'>" + components[i].profileComponentId + "</td>";

                content += "<td style='display:none'>" + components[i].categoryId + "</td>";
                content += "<td style='display:none'>" + components[i].componentId + "</td>";
                content += "<td style='display:none'class='RecordType'>TEMPORAL</td>";
                content += "<td style='display:none'class='RecordStatus'>AGREGADO</td>";
                content += "<td>" + components[i].componentName + "</td>";



                content += "<td>";
                content += "<select class='form-control form-white select-ConditionalAge' id='ddlConditionalAge'>";
                content += "<option value='-1'></option>";
                content += "<option value='1'>Mayores de</option>";
                content += "<option value='2'> Menores de</option >";
                content += "</select>";
                content += "</td>";
                content += "<td><input class='form-control input-numeric' type='text' maxlength='2' min='0' max='90' onkeypress='validateInputNumber(event)'/></td>";
                content += "<td>";
                content += "<select class='form-control form-white select-ConditionalGender' id='ddlConditionalGender'>";
                content += "<option value='-1'></option>";
                content += "<option value='1'>Masculino</option>";
                content += "<option value='2'> Femenino</option >";
                content += "<option value='2'> Ambos</option >";
                content += "</select >";
                content += "</td >";



                
                content += "<td class='col-center'>" + components[i].minPrice + "</td>";
                content += "<td class='col-center'>" + components[i].listPrice + "</td>";
                content += "<td class='col-center'><input type='text' id='" + components[i].componentId+"' class='form-control salePrice input-numeric' value=" + components[i].salePrice + "> </td>";
                content += "<td class='col-center'><i class='fa fa-close text-danger m-r-10' onclick='RemoveComponent(event)'></i></td>";
                content += "</tr>";
            }

        }

        content += "</tbody>";
        content += "</table>";
        content += "</td>";
        content += "</tr>";
        $('#tbody-main').append(content);

        CalculateTotals();

        $("#changeNameProfile").modal("hide");
        $("#search").val("");
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
    $("#changeNameProfile").modal("show");
    $("#txtNameProfileQuotation").val($("#search").val());    
}

function GenerateNameProfile() {
    let
}

function LoadObj(res) {
    
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
            
            profileComponent.salePrice = SetPriceDB(profileComponent.componentId);

            profileComponents.push(profileComponent);
        }
    }
    obj.profileComponents = profileComponents;

}

function SetPriceDB(componentId) {

    var componentDB = objPriceList.filter((component) => {
        return component.ComponentId == componentId;
    });
    return componentDB.length == 0 ? 0 : componentDB[0].Price;
}

function ProcessObj(componentId, event, val) {
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
        "Address": resp.TipoVia + ' ' + resp.CodigoZona + ' N°' + resp.Numero + ' ' + resp.NombreVia + ' ' + resp.TipoZona,
        "PhoneNumber": "",
        "ContactName": "",
        "Mail": "",
        "District": resp.Distrito,
        "PhoneCompany": "",
        "companyHeadquarter": new Array()
    }

    var detail = resp.details;
    for (var i = 0; i < detail.length; i++) {
        var headquarter = {
            "RecordType": "Temporal",
            "RecordStatus": "Agregado",
            "Name": detail[i].TipoZona,
            "Address": detail[i].TipoVia + ' ' + detail[i].NombreVia + ' N°' + detail[i].Numero,
            "PhoneNumber": "",
        }
        data.companyHeadquarter.push(headquarter);
    }

    APIController.SaveCompany(data).then((res) => {
        SearchCompany(res.Data.IdentificationNumber);
    });
}

function SearchCompany(ruc) {
    //APIController.GetCompanyByRuc(ruc).then((res) => {
    //    $('#txtCompanyId').val(res.Data.CompanyId);
    //    $('#txtCompanyName').val(res.Data.Name);
    //    $('#txtDistric').val(res.Data.District);
    //    $('#txtAddress').val(res.Data.Address);

    //    let content = "";
    //    for (var i = 0; i < res.Data.companyHeadquarter.length; i++) {
    //        content += "<option value='" + res.Data.companyHeadquarter[i].CompanyHeadquarterId + "'>" + res.Data.companyHeadquarter[i].Address + "</option>";
    //    }

    //    $('#ddlSede').append(content);

    //    $('#txtCompanyName').attr('readonly', true);
    //    $('#txtDistric').attr('readonly', true);
    //    $('#txtAddress').attr('readonly', true);

    //    $("#txtFullName").focus();

    //    //EN CASO SEA EDICIÓN
    //    if ($('#txtCompanyHeadquarterId').val() != 0) {
    //        $("#ddlSede").val($('#txtCompanyHeadquarterId').val());
    //    }

    //}).catch((err) => {
    //    swal({
    //        title: "Empresa no registrada",
    //        text: "¿Desea buscar en Sunat?",
    //        type: "info",
    //        showCancelButton: true,
    //        closeOnConfirm: false,
    //        showLoaderOnConfirm: true
    //    }, function () {
    //        InfoSunat(ruc);
    //    });

    //});
}

function SaveQuotation(e) {
    let quotationState = $("#ddlStatusQuotation option:selected").val();
    if (ValidateQuotation(e, quotationState)) {
        swal({
            title: "¡Importante!",
            text: "¿Está seguro de guardar esta cotización?",
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
        "QuotationId": $("#txtQuotationId").val(),
        "Code": $("#spanCode").html(),
        "Version": parseInt($("#spanVersion").html()),
        "UserName": "",
        "CompanyId": $("#txtCompanyId").val(),
        "CompanyHeadquarterId": $("#ddlSede option:selected").val(),
        "FullName": $("#txtFullName").val(),
        "Email": $("#txtEmail").val(),
        "CommercialTerms": $("#txtCommercialTerms").val(),
        "TotalQuotation": $(".Total").html(),
        "StatusQuotationId": $(".select-StatusQuotation option:selected").val(),
        "QuotationProfile": [],
        "AdditionalComponentsQuote": []
    }

    $("#tbody-main tr").each(function (index, tr) {

        if ($(tr).hasClass('parent')) {
            var idParent = $(tr).attr('id');
            var oQuotationProfile = {};
            oQuotationProfile.QuotationProfileId = $(this).find("td").eq(8).html();
            oQuotationProfile.ProfileName = $(this).find("input").val();
            var serviceType = $(this).find("td").eq(5);
            oQuotationProfile.ServiceTypeId = $(serviceType.get(0)).find("#ddlService").val();
            let typeFormat = $(this).find("td").eq(6);
            oQuotationProfile.TypeFormatId = $(typeFormat.get(0)).find("#ddlTypeFormat").val();
            oQuotationProfile.ProfileComponent = [];
            oQuotationProfile.RecordType = $(this).find(".RecordType").html();
            oQuotationProfile.RecordStatus = $(this).find(".RecordStatus").html();
            $("#tbody-main tr").each(function (index, tr) {

                if ($(tr).hasClass(idParent)) {
                    $(tr).find("tbody > tr").each(function () {
                        if (GetNameCategory($(this).find("td").eq(1).html()) != "----") {

                            var oProfileComponent = {};
                            oProfileComponent.ProfileComponentId = $(this).find("td").eq(0).html();
                            oProfileComponent.CategoryName = GetNameCategory($(this).find("td").eq(1).html());
                            oProfileComponent.CategoryId = $(this).find("td").eq(1).html();
                            oProfileComponent.ComponentId = $(this).find("td").eq(2).html();
                            oProfileComponent.ComponentName = $(this).find("td").eq(5).html();
                            let ageConditional = $(this).find("td").eq(6);
                            oProfileComponent.AgeConditionalId = $(ageConditional.get(0)).find("#ddlConditionalAge").val();
                            let ageValue = $(this).find("td").eq(7);
                            oProfileComponent.Age = $(ageValue).find("input").val();
                            let genderConditional = $(this).find("td").eq(8);
                            oProfileComponent.GenderConditionalId = $(genderConditional.get(0)).find("#ddlConditionalGender").val();

                            oProfileComponent.MinPrice = $(this).find("td").eq(9).html();
                            oProfileComponent.PriceList = $(this).find("td").eq(10).html();
                            let saleValue = $(this).find("td").eq(11);
                            oProfileComponent.SalePrice = $(saleValue).find("input").val();
                            oProfileComponent.RecordType = $(this).find(".RecordType").html();
                            oProfileComponent.RecordStatus = $(this).find(".RecordStatus").html();
                            //oProfileComponent.InsertUserId
                            oQuotationProfile.ProfileComponent.push(oProfileComponent);
                        }
                    });
                }
            });

            data.QuotationProfile.push(oQuotationProfile);
        }
    });

    $("#tbody-Add-Examns tr").each(function (index, tr) {
        var oAddExam = {};
        oAddExam.quotationId = $("#txtQuotationId").val();
        oAddExam.CategoryId = $(this).find("td").eq(4).html();
        oAddExam.CategoryName = $(this).find("td").eq(5).html();
        oAddExam.ComponentId = $(this).find("td").eq(6).html();
        oAddExam.ComponentName = $(this).find("td").eq(7).html();
        oAddExam.MinPrice = $(this).find("td").eq(9).html();
        oAddExam.PriceList = $(this).find("td").eq(10).html();
        oAddExam.SalePrice = $(this).parent().parent().find(".AddExamPreVen").val()
        oAddExam.RecordType = $(this).find(".RecordType").html();
        oAddExam.RecordStatus = $(this).find(".RecordStatus").html();
        data.AdditionalComponentsQuote.push(oAddExam);
    });


    if (data.QuotationId == 0) {
        APIController.SaveQuotation(data).then((res) => {
            if (res.IsSuccess === false) {
                swal({
                    title: "¡ERROR!",
                    text: "Ocurrió un error en la operación",
                    type: "error"
                });
            } else {
                swal({ title: "Correcto", text: "El nro de cotizacion es :" + res.Data.Code, type: "success" },
                    function () {
                        SaveTrackingInsideRegister(res.Data.QuotationId);
                        $("#spanCode").html(res.Data.Code);
                        window.location.href = "/Quotation/Index/";
                    });
            }
        });

    } else if (data.QuotationId > 0) {
        data.QuotationId = 0;
        data.Code = $("#spanCode").html();
        APIController.NewVersionQuotation(data).then((res) => {

            if (res.IsSuccess === false) {
                swal({
                    title: "¡ERROR!",
                    text: "Ocurrió un error en la operación",
                    type: "error"
                });
            } else {
                swal({
                    title: "¡Importante!",
                    text: "Ingresar comentario para nueva versión",
                    type: "input",
                    showCancelButton: true,
                    closeOnConfirm: false,
                    inputPlaceholder: "ingresar comentario"
                }, function (inputValue) {
                    if (inputValue === false) return false;
                    if (inputValue === "") {
                        swal.showInputError("¡Es necesario ingresar un comentario!");
                        return false
                    }
                        SaveTrackingNewVersion(res.Data.QuotationId, inputValue);
                        swal({
                            title: "Se creó la versión: " + res.Data.Version,
                            text: "",
                            type: "success",
                            showCancelButton: true,
                            confirmButtonClass: "btn-info",
                            confirmButtonText: "Volver a la Matriz",
                            cancelButtonText: "Permanecer en esta página",
                            closeOnConfirm: false,
                            closeOnCancel: false
                        },
                            function (isConfirm) {
                                if (isConfirm) {
                                    window.location.href = "/Quotation/Index/";
                                } else {
                                    swal.close();
                                }
                            });

                });

                APIController.UpdateProccessQuotation({ "QuotationId": res.Data.QuotationId, "Code": data.Code });
            }

        });
    }

}

function PreviewQuotation() {
    var content = "";
    var data = {
        "QuotationId": $("#txtQuotationId").val(),
        "Code": $("#spanCode").html(),
        "Version": parseInt($("#spanVersion").html()),
        "ResponsibleSystemUserId": 1,
        "UserName": "",
        "CompanyId": $("#txtCompanyId").val(),
        "CompanyHeadquarterId": $("#ddlSede option:selected").val(),
        "FullName": $("#txtFullName").val(),
        "Email": $("#txtEmail").val(),
        "CommercialTerms": $("#txtCommercialTerms").val(),
        "ResponsibleSystemUserId": 4,
        "InsertUserId": 4,
        "TotalQuotation": $(".Total").html(),
        "StatusQuotationId": $(".select-StatusQuotation option:selected").val(),
        "QuotationProfile": [],
        "AdditionalComponentsQuote": []
    }

    $("#tbody-main tr").each(function (index, tr) {

        if ($(tr).hasClass('parent')) {
            var idParent = $(tr).attr('id');
            var oQuotationProfile = {};
            oQuotationProfile.QuotationProfileId = $(this).find("td").eq(8).html();
            oQuotationProfile.ProfileName = $(this).find("input").val();
            var serviceType = $(this).find("td").eq(5);
            oQuotationProfile.ServiceTypeId = $(serviceType.get(0)).find("#ddlService").val(),
                oQuotationProfile.ProfileComponent = [];
            oQuotationProfile.RecordType = $(this).find(".RecordType").html();
            oQuotationProfile.RecordStatus = $(this).find(".RecordStatus").html();
            $("#tbody-main tr").each(function (index, tr) {

                if ($(tr).hasClass(idParent)) {
                    $(tr).find("tbody > tr").each(function () {
                        if (GetNameCategory($(this).find("td").eq(1).html()) != "----") {

                            var oProfileComponent = {};
                            oProfileComponent.ProfileComponentId = $(this).find("td").eq(0).html();
                            oProfileComponent.CategoryName = GetNameCategory($(this).find("td").eq(1).html());
                            oProfileComponent.CategoryId = $(this).find("td").eq(1).html();
                            oProfileComponent.ComponentId = $(this).find("td").eq(2).html();
                            oProfileComponent.ComponentName = $(this).find("td").eq(5).html();
                            oProfileComponent.MinPrice = $(this).find("td").eq(6).html();
                            oProfileComponent.PriceList = $(this).find("td").eq(7).html();
                            oProfileComponent.SalePrice = $(this).find("input").val();
                            oProfileComponent.RecordType = $(this).find(".RecordType").html();
                            oProfileComponent.RecordStatus = $(this).find(".RecordStatus").html();
                            //oProfileComponent.InsertUserId
                            oQuotationProfile.ProfileComponent.push(oProfileComponent);
                        }
                    });
                }
            });

            data.QuotationProfile.push(oQuotationProfile);
        }
    });

    $("#tbody-Add-Examns tr").each(function (index, tr) {
        var oAddExam = {};
        oAddExam.quotationId = $("#txtQuotationId").val();
        oAddExam.CategoryId = $(this).find("td").eq(4).html();
        oAddExam.CategoryName = $(this).find("td").eq(5).html();
        oAddExam.ComponentId = $(this).find("td").eq(6).html();
        oAddExam.ComponentName = $(this).find("td").eq(7).html();
        oAddExam.MinPrice = $(this).find("td").eq(9).html();
        oAddExam.PriceList = $(this).find("td").eq(10).html();
        oAddExam.SalePrice = $(this).parent().parent().find(".AddExamPreVen").val()
        oAddExam.RecordType = $(this).find(".RecordType").html();
        oAddExam.RecordStatus = $(this).find(".RecordStatus").html();
        oAddExam.InsertUserId = 1;
        data.AdditionalComponentsQuotes.push(oAddExam);
    });

}

function SaveTrackingInsideRegister(quotationId) {
    let statusQuotation = $(".select-StatusQuotation option:selected").val();
    let params = {};
    if (statusQuotation == STATUS_QUOTATION_POTENCIAL) {
        params = {
            "QuotationId": quotationId,
            "StatusName": "Potencial",
            "Commentary": "Cotización Creada"        
        }
    } else if (statusQuotation == STATUS_QUOTATION_SEGUIMIENTO) {
        params = {
            "QuotationId": quotationId,
            "StatusName": "Seguimiento",
            "Commentary": "Seguimiento Creado"            
        }
    }       
    
    APIController.SaveQuoteTracking(params).then((resp) => {

    });
}

function SaveTrackingNewVersion(quotationId, comentary) {

    let StatusQuotation = $(".select-StatusQuotation option:selected").val();
    var params = {}

    if (StatusQuotation == STATUS_QUOTATION_POTENCIAL) {
        params = {
            "QuotationId": quotationId,
            "Commentary": comentary,
            "StatusName": "Potencial"
        }
    } else {
        params = {
            "QuotationId": quotationId,
            "Commentary": comentary,
            "StatusName": "Seguimiento"            
        }
    }

    APIController.SaveQuoteTracking(params);
}

function GetNameCategory(id) {
    if (id == 1) {

        return "LABORATORIO"
    } else if (id == 2) {
        return "ODONTOLOGÍA"
    } else if (id == 4) {
        return "GINECOLOGÍA"
    } else if (id == 5) {
        return "CARDIOLOGÍA"
    } else if (id == 6) {
        return "RAYOS_X"
    } else if (id == 7) {
        return "PSICOLOGÍA"
    } else if (id == 10) {
        return "TRIAJE"
    } else if (id == 11) {
        return "MEDICINA"
    } else if (id == 12) {
        return "NEUOMOLOGÍA"
    } else if (id == 13) {
        return "INMUNIZACIONES"
    } else if (id == 14) {
        return "OFTALOMOLOGÍA"
    } else if (id == 17) {
        return "UROLOGÍA"
    } else if (id == 18) {
        return "NEUROLOGÍA"
    } else if (id == 19) {
        return "AUDIOMETRÍA"
    } else if (id == 20) {
        return "PSICOPRUEBAS"
    } else if (id == 21) {
        return "ADMINISTRACIÓN"
    } else if (id == 22) {
        return "ALTURA 1.8M"
    } else if (id == 23) {
        return "PSICOSENSOMÉTRICO"
    } else if (id == 24) {
        return "ESPIROMETRÍA"
    } else {
        return "----"
    }


}

function RemoveProfile(event) {
    var recordType = $(event.target).parent().parent().find(".RecordType").html();
    var recordStatus = $(event.target).parent().parent().find(".RecordStatus").html();
    var idTr = $(event.target).parent().parent().attr('id');

    if (recordType === "TEMPORAL" && recordStatus === "AGREGADO") {

        $("#tbody-main tr").each(function (index, tr) {
            if ($(tr).hasClass(idTr)) {
                $(tr).remove();
            }
        })
        console.log("XXXX", $(event.target).parent().parent());
        $(event.target).parent().parent().remove();
    } else {
        $(event.target).parent().parent().find(".RecordType").text("NOTEMPORAL");
        $(event.target).parent().parent().find(".RecordStatus").text("ELIMINADOLOGICO");
        $("#tbody-main tr").each(function (index, tr) {
            if ($(tr).hasClass(idTr)) {
                $(tr).hide();
                $(tr).find(".RecordStatus").text("ELIMINADOLOGICO");
                $(tr).find(".RecordType").text("NOTEMPORAL");
            }
        })
        $(event.target).parent().parent().hide();
    }
    CalculateTotals();
}

function RemoveComponent(event) {

    let idParent = $(event.target).parent().parent().attr('class').split(' ')[1];

    var recordType = $(event.target).parent().parent().find(".RecordType").html();
    var recordStatus = $(event.target).parent().parent().find(".RecordStatus").html();

    if (recordType === "TEMPORAL" && recordStatus === "AGREGADO") {
        $(event.target).parent().parent().remove();

    } else {
        $(event.target).parent().parent().find(".RecordType").text("NOTEMPORAL");
        $(event.target).parent().parent().find(".RecordStatus").text("ELIMINADOLOGICO");
        $(event.target).parent().parent().hide();
    }
    CheckTrParen(idParent);
    CalculateTotals();
}

$('.table-main').on('change', '.input-numeric', function (event) {

    var recordType = $(event.target).parent().parent().find(".RecordType").html();
    var recordStatus = $(event.target).parent().parent().find(".RecordStatus").html();

    if (recordType === "TEMPORAL" && recordStatus === "AGREGADO") {
    } else {
        $(event.target).parent().parent().find(".RecordType").text("NOTEMPORAL");
        $(event.target).parent().parent().find(".RecordStatus").text("MODIFICADO");
    }
})

$('.table-main').on('change', '.input-perfil', function (event) {

    var recordType = $(event.target).parent().parent().find(".RecordType").html();
    var recordStatus = $(event.target).parent().parent().find(".RecordStatus").html();

    if (recordType === "TEMPORAL" && recordStatus === "AGREGADO") {
    } else {
        $(event.target).parent().parent().find(".RecordType").text("NOTEMPORAL");
        $(event.target).parent().parent().find(".RecordStatus").text("MODIFICADO");
    }
})

$('.table-main').on('change', '.select-Service', function (event) {

    var recordType = $(event.target).parent().parent().find(".RecordType").html();
    var recordStatus = $(event.target).parent().parent().find(".RecordStatus").html();

    if (recordType === "TEMPORAL" && recordStatus === "AGREGADO") {
    } else {
        $(event.target).parent().parent().find(".RecordType").text("NOTEMPORAL");
        $(event.target).parent().parent().find(".RecordStatus").text("MODIFICADO");
    }
})

function AddAdditionalExamns() {
    let availableTags = [];
    let data = [];
    if (localStorage.getItem('components') == null) {
        APIController.GetComponents().then((res) => {
            //ADD LOCALSTORAGE
            localStorage.setItem('components', JSON.stringify(res.Data));
            data = res.Data;
            availableTags = data.map((res) => {
                return res.Name;
            });

            addRowAddExam();

            $(".tags").autocomplete({
                source: availableTags
            });

        });
    } else {
        data = JSON.parse(localStorage.getItem('components'));
        availableTags = data.map((res) => {
            return res.Name;
        });

        addRowAddExam();

        $(".tags").autocomplete({
            source: availableTags
        });
    }
}

function addRowAddExam() {       

    let idExamAdd = "ExamAdd-" + Math.random().toString(36).substring(7);
    let content = "";
    content += "<tr id='" + idExamAdd + "'>";
    content += "<td style='display:none' class='RecordType'>TEMPORAL</td>";
    content += "<td style='display:none' class='RecordStatus'>AGREGADO</td>";


    content += "<td style='display:none' class='AddExamID'></td>";
    content += "<td style='display:none' class='AddExamQuotationId'></td>";
    content += "<td style='display:none' class='AddExamCatId'></td>";
    content += "<td style='display:none' class='AddExamCatName'></td>";
    content += "<td style='display:none' class='AddExamCompId'></td>";
    content += "<td style='display:none' class='AddExamCompName'></td>";

    content += "<td><input class='form-control tags'></td>"
    content += "<td class='AddExamPreMin'></td>"
    content += "<td class='AddExamPreLis'></td>"
    content += "<td><input style='width:80px' type='text' class='form-control AddExamPreVen onlyDecimal'  value=''></td>"
    content += "<td class='col-center'><i class='fa fa-close text-danger m-r-10' onclick='RemoveAddExamn(event)'></i></td>"
    content += "</tr>";
    $('#tbody-Add-Examns').append(content);
}

function getDataComponent(value, event) {
    APIController.GetPriceList($("#txtCompanyId").val()).then((res) => {        
        objPriceList = res.Data;
        let data = JSON.parse(localStorage.getItem('components'));

        const result = data.filter(word => word.Name == value);
        $(event.target).parent().parent().find(".AddExamPreMin").text(result[0].CostPrice == null ? "" : result[0].CostPrice);                
        $(event.target).parent().parent().find(".AddExamPreLis").text(result[0].BasePrice == null ? "" : result[0].BasePrice);
        $(event.target).parent().parent().find(".AddExamCatId").text(result[0].CategoryId);
        $(event.target).parent().parent().find(".AddExamCatName").text(result[0].CategoryName);
        $(event.target).parent().parent().find(".AddExamCompId").text(result[0].ComponentId);
        $(event.target).parent().parent().find(".AddExamCompName").text(result[0].Name);

        $(event.target).parent().parent().find(".AddExamPreVen").val(SetPriceDB(result[0].ComponentId));
    });
    
}

function RemoveAddExamn(event) {
    var recordType = $(event.target).parent().parent().find(".RecordType").html();
    var recordStatus = $(event.target).parent().parent().find(".RecordStatus").html();
    var idTr = $(event.target).parent().parent().attr('id');

    if (recordType === "TEMPORAL" && recordStatus === "AGREGADO") {
        $(event.target).parent().parent().remove();
    } else {
        $(event.target).parent().parent().find(".RecordType").text("NOTEMPORAL");
        $(event.target).parent().parent().find(".RecordStatus").text("ELIMINADOLOGICO");
        $(event.target).parent().parent().hide();
    }
}

function CheckTrParen(idParent) {
    var rowCounter = $('#tbody-main tr.' + idParent + ':not([style*="display: none"]) ').length;
    if (rowCounter == 0) {
        //console.log("#", idParent);
        $("#" + idParent).css("display", "none");
    }

    CalculateTotals();
}

function UpdatePrice(params,componentName) {    
    APIController.SetPrice(params).then((res) => {
        newAlertCustom(res.ComponentId, componentName, " precio modificado");
        //let params = { "CompanyId": $("#txtCompanyId").val(), "ComponentId": componentId, "Price": e.currentTarget.value }        
        RefreshSalePrice(params.ComponentId, params.Price);
    });
}

function RefreshSalePrice(componentId, currentValue) {

    $("#tbody-main #" + componentId).each(function () {
        //console.log("SSSS", $(this));
        //console.log("currentValue", currentValue);
        $(this).val(currentValue);

    });
    
}