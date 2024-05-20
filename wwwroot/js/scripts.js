document.addEventListener('DOMContentLoaded', function () {
    const valorImovelInput = document.getElementById('valorImovel');
    if (valorImovelInput) {
        valorImovelInput.addEventListener('input', function (event) {
            let value = event.target.value.replace(/[^\d,]/g, ''); // Remove caracteres inválidos
            if (value.length > 2) {
                value = value.replace(',', '').replace(/\B(?=(\d{3})+(?!\d))/g, '.');
                event.target.value = 'R$ ' + value;
            } else {
                event.target.value = 'R$ ' + value;
            }
        });
    }
});
