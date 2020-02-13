
var objMigration = []
var objPriceListMigration = [];

function openMigrateProtocol(title) {
    //Setear Título del popup
    $("#exampleModalTitle").text(title);

    //Validar que una empresa esté seleccionada
    if ($("#txtCompanyId").val() == 0) {
        swal("Validación", "¡Seleccione una empresa!", "error");
        return;
    }

    //Limpiar temporales
    objMigration = [];
    $("#table-protocols tbody").empty();
    $("#table-Components-Migra tbody").empty();    

    //Obtner Precios de empresa seleccionada
    GetPriceListByCompany();

    //Lanzar Popup
    $("#MigrateProtocolModal").modal("show");    

    $("#txtCompany").autocomplete({        
        minLength: 4,
        delay: 500,
        create: function () { $(this).val("");},
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
            $("#table-Components-Migra tbody").empty();
            let idCompany = ui.item.value;
            APIController.GetAllProtocolsByCompany(idCompany).then((res) => {
                renderTableProtocols(res.Data);
            });
            
            $(this).val(ui.item.label);
            $(this).val("");
            return false;
        }
    });  

    $("#txtAddExamMigra").autocomplete({        
        create: function () { $(this).val(""); },
        source: function (request, response) {

            let result = JSON.parse(localStorage.getItem('components'));
          
            var filterArray = $.map(result, function (item, index) {                
                if (item.Name.toUpperCase().indexOf(request.term.toUpperCase()) != -1) {                                        
                    return {
                        "label": item.Name,
                        "value": item.ComponentId,                                                
                        "Category": item.CategoryName,
                        "CategoryId": item.CategoryId
                    }                    
                }
            })
            response(filterArray);
        },
        open: function () {
            $(this).autocomplete('widget').css('z-index', 8000);
            return false;
        },
        select: function (event, ui) {
            
            AddExamenMigration(ui);
            
            $(this).val(ui.item.label);
            $(this).val("");
            return false;
        }
    });

}

function protocolExistsInobjMigration(idProtocolId) {
    
    let result = objMigration.some((res) => {
        return res.protocolId == idProtocolId;
    });    
    return result;
}

function renderTableProtocols(data) {
    let content = "";
    for (var i = 0; i < data.length; i++) {       
        content += "<tr>";
        if (!protocolExistsInobjMigration(data[i].ProtocolId)) {            
            content += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="protocol-' + data[i].ProtocolId + '" value="check"> <label for="protocol-' + data[i].ProtocolId + '"></label> </div></td>'
        } else {
            
            content += '<td style="width:40px">  <div class="checkbox"> <input type="checkbox" id="protocol-' + data[i].ProtocolId + '" value="check" checked> <label for="protocol-' + data[i].ProtocolId + '"></label> </div></td>'
        }        
        content += "<td class='row-protocol'>" + data[i].ProtocolId + "</td>";
        content += "<td class='row-protocol'>" + data[i].ServiceTypeName + "</td>";
        content += "<td class='row-protocol'>" + data[i].ProtocolName + "</td>";
        content += "<td class='row-protocol'>" + data[i].TypeFormatName + "</td>";        
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
    $("#table-Components-Migra tbody").empty();
    let protocolId = event.target.id.split('-')[1];       
    let searchInobjMigration = protocolExistsInobjMigration(protocolId);   

    if (event.target.checked) { 
        AddClassRowSelectd(event);       
        if (!searchInobjMigration) {
            renderTableDetailProtocol(protocolId, event);
            $("#protocolIdShown").val(protocolId);
        }        
    } else {
        RemoveClassRowSelectd(event)
        if (searchInobjMigration) {
            objMigration = objMigration.filter((res) => {
                return res.protocolId != protocolId;
            });
        }
    }
});

