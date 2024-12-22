
var Controls = (function () {

    return {

        RelaodContainer: function (url, reloadContainerId) {

            var loading = `<div class="d-flex align-items-center justify-content-center gap-2">
                                <div class="spinner-border text-primary my-3" role="status"></div>
                                <p class="fs-5 m-0">Loading...</p>
                            </div>`;

            $.ajax({
                url: url,
                type: "GET",
                beforeSend: function () {
                    $(`#${reloadContainerId}`).html(loading);
                },
                success: function (response) {
                    $(`#${reloadContainerId}`).html(response);                       
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

            $.ajax({
                url: form.attr("action"),
                type: "POST",
                data: form.serialize(),
                success: function (response) {
                    if (response.success) {
                        $(`#${popUpId}`).modal('hide');
                        toastr.success(response.message);
                        $(`#${reloadContainerId}`).html(loading);

                        setTimeout(function () {

                            if (afterSuccess)
                                afterSuccess();
                            else
                                location.reload();

                        }, 1000)
                    }
                    else
                        toastr.error(response.message);
                },
                error: function () {
                    toastr.error("Something went wrong!");
                }
            });
        },

        OpenPopUpModal: function (url, popUpId, title, btnText, btnClass) {

            $.get(url, function (data) {
                $(`#${popUpId} .modal-body`).html(data);
                $(`#${popUpId} .modal-title`).text(title);
                $(`#${popUpId} .btn-modal-submit`).text(btnText);
                $(`#${popUpId} .btn-modal-submit`).removeClass().addClass("btn " + btnClass);
                $(`#${popUpId}`).modal("show");
            });
        },

    };

})();