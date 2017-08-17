$(document).ready(function () {
    $("#dtNascimento").mask("99/99/9999");



    $("#dialog").dialog({
        modal: true,
        bgiframe: true,
        width: 500,
        height: 200,
        autoOpen: false
    });


    $(".excluir").click(function () {        

        $("#dialog").dialog('option', 'buttons', {
            "Confirm": function () {
                window.location.href = theHREF;
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        });

        $("#dialog").dialog("open");
    });
});