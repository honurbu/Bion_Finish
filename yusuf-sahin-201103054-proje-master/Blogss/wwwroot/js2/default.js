/*
  Created on : 22.Ağustos.2022, 15:30:30
  Author     : ISDO Web & Yazilim
*/
$(document).ready(function(){

  //Modal
   $('.modal').modal();


   //Sidenav
   $('.sidenav').sidenav();

   //SLIDER
   $('.slider').owlCarousel({
      loop:true,
      margin:10,
      nav:true,
      dot:false,
      navText: ["<img class='left-arrow' src='/images/left-arrow-1.png' alt='MATDER'>","<img class='right-arrow' src='/images/right-arrow-1.png' alt='MATDER'>"],
      responsive:{
          0:{
              items:1
          },
          600:{
              items:1
          },
          1000:{
              items:1
          }
      }
  });

  //Parallax
   $('.parallax').parallax();

  //DROPDOWN
   $('.dropdown-trigger').dropdown();

   // İletişim Formu
   $('#iletisimFormuOnay').click(function () {
       var isim_soyisim = $("#isim_soyisim").val();
       var email = $("#email").val();
       var tel = $("#tel").val();
       var mesaj = $("#mesaj").val();
       if (isEmail(email) && isim_soyisim!="" && mesaj!="") {
           $("#iletisimFormuOnay").attr("disabled", true);
           $("#iletisimFormuOnay").text('Gönderiliyor...');
           var data = new FormData($("#iletisimformu")[0]);
           var ajaxRequest = $.ajax({
           type: "POST",
           url: "/ajax/all_methods.asp?method=iletisimformuonay",
           contentType: false,
           processData: false,
           data: data,
           success: function (data) {
               $("#iletisimFormuOnay").attr("disabled", false);
               $("#iletisimFormuOnay").text('Gönder');

                   if (data.indexOf("error") >= 0) {
                   var res = data.split(':');
                   var hata = res[1];
                   M.toast({html:hata}, 4000);
                   }
                   else if (data.indexOf("success") >= 0) {
                   //var res = data.split(':');
                   //var sonuc = res[1];
                   $("#iletisimformu")[0].reset();
                   M.toast({html:"Mesajınız ilgili birime iletilmiştir. En kısa sürede cevaplanacaktır."}, 4000);
                   }
               }
           });
       }
       else{
           if(!isEmail(email)) {M.toast({html:"Geçerli bir e-mail adresi girmediniz!"}, 4000);}
           if(isim_soyisim=="" ) {M.toast({html:"Lütfen Adınızı Yazınız!"}, 4000);}
           if(tel=="" ) {M.toast({html:"Lütfen telefon numaranızı giriniz..."}, 4000);}
           if(mesaj=="" ) {M.toast({html:"Lütfen mesajınızı giriniz..."}, 4000);}
       }
   });
   function isEmail(value) {
      return /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(value) ? true : false;
  }
   //Header Search Show/Hide
  $('.header-search button').click(function(){
      $('.header-search input').toggleClass('show-input');
  });

  $('.dropdown-list-title a ').click(function(){
      $(this).parent().toggleClass("open-dropdown-list-content");
  });
});


//Mobile-Slider
function sliderMobile(){
  var ScreenWidth = $( window ).width();
  if(ScreenWidth <= 601){
      $( "#anaslide .item img" ).each(function( index, element ) {
          var elementData=$(element).attr("data-resim");
          $(element).attr("src",elementData);
      });
  }

  $('.slides-href').click(function(){
    $(".slides").hide();
    var dataId = $(this).attr("data-id");
    console.log(dataId)
    $(".slides[data-id='"+dataId+"']").show();
});
}
