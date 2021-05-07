// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var swiper = new Swiper('.swiper-container', {
    direction: 'vertical',
    spaceBetween: 5,
    centeredSlides: true,
    autoplay: {
        delay: 10000,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});

// search function

$(document).ready(function () {
    $('#search').click(function () {
        $('.myNav-item').addClass('hide-item');
        $('.search-form').addClass('active');
        $('.close').addClass('active');
        $('#search').hide();
        $('.search-dropdown').addClass('active');
        
    })
    $('.close').click(function () {
        $('.myNav-item').removeClass('hide-item');
        $('.search-form').removeClass('active');
        $('.close').removeClass('active');
        $('.search-dropdown').removeClass('active');
        $('#search').show();

    })
})

