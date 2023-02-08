//buscar cep
var httpRequest;
function buscaCEP(cep) {
    httpRequest = new XMLHttpRequest();
    httpRequest.onreadystatechange = processaResponse;
    httpRequest.open('GET', 'https://viacep.com.br/ws/' + cep + '/json/');
    httpRequest.send();
}

function processaResponse() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            preencheDados(httpRequest.responseText);
        } else {
          alert('Não foi possível consultar o CEP informado');
        }
      }
}
function preencheDados(dados) {
    var endereco = JSON.parse(dados);

    if(!!endereco.erro) {
        document.getElementById("cep").value = "";
        alert("CEP não encontrado");
        return;
    }

    document.getElementById("endereco").value = endereco.logradouro;
    document.getElementById("bairro").value = endereco.bairro;
    document.getElementById("cidade").value = endereco.localidade;
    document.getElementById("estado").value = endereco.uf;
}

function salvar(event) {
    event.preventDefault();

    let requestBody = montarRequest();
    httpRequest = new XMLHttpRequest();
    httpRequest.onreadystatechange = exibeConfirmacao;
    httpRequest.open('POST', '/users');
    httpRequest.setRequestHeader("Content-Type", "application/json");
    httpRequest.send(JSON.stringify(requestBody));
}

function montarRequest() {
    return {
        cpf: document.getElementById('cpf').value,
        password: document.getElementById('password').value,
        name: document.getElementById('nome').value,
        phone: document.getElementById("telefone").value,
        email: document.getElementById("email").value,
        address: {
            street: document.getElementById("endereco").value,
            number: document.getElementById("numero").value,
            district: document.getElementById("bairro").value,
            city: document.getElementById("cidade").value,
            state: document.getElementById("estado").value,
            zipCode: document.getElementById("cep").value
        }
    }
}

function exibeConfirmacao() {
    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            alert("Cadastrado com sucesso! Id: " + httpRequest.responseText);
        } else {
          alert('Não foi possível concluir o cadastro');
        }
      }
}