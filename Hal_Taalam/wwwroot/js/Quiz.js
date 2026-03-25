// Quiz Game JavaScript - Animations Only
document.addEventListener('DOMContentLoaded', function () {
    initializeQuiz();
});

function initializeQuiz() {
    const answerOptions = document.querySelectorAll('.answer-option');
    const btnNext = document.getElementById('btnNext');

    // Add click handlers to answer options for animations
    answerOptions.forEach(option => {
        option.addEventListener('click', function () {
            selectAnswer(this);
        });
    });

    // Add entrance animations
    addEntranceAnimations();

    // Add keyboard navigation
    addKeyboardNavigation();
}

function selectAnswer(selectedOption) {
    const answerOptions = document.querySelectorAll('.answer-option');
    const btnNext = document.getElementById('btnNext');

    // Remove selected class from all options
    answerOptions.forEach(option => {
        option.classList.remove('selected');
    });

    // Add selected class to clicked option
    selectedOption.classList.add('selected');

    // Check the corresponding radio button
    const radio = selectedOption.querySelector('.answer-radio');
    if (radio) {
        radio.checked = true;
    }

    // Enable the next button with animation
    if (btnNext) {
        btnNext.disabled = false;
        btnNext.style.animation = 'pulse 0.5s ease';
        setTimeout(() => {
            btnNext.style.animation = '';
        }, 500);
    }

    // Add selection animation
    selectedOption.style.transform = 'scale(1.05)';
    setTimeout(() => {
        selectedOption.style.transform = '';
    }, 200);
}

function addEntranceAnimations() {
    const answerOptions = document.querySelectorAll('.answer-option');

    // Animate each answer option on page load
    answerOptions.forEach((option, index) => {
        option.style.opacity = '0';
        option.style.transform = 'translateX(-50px)';

        setTimeout(() => {
            option.style.transition = 'all 0.5s ease';
            option.style.opacity = '1';
            option.style.transform = 'translateX(0)';
        }, 200 + (index * 100));
    });

    // Animate question icon
    const questionIcon = document.querySelector('.question-icon');
    if (questionIcon) {
        questionIcon.style.opacity = '0';
        questionIcon.style.transform = 'scale(0)';

        setTimeout(() => {
            questionIcon.style.transition = 'all 0.6s cubic-bezier(0.34, 1.56, 0.64, 1)';
            questionIcon.style.opacity = '1';
            questionIcon.style.transform = 'scale(1)';
        }, 100);
    }

    // Animate question text
    const questionText = document.querySelector('.question-text');
    if (questionText) {
        questionText.style.opacity = '0';
        questionText.style.transform = 'translateY(-20px)';

        setTimeout(() => {
            questionText.style.transition = 'all 0.5s ease';
            questionText.style.opacity = '1';
            questionText.style.transform = 'translateY(0)';
        }, 300);
    }
}

function addKeyboardNavigation() {
    document.addEventListener('keydown', function (e) {
        const answerOptions = document.querySelectorAll('.answer-option');
        const btnNext = document.getElementById('btnNext');

        // Select answers with keyboard (1-4 or A-D)
        if (e.key >= '1' && e.key <= '4') {
            const index = parseInt(e.key) - 1;
            if (answerOptions[index]) {
                selectAnswer(answerOptions[index]);
            }
        } else if (['a', 'b', 'c', 'd'].includes(e.key.toLowerCase())) {
            const index = e.key.toLowerCase().charCodeAt(0) - 'a'.charCodeAt(0);
            if (answerOptions[index]) {
                selectAnswer(answerOptions[index]);
            }
        }

        // Submit with Enter key
        if (e.key === 'Enter') {
            const selectedRadio = document.querySelector('.answer-radio:checked');
            if (selectedRadio && btnNext && !btnNext.disabled) {
                e.preventDefault();
                btnNext.click();
            }
        }
    });
}

// Add button hover animations
document.addEventListener('DOMContentLoaded', function () {
    const btnNext = document.getElementById('btnNext');

    if (btnNext) {
        btnNext.addEventListener('mouseenter', function () {
            if (!this.disabled) {
                this.style.transform = 'translateY(-3px) scale(1.02)';
            }
        });

        btnNext.addEventListener('mouseleave', function () {
            this.style.transform = '';
        });

        btnNext.addEventListener('mousedown', function () {
            if (!this.disabled) {
                this.style.transform = 'translateY(-1px) scale(0.98)';
            }
        });

        btnNext.addEventListener('mouseup', function () {
            if (!this.disabled) {
                this.style.transform = 'translateY(-3px) scale(1.02)';
            }
        });
    }
});

// Add pulse animation style
const style = document.createElement('style');
style.textContent = `
    @keyframes pulse {
        0%, 100% { transform: scale(1); }
        50% { transform: scale(1.05); }
    }
`;
document.head.appendChild(style);