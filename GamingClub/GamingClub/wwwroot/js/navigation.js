document.addEventListener('DOMContentLoaded', function () {
    // Обработчик кликов по навигационным ссылкам
    document.querySelectorAll('nav a').forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();
            const path = this.getAttribute('href');
            navigateTo(path);
        });
    });

    // Функция навигации
    function navigateTo(path) {
        fetch(path)
            .then(response => response.text())
            .then(html => {
                const parser = new DOMParser();
                const newDoc = parser.parseFromString(html, 'text/html');

                // Заменяем только основное содержимое (не всю страницу)
                const mainContent = document.querySelector('main');
                const newContent = newDoc.querySelector('main');
                if (mainContent && newContent) {
                    mainContent.innerHTML = newContent.innerHTML;
                }

                // Обновляем title
                document.title = newDoc.title;

                // Обновляем URL в адресной строке
                window.history.pushState({}, '', path);

                // Переинициализируем страницу
                if (window.initPage) {
                    window.initPage();
                }
            })
            .catch(err => {
                console.error('Navigation error:', err);
                window.location.href = path; // Fallback
            });
    }

    // Обработчик кнопок "Назад/Вперед"
    window.addEventListener('popstate', function () {
        navigateTo(window.location.pathname);
    });

    // Инициализация текущей страницы
    if (window.initPage) {
        window.initPage();
    }
});