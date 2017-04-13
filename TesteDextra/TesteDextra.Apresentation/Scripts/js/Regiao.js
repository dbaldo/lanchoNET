//Variáveis globais
var idAtivar = 0;

//Função principal load da página
$(function () {
    pageLoad();
});
//Carrega todas as funções
function pageLoad() {
    $("#Ingrediente-form").submit(function () {
        salvar($(this));
        return false;
    });
    $("#sim-inativar").click(inativar);
    $(".inativar").click(preencheIDInativar);
    $(".ativar").click(preencheIDAtivar);
    $(".editar").click(preencheTelaParaEdicao);
    $("#buscar").click(buscarRegioesLanche);
    $("#gravar").click(gravarRegioesPorForncedor);
}


//==================================================
//Funções
//=================================================
function buscarRegioesLanche()
{
    var id = $("#LancheID").val()
    if (id == "null")
        imprimirErro("Selecione algum Lanche antes de continuar!");
    else
        buscarRegioesEPreencheGrid(id);
}
function preencheIDAtivar()
{
    var tr = $(this).closest("tr");
    idAtivar = $(tr).attr("id");
    ativar();
}

function preencheTelaParaEdicao()
{
    var tr = $(this).closest("tr");
    $("#IngredienteID").val($(tr).attr("id"));
    var tds = $(tr).find("td");
    var id = $("#IngredienteLancheID").find("option:contains(" + $(tds)[0].textContent + ")").val();
    $("#IngredienteLancheID").val(id);
    $("#Descricao").val(tds[1].textContent);
    $("#Inclusao").val("False");
    $("#salvar").show();
    $("#inserir").hide();
}
function preencheIDInativar()
{
    $("#idIngredienteInativar").html($(this).closest("tr").attr("id"));
}
function imprimirErro(erro)
{
    $("#retorna-erro").empty();
    $("#retorna-erro").append(erro);
    $("#retorna-erro").show();
}
//==================================================
//Funções Ajax
//=================================================
function salvar($form) {
    if ($form.valid()) {
       
        var url = localStorage.getItem("url-root")+"Ingrediente/Salvar";
        var inclusao = ($("#IngredienteID").val() == "0")

        var data = {
            "IngredienteID": $("#IngredienteID").val(),
            "IngredienteLancheID": $("#IngredienteLancheID").val(),
            "Descricao": $("#Descricao").val(),
            "Inclusao": inclusao
        };

        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (retorno) {
                if (retorno.sucesso) {
                    window.location.href = localStorage.getItem("url-root") + "Ingrediente";
                } else {
                    imprimirErro(retorno.error);
                }
            },
            error: function () {
                imprimirErro("Erro no servidor!");
            }
        }).always(function () {

        });
    }
}
function inativar() {
    var url = localStorage.getItem("url-root") + "Ingrediente/Inativar";

    var data = {
        "IngredienteID": $("#idIngredienteInativar").html()
    };

    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (retorno) {
            if (retorno.sucesso) {
                if (retorno.sucesso) {
                    window.location.href = localStorage.getItem("url-root") + "Ingrediente";
                } else {
                    imprimirErro(retorno.error);
                }
            }
        }
    });
}
function ativar() {
    var url = localStorage.getItem("url-root") + "Ingrediente/Ativar";

    var data = {
        "IngredienteID": idAtivar
    };

    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (retorno) {
            if (retorno.sucesso) {
                if (retorno.sucesso) {
                    window.location.href = localStorage.getItem("url-root") + "Ingrediente";
                } else {
                    imprimirErro(retorno.error);
                }
            }
        }
    });
}
function buscarRegioesEPreencheGrid(id)
{
    var url = localStorage.getItem("url-root") + "Lanche/BuscarRegioes";

    var data = {
        "LancheID": id
    };

    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (retorno) {
            if (retorno.sucesso) {
                if (retorno.sucesso) {
                    $("#tabela-regioes").find("tbody").html("");
                    retorno.regioes.forEach(function (item)
                    {
                        $("#tabela-regioes").find("tbody").append("<tr id = '" + item.IngredienteID + "'><td><input type=\"checkbox\"></td><td>" + item.IngredienteLanche + "</td><td>" + item.Descricao + "</td></tr>");
                        if (item.Selecionda)
                            $("#" + item.IngredienteID).find("input").prop("checked", true);
                        if (!item.Ativo)
                            $("#" + item.IngredienteID).attr("class", "vermelho");
                    });
                } else {
                    imprimirErro(retorno.error);
                }
            }
        }
    });
}
function gravarRegioesPorForncedor() {
    var url = localStorage.getItem("url-root") + "Lanche/SalvarRegioes";
    var regioes = new Array();
    $("#tabela-regioes").find("tbody").find("tr").each(function () {
        if ($(this).find("input").prop("checked") == true)
            regioes[regioes.length] = $(this).attr("id");
    });
    var data = {
        "RegioesID": regioes,
        "LancheID": $("#LancheID").val()
    };

    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (retorno) {
            if (retorno.sucesso) {
                if (retorno.sucesso) {
                    if (retorno.sucesso) {
                        window.location.href = localStorage.getItem("url-root") + "Lanche/CadastrarIngrediente";
                    } else {
                        imprimirErro(retorno.error);
                    }
                }
            }
        }
    });
}