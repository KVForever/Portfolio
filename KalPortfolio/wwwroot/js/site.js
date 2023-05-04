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

$(function () {
    $(window).scroll(function (ev) {
        if ((window.innerHeight + window.pageYOffset) >= (document.body.offsetHeight / 2)) {
            var x = $(".rate-tease");
            x.addClass("rate-tease-reveal");
        }
    });
});


$(function () {
    $(document).on("click", ".rate-tease", function () {
        var element = document.getElementById("tease");
        var style = window.getComputedStyle(element);
        var display = style.getPropertyValue("display");
        
        if (display != 'none' ) {

            $('.overlay').css('display', 'block');
        }
        
    })
});

$(function () {
    $(document).on("click", ".rate-site-close", function () {
        
        $('.overlay').css('display', 'none');
    })
});

$(function () {
    $(document).on("click", ".rate-tease-close", function () {

        $('.rate-tease').css('display', 'none');
        
    })
});

function search() {
    $.get('/Admin/SearchResultList?name=' + document.querySelector('#search-for-message').value, function (data) {

        $('#user-result-list').html(data);

    });
}

function removeMessage(id) {
    $.post('/Admin/DeleteResultList?id=' + id, function (data) {           
        $('#user-result-list').html(data);
    });
       
}

function messageDetails(id) {
    $.get('/Admin/MessageDetail?id=' + id, function (data) {
        $('#user-info').html(data);
    });
}

function removeAdmin(id) {
    $.post('/Admin/DeleteAdminResultList?id=' + id, function (data) {
        $('#admin-result-list').html(data);
    });
}

function createAccountBtn() {
    location.href = '/Login/CreateAccount';
}

function messageFormSubmit() {
    location.href = '/Home/Home#contact-form';
};


