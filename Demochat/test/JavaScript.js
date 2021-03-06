$(function () {
    var chat = $.connection.chat;
    console.log(chat);
    loadClient(chat)
    $.connection.hub.start().done(function () {
        $('#btnSend').click(function () {
            var msg = $('#txtMessage').val();
            chat.server.message(msg);
            $('#txtMessage').val('').focus();
        });
    });

});
function loadClient(chat) {
    chat.client.message = function (msg) {
        $('#contentMsg').append("<li>" + msg + "</li>");
    }

}