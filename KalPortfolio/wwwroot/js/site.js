// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    var findMeLinks = $(".find-me-links");
    var verticalLine = $(".vertical-line");
    var findMe = $(".find-me");
    var count = 0;
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();

        if (scroll >= (5) && count < 1) {
            findMeLinks.addClass("links-animate");
            verticalLine.addClass("line-left");
            findMe.addClass("find-me-animate");
            count++;
        }
    });
});

function search() {
    $.get('/Admin/UserResultList?name=' + document.querySelector('#search-for-message').value, function (data) {

        $('#user-result-list').html(data);

    });
}

function remove(id) {
    $.post('/Admin/DeleteResultList?id=' + id, function (data) {           
        $('#user-result-list').html(data);
    });
       
}

function details(id) {
    $.get('/Admin/UserDetailList?id=' + id, function (data) {
        $('#user-info').html(data);
    });
}

function createAccountBtn() {
    location.href = '/Login/CreateAccount';
}

