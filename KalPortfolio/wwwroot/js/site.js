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
        if ((window.innerHeight + window.pageYOffset) >= (document.body.offsetHeight / 1.75)) {
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

        if (display != 'none') {
            $('.overlay').css('display', 'block');
            $('.rate-site').css('display', 'block');
        }

    })
});

$(function () {
    $(document).on("click", ".rate-site-close", function () {
        
        $('.overlay').css('display', 'none');
        $('.rate-tease').css('display', 'none');
       
    })
});

$(function () {
    $(document).on("click", '.star', function () {
        var whichStar = $(this).attr('id');
 
        var allStars = [];
        $('.star').each(function () {
            allStars.push($(this).attr('id'));
        });

        var indexOfClickedStar = getStarIndex();

        for (var i = 0; i < allStars.length; i++) {

            var id = 'id="' + allStars[i] + '"';

            if (i > indexOfClickedStar) {

                $("#" + allStars[i]).replaceWith(function (n) {
                    return '<button type="button"' + id + 'class="star"> <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="white" class="bi bi-star" viewBox="0 0 16 16" ><path d="M2.866 14.85c-.078.444.36.791.746.593l4.39-2.256 4.389 2.256c.386.198.824-.149.746-.592l-.83-4.73 3.522-3.356c.33-.314.16-.888-.282-.95l-4.898-.696L8.465.792a.513.513 0 0 0-.927 0L5.354 5.12l-4.898.696c-.441.062-.612.636-.283.95l3.523 3.356-.83 4.73zm4.905-2.767-3.686 1.894.694-3.957a.565.565 0 0 0-.163-.505L1.71 6.745l4.052-.576a.525.525 0 0 0 .393-.288L8 2.223l1.847 3.658a.525.525 0 0 0 .393.288l4.052.575-2.906 2.77a.565.565 0 0 0-.163.506l.694 3.957-3.686-1.894a.503.503 0 0 0-.461 0z" /></svg ></button > '
                })
            } else {

                $("#" + allStars[i]).replaceWith(function (n) {
                    return '<button type="button"' + id + 'class="star"> <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="white" class="bi bi-star-fill" viewBox="0 0 16 16"> <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" /></svg > </button>'
                })

            }
        }
        
        function getStarIndex() {
            for (var i = 0; i < allStars.length; i++) {
                if (allStars[i] === whichStar) {
                   $('#rate-site').val(i + 1);
                    
                    return i;
                }
            }
        }
    })

    
});

$(function () {
    $(document).on("click", ".rate-tease-close", function () {

        $('.rate-tease').css('display', 'none');
        
    })
});

$(function () {
    $(document).on("click", "#rate-submit-btn", function (e) {
        e.preventDefault();
        
        var requestAntiForgeryToken = document.querySelector('[name=__RequestVerificationToken]').value;
        var url = $("#rate-site-form").attr('action');
        $.ajax({
            type: 'POST',
            url: url,
            data: $('#rate-site-form').serialize(), requestAntiForgeryToken,
            error: function () {
                alert('The form did not submit!')
            },
            success: function () {
                document.querySelector('#rate-submit-btn').innerText = 'Thank You!';
                
            }
        });
    })
})

$(function () {
    $(document).on('click', '#submit-message', function (e) {
        e.preventDefault();
        var requestAntiForgeryToken = document.querySelector('[name=__RequestVerificationToken]').value;
        $.ajax({
            type: 'POST',
            url: '/Home/Home',
            data: $('#messageform').serialize(), requestAntiForgeryToken,
            error: function (response) {
                alert("Sorry but the form did not submit!");
            },
            success: function (d) {
                $('#messageform')[0].reset();
                document.querySelector('#submit-message').innerText = 'Thank You!';
            }
        })
        setTimeout(function () {
            document.querySelector('#submit-message').innerText = 'Submit';
        }, 5000)
    })

})

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

$(function () {
    const otherHidden = document.querySelectorAll(".hidden");
    const hiddenAboutMe = document.querySelectorAll(".hidden-about");
    const firstRowHidden = document.querySelectorAll(".first-project");
    

    const aboutObserver = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.classList.add('show-about');
            }
            else {
                if (entry.target.classList.contains('show-about')) {
                    entry.target.classList.remove('show-about');
                }

            }
        });

    });

    hiddenAboutMe.forEach((el) => aboutObserver.observe(el));

    const otherObserver = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.classList.add('show');
            }
            else {
                if (entry.target.classList.contains('show')) {
                    entry.target.classList.remove('show');
                }

            }
        });
    })

    otherHidden.forEach((el) => otherObserver.observe(el));

    const firstRowObserver = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            const children = Array.from(document.querySelector('.small-projects').children);
            if (entry.isIntersecting) {
                children.forEach((item) => {
                    item.classList.add('show-project');
                });
            }
        });
    })

    firstRowHidden.forEach((el) => firstRowObserver.observe(el));

    
})