$('#table-protocols').on('click','.row-protocol', function (event) {
    $('#table-protocols > tbody  > tr').each(function (index, tr) {
        $(tr).removeClass("rowSelected");
    });
    $(this).parent().addClass("rowSelected");
    let protocolId = $(this).parent().find("input").attr('id').split('-')[1];
    $("#protocolIdShown").val(protocolId);
    renderTableDetailProtocol(protocolId, null);
});

function AddClassRowSelectd(event) {

    $('#table-protocols > tbody  > tr').each(function (index, tr) {                
        $(tr).removeClass("rowSelected");
    });

    $(event.target).parent().parent().parent().addClass("rowSelected");
}

function RemoveClassRowSelectd(event) {

    $(event.target).parent().parent().parent().removeClass("rowSelected");
}

function renderTableDetailProtocol(idProtocol, event) { 
    
    let search = objMigration.filter((res) => {
        return res.protocolId == idProtocol;
    })
    if (search.length != 0) {
        builTableDetailProtocol(search[0].componentes, event);
    } else {
        //Buscar en la BD 
        APIController.GetProtocolDetailByProtocolId(idProtocol).then((res) => {
            builTableDetailProtocol(res.Data, event);
        });
    }
}

function builTableDetailProtocol(data, event) {
    let content = "";
    let buffer = "";
    for (var i = 0; i < data.length; i++) {
        if (buffer == data[i].CategoryName) {
            content += "<tr class='componente componente-" + data[i].CategoryName + "'>";
            content += "<td colspan='2'>" + data[i].ComponentName + "<i class='icon-trash' onclick=removeComponetMigra(event)></i></td>";
            content += "</tr>";
        } else {
            buffer = data[i].CategoryName;
            content += "<tr class='categoria categoria-" + data[i].CategoryName + "'>";
            content += "<td style='width:15px;'><i class='fa fa-plus text-inverse' onclick=showComponetsMigra('" + data[i].CategoryName + "')></i></td>";
            content += "<td>" + data[i].CategoryName + "</td>";
            content += "</tr>";
            i--;
        }
    }
    $("#table-Components-Migra tbody").empty();
    $("#table-Components-Migra tbody").append(content);
    addProfileObjMigration(event, data);
}

function showComponetsMigra(component) {
    var tdIcon = $($(".categoria-" + component + " td")[0]).find("i");
    let childClass = '.componente-' + component;
    if ($(childClass).css("display") == "none") {
        $(childClass).fadeIn(500);
        $(childClass).show();
        tdIcon.addClass('fa-minus');
        tdIcon.removeClass('fa-plus');
    } else {
        $(childClass).hide();
        tdIcon.removeClass('fa-minus');
        tdIcon.addClass('fa-plus');
    }
}

function removeComponetMigra(elem) {    
    let componentName = $(elem.target).parent().text().replace("nuevo","");      
    $(elem.target).parent().parent().remove();
    let nombrePadre = $($($(elem.target).parent().parent()))[0].classList[1].split('-')[1];    
    
    let countChild = $("#table-Components-Migra tbody").find(".componente-" + nombrePadre).length;    
    
    if (countChild == 0) {
        $(".categoria-" + nombrePadre).remove();
    }  
    //Remover del objeto objMigration un nuevo item
    let protocolId = $("#protocolIdShown").val();
    objMigration.map((res) => {

        if (res.protocolId == protocolId) {

           res.componentes = res.componentes.filter((res) => {
                return res.ComponentName != componentName;
            });
        }

    });
}

