$(function () {
    setAccordion();
});

function setAccordion() {
    $(".cbp_tmlabel").click(function () {        
        $(this).find("p").slideToggle("slow");
    });
}