$('#tipo_docume').addClass('col-md-6');
$('#tipo_docume').height('30px');
let valor_t = $('#tipo_documento').val();


$(document).ready(function () {
for (var option of document.getElementById('tipo_docume').options) {
    if (option.value === valor_t) {
        option.selected = true;
        return;
    }
    }


});

$('#tipo_docume').change(function () {
    
    $('#tipo_documento').val(this.value);
});


$('#tipo_estado').addClass('col-md-6');
$('#tipo_estado').height('30px');
let valort = $('#estado_afiliacion').val();


$(document).ready(function () {
    for (var option of document.getElementById('tipo_estado').options) {
        if (option.value === valort) {
            option.selected = true;
            return;
        }
    }


});

$('#tipo_estado').change(function () {

    $('#estado_afiliacion').val(this.value);
});
