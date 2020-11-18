var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {
        //$('.btn-active').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    var btn = $(this);
        //    var id = btn.data('id');
        //    $.ajax({
        //        url: "/Category/ChangeStatus",
        //        data: { id: id },
        //        dataType: "json",
        //        type: "POST",
        //        success: function (response) {
        //            console.log(response);
        //            if (response.status == true) {
        //                btn.text('Kích hoạt');
        //            } else {
        //                btn.text('Khoá');
        //            }
        //        }
        //    });
        //});

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                title: "Xóa sản phẩm",
                message: "Bạn có muốn xóa sản phẩm này không?",
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
                        product.deleteProduct(id);
                    }
                }
            });
        });
    },
    deleteProduct: function (id) {
        $.ajax({
            data: { id: id },
            url: '/Product/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa sản phẩm thành công",
                        buttons: {
                            ok: {
                                label: 'Xác nhận'
                            }
                        },
                        callback: function () {
                            window.location.href = "/Product/Index";
                        }
                    });
                } else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa sản phẩm thất bại",
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
product.init();