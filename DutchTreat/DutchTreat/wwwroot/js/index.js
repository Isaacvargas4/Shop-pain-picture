$(document).ready(() => {

    let theForm = $("#theForm");
    theForm.hide();

    let button = $("#buyButton");

    button.on("click", () => console.log(' buying paintin '));

    let productInfo = $(".product-props li");

    productInfo.on("click", function () {
        console.log(` You clicked on ${this.innerText} `)

    });

    let $LoginToggle = $("#loginToggle");
    let $popupForm = $(".popup-form");

    $LoginToggle.on("click", function () {
        console.log('hide the login')
        $popupForm.slideToggle(500);
    });

});