function AddExamenMigration(ui) {
    let ComponentId = ui.item.value;
    let ComponentName = ui.item.label;
    let CategoryName = ui.item.Category;
    let CategoryId = ui.item.CategoryId;
    let result = verifyIfComponentIsExistsObjMigration($("#protocolIdShown").val(), ComponentName);
    
    if (result === "BLOQUEADO") {
        alert("check en protocolo para editar");
        return;
    } else if (result === "EXISTE") {
        alert("Este componente ya existe");
        return;

    }

    let classCategoryName = "categoria-" + CategoryName;    
    let serarchParent = $("#table-Components-Migra tbody").find("."+classCategoryName).length;
    let content = "";

    //Crear una nueva categoría con el nuevo examen
    if (serarchParent == 0) {
        
        content += "<tr class='categoria categoria-"+CategoryName+"'>";
        content += "<td style='width:15px;'><i class='fa fa-plus text-inverse' onclick=showComponetsMigra('"+ CategoryName+"')></i></td>";
        content += "<td>"+CategoryName+"</td>";
        content += "</tr >";
        content += "<tr class='componente componente-" + CategoryName +"'>";
        content += "<td colspan='2'>"+ ComponentName+"<i class='icon-trash' onclick=removeComponetMigra(event)></i></td>";
        content += "</tr >";

        $("#table-Components-Migra tbody").append(content);

    } else {

        content += "<tr class='componente componente-" + CategoryName + "'>";
        content += "<td colspan='2'>" + ComponentName + "<span class='label label-info label-rounded'>nuevo</span><i class='icon-trash' onclick=removeComponetMigra(event)></i></td>";
        content += "</tr >";

        $(".categoria-" + CategoryName).after(content);
    }

    //Agregar al objeto objMigration un nuevo item
    let protocolId = $("#protocolIdShown").val();    
    let priceCompany = objPriceListMigration.find(p => p.ComponentId == ComponentId) == undefined ? 0 : objPriceListMigration.find(p => p.ComponentId == ComponentId).Price;
    
    objMigration.map((res) => {
        if (res.protocolId == protocolId) {
            res.componentes.push({
                ProtocolDetailId: 0,
                ProtocolId: parseInt(protocolId),
                CategoryId: CategoryId,
                CategoryName: CategoryName,
                ComponentId: ComponentId,
                ComponentName: ComponentName,
                MinPrice: 0,
                PriceList: 0,
                SalePrice: priceCompany,
                AgeConditionalId: 0,
                Age: 0,
                GenderConditionalId: 0,
                QuotationProfileIdRef: 0,
            });

            return res;
        }

    });
}

function addProfileObjMigration(event,components) {
    if (event != null) {
        let typeAcction = $("#exampleModalTitle").text();
        
        if (typeAcction == "Migrar Protocolo") {

            components = components.map((item) => {
                item.SalePrice = 0;
                return item;
            });
            
            objMigration.push({
                protocolId: $($(event.target).parent().parent().parent()[0].children[1]).html(),
                tipoEmo: $($(event.target).parent().parent().parent()[0].children[2]).html(),
                protocolName: $($(event.target).parent().parent().parent()[0].children[3]).html(),
                ficha: $($(event.target).parent().parent().parent()[0].children[4]).html(),
                componentes: components
            });
        } else {
            objMigration.push({
                protocolId: $($(event.target).parent().parent().parent()[0].children[1]).html(),
                tipoEmo: $($(event.target).parent().parent().parent()[0].children[2]).html(),
                protocolName: $($(event.target).parent().parent().parent()[0].children[3]).html(),
                ficha: $($(event.target).parent().parent().parent()[0].children[4]).html(),
                componentes: components
            });
        }
        

    } else {
        console.log("No está en memoria");
    }
    
}

function verifyIfComponentIsExistsObjMigration(protocolId, componentName) {

    let objProtocol = objMigration.find(p => p.protocolId == protocolId);
    
    if (objProtocol == undefined) {
        return "BLOQUEADO";
    }
    let result = objProtocol.componentes.some((comp) => {
       return comp.ComponentName == componentName;
    });

    if (result) return "EXISTE";

    return "NOEXISTE";
    
}

function dynamicSort(property) {
    var sortOrder = 1;
    if (property[0] === "-") {
        sortOrder = -1;
        property = property.substr(1);
    }
    return function (a, b) {
        /* next line works with strings and numbers, 
         * and you may want to customize it to your needs
         */
        var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
        return result * sortOrder;
    }
}

