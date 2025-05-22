window.initPage = function () {
    console.log('About page initialized');

    // Специфичная логика для страницы About
    const teamMembers = document.querySelectorAll('.team-member');
    teamMembers.forEach(member => {
        member.addEventListener('click', () => {
            console.log('Team member clicked');
        });
    });
};