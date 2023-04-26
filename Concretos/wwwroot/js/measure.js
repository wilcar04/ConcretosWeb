$(document).ready(function () {
    setRemainingHeight('form-measure', 'table-measures', 65);

    $('#btn-calculate').click(function () {
        calculate();
    });

    $('#experimental-porosity').keyup(function () {
        validatePorosity()
    });

});

function modalExperimentalData() {
    $('#modal-experimental-data').modal('show');
}

function calculate() {
    $('#expected-density').val(10);
    $('#expected-resistence').val(10);
}

function validatePorosity() {
    const porosity = $('#experimental-porosity').val();

    if (isNaN(porosity) || porosity < 0 || porosity > 100) {
        $('#experimental-porosity').addClass('border-danger');
    } else {
        $('#experimental-porosity').removeClass('border-danger');
    }
}