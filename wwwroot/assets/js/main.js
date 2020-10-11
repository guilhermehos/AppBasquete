$(function () {
    "use strict"; $(window).on('load', function (event) { $('.preloader').delay(500).fadeOut(500); }); $(window).on('scroll', function (event) { var scroll = $(window).scrollTop(); if (scroll < 20) { $(".navbar-area").removeClass("sticky"); } else { $(".navbar-area").addClass("sticky"); } }); var scrollLink = $('.page-scroll'); $(window).scroll(function () { var scrollbarLocation = $(this).scrollTop(); scrollLink.each(function () { var sectionOffset = $(this.hash).offset().top - 73; if (sectionOffset <= scrollbarLocation) { $(this).parent().addClass('active'); $(this).parent().siblings().removeClass('active'); } }); }); $(".navbar-nav a").on('click', function () { $(".navbar-collapse").removeClass("show"); }); $(".navbar-toggler").on('click', function () { $(this).toggleClass("active"); }); $(".navbar-nav a").on('click', function () { $(".navbar-toggler").removeClass('active'); }); $('.video-popup').magnificPopup({ type: 'iframe' }); $('.image-popup').magnificPopup({ type: 'image', gallery: { enabled: true } }); $(window).on('scroll', function (event) { if ($(this).scrollTop() > 600) { $('.back-to-top').fadeIn(200) } else { $('.back-to-top').fadeOut(200) } }); $('.back-to-top').on('click', function (event) { event.preventDefault(); $('html, body').animate({ scrollTop: 0, }, 1500); }); jQuery('img.svg').each(function () {
        var $img = jQuery(this); var imgID = $img.attr('id'); var imgClass = $img.attr('class'); var imgURL = $img.attr('src'); jQuery.get(imgURL, function (data) {
            var $svg = jQuery(data).find('svg'); if (typeof imgID !== 'undefined') { $svg = $svg.attr('id', imgID); }
if(typeof imgClass!=='undefined'){$svg=$svg.attr('class',imgClass+' replaced-svg');}
    $svg = $svg.removeAttr('xmlns:a'); $img.replaceWith($svg);
}, 'xml');
}); new WOW().init(); var swiper = new Swiper('.swiper-container', { pagination: { el: '.swiper-pagination', type: 'bullets', clickable: true, }, speed: 1000, effect: 'coverflow', loop: true, centeredSlides: true, slidesPerView: 'auto', coverflowEffect: { rotate: 0, stretch: 40, depth: 150, modifier: 1, slideShadows: false, } }); $('.testimonial-content').slick({ slidesToShow: 1, slidesToScroll: 1, arrows: false, fade: true, asNavFor: '.testimonial-author' });
    $('.testimonial-author').slick({ slidesToShow: 5, slidesToScroll: 1, asNavFor: '.testimonial-content', dots: false, arrows: false, centerMode: true, focusOnSelect: true, centerPadding: "0", responsive: [{ breakpoint: 768, settings: { slidesToShow: 3 } }, { breakpoint: 576, settings: { slidesToShow: 3 } }] });
    /***** Contact form *****/
    
    $('#contact-form').submit(function (e) {
        e.preventDefault();
        $('#contact-form input[type="text"], #contact-form textarea').removeClass('is-invalid');
        var data = {
            name: $('#contact-name').val(),
            email: $('#contact-email').val(),
            subject: $('#contact-subject').val(),
            message: $('#contact-message').val()
        };

        if (!data.name) $('#contact-name').addClass('is-invalid');        
        if (!data.email) $('#contact-email').addClass('is-invalid');        
        if (!data.subject) $('#contact-subject').addClass('is-invalid');        
        if (!data.message) $('#contact-message').addClass('is-invalid');

        if (data.name && data.email && data.subject && data.message) {
            $.ajax({
                type: 'POST',
                url: 'api/Contact/Send',
                data: JSON.stringify(data),
                contentType: "application/json",
                dataType: 'json',
                success: function (json) {
                    $('#contact-name').val('');
                    $('#contact-email').val('');
                    $('#contact-subject').val('');
                    $('#contact-message').val('');

                    $('#contact-form input[type="text"], #contact-form textarea').removeClass('is-invalid');
                    //$('#contact-form-result').html();
                    if (json.success) {
                        swal("Mensagem enviada com sucesso!", json.message, "success");
                    } else {
                        swal("Erro!", json.messages, "error");
                    }

                },
                error: function (jqXHR, error, errorThrown) {
                    if (jqXHR.status && jqXHR.status === 400) {
                        swal("Erro!", jqXHR.responseText, "error");
                    } else {
                        swal("Erro!", "Something went wrong", "error");
                    }
                }
            });
        }
    });  
});
