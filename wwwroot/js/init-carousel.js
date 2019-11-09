function initializeCarousel(){
    window.initializeCarousel = () => {
        $('#quiz-carousel').carousel({ interval: 2000 });
        //see step 2 to understand these news id's:
        $('#quiz-carousel-prev').click(() => $('#quiz-carousel').carousel('prev'));
        $('#quiz-carousel-next').click(() => $('#quiz-carousel').carousel('next'));
    };
}
