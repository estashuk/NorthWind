function Disable_Scrolling(){
    $("html, body").css("overflow", "hidden");
};
function Enable_Scrolling(){
    $("html, body").css("overflow", "");
};
function ShowCart() {
    $("#cartState").dialog({
        open: function() {
            Disable_Scrolling();
        },
        close: function() {
            Enable_Scrolling();
        },
        height: 500,
        width: 600,
        modal: true
    });
}
function CloseCartWindow() {
    $("#cartState").dialog("close");
}

//function ShowCart() {
//    $("#cartState").kendoWindow({
//        open: function (e) {
//            Disable_Scrolling();
//        },
//        close: function(e){
//            Enable_Scrolling();
//        },
//        title: lang("Редагування"),
//        modal: true,
//        pinned: true,
//        width: 600,
//        height: 350,
//        maxHeight: (document.parentWindow || document.defaultView).innerHeight - 100
//    }).data("kendoWindow");
//}
