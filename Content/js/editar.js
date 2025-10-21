function converterDataParaInputDate(data) {
    if (!data) return "";
    const [dia, mes, ano] = data.split('/');
    return `${ano}-${mes.padStart(2, '0')}-${dia.padStart(2, '0')}`;
}

function normalizarCategoria(categoria) {
    return categoria.toLowerCase()
        .normalize("NFD")
        .replace(/[\u0300-\u036f]/g, "")
        .replace(/\s+/g, '-');
}

/**
 * Função que preenche o formulário de edição
 * @param {object} produto - objeto com dados do produto
 */
function preencherFormularioEditar(produto) {
    document.querySelector('#container-cadastro input[name="nome"]').value = produto.nome || '';
    document.querySelector('#container-cadastro select[name="category"]').value = normalizarCategoria(produto.categoria || '');
    document.querySelector('#container-cadastro input[name="observacao"]').value = produto.observacao || '';
    document.querySelector('#container-cadastro input[name="valor"]').value = produto.valor || '';
    document.querySelector('#container-cadastro input[name="quantidade"]').value = produto.quantidade || '';

    if (produto.validade) {
        const validadeFormatada = converterDataParaInputDate(produto.validade);
        document.querySelector('#container-cadastro input[name="dataCadastro"]').value = validadeFormatada;
    }

    const botaoCadastrar = document.getElementById('btn-cadastrar');
    botaoCadastrar.querySelector('span').textContent = 'ALTERAR';
    botaoCadastrar.setAttribute('data-id-edicao', produto.id);

    trocarConteudo('cadastro'); // função sua para exibir a seção de cadastro
}

/**
 * Limpa o formulário e reseta o botão
 */
function limparFormularioCadastro() {
    document.querySelector('#container-cadastro input[name="nome"]').value = '';
    document.querySelector('#container-cadastro select[name="category"]').value = 'null';
    document.querySelector('#container-cadastro input[name="observacao"]').value = '';
    document.querySelector('#container-cadastro input[name="valor"]').value = '';
    document.querySelector('#container-cadastro input[name="dataCadastro"]').value = '';
    document.querySelector('#container-cadastro input[name="quantidade"]').value = '';

    const botaoCadastrar = document.getElementById('btn-cadastrar');
    botaoCadastrar.querySelector('span').textContent = 'CADASTRAR';
    botaoCadastrar.removeAttribute('data-id-edicao');
}

// Evento do botão CANCELAR
document.querySelector('#container-cadastro .btn[style*="red"]')
    .addEventListener('click', limparFormularioCadastro);

// Evento do botão CADASTRAR / ALTERAR
const botaoCadastrar = document.getElementById('btn-cadastrar');
botaoCadastrar.addEventListener('click', () => {
    const idEdicao = botaoCadastrar.getAttribute('data-id-edicao');
    if (idEdicao) {
        alert("Produto editado com sucesso!");
        // Aqui você pode enviar via AJAX para atualizar no servidor
    } else {
        alert("Produto cadastrado com sucesso!");
        // Aqui você pode enviar via AJAX para criar novo produto
    }
});

/**
 * Integração com o DataTables
 * Pega os dados da linha clicada e chama o preencherFormularioEditar
 */
$(document).ready(function () {
    const tabela = $('#tabela-historico').DataTable();

    $('#tabela-historico').on('click', '.editar', function () {
        const linha = $(this).closest('tr');
        const dados = tabela.row(linha).data();

        // Aqui você define o mapeamento conforme as colunas da tabela
        const produto = {
            id: $(this).data('id'),
            nome: dados[0],
            quantidade: dados[1],
            categoria: dados[2],
            validade: dados[3],
            valor: dados[4],
            observacao: '' // se quiser buscar do backend depois
        };

        preencherFormularioEditar(produto);
    });
});
