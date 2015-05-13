var Product = {};

Product.ExportJson = function () {
    $.ajax({
        url: "GetAllProducts",
        type: 'GET',
    }).done(function (products) {
        $.each(products, function () {
            $("#dialog").dialog({
                modal: true,
                hide: "explode",
                open: function (event, ui) {
                    $('.ui-dialog-content').html("Succesful");
                },
                buttons: [{
                    text: "OK",
                    click: function () {
                        $(this).dialog("close");
                    }
                }]
            });
        })
        $.ajax({
            url: "ExportJson",
            type: 'POST',
            data: {products : JSON.stringify(products)}
        });
       
    }).fail(function (xhr) {
    });
};