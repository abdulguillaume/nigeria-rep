//i will add validation for client side validation


$.validator.addMethod(
"otherspecifyvalidation",
function (value, element, params) {
    //var tmp = (value != '' ? params : '-1');
    var sel = $('[id$=' + params['propertyname'] + ']').val();

    //    if (sel != '' && params['desiredvalue'] == '') {
    //        return false;
    //    }
    //    else if (sel == '' && params['desiredvalue'] != '') {
    //        return false;
    //    }
    //    else if (sel == params['desiredvalue'] && value == '') {
    //        return false;
    //    }
    //    else if (sel != params['desiredvalue'] && value != '') {
    //        alert("tstett");
    //        return false;
    //    }

    if (
    (sel == params['desiredvalue'] && value != '') ||
        (sel != params['desiredvalue'] && value == '')
    ) {
        return true;
    } 

    return false;

});


$.validator.unobtrusive.adapters.add('otherspecifyvalidation', ['propertyname', 'desiredvalue'], function (options) {
    options.rules['otherspecifyvalidation'] = {
        propertyname: options.params['propertyname'].split(','),    
        desiredvalue: options.params['desiredvalue'].split(',') 
    };
//    var desiredvalue = options.params.desiredvalue;
//    var propertyname = options.params.propertyname;
    options.messages["otherspecifyvalidation"] = options.message;
});


//$.validator.addMethod(
//"nullvalidation",
//function (value, element, params) {
//    var sel = $('[id$=0_' + params['propertyname'] + ']').val();
//    alert(params['propertyname']);
//    if (sel != '' && value == '') {
//        return false;
//    }

//    return true;

//});

//$.validator.unobtrusive.adapters.add('nullvalidation', ['propertyname'], function (options) {
//    options.rules['nullvalidation'] = options.params.propertyname;
//    options.messages["nullvalidation"] = options.message;
//});
