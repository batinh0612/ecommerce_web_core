var CartController = function () {
    this.initialize = function () {
        RegisterEvents();
    }

    function RegisterEvents() {
        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            deleteCart(id);
        })
    }

    function deleteCart(id) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: '/Cart/DeleteCart',
            data: {
                id: id
            },
            success: function (res) {

            }
        });
    }
};

