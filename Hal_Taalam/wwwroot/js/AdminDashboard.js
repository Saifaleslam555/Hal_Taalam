document.addEventListener('DOMContentLoaded', function () {
    // 1. زر التحديث (Refresh)
    const refreshBtn = document.getElementById('refreshBtn');
    if (refreshBtn) {
        refreshBtn.addEventListener('click', function () {
            // إضافة تأثير دوران للأيقونة
            const icon = this.querySelector('.btn-icon');
            icon.style.transition = "transform 0.5s ease";
            icon.style.transform = "rotate(360deg)";

            // محاكاة تحميل بيانات (ممكن تبدلها بـ AJAX call)
            setTimeout(() => {
                location.reload();
            }, 500);
        });
    }

    // 2. تأثير خفيف عند المرور على صفوف الجدول
    const tableRows = document.querySelectorAll('.data-table tbody tr');
    tableRows.forEach(row => {
        row.addEventListener('mouseenter', () => {
            row.style.backgroundColor = '#fff9f0';
            row.style.cursor = 'pointer';
        });
        row.addEventListener('mouseleave', () => {
            row.style.backgroundColor = 'transparent';
        });
    });

    // 3. أنيميشن بسيط للـ Progress Bars عند فتح الصفحة
    const progressBars = document.querySelectorAll('.category-progress');
    progressBars.forEach(bar => {
        const width = bar.style.width;
        bar.style.width = '0';
        setTimeout(() => {
            bar.style.transition = "width 1s ease-in-out";
            bar.style.width = width;
        }, 100);
    });

    // 4. رسالة ترحيب في الكونسول (للمطورين)
    console.log("%cHal Taalam Admin Dashboard Loaded!", "color: #f39c12; font-size: 20px; font-weight: bold;");
});