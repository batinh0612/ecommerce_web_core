var manufacture = {
    init: function () {
        manufacture.registerEvents();
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
                        manufacture.deleteManufacture(id);
                    }
                }
            });
        });
    },
    deleteManufacture: function (id) {
        $.ajax({
            data: { id: id },
            url: '/Manufacture/Delete',
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
                        callback: function(){
                            manufacture.loadData();
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
    },

    loadData: function () {
        //$.ajax({
        //    type: "GET",
        //    url: '/Manufacture/Index',
        //    success: function (res) {
        //        var html = '';
        //        $.each(res, function (i, item) {
        //            html += "<tr>" +
        //                +"<td>" + item.Name + "</td >"
        //                +"<td>" + item.CodeName + "</td>"
        //                +"<td>" + item.Phone + "</td>"
        //                +"<td>" + item.Email + "</td>"
        //                +"<td>" + item.Fax + "</td>"
        //                + "<td>"
        //                + "@Html.ActionLink(\"Sửa\", \"Edit\", new { id = item.Id }, new { @class = \"btn btn-primary btn-action\"})"
        //                    + "@Html.ActionLink(\"Xem chi tiết\", \"Details\", new { id = item.Id }, new { @class = \"btn btn-info btn-action\"})"
        //                + "<a href=\"#\" data-id=\"@item.Id\" class=\"btn btn-danger btn-action btn-delete\">Xoá</a>"
        //                    + "</td>"
        //                +"</tr>";
        //        });

        //        $("#content_tbody").html(html);
        //    }
        //});

        $("#example1").DataTable({
            "destroy": true,
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "columnDefs": [
                { "targets": 5, "orderable": false }
            ],
            "info": true,
            "autoWidth": false,
            "responsive": true,
            "language": {
                "info": "Hiển thị _START_ đến _END_ trong _TOTAL_ bản ghi",
                "search": "Tìm kiếm:",
                "zeroRecords": "Không tìm thấy bản ghi nào",
                "infoFiltered": "(Tìm kiếm từ _MAX_ bản ghi)",
                "paginate": {
                    "first": "Đầu",
                    "last": "Cuối",
                    "next": "Sau",
                    "previous": "Trước"
                },
                "lengthMenu": "Hiển thị _MENU_ bản ghi",
                "infoEmpty": "Hiển thị 0 đến 0 trong 0 bản ghi",
                "emptyTable": "Không có dữ liệu trong bảng",
            },
            "zeroRecords": "Không tìm thấy bản ghi nào",  
            "ajax": {
                "url": "/Manufacture/Index",
                "type": "GET"
            },
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
            "columns": [
                { "data": "Id"},
                { "data": "CodeName"},
                { "data": "Name"},
       
                { "data": "Phone"},
                { "data": "Email"},
                { "data": "Fax"},
                //{
                //    "render": function (data, type, full, meta) { return '@Html.ActionLink(\"Sửa\", \"Edit\", new { id = full.Id }, new { @class = \"btn btn-primary btn-action\"})'; }
                //},
                {
                    data: null,
                    render: function (data, type, row) {
                        return "<a href='#' data-id='" +row.Id+"' class='btn btn-danger btn-action btn-delete'>Xoá</a>";
                    }
                },
            ]

        });  
    }
}


manufacture.init();