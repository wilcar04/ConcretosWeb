// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    setUserId();
});

function setUserId() {
    let params = new URLSearchParams(window.location.search)

    if (params.has('user_id')) {
        localStorage.setItem('user_id', params.get('user_id'))
    }

    if (localStorage.getItem('user_id') != null && $("#user-id").length != 0) {
        $("#user-id").val(localStorage.getItem('user_id'));
    }

}