function ValidateWorkerData(e) {
    e.preventDefault();
    //I)eliminar la clase error
    clearErrorsWorkerData();

    //II)Valida
    var validateFirstName = validateInputWorkerData("txtFirstName", "Primer nombre requerido");
    console.log("validateFirstName", validateFirstName);
    var validateFirstLastName = validateInputWorkerData("txtFirstLastName", "Apellido Paterno requerido");
    var validateSecondLastName = validateInputWorkerData("txtSecondLastName", "Apellido Materno requerido");
    var validateNroDocument = validateInputWorkerData("txtNroDocument", "Nro. Documento requerido");
    var validateDateBirth = validateInputWorkerData("dpt-DateOfBirth", "Fecha Nacimiento requerido");

    //Validate Gender--------------------------------------------------
    let validateGender = false;
    let GenderId = $("#select-gender-Worker option:selected").val();    
    if (GenderId == -1) {
        InputErrorWorkerData("#select-gender-Worker");
        newAlertWorkerData("select-gender-Worker", "VALIDACIÓN", "Género es requerido");
    } else {
        validateGender = true;
    }


    //Validate Calendar---------------------------------------------

    //II)Retornar resultado de validación
    if (validateFirstName && validateFirstLastName && validateSecondLastName && validateNroDocument && validateGender && validateDateBirth)
        return true;
    return false;

}


function clearErrorsWorkerData() {
    $("#txtFirstName").removeClass('error');
    $("#txtFirstLastName").removeClass('error');
    $("#txtSecondLastName").removeClass('error');
    $("#txtNroDocument").removeClass('error');
    $("#select-gender-Worker").removeClass('error');
    $("#dpt-DateOfBirth").removeClass('error');
}

function validateInputWorkerData(id, message) {
    let element = document.getElementById(id);
    if (!element.checkValidity()) {
        newAlertWorkerData(element, "VALIDACIÓN", message);
        InputErrorWorkerData(element);
        return false;
    }
    return true;
}

function InputErrorWorkerData(elem) {
    $(elem).addClass('error');
}

function newAlertWorkerData(elem, title, message) {
    var id = $(elem).attr('id');

    let content = "";
    content += "<div id='vali-" + id + "' class='alert alert-warning alert-dismissible fade show alertCustom' role='alert'>";
    content += "<strong>" + title + "</strong> <span>" + message + "</span> ";
    content += "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>";
    content += "<span aria-hidden='true'>&times;</span>";
    content += "</button>";
    content += "</div>";

    $('.content-alert').append(content);

    $("#vali-" + id).delay(2000).slideUp(200, function () {
        $(this).alert('close');
    });
}
