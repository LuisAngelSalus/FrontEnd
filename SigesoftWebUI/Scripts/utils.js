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
    var regex = /[0-9]/;
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

function newAlertCustom(elem, title, message) {
    var id = $(elem).attr('id');

    let content = "";
    content += "<div id='vali-" + id + "' class='alert alert-warning alert-dismissible fade show alertCustom' role='alert'>";
    content += "<strong>" + title + "</strong> <span>" + message + "</span> ";
    content += "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>";
    content += "<span aria-hidden='true'>&times;</span>";
    content += "</button>";
    content += "</div>";

    $('.alert-popup-profile').append(content);

    $("#vali-" + id).delay(2000).slideUp(200, function () {
        $(this).alert('close');
    });
}

function InputError(elem) {    
    $(elem).addClass('error');
}

function isNumberKey(evt) {    
    var charCode = (evt.which) ? evt.which : evt.keyCode;    
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function baseUrl() {
    var href = window.location.href.split('/');
    return href[0] + '//' + href[2] + '/';
}

function checkPassword(password) {
	var strength = 0;
	if (password.length >= 5) {
		strength++;

		if (password.match(/([a-z])/) && password.match(/([A-Z])/)) {
			strength++;
		}
		if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) {
			strength++;
		}
		if (password.match(/([!, @, #, $, %, ^, &, *, _, ~, ?])/)) {
			strength++;
		}
		if (password.match(/(.*[!, @, #, $, %, ^, &, *, _, ~, ?].*[!, @, #, $, %, ^, &, *, _, ~, ?])/)) {
			strength++;
		}

	}

	if (strength == 0) {
		$("#meter").progressbar({ value: 20 });
		$(".ui-progressbar-value").css("background", "red");
		$("#result").html("Demasiado corta").css("color", "red");
	}
	else if (strength < 3) {
		$("#meter").progressbar({ value: 40 });
		$(".ui-progressbar-value").css("background", "orange");
		$("#result").html("Débil").css("color", "orange");
	}
	else if (strength == 3) {
		$("#meter").progressbar({ value: 70 });
		$(".ui-progressbar-value").css("background", "blue");
		$("#result").html("Buena").css("color", "blue");
	}
	else {
		$("#meter").progressbar({ value: 100 });
		$(".ui-progressbar-value").css("background", "green");
		$("#result").html("Segura").css("color", "green");
	}
	if (password.length == 0) {
		$("#meter").progressbar({ value: 0 });
		$(".ui-progressbar-value").css("background", "white");
		$("#result").html("");
	}
}