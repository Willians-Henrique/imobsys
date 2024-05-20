// Event listener para formatar o campo de valor como moeda
document.addEventListener('DOMContentLoaded', function () {
    const valorImovelInput = document.getElementById('valorImovel');
    if (valorImovelInput) {
        valorImovelInput.addEventListener('input', function (event) {
            let value = event.target.value.replace(/[^0-9,]/g, ''); // Remove caracteres inválidos
            event.target.value = 'R$ ' + value;
        });
    }

    // Event listener para abrir o modal de novo cliente
    const openNovoClienteModal = document.getElementById('openNovoClienteModal');
    if (openNovoClienteModal) {
        openNovoClienteModal.addEventListener('click', function () {
            const novoClienteModal = new bootstrap.Modal(document.getElementById('novoClienteModal'));
            novoClienteModal.show();
        });
    }

    // Event listener para abrir o modal de novo atendimento
    const openNovoAtendimentoModal = document.getElementById('openNovoAtendimentoModal');
    if (openNovoAtendimentoModal) {
        openNovoAtendimentoModal.addEventListener('click', function () {
            const novoAtendimentoModal = new bootstrap.Modal(document.getElementById('novoAtendimentoModal'));
            novoAtendimentoModal.show();
        });
    }
});

// Função para fechar o modal de novo atendimento
function fecharNovoAtendimentoModal() {
    const novoAtendimentoModal = new bootstrap.Modal(document.getElementById('novoAtendimentoModal'));
    novoAtendimentoModal.hide();
}
