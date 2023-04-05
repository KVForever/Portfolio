// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    var navBar = $(".home-nav")
    var findMeLinks = $(".find-me-links");
    var verticalLine = $(".vertical-line")
    var findMe = $(".find-me")
    var navBarTop = navBar.offset().top;
    var windowHeight = $(window).height();
    var count = 0;
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();

        if (scroll >= (5) && count < 1) {
            findMeLinks.addClass("links-animate");
            verticalLine.addClass("line-left");
            findMe.addClass("find-me-animate");
            count++;
        }

        //if (count == 1) {
        //    $(".line-left").addClass("line-height");
        //}
       
    });
});