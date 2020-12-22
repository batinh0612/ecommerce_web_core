var CartController = function () {
    this.initialize = function () {
        loadData();
        RegisterEvents();
    }

    function RegisterEvents() {
        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            deleteCart(id);
        })

        $('body').on('click', '.increase', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#sst_' + id).val()) + 1;
            updateCart(id, quantity);
        })

        $('body').on('click', '.reduced', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#sst_' + id).val()) - 1;
            updateCart(id, quantity);
        })
        $('body').on('change','.qty', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#sst_' + id).val());
            updateCart(id, quantity);
        })

        $(".qty").click(function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#sst_' + id).val());
            updateCart(id, quantity);
        });

        
    }

    function updateCart(id, quantity) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function () {
                loadData();
            },
            error: function () {
                loadData();
            }
        });
    }

    function deleteCart(id) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: '/Cart/DeleteCart',
            data: {
                id: id
            },
            success: function () {
                loadData();
            }
        });
    }

    function loadData() {
        $.ajax({
            type: 'GET',
            url: '/Cart/GetListItems',
            success: function (res) {
                var html = '';
                var total = 0;
                $.each(res, function (i, item) {
                    var amount = (item.price * item.quantity) - ((item.price * item.quantity * item.percentDiscount) / 100);
                    html += "<tr>"
                        + "<td><div class=\"media\">"
                        + "<div class=\"d-flex\"><img width=\"80\" height=\"80\" src=\"" + $('#hiddenBaseAddress').val() + item.imageLink + "\"></div>"
                        + "<div class=\"media-body\"><p>" + item.name + "</p></div></div></td>"
                        + "<td><h5>" + numberWithCommas(item.price) + "</h5></td>"
                        + "<td>" + item.percentDiscount + "</td>"
                        + "<td><div class=\"product_count\">"
                        + "<input type =\"text\" onkeypress=\"myFunction()\" data-id=\"" + item.id + "\" name=\"qty\" id=\"sst_" + item.id + "\" maxlength=\"12\" value=\"" + item.quantity + "\" title=\"Quantity:\"class=\"input-text qty\">"
                        + "<button data-id=\"" + item.id + "\" onclick=\"var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst )) result.value++;return false;\"class=\"increase items-count\" type=\"button\"><i class=\"lnr lnr-chevron-up\"></i></button>"
                        + "<button data-id=\"" + item.id + "\" onclick=\"var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst ) &amp;&amp; sst > 0 ) result.value--;return false;\"class=\"reduced items-count\" type=\"button\"><i class=\"lnr lnr-chevron-down\"></i></button>"
                        + "</div></td>"
                        + "<td><h5>" + numberWithCommas(item.totalPrice - (item.totalPrice * item.percentDiscount)/100) + "</h5></td>"
                        + "<td><button data-id=\"" + item.id + "\" class=\"btn btn-danger btn-remove\">Xóa</button></td>"
                        + "</tr>";
                    total += amount;
                      
                });
                html += +"<tr class=\"bottom_button\">"
                    //+ "<td><a class=\"gray_btn\" href=\"#\">Update Cart</a></td><td></td><td></td>"
                    + "<td></td><td></td><td></td>"
                    + "<td></td>"
                    + "<td><h5 id='lbl_total'>Subtotal: </h5></td>"
                    + "</tr>";

                $("#cart_body").html(html);
                $("#lbl_total").append(numberWithCommas(total) + " " + "VNĐ");
            }
        });
    }
};

function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}