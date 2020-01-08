function validateInputNumber(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

function newAlert(elem, title, message) {    
    var id = $(elem).attr('id');
    
    let content = "";
    content += "<div id='vali-" + id+"' class='alert alert-warning alert-dismissible fade show alertCustom' role='alert'>";
    content += "<strong>" + title + "</strong> <span>" + message +"</span> ";
    content += "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>";
    content += "<span aria-hidden='true'>&times;</span>";
    content += "</button>";
    content += "</div>";

    $('.content-alert').append(content);

    $("#vali-" + id).delay(2000).slideUp(200, function () {
        $(this).alert('close'); 
    });
}

function InputError(elem) {    
    $(elem).addClass('error');
}



