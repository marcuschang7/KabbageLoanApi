$(document).ready(function () {
    var vd = $('#txtQualify').val();
    if (vd == 'Congratulations your Qualified' || vd == 'Sorry your not Qualified' || vd == 'Sorry this service is currently down or invalid values were entered.') {
        $('#myModal').modal('show');

    }
});
