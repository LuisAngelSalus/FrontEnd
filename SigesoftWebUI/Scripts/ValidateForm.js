function validateInputText(element) {
    let $elem = $(element);    
    if ($elem.get(0).value == "") {        
        $elem.addClass('error');
        return false
    };
    
    return true;
}