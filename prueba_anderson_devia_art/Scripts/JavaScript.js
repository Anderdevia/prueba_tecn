$("#primer").hide();
function ShowSelected() {
    /* Para obtener el valor */
    var cod = document.getElementById("tipo").value;

    /* Para obtener el texto */
    var combo = document.getElementById("tipo");
    var selected = combo.options[combo.selectedIndex].text;
    $("#tipo_documento").val(cod);
}