function limparFormularioPedido() {
    $("#txtDescricao").val("");
    $("#txtDescricao").focus();
    $("#clienteSelecionado").remove();
    $("#nValor").val("0.0");
    $("#txtProduto").val(""); 
    $("#nQuantidade").val("0.0");
}



$("#btnCadastrarPedido").click(function () {
    
    var txtDescricao = $("#txtDescricao").val();
    var clienteSelecionado = parseInt($("#clienteSelecionado").val());
    var valor = $("#nValor").val();
    var quantidade = $("#nQuantidade").val();
    var produto = $("#txtProduto").val(); 

    var json =
        {
            Descricao: txtDescricao,
            ClienteId: clienteSelecionado,
            PedidoItem:[
            {
                Produto: produto,
                Valor: valor,
                Quantidade: quantidade
            }]
        }

    adicionarPedido(json);

});

function adicionarPedido(json) {

    var url = "http://localhost:52647/api/Pedidos/Adicionar";
    $.ajax({
        type: "POST",
        url: url,
        data: json,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {

        onComplete();
        limparFormularioPedido();
    });

}

function obterPedidosPorPorCliente(id)
{

    var url = "http://localhost:52647/api/Pedidos/ObterPedidosPorPorCliente/" + parseInt(id);

    $.ajax({
        type: "POST",
        url: url,
        data: '{}',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccessMeusPedidos,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {
        onComplete();
    });

}


function onSuccessMeusPedidos(json)
{
    $("#limparTabelaMeusPedidos").empty();
    var tr;

    for (var i in json) {
        tr = $('<tr/>');
        tr.append("<td>" + json[i].PedidoItem.Produto + "</td>");
        tr.append("<td>" + json[i].Descricao + "</td>");
        tr.append("<td>" + json[i].DataCadastro.replace("T", " ").substring(0, 16) + "</td>");
        tr.append("<td>" +'R$ ' + json[i].PedidoItem.Valor + ',00' + "</td>");
        tr.append("<td>" + json[i].PedidoItem.Quantidade + "</td>");
        tr.append("<td>" + 'R$ ' + (json[i].PedidoItem.Quantidade * json[i].PedidoItem.Valor) + ',00' + "</td>");

        $('#tblMeusPedidos').append(tr);
    }
}

function obterClientesPedido() {
    var url = "http://localhost:52647/api/Clientes/ObterTodos";
    $.ajax({
        type: "POST",
        url: url,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        data: '{}',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccessBuscarClientes,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {
        onComplete();
    });
}


function onSuccessBuscarClientes(json) {

    if (json.length == 0) return;

    $("#clienteSelecionado").remove();
    $("#divCliente").append('<select class="form-control" id="clienteSelecionado">');

    for (var i in json)
    {
        $("#clienteSelecionado").append(
            '<option value="' + json[i].ClienteId + '">' + json[i].Nome + '</option>');
    }

    $("#clienteSelecionado").append('</select>');
}