function SaveMigrateProtocol() {

    for (var i = 0; i < objMigration.length; i++) {
        
    let idPerfil = "perfil-" + Math.random().toString(36).substring(7);
    var content = "";
    content += "<tr id='" + idPerfil + "' class='parent'>";
    content += "<td><i class='fa fa-plus text-inverse m-r-10' onclick=show('" + idPerfil + "')></i></td>";
    content += "<td style='display:none' class='RecordType'>TEMPORAL</td>";
    content += "<td style='display:none' class='RecordStatus'>AGREGADO</td>";        
    content += "<td class='profileId' style='display:none'>" + objMigration[i].protocolId + "</td>";
    content += "<td><input class='form-control input-perfil' type='text' value='" + objMigration[i].protocolName + "' disabled/></td>";
    content += "<td>";

    content += "<select class='form-control form-white select-Service' data-placeholder='Seleccione un servicio...' id='ddlService' disabled>";


    if ("Preocupacional" === objMigration[i].tipoEmo) {
        content += "<option value='1'>Preocupacional</option>";
    } else if ("Periodico" === objMigration[i].tipoEmo) {
        content += "<option value='2'>Periodico</option>";
    } else if ("Retiro" === objMigration[i].tipoEmo) {
        content += "<option value='3'>Retiro</option>";
    } else {
        content += "<option value='4'>Visita</option>";
    }

    content += "</select>";

    content += "</td>";

    content += "<td>";
    content += "<select class='form-control form-white select-TypeFormat' id='ddlTypeFormat'>";
    content += "<option value='-1'>--Seleccionar--</option>";
        if ("RM 312" === objMigration[i].ficha) {
            content += "<option value='1' selected>RM 312</option>";
            content += "<option value='2'> Anexo 16</option >";
            content += "<option value='3'> Anexo 16.A</option >";
            content += "<option value='4'> Ambos</option >";
            content += "<option value='5'>Componente</option >";
        } else if ("Anexo 16" === objMigration[i].ficha) {
            content += "<option value='1'>RM 312</option>";
            content += "<option value='2' selected> Anexo 16</option >";
            content += "<option value='3'> Anexo 16.A</option >";
            content += "<option value='4'> Ambos</option >";
            content += "<option value='5'>Componente</option >";
        } else if ("Anexo 16.A" === objMigration[i].ficha) {
            content += "<option value='1'>RM 312</option>";
            content += "<option value='2'> Anexo 16</option >";
            content += "<option value='3' selected> Anexo 16.A</option >";
            content += "<option value='4'> Ambos</option >";
            content += "<option value='5'>Componente</option >";
        } else if ("Ambos" === objMigration[i].ficha) {
            content += "<option value='1'>RM 312</option>";
            content += "<option value='2'> Anexo 16</option >";
            content += "<option value='3'> Anexo 16.A</option >";
            content += "<option value='4' selected> Ambos</option >";
            content += "<option value='5'>Componente</option >";
        } else if ("Componente" === objMigration[i].ficha) {
            content += "<option value='1'>RM 312</option>";
            content += "<option value='2'> Anexo 16</option >";
            content += "<option value='3'> Anexo 16.A</option >";
            content += "<option value='4'> Ambos</option >";
            content += "<option value='5' selected>Componente</option >";
        }

   
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
        var components = objMigration[i].componentes;
        components.sort(dynamicSort("CategoryName"));        
    let quotationProfileId = "perfil-" + Math.random().toString(36).substring(7);
        for (let ii = 0; ii < components.length; ii++) {
            
        let cateName = components[ii].CategoryName.replace(/\s/g, "_");
        let valorAntiguo = components[ii].CategoryName.replace(/\s/g, "_");

        if (valor != valorAntiguo) {
            valor = valorAntiguo;
            content += "<tr id='" + quotationProfileId + "-" + cateName + "'>";
            content += "<td><i class='fa fa-minus text-inverse m-r-10' onclick=show('" + quotationProfileId + "-" + cateName + "')></i></td>";
            content += "<td colspan='9'>" + cateName + "</td>";
            content += "</tr>";
            ii--;
        } else {
            content += "<tr class=" + quotationProfileId + "-" + cateName + ">";
            content += "<td style='color:white'>" + components[i].ProtocolDetailId + "</td>";
            content += "<td style='display:none'>" + components[i].CategoryId + "</td>";
            content += "<td style='display:none'>" + components[i].ComponentId + "</td>";
            
            content += "<td style='display:none'class='RecordType'>TEMPORAL</td>";
            content += "<td style='display:none'class='RecordStatus'>AGREGADO</td>";
            content += "<td>" + components[ii].ComponentName + "</td>";



            content += "<td>";
            content += "<select class='form-control form-white select-ConditionalAge' id='ddlConditionalAge'>";
            
            if ("1" == components[ii].AgeConditionalId) {
                content += "<option value='-1'></option>";
                content += "<option value='1' selected>Mayores de</option>";
                content += "<option value='2'> Menores de</option >";
            } else if ("2" == components[ii].AgeConditionalId) {
                content += "<option value='-1'></option>";
                content += "<option value='1'>Mayores de</option>";
                content += "<option value='2' selected> Menores de</option >";
            } else {
                content += "<option value='-1' selected></option>";
                content += "<option value='1'>Mayores de</option>";
                content += "<option value='2'> Menores de</option >";
            }        

            content += "</select>";
            content += "</td>";
            if (components[ii].Age == null || components[ii].Age == 0) {
                content += "<td><input class='form-control input-numeric' type='text' maxlength='2' min='0' max='90' onkeypress='validateInputNumber(event)'></td>";
            } else {
                content += "<td><input class='form-control input-numeric' type='text' maxlength='2' min='0' max='90' onkeypress='validateInputNumber(event)' value=" + components[ii].Age + "></td>";
            }
            
            content += "<td>";
            content += "<select class='form-control form-white select-ConditionalGender' id='ddlConditionalGender'>";
            content += "<option value='-1'></option>";

            if ("1" == components[ii].GenderConditionalId) {
                content += "<option value='1' selected>Masculino</option>";
                content += "<option value='2'> Femenino</option >";
                content += "<option value='3'> Ambos</option >";
            } else if ("2" == components[ii].GenderConditionalId) {
                content += "<option value='1'>Masculino</option>";
                content += "<option value='2' selected> Femenino</option >";
                content += "<option value='3'> Ambos</option >";
            } else if ("3" == components[ii].GenderConditionalId) {
                content += "<option value='1' >Masculino</option>";
                content += "<option value='2'> Femenino</option >";
                content += "<option value='3' selected> Ambos</option >";
            }

            content += "</select >";
            content += "</td >";


            content += "<td class='col-center'>" + components[ii].MinPrice + "</td>";
            content += "<td class='col-center'>" + components[ii].PriceList + "</td>";
            content += "<td class='col-center'><input type='text' id='" + components[ii].ComponentId + "' class='form-control salePrice input-numeric' value=" + components[ii].SalePrice+"> </td>";
            
            content += "<td class='col-center'><i class='fa fa-close text-danger m-r-10' onclick='RemoveComponent(event)'></i></td>";
            content += "</tr>";
        }

    }

    content += "</tbody>";
    content += "</table>";
    content += "</td>";
    content += "</tr>";
    $('#tbody-main').append(content);

        let title = $("#exampleModalTitle").text();
        if (title == "Migrar Protocolo") {
            let tramite = parseFloat($(".Tramite").text());
            tramite += 10;
            $(".Tramite").text(tramite);
        } else {
            let tramite = parseFloat($(".Tramite").text());
            tramite += 0;
            $(".Tramite").text(tramite);
        }
    

    CalculateTotals();
}

}