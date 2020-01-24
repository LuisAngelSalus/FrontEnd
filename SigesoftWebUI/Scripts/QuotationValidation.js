function ValidateQuotation(e) {

    e.preventDefault();

    //I)eliminar la clase error
    clearErrors();

    //II)Valida inputs
    var validateRuc = validateInput("txtRuc", "Ruc requerido");
    var validateFullName = validateInput("txtFullName", "Primer Contacto requerido");
    var validateEmail = validateInput("txtEmail", "Email requerido");
    var validateHeadquarter = validateddlHeadquarter("ddlSede", "Sede requerida"); 
    var validateCommercialTerms = validateInput("txtCommercialTerms", "Términos comerciales requerido");    
    var validateTableQuotation = ValidateTableQuotation();
    //II)Retornar resultado de validación
    if (validateRuc && validateFullName && validateEmail && validateTableQuotation && validateHeadquarter && validateCommercialTerms) {       
        return true;
    } else {   
        return false;
    }    
}

function validateInput(id, message) {
    let element = document.getElementById(id);    
    if (!element.checkValidity()) {        
        newAlert(element, "VALIDACIÓN", message);
        InputError(element);
        return false;
    }
    return true;     
}

function clearErrors() {
    $("#txtRuc").removeClass('error');
    $("#txtFullName").removeClass('error');
    $("#txtEmail").removeClass('error');
    $("#tbody-main").parent().parent().removeClass('error');
}

function ValidateTableQuotation() {   
   return ValidateTable('tbody-main');
}

function ValidateTable(tbodyId) {
    var rowCounter = $('#' + tbodyId + '  tr.parent:not([style*="display: none"]) ').length;
    console.log("rowCounter", rowCounter);
    if (rowCounter == 0) {
        console.log($('#' + tbodyId).parent());
        $('#' + tbodyId).parent().parent().removeClass('card');
        $('#' + tbodyId).parent().parent().addClass('error');
        return false;
    }
    else {
        var breakOut;
        $('#' + tbodyId + ' tr').each(function (index, tr) {
            var trr = $(tr).find('#ddlService');
            if ($(trr).val() === "-1") {
                InputError($(trr));
                breakOut = true;
                return false;
            } 

        });

        $('#' + tbodyId + ' tr').each(function (index, tr) {
            var trr = $(tr).find('#ddlTypeFormat');
            if ($(trr).val() === "-1") {
                InputError($(trr));
                breakOut = true;
                return false;
            }

        });

        if (breakOut) {
            breakOut = false;
            return false;
        } else {
            console.log("¡????");
            return true;
        }

        
    }
} 

function validateddlHeadquarter(element,message) {    
    var val = $("#" + element+" option:selected").val();    
    if (val == undefined) {       
        newAlert(element, "VALIDACIÓN", message);
        return false;
    }
    return true;
}