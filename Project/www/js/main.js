var width = 800;
var height = 600;
var baseUri = "http://192.168.1.149:55555/api/";
var base64Image = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";

//base64
//iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==
$(document).ready(function() {

    document.addEventListener("deviceready", function(){

        $("#slikaj").click(function () {
          TakePhoto();
        });

        $("#gallery").click(function () {
          TakePhoto(1);
        });

        $("#grayscale").click(function () {
          $.mobile.loading( 'show');
          ConvertToGrayscale();
        });

        $("#invert").click(function () {
          $.mobile.loading( 'show');
          InvertColors();
        });

        $("#darken").click(function () {
          $.mobile.loading( 'show');
          DarkenImage();
        });

    });
});

function DarkenImage() {
  $.post(baseUri+"darken", {base64: base64Image}, function(result){
    $.mobile.loading( 'hide');
    ShowImage(result);
  });
}

function InvertColors() {
  $.post(baseUri+"invert", {base64: base64Image}, function(result){
    $.mobile.loading( 'hide');
    ShowImage(result);
  });
}

function ConvertToGrayscale() {
  $.post(baseUri+"grayscale", {base64: base64Image}, function(result){
    $.mobile.loading( 'hide');
    ShowImage(result);
  });
}

function ShowImage(image) {
  $("#img").attr('src', "data:image/png;base64, " + image);
  //image.substring(1,image.length -2));
}

function TakePhoto(gallery = 0) {
    navigator.camera.getPicture(onSuccess, onFail, GetOptions(gallery));
}

function onSuccess(imageData) {
    $("#img").attr('src', "data:image/png;base64, " + imageData);
    base64Image = imageData;
}

function onFail(message) {
    alert('Failed because: ' + message);
}

function GetOptions(gallery) {
  switch(gallery) {
    case 1:
      return {
          quality: 80,
          destinationType: Camera.DestinationType.DATA_URL,
          sourceType: Camera.PictureSourceType.PHOTOLIBRARY,
          encodingType: Camera.EncodingType.JPEG,
          mediaType: Camera.MediaType.PICTURE,
          targetWidth: width,
          targetHeight: height
      }
    default:
      return {
          quality: 80,
          destinationType: Camera.DestinationType.DATA_URL,
          encodingType: Camera.EncodingType.JPEG,
          mediaType: Camera.MediaType.PICTURE,
          targetWidth: width,
          targetHeight: height
      }
  }
}
