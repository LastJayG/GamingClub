window.initPage = function () {
    console.log('Tournaments page initialized');

    // Специфичная логика для страницы Tournaments
    const registerButtons = document.querySelectorAll('.register-btn');
    registerButtons.forEach(button => {
        button.addEventListener('click', (e) => {
            e.preventDefault();
            alert('Registration will be implemented soon');
        });
    });
};