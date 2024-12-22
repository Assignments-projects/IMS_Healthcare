// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Side bar toggle
const sidebarToggle = document.querySelector(".sidebar-toggle");

sidebarToggle.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("collapsed");
});

// Use feather icons
feather.replace();

// expand to full screen mode
$('.js-fullscreen').click(function () {
    if (!document.fullscreenElement)
        document.documentElement.requestFullscreen();
    else
        document.exitFullscreen();
});
