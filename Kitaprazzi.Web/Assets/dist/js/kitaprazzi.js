
function openSubMenu(e,n){$(document).on("click",e,function(){$(this).next(n).toggleClass("opened")})}$(document).ready(function(){$(".mobile-menu").click(function(){$(this).next(".main-menu").addClass("opened")}),$(".close-menu").click(function(){$(".main-menu").removeClass("opened")}),openSubMenu(".main-menu-item-wrapper",".wide-menu"),openSubMenu(".opened .sub-menu-title",".sub-menu");new Swiper(".main-slider",{slidesPerView:1,spaceBetween:30,loop:!0,pagination:{el:".swiper-pagination",clickable:!0},navigation:{nextEl:".swiper-button-next",prevEl:".swiper-button-prev"},effect:"fade"})});