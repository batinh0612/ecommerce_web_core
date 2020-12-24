var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                title: "Xóa người dùng",
                message: "Bạn có muốn xóa người dùng này không?",
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
                        user.deleteUser(id);
                        toastr.success('Xóa thành công');
                    }
                }
            });
        });
    },
    deleteUser: function (id) {
        $.ajax({
            data: { id: id },
            url: '/User/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa người dùng thành công",
                        buttons: {
                            ok: {
                                label: 'Xác nhận'
                            }
                        },
                        callback: function () {
                            //window.location.href = "/User/Index";
                            $('#example1').DataTable().ajax.reload();
                        }
                    });
                } else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: "Xóa người dùng thất bại",
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
user.init();