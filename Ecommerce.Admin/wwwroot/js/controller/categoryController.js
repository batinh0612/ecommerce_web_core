var category = {
    init: function () {
        category.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Category/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                    } else{
                        btn.text('Khoá');
                    }
                }
            });
        });

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                title: "Xóa danh mục",
                message: "Bạn có muốn xóa danh mục này không?",
                buttons: {
                    confirm: {
                        label: 'Xóa',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'Hủy',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    if (result) {
                        category.deleteEmployee(id);
                    }
                }
            });
        });
    },
    deleteEmployee: function (id) {
        $.ajax({
            data: { id: id },
            url: '/Category/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa danh mục thành công",
                        buttons: {
                            ok: {
                                label: 'Xác nhận'
                            }
                        },
                        callback: function () {
                            window.location.href = "/Category/Index";
                        }
                    });
                } else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa danh mục thất bại",
                        buttons: {
                            ok: {
                                label: 'Xác nhận'
                            }
                        }
                    });
                }
            }
        });
    }
}
category.init();