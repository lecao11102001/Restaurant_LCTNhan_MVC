// to get current year
function getYear() {
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    document.querySelector("#displayYear").innerHTML = currentYear;
}

getYear();


// isotope js
$(window).on('load', function () {

    var $grid = $(".grid").isotope({
        itemSelector: ".all",
        percentPosition: false,
        masonry: {
            columnWidth: ".all"
        }
    })

    $('.filters_menu li').click(function () {

        $('.filters_menu li').removeClass('active');
        $(this).addClass('active');

        var data = $(this).attr('data-filter');
        $grid.isotope({
            filter: data
        })
    });

});

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

//$(document).ready(function () {
//    var items = $("#ItemsFood .col-lg-4") // Lấy danh sách sản phẩm
//    var itemsPerPage = 9; // Số sản phẩm trên mỗi trang
//    var totalPages = Math.ceil(items.length / itemsPerPage); // Tính tổng số trang

//    // Tạo các liên kết phân trang sử dụng Bootstrap Pagination
//    for (var i = 1; i <= totalPages; i++) {
//        $("#pagination")
//            .append('<li class="page-item"><a class="page-link" href="#">' + i + '</a></li>');
//    }

//    // Ẩn tất cả các sản phẩm, chỉ hiển thị trang đầu tiên
//    items.hide();
//    items.slice(0, itemsPerPage).show();

//    // Xử lý sự kiện khi nhấn vào các liên kết phân trang
//    $("#pagination li").on("click", function () {
//        var page = $(this).index();
//        var start = page * itemsPerPage;
//        var end = start + itemsPerPage;

//        items.hide();
//        items.slice(start, end).show();
//    });
//});


// page login
//var username = document.getElementById("login_username").value;
//var password = document.getElementById("login_password").value;


//$('#book_date').datepicker({
//    'format': 'dd/mm/yyyy',
//    'autoclose': true
//});

$('#book_date').datepicker({
    'format': 'dd/mm/yyyy',
    'autoclose': true
});
$('#book_time').timepicker({
    format: 'hh:mm:ss',
});


var btn_reservation = document.getElementById("btn_reservation");
console.log(btn_reservation);

btn_reservation.addEventListener('click', function () {

    var reservationId = document.getElementById("reservationId").value;
    console.log(reservationId);

    if (reservationId === '') {
        alert('Hãy đăng nhập');
    }
});