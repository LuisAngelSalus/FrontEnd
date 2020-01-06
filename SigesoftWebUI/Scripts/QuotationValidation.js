function ValidateQuotation(e) {
    e.preventDefault();
    //1)eliminar la clase error
    clearErrors();
    //Valida inputs
    var validateRuc = validateInput("txtRuc", "Ruc requerido");
    var validateFullName = validateInput("txtFullName", "Primer Contacto requerido");
    var validateEmail = validateInput("txtEmail", "Email requerido");

    //Retornar resultado de validación
    if (validateRuc && validateFullName && validateEmail) {       
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
}