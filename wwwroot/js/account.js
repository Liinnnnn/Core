const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);

function imgLoader() {
    const img = $('.account-avatar')
    const file = $('#file').files[0];
    const url = new FileReader();
    url.onloadend = function () {
        img.src = url.result;
    }

    if (file) {
        url.readAsDataURL(file)
    } else
        img.src = "/assets/img/team/default.png"
}