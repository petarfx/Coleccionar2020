﻿var cantImg = 5; //de 0 a 5 son 6 imagenes

$(".imgAdd").click(function () {
    if (cantImg > 0) {  //col-sm-4 col-md-3 col-lg-2
        $(this).closest(".row").find('.imgAdd').before('<div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 imgUp"><div class="imagePreview"></div><label class="btn btn-primary">Cargar<input type="file" runat="server" class="uploadFile img" name="ctl00$MainContent$FileUpload3" id="MainContent_FileUpload3" value="Upload Photo" style="width:0px;height:0px;overflow:hidden;"></label><i class="fa fa-times del"></i></div>');
        cantImg--;
    }
    if (cantImg == 0)
        document.getElementsByClassName('imgAdd')[0].style.visibility = 'hidden';

});
$(document).on("click", "i.del", function () {
    $(this).parent().remove();
    cantImg++;
    document.getElementsByClassName('imgAdd')[0].style.visibility = 'visible';
});
$(function () {
    $(document).on("change", ".uploadFile", function () {
        var uploadFile = $(this);
        var files = !!this.files ? this.files : [];
        if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

        if (/^image/.test(files[0].type)) { // only image file
            var reader = new FileReader(); // instance of the FileReader
            reader.readAsDataURL(files[0]); // read the local file

            reader.onloadend = function () { // set image data as background of div
                //alert(uploadFile.closest(".upimage").find('.imagePreview').length);
                uploadFile.closest(".imgUp").find('.imagePreview').css("background-image", "url(" + this.result + ")");
            }
        }

    });
});

function MuestraOcultaMensaje() {
    //$(".showhide").hide().fadeIn(4000);
    $(".showhide").fadeIn(4000);
    $(".showhide").delay(8000);
    $(".showhide").fadeOut(2000);
};


$(function () {
    $('#myCarousel').carousel();
});

function openLoTengoModal() {
    $('#loTengoModal').modal('show');
}