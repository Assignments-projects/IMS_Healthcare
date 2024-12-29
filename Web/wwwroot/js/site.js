// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Side bar toggle
const sidebarToggle = document.querySelector(".sidebar-toggle");

sidebarToggle.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("collapsed");
});

// Intitialize feather icons
feather.replace();

// Expand to full screen mode
$('.js-fullscreen').click(function () {
    if (!document.fullscreenElement)
        document.documentElement.requestFullscreen();
    else
        document.exitFullscreen();
});

// Function for load Tab active tab-pane
var LoadTabActive = function (navLink) {

    if (navLink) {
        var reloadId = navLink.data("reload-id");
        var url      = navLink.data("url");

        Controls.RelaodContainer(url, reloadId);
    }
    else {
        var activeTab = $('.nav-link.active');

        if (activeTab.length > 0) {
            activeTab.each(function (index, element) {
                var reloadId = $(this).data("reload-id");
                var url      = $(this).data("url");

                Controls.RelaodContainer(url, reloadId);
            });
        }
    }
}

// Activate closest tab
var ActiveClosestTab = function (element) {
    var targetId = element.closest('.tab-pane').attr('id');
    $(`.nav-link[data-realod-id="${target}"]`).click();
}

// Load all active tabs
LoadTabActive();

// Load tab which clicked
$('.nav-link').click(function () {
    LoadTabActive($(this));
});
