document.addEventListener("DOMContentLoaded", function () {
    inicializarEventosTabela();
});

function inicializarEventosTabela() {
    const linhas = document.querySelectorAll("#product-list tr");

    linhas.forEach((tr, index) => {
        const modalId = `reaction-modal-${index}`;
        const imgOpcoes = tr.querySelector(".img-opcoes img");
        const modal = tr.querySelector(".reaction-modal");
        const btnEditar = tr.querySelector(".editar");
        const btnExcluir = tr.querySelector(".excluir");

        // Ajusta IDs e atributos dos modais e botões
        if (modal) {
            modal.id = modalId;
        }
        if (imgOpcoes) {
            imgOpcoes.dataset.modal = modalId;
        }

        // Eventos do modal de opções (hover)
        if (imgOpcoes && modal) {
            imgOpcoes.addEventListener("mouseenter", () => {
                modal.style.display = "block";
            });

            modal.addEventListener("mouseenter", () => {
                modal.style.display = "block";
            });

            imgOpcoes.addEventListener("mouseleave", () => {
                setTimeout(() => {
                    if (!modal.matches(":hover")) {
                        modal.style.display = "none";
                    }
                }, 100);
            });

            modal.addEventListener("mouseleave", () => {
                modal.style.display = "none";
            });
        }

        // Botão Editar
        if (btnEditar) {
            btnEditar.addEventListener("click", () => {
                const idProduto = btnEditar.getAttribute("data-id");
                console.log("Editar produto:", idProduto);
                // Aqui você chama sua função de edição, por exemplo:
                // trocarConteudo('cadastro');
                // carregarCategorias().then(() => preencherFormularioEditar(idProduto));
            });
        }

        // Botão Excluir
        if (btnExcluir) {
            btnExcluir.addEventListener("click", () => {
                const idProduto = btnExcluir.getAttribute("data-id");
                mostrarModalConfirmacao(idProduto);
            });
        }
    });
}

function mostrarModalConfirmacao(idProduto) {
    const modal = document.createElement('div');
    modal.classList.add('modal');
    modal.innerHTML = `
        <div class="modal-content">
            <p>Tem certeza que deseja excluir esse produto?</p>
            <button id="confirmarSim">Sim</button>
            <button id="confirmarNao">Não</button>
        </div>
    `;
    document.body.appendChild(modal);

    document.getElementById('confirmarSim').addEventListener('click', () => {
        excluirProduto(idProduto);
        document.body.removeChild(modal);
    });

    document.getElementById('confirmarNao').addEventListener('click', () => {
        document.body.removeChild(modal);
    });
}

// Função para excluir produto (chamada ao backend)
function excluirProduto(id) {
    fetch('/crudmvc_mm-main/Excluir', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: `id=${id}`
    })
        .then(response => {
            if (!response.ok) throw new Error('Erro ao excluir produto');
            return response.text();
        })
        .then(() => {
            alert('Produto excluído com sucesso!');
            // Remove linha da tabela visualmente:
            const linha = document.querySelector(`.excluir[data-id="${id}"]`)?.closest("tr");
            if (linha) linha.remove();
        })
        .catch(error => {
            alert('Erro ao excluir produto: ' + error.message);
            console.error(error);
        });
}
