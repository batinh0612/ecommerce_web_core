var supplier = {
    init: function () {
        supplier.registerEvents();
    },
    registerEvents: function () {
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                title: "Xóa người dùng",
                message: "Bạn có muốn xóa nhà cung cấp này không?",
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
                        supplier.deleteSupplier(id);
                    }
                }
            });
        });
    },
    deleteSupplier: function (id) {
        $.ajax({
            data: { id: id },
            url: '/Supplier/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa nhà cung cấp thành công",
                        buttons: {
                            ok: {
                                label: 'Xác nhận'
                            }
                        },
                        callback: function () {
                            window.location.href = "/Supplier/Index";
                        }
                    });
                } else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa nhà cung cấp thất bại",
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
supplier.init();