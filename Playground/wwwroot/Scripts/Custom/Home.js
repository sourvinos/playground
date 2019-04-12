$(document).ready(function () {

    resizeImage();

})

$(document).resize()
{
    resizeImage();
}

function resizeImage() {

    var wrapperHeight = $("#wrapper").css("height");
    var wrapperWidth = $("#wrapper").css("width");

    console.log(wrapperHeight);
    console.log(wrapperWidth);

    $("#mainImage").css("height", wrapperHeight);
    $("#mainImage").css("width", wrapperHeight);

};
