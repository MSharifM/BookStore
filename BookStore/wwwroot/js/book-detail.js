document.addEventListener('DOMContentLoaded', function () {
    const tabHeaders = document.querySelectorAll('.tabs-header li');
    const tabPanes = document.querySelectorAll('.tab-pane');

    tabHeaders.forEach(header => {
        header.addEventListener('click', function () {
            const tabId = this.getAttribute('data-tab');

            tabHeaders.forEach(h => h.classList.remove('active'));
            tabPanes.forEach(p => p.classList.remove('active'));

            this.classList.add('active');
            document.getElementById(tabId).classList.add('active');
        });
    });

    const minusBtn = document.querySelector('.quantity-btn.minus');
    const plusBtn = document.querySelector('.quantity-btn.plus');
    const quantityInput = document.querySelector('.quantity-selector input');

    if (minusBtn && plusBtn && quantityInput) {
        minusBtn.addEventListener('click', function () {
            let value = parseInt(quantityInput.value);
            if (value > 1) {
                quantityInput.value = value - 1;
            }
        });

        plusBtn.addEventListener('click', function () {
            let value = parseInt(quantityInput.value);
            const max = parseInt(quantityInput.getAttribute('max'));
            if (value < max) {
                quantityInput.value = value + 1;
            }
        });
    }

    const addToCartBtn = document.querySelector('.add-to-cart');
    if (addToCartBtn) {
        addToCartBtn.addEventListener('click', function () {
            const bookId = this.getAttribute('data-book-id');
            const quantity = parseInt(quantityInput.value);

            fetch('/Cart/Add', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({
                    bookId: bookId,
                    quantity: quantity
                })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        const cartCount = document.querySelector('.cart-count');
                        if (cartCount) {
                            cartCount.textContent = data.cartCount;
                        }

                        Swal.fire({
                            icon: 'success',
                            title: 'موفقیت آمیز',
                            text: 'کتاب با موفقیت به سبد خرید اضافه شد',
                            confirmButtonText: 'باشه'
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'خطا',
                            text: data.message || 'خطا در افزودن به سبد خرید',
                            confirmButtonText: 'باشه'
                        });
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'خطا',
                        text: 'خطا در ارتباط با سرور',
                        confirmButtonText: 'باشه'
                    });
                });
        });
    }

    const addToWishlistBtn = document.querySelector('.add-to-wishlist');
    if (addToWishlistBtn) {
        addToWishlistBtn.addEventListener('click', function () {
            const bookId = this.getAttribute('data-book-id');

            fetch('/Wishlist/Add', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({
                    bookId: bookId
                })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        Swal.fire({
                            icon: 'success',
                            title: 'موفقیت آمیز',
                            text: 'کتاب با موفقیت به علاقه‌مندی‌ها اضافه شد',
                            confirmButtonText: 'باشه'
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'خطا',
                            text: data.message || 'خطا در افزودن به علاقه‌مندی‌ها',
                            confirmButtonText: 'باشه'
                        });
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'خطا',
                        text: 'خطا در ارتباط با سرور',
                        confirmButtonText: 'باشه'
                    });
                });
        });
    }

});