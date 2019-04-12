$currentLeft = 0;
$thumbnailsTotal = $(".thumbnail").length;
$thumbnailWidth = parseInt($(".thumbnail").css("width"));
$thumbnailsVisible = parseInt($("#thumbnails").width() / $(".thumbnail").width());
$thumbnailsWidth = $thumbnailWidth * $thumbnailsTotal;

$("#scrollLeft").on("click", function () {

    $currentLeft -= $thumbnailWidth;

    if ($currentLeft >= 0) {
        $("#thumbnails").animate({ scrollLeft: $currentLeft });
    } else {
        $currentLeft = $thumbnailsWidth - ($thumbnailsVisible * $thumbnailWidth);
        $("#thumbnails").animate({ scrollLeft: $currentLeft });
    }

})

$("#scrollRight").click(function () {

    $currentLeft += $thumbnailWidth;

    if ($currentLeft + ($thumbnailWidth * $thumbnailsVisible) <= $thumbnailsWidth) {
        $("#thumbnails").animate({ scrollLeft: $currentLeft });
    } else {
        $currentLeft = 0;
        $("#thumbnails").animate({ scrollLeft: $currentLeft });
    }

})

$(".thumbnail img").on("click", function () {
    $(".thumbnail img").each(function (index) {
        $(this).removeClass("active");
    });

    $(this).addClass("active");

    $mainImage = $("#mainImage img").attr("src", $(this).attr("src"));
})
