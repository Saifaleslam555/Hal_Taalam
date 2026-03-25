// Profile Page JavaScript - Pure Animations & UI Only
document.addEventListener('DOMContentLoaded', function () {
    initializeProfilePage();
});

function initializeProfilePage() {
    const inputs = document.querySelectorAll('.form-input');

    // Add input animations
    inputs.forEach(input => {
        input.addEventListener('focus', handleInputFocus);
        input.addEventListener('blur', handleInputBlur);
        input.addEventListener('input', handleInputChange);
    });

    // Add smooth page animations
    addPageAnimations();

    // Add button click animations
    addButtonAnimations();

    // Add special animations for age input (number input)
    addAgeInputAnimations();
}

function handleInputFocus(e) {
    const input = e.target;
    const formGroup = input.closest('.form-group');

    if (formGroup) {
        formGroup.classList.add('focused');
    }

    // Add glow effect to input
    input.style.boxShadow = '0 0 20px rgba(230, 115, 0, 0.3)';
}

function handleInputBlur(e) {
    const input = e.target;
    const formGroup = input.closest('.form-group');

    if (formGroup) {
        formGroup.classList.remove('focused');
    }

    // Remove glow effect
    input.style.boxShadow = '';
}

function handleInputChange(e) {
    const input = e.target;

    // Visual feedback for filled inputs
    if (input.value.trim() !== '') {
        input.classList.add('has-value');

        // Add success animation
        const label = input.parentElement.querySelector('.form-label');
        if (label) {
            label.style.transform = 'scale(1.02)';
            setTimeout(() => {
                label.style.transform = '';
            }, 300);
        }
    } else {
        input.classList.remove('has-value');
    }

    // Special handling for name input
    if (input.name && input.name.toLowerCase().includes('name')) {
        handleNameInputChange(input);
    }

    // Special handling for age input
    if (input.name && input.name.toLowerCase().includes('age')) {
        handleAgeInputChange(input);
    }
}

function handleNameInputChange(input) {
    // Add character typing effect
    if (input.value.length > 0) {
        input.style.background = 'linear-gradient(45deg, #f0fff0, #ffffff)';
    } else {
        input.style.background = '#fafafa';
    }
}

function handleAgeInputChange(input) {
    // Add age-specific visual feedback
    const age = parseInt(input.value);

    if (age && age > 0) {
        if (age < 13) {
            input.style.borderColor = '#17a2b8'; // Info blue for kids
        } else if (age >= 13 && age < 18) {
            input.style.borderColor = '#ffc107'; // Warning yellow for teens
        } else if (age >= 18) {
            input.style.borderColor = '#28a745'; // Success green for adults
        }
    } else {
        input.style.borderColor = '#ffe6cc';
    }
}

function addAgeInputAnimations() {
    const ageInput = document.querySelector('input[name*="Age"], input[id*="Age"]');

    if (ageInput) {
        // Add number increment/decrement animations
        ageInput.addEventListener('keydown', function (e) {
            if (e.key === 'ArrowUp' || e.key === 'ArrowDown') {
                this.style.transform = 'scale(1.05)';
                setTimeout(() => {
                    this.style.transform = '';
                }, 200);
            }
        });

        // Add mouse wheel animation
        ageInput.addEventListener('wheel', function (e) {
            if (this === document.activeElement) {
                this.style.transform = 'scale(1.02)';
                setTimeout(() => {
                    this.style.transform = '';
                }, 150);
            }
        });
    }
}

function addPageAnimations() {
    // Staggered animation for form elements
    const formElements = document.querySelectorAll('.form-group, .profile-footer');

    formElements.forEach((element, index) => {
        element.style.opacity = '0';
        element.style.transform = 'translateY(30px)';

        setTimeout(() => {
            element.style.transition = 'all 0.5s ease';
            element.style.opacity = '1';
            element.style.transform = 'translateY(0)';
        }, 150 + (index * 100));
    });

    // Logo animation
    const logo = document.querySelector('.profile-logo img');
    if (logo) {
        logo.style.opacity = '0';
        logo.style.transform = 'scale(0.5) rotate(-180deg)';

        setTimeout(() => {
            logo.style.transition = 'all 0.8s cubic-bezier(0.34, 1.56, 0.64, 1)';
            logo.style.opacity = '1';
            logo.style.transform = 'scale(1) rotate(0deg)';
        }, 300);
    }

    // Header text animations
    const headerElements = document.querySelectorAll('.profile-header h1, .profile-header p');
    headerElements.forEach((element, index) => {
        element.style.opacity = '0';
        element.style.transform = 'translateX(-50px)';

        setTimeout(() => {
            element.style.transition = 'all 0.6s ease';
            element.style.opacity = '1';
            element.style.transform = 'translateX(0)';
        }, 500 + (index * 200));
    });
}

function addButtonAnimations() {
    // Submit button animations
    const submitButton = document.querySelector('.btn-submit');
    if (submitButton) {
        submitButton.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-4px) scale(1.02)';
        });

        submitButton.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0) scale(1)';
        });

        submitButton.addEventListener('mousedown', function () {
            this.style.transform = 'translateY(-2px) scale(0.98)';
        });

        submitButton.addEventListener('mouseup', function () {
            this.style.transform = 'translateY(-4px) scale(1.02)';
        });
    }

    // Back link animations
    const backLink = document.querySelector('.back-link a');
    if (backLink) {
        backLink.addEventListener('click', function (e) {
            this.style.transform = 'translateX(-6px) scale(0.98)';
            setTimeout(() => {
                this.style.transform = '';
            }, 150);
        });
    }
}

// Add floating animation to the card
function addFloatingAnimation() {
    const profileCard = document.querySelector('.profile-card');
    if (profileCard) {
        let floatDirection = 1;

        setInterval(() => {
            profileCard.style.transform = `translateY(${floatDirection * 2}px)`;
            floatDirection *= -1;
        }, 3000);
    }
}

// Initialize floating animation after page load
setTimeout(addFloatingAnimation, 2000);