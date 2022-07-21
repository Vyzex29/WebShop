$(document).ready(function () {
    $(".minus").click(function (e) {
        e.preventDefault();
        productId = $(this).attr("data-field");
        console.log("itemId: " + productId);
        CallMinus(productId);
    });
});
$(document).ready(function () {
    $(".plus").click(function (e) {
        e.preventDefault();
        productId = $(this).attr("data-field");
        requestUrl = $(this).attr("data-request-url");
        console.log("itemId: " + productId);
        CallPlus(productId, requestUrl);
    });
});
$(document).ready(function () {
    $(".quantityInput").change(function (e) {
        e.preventDefault();
        productId = $(this).attr("id");
        console.log("itemId: " + productId);
        inputField = document.getElementById(productId);
        inputValue = parseInt(inputField.value);
        console.log("inputValue" + inputValue);
        validatedQuantity = 0;
        if (!isNaN(inputValue) && inputValue > 0) {
            console.log("The input was changed to -> " + inputValue);
            validatedQuantity = inputValue;
        } else {
            inputField.setAttribute("value", "1");
            validatedQuantity = 1;
        }
        CallEditQuantity(productId, validatedQuantity)
    });
});
function CallMinus(productId) {
    let inputField = document.getElementById(productId);
    console.log("InputField value:" + inputField.value);
    if (inputField.value > 1) {
        var currentVal = parseInt(inputField.value);
        var newValue = currentVal - 1;
        inputField.setAttribute("value", newValue);
        $.ajax({
            type: "POST",
            url: "Cart/SubtractAnItem",
            data: { itemId: productId },
            dataType: "json",
            success: function (result) {
                console.log(result);


            },
            error: function (req, status, error) {
                console.log(req);
                console.log(status);
                console.log(error);
            }
        });
    }
};

function CallPlus(productId, requestUrl) {
    let inputField = document.getElementById(productId);
    console.log("InputField value: " + inputField.value);
    console.log("ProductId before ajax call: " + productId);
    $.ajax({
        type: "POST",
        url: requestUrl,
        data: { itemId: productId }, // { "itemId":"${productIdValue}"}
        dataType: "json",
        success: function (result) {
            console.log(result);
            var currentVal = parseInt(inputField.value);
            var newValue = currentVal + 1;
            inputField.setAttribute("value", newValue);

        },
        error: function (req, status, error) {
            console.log(req);
            console.log(status);
            console.log(error);
        }
    });
};

function CallEditQuantity(productId, quantity) {
    $.ajax({
        type: "POST",
        url: "/Cart/EditQuantity",
        data: { quantity: quantity, itemId: productId }, // { "itemId":"${productIdValue}"}
        dataType: "json",
        success: function (result) {
            console.log(result);
        },
        error: function (req, status, error) {
            console.log(req);
            console.log(status);
            console.log(error);
        }
    });
};