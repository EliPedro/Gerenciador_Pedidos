$(document).ready(function ()
{
   obterClientes();

});




function obterEnderecoPorId(id)
{
    var url = "http://localhost:52647/api/Clientes/ObterEndereco/" + parseInt(id);

    $.ajax({
        type: "POST",
        url: url,
        data: '{}',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccessEndereco,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {
        onComplete();
    });
}

function onSuccessEndereco(json)
{
    if (json.length == 0) return;

    $("#cep").html(json.CEP);
    $("#bairro").html(json.Bairro);
    $("#cidade").html(json.Cidade);
    $("#estado").html(json.Estado);
    $("#logradouro").html(json.Logradouro);
    $("#numero").html(json.Numero);
}

function obterClientes()
{
    var url = "http://localhost:52647/api/Clientes/ObterTodos";
    $.ajax({
        type: "POST",
        url: url,
        headers: {'Content-Type': 'application/x-www-form-urlencoded'},
        data: '{}',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccess,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {
        onComplete();
    });
}

function limparFormularioCliente() {
    $("#txtNome").val("");
    $("#txtNome").focus();
    $("#txtCPF").val("");
    $("#txtEmail").val("");
    $("#erroNome").css("display", "none");
    $("#erroNome").html("");
    $("#erroCPF").css("display", "none");
    $("#erroCPF").html("");

    limparCEP();   
}

function limparCEP()
{
    $("#txtCEP").val("");
    $("#txtBairro").html("");
    $("#txtCidade").html("");
    $("#txtEstado").html("");
    $("#txtLogradouro").html("");
    $("#txtNumero").val("");
}

$("#btnCadastrarCliente").click(function () {

    var erro = 0;

    var txtNome = $("#txtNome").val();
    var txtCPF = $("#txtCPF").val();
    var txtEmail = $("#txtEmail").val();
    var txtCEP = $("#txtCEP").val();
    var txtBairro = $("#txtBairro").text();
    var txtCidade = $("#txtCidade").text();
    var txtEstado = $("#txtEstado").text();
    var txtLogradouro = $("#txtLogradouro").text();
    var txtNumero = $("#txtNumero").val();
    
    if (txtNome == "")
    {
        $("#erroNome").css("display", "block");
        $("#erroNome").html("O nome é obrigátorio.");

        erro += 1;
    }
      

    if (txtCPF == "")
    {
        $("#erroCPF").css("display", "block");
        $("#erroCPF").html("O CPF é obrigátorio.");
        
        erro += 1;
    }


    if (erro > 0) { limparCEP(); return; }
    var json =
        {
            Nome: txtNome,
            CPF: txtCPF,
            Endereco:
            {
                CEP: txtCEP,
                Bairro: txtBairro,
                Cidade: txtCidade,
                Estado: txtEstado,
                Logradouro: txtLogradouro,
                Numero: txtNumero
            },
            Email: txtEmail

        }

    adicionar(json);
    
});

function adicionar(json) {

    var url = "http://localhost:52647/api/Clientes/Adicionar";
    $.ajax({
        type: "POST",
        url: url,
        data: json,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccess,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {

        setTimeout(function () {obterClientes();}, 10);
        onComplete();
        
        });

}


function buscandoCep()
{
    $("#txtBairro").html("<i>Buscando Bairro ...</i>");
    $("#txtCidade").html("<i>Buscando Cidade ...</i>");
    $("#txtEstado").html("<i>Buscando Estado ...</i>");
    $("#txtLogradouro").html("<i>Buscando Logradouro ...</i>");
}

$("#txtCEP").blur(function () {


    buscandoCep();
    var cep = $("#txtCEP").val();
    
    var url = "https://viacep.com.br/ws/" + cep + "/json/";
    $.ajax({
        type: "GET",
        url: url,
        data: '{}',
        contentType: "application/json: charset=utf-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccessCEP,
        failure: function (response) {
            alert(response.d);
        }
    }).done(function (data) {
        onComplete();
    });
});


function onSuccess(json) {
    
    $("#limparTabela").empty();
    var tr;

    for (var i in json) 
    {
        tr = $('<tr/>');
        tr.append("<td>" + json[i].Nome + "</td>");
        tr.append("<td>" + json[i].CPF.Codigo + "</td>");
        tr.append('<td><button onClick="obterEnderecoPorId(this.value);" data-toggle="modal" data-target="#mdEndereco" class="btn btn-link" value=' + parseInt(json[i].EnderecoId) + '">Detalhes</button>');
        tr.append("<td>" + json[i].Email + "</td>");
        tr.append("<td>" + json[i].DataCadastro.replace("T", " ").substring(0, 16) + "</td>");      
        tr.append('<td><button id="btnPedidos" onClick="obterPedidosPorPorCliente(this.value);" data-toggle="modal" data-target="#mdMeusPedidos" class="btn btn-link" value=' + parseInt(json[i].ClienteId) + '">Meus Pedidos</button>');

        $('#tblclientes').append(tr);
    }

    limparFormularioCliente();

}


function cepNaoEncontrado()
{
    $("#txtBairro").html("<i>Bairro não encontrado ...</i>");
    $("#txtCidade").html("<i>Cidade não encontrada...</i>");
    $("#txtEstado").html("<i>Estado não encontrado...</i>");
    $("#txtLogradouro").html("<i>Logradouro não encontrado  ...</i>");

}

function onSuccessCEP(json) {
    if (json.length == 0)
    {
        cepNaoEncontrado();
    }

    $("#txtBairro").html(json.bairro);
    $("#txtCidade").html(json.localidade);
    $("#txtEstado").html(json.logradouro);
    $("#txtLogradouro").html(json.uf);
}


$("#txtCPF").blur(function () {

    if ($("#txtCPF").val() == "") return;

    var url = "http://localhost:52647/api/Clientes/EhValidoCPF?cpf=" + $("#txtCPF").val();
    $.ajax({
        type: "POST",
        url: url,
        data: '{}',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        beforeSend: onBegin,
        success: onSuccessValidacaoCEP,
        failure: function (response) {
            alert(response.d);
        }
    })
});


function onSuccessValidacaoCEP(json)
{
    if (json == 1)
    {
        $("#erroCPF").css("display","block");
        $("#erroCPF").html("CPF Já cadastrado!");
        return;
    }

    if (json == 2) {
        $("#erroCPF").css("display", "block");
        $("#erroCPF").html("CPF Inválido!");
        return;
    }

    $("#erroCPF").css("display", "none");
    $("#erroCPF").html("");

}

function onBegin() {
    $("#wait").css("display", "block");
}

function onComplete() {
    $("#wait").css("display", "none");
}
