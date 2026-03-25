// Authentication Pages JavaScript - Pure Animations & UI Only
document.addEventListener('DOMContentLoaded', function () {
    initializeAuthPage();
});

function initializeAuthPage() {
    const inputs = document.querySelectorAll('.form-input');

    // Add input animations only
    inputs.forEach(input => {
        input.addEventListener('focus', handleInputFocus);
        input.addEventListener('blur', handleInputBlur);
        input.addEventListener('input', handleInputChange);
    });

    // Add smooth page animations
    addPageAnimations();

    // Handle checkbox animations
    initializeCustomCheckbox();

    // Add button click animations
    addButtonAnimations();
}

function handleInputFocus(e) {
    const input = e.target;
    const formGroup = input.closest('.form-group');

    if (formGroup) {
        formGroup.classList.add('focused');
    }
}

function handleInputBlur(e) {
    const input = e.target;
    const formGroup = input.closest('.form-group');

    if (formGroup) {
        formGroup.classList.remove('focused');
    }
}

function handleInputChange(e) {
    const input = e.target;

    // Visual feedback for filled inputs
    if (input.value.trim() !== '') {
        input.classList.add('has-value');
    } else {
        input.classList.remove('has-value');
    }
}

function initializeCustomCheckbox() {
    const checkboxLabels = document.querySelectorAll('.checkbox-label');

    checkboxLabels.forEach(label => {
        label.addEventListener('click', function (e) {
            const customCheckbox = this.querySelector('.checkbox-custom');

            // Add click animation
            if (customCheckbox) {
                customCheckbox.style.transform = 'scale(0.9)';
                setTimeout(() => {
                    customCheckbox.style.transform = 'scale(1)';
                }, 100);
            }
        });
    });
}

function addPageAnimations() {
    // Staggered animation for form elements
    const formElements = document.querySelectorAll('.form-group, .auth-footer');

    formElements.forEach((element, index) => {
        element.style.opacity = '0';
        element.style.transform = 'translateY(20px)';

        setTimeout(() => {
            element.style.transition = 'all 0.4s ease';
            element.style.opacity = '1';
            element.style.transform = 'translateY(0)';
        }, 100 + (index * 50));
    });
}

function addButtonAnimations() {
    // Add click effects to buttons and links
    document.addEventListener('click', function (e) {
        if (e.target.matches('.btn-submit, .switch-auth, .forgot-password, .back-link a')) {
            e.target.style.transform = 'scale(0.98)';
            setTimeout(() => {
                e.target.style.transform = '';
            }, 150);
        }
    });
}