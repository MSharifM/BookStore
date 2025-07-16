document.addEventListener('DOMContentLoaded', function () {
    const slider = document.querySelector('.slider');
    const slides = document.querySelectorAll('.slide');
    const dotsContainer = document.querySelector('.slider-dots');
    const prevBtn = document.querySelector('.prev-slide');
    const nextBtn = document.querySelector('.next-slide');

    let currentSlide = 0;
    const slideCount = slides.length;

    // ایجاد نقاط برای اسلایدر
    slides.forEach((_, index) => {
        const dot = document.createElement('div');
        dot.classList.add('dot');
        if (index === 0) dot.classList.add('active');
        dot.addEventListener('click', () => goToSlide(index));
        dotsContainer.appendChild(dot);
    });

    const dots = document.querySelectorAll('.dot');

    // رفتن به اسلاید خاص
    function goToSlide(slideIndex) {
        slider.style.transform = `translateX(-${slideIndex * 100}%)`;
        currentSlide = slideIndex;

        // آپدیت نقاط فعال
        dots.forEach((dot, index) => {
            dot.classList.toggle('active', index === currentSlide);
        });
    }

    // اسلاید بعدی
    function nextSlide() {
        currentSlide = (currentSlide + 1) % slideCount;
        goToSlide(currentSlide);
    }

    // اسلاید قبلی
    function prevSlide() {
        currentSlide = (currentSlide - 1 + slideCount) % slideCount;
        goToSlide(currentSlide);
    }

    // رویدادهای دکمه‌ها
    nextBtn.addEventListener('click', nextSlide);
    prevBtn.addEventListener('click', prevSlide);

    // اسلاید خودکار
    let slideInterval = setInterval(nextSlide, 5000);

    // توقف اسلاید خودکار هنگام هاور
    slider.addEventListener('mouseenter', () => {
        clearInterval(slideInterval);
    });

    slider.addEventListener('mouseleave', () => {
        slideInterval = setInterval(nextSlide, 5000);
    });

    // سوایپ برای موبایل
    let touchStartX = 0;
    let touchEndX = 0;

    slider.addEventListener('touchstart', (e) => {
        touchStartX = e.changedTouches[0].screenX;
    }, { passive: true });

    slider.addEventListener('touchend', (e) => {
        touchEndX = e.changedTouches[0].screenX;
        handleSwipe();
    }, { passive: true });

    function handleSwipe() {
        if (touchEndX < touchStartX - 50) {
            nextSlide();
        } else if (touchEndX > touchStartX + 50) {
            prevSlide();
        }
    }
});