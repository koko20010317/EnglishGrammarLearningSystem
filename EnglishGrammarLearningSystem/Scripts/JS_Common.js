var ajax_get_unSuccessStr = 'Oops! Fail to get content, <br>please try again later!';
var ajax_get_errorStr = 'Oops! Fail to get content(error), <br>please try again later!';
var ajax_put_unSuccessStr = 'Oops! Fail to upload data, <br>please try again later!';
var ajax_put_errorStr = 'Oops! Fail to upload data(error), <br>please try again later!';

function LoadingBlockUI() {
    $.blockUI({
        message: '<img src="' + baseUrl + 'Content/loading.gif" style="width:10%">',
        css: {
            'width': '30%',
            'top': '40%',
            'left': '35%',
            'text-align': 'center',
            'color': 'rgb(0, 0, 0)',
            'border': '3px solid rgba(170, 170, 170, 0)',
            'background-color': 'rgba(255, 255, 255, 0)',
            'z-index': '5000'
        }
    });

    $('.blockPage').css('z-index', '6000');
    $('.blockOverlay').css('z-index', '5000');
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    while (1)
        if ((new Date().getTime() - start) > milliseconds)
            break;
}

// Opera 8.0+
var isOpera = (!!window.opr && !!opr.addons) || !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;

// Firefox 1.0+
var isFirefox = typeof InstallTrigger !== 'undefined';

// Safari 3.0+ "[object HTMLElementConstructor]" 
var isSafari = /constructor/i.test(window.HTMLElement) || (function (p) { return p.toString() === "[object SafariRemoteNotification]"; })(!window['safari'] || (typeof safari !== 'undefined' && safari.pushNotification));

// Internet Explorer 6-11
var isIE = /*@cc_on!@*/false || !!document.documentMode;

// Edge 20+
var isEdge = !isIE && !!window.StyleMedia;

// Chrome 1 - 71
var isChrome = !!window.chrome && (!!window.chrome.webstore || !!window.chrome.runtime);

// Blink engine detection
var isBlink = (isChrome || isOpera) && !!window.CSS;

//function browserDetection() {    
//    if (isChrome != true && isFirefox != true) {
//        location.href = browserNs;
//    }
//}

//browserDetection();

$(document).on('click', 'input:checkbox', function () {
    // in the handler, 'this' refers to the box clicked on
    var $box = $(this);
    if ($box.is(":checked")) {
        // the name of the box is retrieved using the .attr() method
        // as it is assumed and expected to be immutable
        var group = "input:checkbox[name='" + $box.attr("name") + "']";
        // the checked state of the group/box on the other hand will change
        // and the current value is retrieved using .prop() method
        $(group).prop("checked", false);
        $box.prop("checked", true);
    } else {
        $box.prop("checked", false);
    }
});

function validateEmail(email) {
    //var re = /^(([^<>()\[\]\\.,;:\s@@"]+(\.[^<>()\[\]\\.,;:\s@@"]+)*)|(".+"))@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var re = /\S+@\S+\.\S+/;
    return re.test(String(email).toLowerCase());
}