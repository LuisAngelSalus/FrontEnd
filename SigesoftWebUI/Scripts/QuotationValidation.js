function ValidateQuotation(e) {
    e.preventDefault();
    //1)eliminar la clase error
    clearErrors();
    //2)Valida inputs
    var validateRuc = validateInput("txtRuc", "Ruc requerido");
    var validateFullName = validateInput("txtFullName", "Primer Contacto requerido");
    var validateEmail = validateInput("txtEmail", "Email requerido");
    var validateTableQuotation = ValidateTableQuotation();
    
    //3)Retornar resultado de validación
    if (validateRuc && validateFullName && validateEmail && validateTableQuotation) {       
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
    var rowCounter = $('#' + tbodyId + ' tr').length;
    console.log("WWW", rowCounter);
    if (rowCounter == 0) {
        console.log($('#' + tbodyId).parent());
        $('#' + tbodyId).parent().parent().removeClass('card');
        $('#' + tbodyId).parent().parent().addClass('error');
        return false;
    }
    else {
        return true;
    }
} 