function AjaxModal() {
    $.ajaxSetup({
        cache: false
    });

    $("a[data-modal]").on("click", function (e) {
        $("#myModalContent").load(this.href, function () {
            $("#myModal").modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });


    function bindForm(dialog) {
        $("form", dialog).submit(function () {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#myModal").modal('hide');
                        $("#AddressTarget").load(result.url);
                        bindForm(dialog);
                    } else {
                        $("#myModalContent").html(result);
                        bindForm(dialog);
                    }
                }
            });
            return false;
        })
    }
}

function bindCepForm() {
    function cepFormValues(value) {
        $("#publicPlace").val(value);
        $("#district").val(value);
        $("#city").val(value);
        $("#state").val(value);
    }

    $("#cep").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {
            var cepValidation = /^([\d]{2})\.*([\d]{3})-*([\d]{3})/

            if (cepValidation.test(cep)) {
                cepFormValues("...");

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (data) {
                    if (!("erro" in data)) {

                        $("#publicPlace").val(data.logradouro);
                        $("#district").val(data.bairro);
                        $("#city").val(data.localidade);
                        $("#state").val(data.uf);
                    } else {
                        cepFormValues("");
                        alert("CEP não encontrado.");
                    }
                });
            } else {
                cepFormValues("");
                alert("Formato de CEP inválido.");
            }
        } else {
            cepFormValues("");
        }
    });
}

function formatCEP(str) {
    var re = /^([\d]{2})\.*([\d]{3})-*([\d]{3})/; // Pode usar ? no lugar do *

    if (re.test(str)) {
        return str.replace(re, "$1.$2-$3");
    } else {
        alert("CEP inválido!");
    }

    return "";
}