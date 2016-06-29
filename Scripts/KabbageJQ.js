$(document).ready(function () {

    var vd = $('#txtQualify').val();
    if (vd == 'Qualified' || vd == 'NotQualified' || vd == 'TryAgain') {
        if (vd == 'Qualified') {
            $('#Status').text("Your Pre-Approved Click the Apply Now button to continue");
            $('#btnApply').show();
        }
        if (vd == 'NotQualified') {
            $('#divBTNapplynow').hide();
            $('#Status').text("Sorry your not approved");
        }
        if (vd == 'TryAgain') {
            $('#divBTNapplynow').hide();
            $('#Status').text("Please check your entries or try again later");
        }

        $('#myModal').modal('show');


    }
});
