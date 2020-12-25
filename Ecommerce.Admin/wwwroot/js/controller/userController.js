var user = {
    init: function () {
        user.registerEvents();
        //user.loadData();
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

                    }
                }
            });
        });
    },
    //deleteUser: function (id) {
    //    $.ajax({
    //        data: { id: id },
    //        url: '/User/Delete',
    //        dataType: 'json',
    //        type: 'POST',
    //        success: function (res) {
    //            if (res.status == true) {
    //                bootbox.alert({
    //                    title: "Thông báo",
    //                    message: "Xóa người dùng thành công",
    //                    buttons: {
    //                        ok: {
    //                            label: 'Xác nhận'
    //                        }
    //                    },
    //                    callback: function () {
    //                        //window.location.href = "/User/Index";
    //                        $('#example1').DataTable().ajax.reload();
    //                    }
    //                });
    //            } else {
    //                bootbox.alert({
    //                    title: "Thông báo",
    //                    message: "Xóa người dùng thất bại",
    //                    buttons: {
    //                        ok: {
    //                            label: 'Xác nhận'
    //                        }
    //                    }
    //                });
    //            }
    //        }
    //    });
    //}

    deleteUser: function (id) {
        $.ajax({
            data: { id: id },
            url: '/User/Delete',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status) {
                    toastr.success('Xóa thành công');
                    $('#example1').DataTable().ajax.reload();
                    //$('.tbl11').DataTable().ajax.reload();
                }

            }
        });
    },

    //loadData: function () {
    //    $.ajax({
    //        type: 'GET',
    //        url: '/User/Index',
    //        dataType: 'text',
    //        success: function (res) {
    //            var html = '';
    //            $.each(res, function (i, item) {
    //                html += "<tr>"
    //                    + "<td>"+item.Username+"</td>"
    //                    + "<td>"+item.FirstName + item.LastName+"</td>"
    //                    + "<td>"+item.Phone+"</td>"
    //                    + "<td>"+item.Email+"</td>"
    //                    + "<td><a href=\"#\" data-id="+item.Id+" class=\"btn btn-action btn-active btn-outline-success status\">"+(item.IsDelete ? "Khóa" : "Kích hoạt")+"</a></td>"
    //                    + "<td>"
    //                    + "  @Html.ActionLink(\"Sửa\", \"Edit\", new {"+id = item.Id+"}, new { @class = \"btn btn-primary btn-action\" })"
    //                    + "        @Html.ActionLink(\"Xem chi tiết\", \"Details\", new {id = item.Id}, new { @class = \"btn btn-info btn-action\" })"
    //                    + "      <a href=\"#\" data-id=\"@item.Id\" class=\"btn btn-danger btn-action btn-delete\">Xoá</a>"
    //                    + "</td>"
    //                    + "</tr>"
    //            });
    //            $("#tbl_User").html(html);
    //        }
    //    });
    //}
}
user.init();