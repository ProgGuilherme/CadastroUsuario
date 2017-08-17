$(document).ready(function () {
    $("#dtNascimento").mask("99/99/9999");
    $(".mensagem").hide();
    $(".excluir").click(function () {
        $(".mensagem").dialog({
            modal: true,
            buttons: {
                Cancelar: function () {
                    $(this).dialog("close");
                    return false;
                },
                Excluir: function () {
                    $(this).dialog("close");
                    var objId = $(".excluir").attr('data-id');
                    window.location.href = "Excluir?idUsuario=" + objId;
                }
            }
        });
    });
});