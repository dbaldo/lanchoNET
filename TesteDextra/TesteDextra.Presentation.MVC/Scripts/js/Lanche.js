//Função principal load da página
$(function () {
    pageLoad();
});
//Carrega todas as funções
function pageLoad() {
    $("#btn-calcular").click(calcular);
}

//==================================================
//Funções
//=================================================
function calcular() {
    

        var url = localStorage.getItem("url-root") + "Lanchonete/CalculaPreco";
        var ingredientes = new Array();
        $(".ingrediente-selecionado").each(function()
        {
            if($(this).prop("checked"))
            {
                ingredientes[ingredientes.length] = {
                    "IngredienteID": $(this).closest("tr").attr("id"),
                    "LancheID": 0,
                    "Quantidade": $(this).closest("tr").find(".quantidade-ingrediente").val()
                };
            }
        })


        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(ingredientes),
            dataType: "json",
            contentType: "application/json",
            success: function (retorno) {
                if (retorno.sucesso) {
                    $("#preco-final").find("h3").html("O preço do seu lanche é R$: " + retorno.preco);
                    $("#preco-final").show();
                    
                } else {
                    $("#preco-final").find("h3").html(error);
                    $("#preco-final").show();
                }
                window.location.href = "#preco-final";
            },
            error: function () {
                imprimirErro("Erro no servidor!");
            }
        }).always(function () {

        });
}
