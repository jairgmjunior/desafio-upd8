// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(window).ready(function () {
    CadastroCliente.Init();
})

class CadastroCliente {
    static Init() {

        $("#CPF").mask("000.000.000-00");
        $("#DataNascimento").mask("00/00/0000");

        $("#CodigoIbge").select2({
            placeholder: 'Selecione',
            minimumInputLength: 3,
            language: "pt-BR",
            allowClear: true,
            ajax: {
                type: 'GET',
                url: "/Cliente/GetCidadesPorEstado",
                dataType: 'json',
                async: true,
                data: function (params) {
                    return {
                        pageSize: 100,
                        pageNum: params.page || 1,
                        searchTerm: params.term,
                        estado: $("#Estado").val()
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    return {
                        results: data.results,
                        pagination: {
                            more: (params.page * 100) <= data.Total
                        }
                    };
                }
            }
        });

        $("#limpar").on("click", function () {
            $("#Nome").val("");
            $("#CPF").val("");
            $("#Complemento").val("");
            $("#DataNascimento").val("");
            $("#Estado").val("").change();
            $("#CodigoIbge").val("").trigger("change");

            $("#CPF").focus();
        });

        CadastroCliente.InitEdicao();
    }

    static InitEdicao() {
        if (_Model) {
            SelectUtil.ConfiguraSelect2AjaxEdit("CodigoIbge", "/Cliente/GetCidadePorCodigoIbge", _Model.codigoIbge);
        }
    }
}


var SelectUtil = {
    ConfiguraSelect2AjaxEdit: function (idComponente, action, codigoIbge) {
        provedorSelect2AjaxEdit(idComponente, action, codigoIbge);
    },
}

function provedorSelect2AjaxEdit(idComponente, action, codigoIbge) {

    var url = action;
    var param = { codigoIbge: codigoIbge };
    $.get(url, param, function (data) {
        if (data.id) {
            $("#" + idComponente + " option").remove();
            var optionSel = new Option(data.text, data.id, true);
            $("#" + idComponente).append(optionSel);
            $("#" + idComponente).trigger("change");
        } 
    });
}