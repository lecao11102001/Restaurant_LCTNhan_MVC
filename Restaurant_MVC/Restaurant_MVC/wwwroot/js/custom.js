// to get current year
function getYear() {
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    document.querySelector("#displayYear").innerHTML = currentYear;
}

getYear();


// isotope js
//$(window).on('load', function () {

//    var $grid = $(".grid").isotope({
//        itemSelector: ".all",
//        percentPosition: false,
//        masonry: {
//            columnWidth: ".all"
//        }
//    })

//    $('.filters_menu li').click(function () {

//        $('.filters_menu li').removeClass('active');
//        $(this).addClass('active');

//        var data = $(this).attr('data-filter');
//        $grid.isotope({
//            filter: data
//        })
//    });

//});

// nice select
$(document).ready(function () {
    $('select').niceSelect();
});

/** google_map js **/
function myMap() {
    var mapProp = {
        center: new google.maps.LatLng(16.08908344751612, 108.21743781937148),
        zoom: 20,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
}

// client section owl carousel
$(".client_owl-carousel").owlCarousel({
    loop: true,
    margin: 0,
    dots: false,
    nav: true,
    navText: [],
    autoplay: true,
    autoplayHoverPause: true,
    navText: [
        '<i class="fa fa-angle-left" aria-hidden="true"></i>',
        '<i class="fa fa-angle-right" aria-hidden="true"></i>'
    ],
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2
        },
        1000: {
            items: 2
        }
    }
});

// Hàm hiển thị/ẩn bảng nhỏ khi click vào icon user
function toggleUserPopup() {
    const userPopup = document.getElementById('user-popup');
    userPopup.classList.toggle('show-popup');
}



$('#book_date').datepicker({
    'format': 'dd/mm/yyyy',
    'autoclose': true
});
$('#book_time').timepicker({
    format: 'hh:mm:ss',
});

var btn_reservation = document.getElementById("btn_reservation");
btn_reservation.addEventListener('click', function () {
    var reservationId = document.getElementById("reservationId").value;
    if (reservationId === '') {
        alert('Hãy đăng nhập');
    }
});





//// Lấy tất cả các nút danh mục
//var categoryButtons = document.querySelectorAll(".category-button");
//Console.log(categoryButtons);
//// Lặp qua từng nút danh mục và gắn sự kiện click
//categoryButtons.forEach(function (button) {
//    button.addEventListener("click", function () {
//        // Lấy giá trị của thuộc tính "value" của nút danh mục
//        var categoryValue = button.getAttribute("value");

//        // Tạo URL mới với giá trị danh mục
//        var newUrl = "/Specialties/Index?foodcategoryid=" + categoryValue;

//        // Chuyển đến URL mới
//        window.location.href = newUrl;
//    });
//});