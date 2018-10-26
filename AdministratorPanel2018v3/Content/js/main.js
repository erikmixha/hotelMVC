
$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('#scroll').fadeIn();
        } else {
            $('#scroll').fadeOut();
        }
    });
    $('#scroll').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });
});

function scrollNav() {
    $('.nav a').click(function () {
        //Toggle Class
        $(".active").removeClass("active");
        $(this).closest('li').addClass("active");
        var theClass = $(this).attr("class");
        $('.' + theClass).parent('li').addClass('active');
        //Animate
        $('html, body').stop().animate({
            scrollTop: $($(this).attr('href')).offset().top - 160
        }, 400);
        return false;
    });
    $('.scrollTop a').scrollTop();
}
scrollNav();



function initMap() {

var location = {lat: 39.872289, lng: 20.002352 };
var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
center: location
});
var marker = new google.maps.Marker({
        position: location,
map: map
});
}

    function initMap() {
        var uluru = { lat: 41.319674, lng: 19.819240000000036 };
                var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
                    center: uluru
                });
                var marker = new google.maps.Marker({
        position: uluru,
                    map: map
                });
            }

$(document).on('click', '.navbar-collapse.in', function (e) {
    if ($(e.target).is('a')) {
        $(this).collapse('hide');
    }
});