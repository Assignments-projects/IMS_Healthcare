
var Controls = (function () {

    return {

        RelaodContainer: function (url, reloadContainerId, parameter) {

            var loading = `<div class="d-flex align-items-center justify-content-center gap-2">
                                <div class="spinner-border text-primary my-3" role="status"></div>
                                <p class="fs-5 m-0">Loading...</p>
                            </div>`;

            $.ajax({
                url: url,
                type: "GET",
                data: parameter,
                beforeSend: function () {
                    $(`#${reloadContainerId}`).html(loading);
                },
                success: function (response) {
                    $(`#${reloadContainerId}`).html(response);

                    // Intitialize feather icons
                    feather.replace();
                },
                error: function () {
                    toastr.error("Something went wrong!");
                }
            });
        },

        RelaodVoid: function (url, parameter, afterSuccess) {

            $.ajax({
                url: url,
                type: "GET",
                data: parameter,
                success: function (response) {

                    if (response.success) {

                        toastr.success(response.message);

                        if (response.url) {
                            window.location.href = response.url;
                        }

                        setTimeout(function () {

                            if (afterSuccess)
                                afterSuccess();
                            else
                                location.reload();

                        }, 200)
                    }
                    else
                        toastr.error(response.message);
                },
                error: function () {
                    toastr.error("Something went wrong!");
                }
            });
        },

        RelaodContainerOnModalPost: function (popUpId, form, reloadContainerId, afterSuccess) {

            var loading = `<div class="d-flex align-items-center justify-content-center gap-2">
                                <div class="spinner-border text-primary my-3" role="status"></div>
                                <p class="fs-5 m-0">Loading...</p>
                            </div>`;

            var formData = new FormData(form[0]);

            $.ajax({
                url: form.attr("action"),
                type: "POST",
                data: formData,
                processData: false,
                contentType: false, 
                success: function (response) {
                    if (response.success) {
                        $(`#${popUpId}`).modal('hide');
                        toastr.success(response.message);
                        $(`#${reloadContainerId}`).html(loading);

                        if (response.url) {
                            window.location.href = response.url;
                        }

                        setTimeout(function () {

                            if (afterSuccess)
                                afterSuccess();
                            else
                                location.reload();

                        }, 200)

                        // Intitialize feather icons
                        feather.replace();
                    }
                    else
                        toastr.error(response.message);
                },
                error: function () {
                    toastr.error("Something went wrong!");
                }
            });
        },

        // Open Bootstrap modal with ajax get call
        OpenPopUpModal: function (url, popUpId, title, btnText, btnClass) {

            var btnClassDefult = "jq-main-modal-submit-button-class";
            console.log(url)
            
            $.get(url)
                .done(function (data) {
                    // Check if the response is JSON and indicates an error
                    try {

                        var jsonResponse = JSON.parse(data);

                        if (jsonResponse.success === false) {
                            toastr.error(data.message);
                            return;
                        }
                    } catch (e) {}

                    // Populate the modal with HTML content
                    $(`#${popUpId} .modal-body`).html(data);
                    $(`#${popUpId} .modal-title`).text(title);
                    $(`#${popUpId} .${btnClassDefult}`).text("Submit");
                    $(`#${popUpId} .${btnClassDefult}`).removeClass().addClass(`btn btn-success ${btnClassDefult}`);

                    if (btnText) {
                        $(`#${popUpId} .${btnClassDefult}`).text(btnText);
                    }
                    if (btnClass) {
                        $(`#${popUpId} .${btnClassDefult}`).removeClass().addClass(`btn ${btnClass} ${btnClassDefult}`);
                    }

                    $(`#${popUpId}`).modal("show");

                    // Initialize Feather icons
                    feather.replace();
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    toastr.error(`Failed to load content: ${textStatus} - ${errorThrown}`);
                });
        },

        // Initiate datatable js for the given id of the table
        InitiateDataTable: function (tableId) {

            $(`#${tableId}`).DataTable().destroy();

            $(`#${tableId}`).DataTable({
                layout: {
                    topStart: {
                        buttons: ['excelHtml5', 'pdfHtml5']
                    }
                }
            });
        }
    };

})();