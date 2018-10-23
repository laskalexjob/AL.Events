$("#UploadImg").on('click', function () {
    UnloadImage();
})


function UnloadImage() {
    var data = new FormData();
    var files = $("#imageBrowes").get(0).files;
    if (files.length > 0) {
        data.append("imageBrowes", files[0]);
    }

    $.ajax({
        url: "/Event/AddImage",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            $("#UserImage").attr("src", response.imagePath);
            var a = $("input[name='ImagePath']").val();
            $("input[name='ImagePath']").val(response.imagePath);
        }
    });
}