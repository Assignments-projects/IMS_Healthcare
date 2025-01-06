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

// Activate side menu 
$(document).ready(function () {
    // Get the current URL path
    var currentPath = window.location.pathname.toLowerCase();
    var savedPath   = localStorage.getItem("lastPath");
    var hasActive   = false;

    // Function for activate menu by go through each element href
    var ActivateMenu = function (path) {

        $('.sidebar-link').each(function () {

            var href = $(this).attr('href') ? $(this).attr('href').toLowerCase() : '';

            // Check if the href matches the current path
            if (path === href || (path === "/home/index" && href === "/")) {

                // Expand the parent dropdown
                var parentDropdown = $(this).closest('.sidebar-dropdown');
                $(this).parents('.sidebar-item').addClass('active');

                if (parentDropdown.length) {
                    parentDropdown.addClass('show');
                    $(this).parents('.sidebar-item').children('[data-bs-toggle="collapse"]').removeClass('collapsed');
                }

                hasActive = true;
                localStorage.setItem("lastPath", path);
            }
        });
    }

    // Activate the menu
    ActivateMenu(currentPath);

    if (!hasActive) {
        ActivateMenu(savedPath);
    }
});
