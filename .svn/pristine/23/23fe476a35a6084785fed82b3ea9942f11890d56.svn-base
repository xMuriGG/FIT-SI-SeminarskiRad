
var brojeva = $('#brojevaTelefona').val();

var naziv = '';


$("#AddBtn").click(function dodajUnosTelefona() {

    if (brojeva < 5) {

        naziv = getNaziv("BrojeviTelefona", brojeva);

        //var $brojTextBox = $('[name="BrojeviTelefona[0].Broj"]');
        //var $brojTextBoxClone = $brojTextBox.clone().prop('name', naziv + '.Broj');
        //var $tip = $('[name="BrojeviTelefona[0].TipTelefona"]'s);
        //var $tipklon = $tip.clone().prop('name', naziv + '.TipTelefona');

        //$("#brojevi").append($brojTextBoxClone);
        //$("#brojevi").append($tipklon);


        var id = $("#brojevi #broj:first");
        if (id.length > 0) {
            var clone = id.clone();

            clone.find("input, select").each(function () {
                var element = $(this);
                var elementID = element.attr('id').replace('0', brojeva);
                var elementName = element.attr('name').replace('0', brojeva);
                element.attr('id', elementID);
                element.attr('name', elementName);

                if (element.is("input")) {
                    if ($(this).val().length > 4)
                        $(this).val("");
                }
            });

            clone.find(".field-validation-valid").each(function () {
                var element = $(this);
                var elementValMsg = element.attr('data-valmsg-for').replace('0', brojeva);
                element.attr('data-valmsg-for', elementValMsg);
            });

            $("#brojevi").append(clone);
            brojeva++;
        }
    }
});

$("#RemoveBtn").click(function ukloniUnosTelefona() {
    if (brojeva - 1 != 0) {
        //naziv = getNaziv("BrojeviTelefona", brojeva - 1);
        //$('[name="' + naziv + '.Broj"').remove();
        //$('[name="' + naziv + '.TipTelefona"').remove();

        var id = $("#brojevi #broj:last-child");
        if (id.length > 0) {
            id.remove();
            brojeva--;
        }
    }
});

function getNaziv(itemName, itemNumber) {

    return (itemName + "[" + itemNumber + "]");
}


//$("#submit").click(function validiraj() {
//    var valid = true;
//    for (var i = 0; i < brojeva; i++) {
//        naziv = getNaziv("BrojeviTelefona", i);

//        var $brojTextBox = $('[name="' + naziv + '.Broj"]');
//        if ($brojTextBox.val().length < 5) {
//            valid = false;
//            $brojTextBox.css("border-bottom-color", "#FF0000");
//        }

//    }
//    return valid;
//});