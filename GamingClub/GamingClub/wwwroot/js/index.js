window.initPage = function () {
    console.log('Initializing home page');

    const reservationBtn = document.querySelector('.reservation-btn');
    if (reservationBtn) {
        reservationBtn.addEventListener('click', function (e) {
            e.preventDefault();
            window.location.href = '/make-reservation.html';
        });
    }
};

document.addEventListener('DOMContentLoaded', function () {
    // Элементы навигации
    const navLinks = {
        about: document.querySelector('a[href="about.html"]'),
        tournaments: document.querySelector('a[href="tournaments.html"]'),
        reservation: document.querySelector('.reservation-btn'),
        login: document.querySelector('a[href="login.html"]'),
        register: document.querySelector('a[href="register.html"]')
    };

    // Обработчики переходов
    navLinks.about.addEventListener('click', function (e) {
        e.preventDefault();
        console.log('Переход на страницу "About Us"');
        window.location.href = 'about.html';
    });

    navLinks.tournaments.addEventListener('click', function (e) {
        e.preventDefault();
        console.log('Переход на страницу "Tournaments"');
        window.location.href = 'tournaments.html';
    });

    navLinks.reservation.addEventListener('click', function (e) {
        e.preventDefault();
        console.log('Переход на страницу бронирования');
        window.location.href = 'reservation.html';
    });

    // Заглушки для будущей функциональности
    navLinks.login.addEventListener('click', function (e) {
        e.preventDefault();
        console.log('Открыть форму входа');
        alert('Форма входа будет реализована позже');
    });

    navLinks.register.addEventListener('click', function (e) {
        e.preventDefault();
        console.log('Открыть форму регистрации');
        alert('Форма регистрации будет реализована позже');
    });

    // Анимация для кнопки бронирования
    const reservationBtn = document.querySelector('.reservation-btn');
    reservationBtn.addEventListener('mouseenter', function () {
        this.style.transform = 'translateY(-3px)';
        this.style.boxShadow = '0 4px 8px rgba(247, 37, 133, 0.4)';
    });

    reservationBtn.addEventListener('mouseleave', function () {
        this.style.transform = 'translateY(0)';
        this.style.boxShadow = 'none';
    });

    // Загрузка изображений галереи (имитация)
    console.log('Загрузка изображений галереи...');
    setTimeout(() => {
        console.log('Изображения загружены');
    }, 1000);
});