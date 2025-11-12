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
        const btnExcluirUsuario = tr.querySelector(".excluirUsuario");

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

        // Botão Excluir
        if (btnExcluir) {
            btnExcluir.addEventListener("click", () => {
                mostrarModalConfirmacao();
            });
        }
        // Botão Excluir
        if (btnExcluirUsuario) {
            btnExcluirUsuario.addEventListener("click", () => {
                mostrarModalConfirmacaoUsuario();
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

function mostrarModalConfirmacaoUsuario(idUsuario) {
    const modal = document.createElement('div');
    modal.classList.add('modal');
    modal.innerHTML = `
        <div class="modal-content">
            <p>Tem certeza que deseja excluir esse usúario?</p>
            <button id="confirmarSim">Sim</button>
            <button id="confirmarNao">Não</button>
        </div>
    `;
    document.body.appendChild(modal);

    document.getElementById('confirmarSim').addEventListener('click', () => {
        excluirProduto(idUsuario);
        document.body.removeChild(modal);
    });

    document.getElementById('confirmarNao').addEventListener('click', () => {
        document.body.removeChild(modal);
    });
}
