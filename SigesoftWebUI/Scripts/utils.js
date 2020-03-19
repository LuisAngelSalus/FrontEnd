//constantes
const PROFILE_POTENCIAL = 96;
const STATUS_QUOTATION_POTENCIAL = 4;
const STATUS_QUOTATION_SEGUIMIENTO = 1;
const STATUS_QUOTATION_ACEPTADA = 2;
const STATUS_QUOTATION_DESCARTADA = 3;

const ROLE_SISTEMAS = 1;
const ROLE_MEDICO = 2;
const ROLE_RECEPCION = 3;
const ROLE_GERENCIA = 4;
const ROLE_COMERCIAL = 5;
const ROLE_ADMNISTRADOR = 6;
const ROLE_CLIENTE = 7;
const ROLE_TRABAJADOR = 8;


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

function getFirstAndLastDayOfMonth() {
    var date = new Date();
    var primerDia = new Date(date.getFullYear(), date.getMonth(), 1);
    var ultimoDia = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    primerDia = moment(primerDia).format("DD/MM/YYYY");
    ultimoDia = moment(ultimoDia).format("DD/MM/YYYY");
    return {
        "FirstDate": primerDia,
        "EndDate": ultimoDia
    }
}

function MessageTable(response,nroColumns,className) {
    return `<tr class='${className}'><td colspan='${nroColumns}'><p> ${response.Message} </p></td></tr>`;
}

function formatDate(dateString) {
    if (dateString == null) return "";

    moment.locale('es');
    return moment(dateString).format("DD, MMMM YYYY");
}

function formatDateForCalendar(dateString) {
    if (dateString == null) return "";

    moment.locale('es');
    return moment(dateString).format("DD/MM/YYYY");
}

function browserSupportsNotifications(){
    if (!window.Notification) {
        return false;
        alert("No soporta notificaciones");
    } else {        
        return true;   
    }
}

function requestPermission() {
    if (window.Notification.permission === "granted") {        
        new Notification("Hola Mundo -granted");
    } else if (
        Notification.permission !== "denied" ||
        Notification.permission !== "default"
    ) {
        Notification.requestPermission(function (permission) {
            if (permission === "granted") {
                new Notification("Hola mundo - pregunta");
            }
        });
    }

    if (window.Notification && Notification.permission == 'granted') {
        // We would only have prompted the user for permission if new
        // Notification was supported (see below), so assume it is supported.
        //doStuffThatUsesNewNotification();
        new Notification("Hola Mundo -granted");
    } else if (isNewNotificationSupported()) {
        // new Notification is supported, so prompt the user for permission.
        showOptInUIForNotifications();
    }
}

function urlBase64ToUint8Array(base64String) {
    const padding = "=".repeat((4 - (base64String.length % 4)) % 4);
    const base64 = (base64String + padding).replace(/-/g, "+").replace(/_/g, "/");

    const rawData = window.atob(base64);
    const outputArray = new Uint8Array(rawData.length);

    for (let i = 0; i < rawData.length; ++i) {
        outputArray[i] = rawData.charCodeAt(i);
    }

    return outputArray;
}