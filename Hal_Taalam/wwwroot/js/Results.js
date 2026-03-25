// Results Page JavaScript - Animations Only
document.addEventListener('DOMContentLoaded', function () {
    initializeResultsAnimations();
});

function initializeResultsAnimations() {
    // Add score counting animation
    animateScoreCount();

    // Add confetti animation for perfect score
    addConfettiAnimation();

    // Add trophy hover effect
    addTrophyHoverEffect();

    // Add button hover animations
    addButtonHoverAnimations();

    // Add message card entrance animation
    addMessageCardAnimation();

    // Add stats items stagger animation
    addStatsAnimation();
}

function animateScoreCount() {
    const scoreNumber = document.querySelector('.score-number');
    if (!scoreNumber) return;

    const finalScore = parseInt(scoreNumber.textContent);
    const duration = 2000; // 2 seconds
    const steps = 50;
    const increment = finalScore / steps;
    const stepDuration = duration / steps;

    let currentScore = 0;
    scoreNumber.textContent = '0';

    const counter = setInterval(() => {
        currentScore += increment;
        if (currentScore >= finalScore) {
            scoreNumber.textContent = finalScore;
            clearInterval(counter);

            // Add pulse animation at the end
            scoreNumber.style.animation = 'pulse 0.5s ease';
            setTimeout(() => {
                scoreNumber.style.animation = '';
            }, 500);
        } else {
            scoreNumber.textContent = Math.floor(currentScore);
        }
    }, stepDuration);
}

function addConfettiAnimation() {
    const confetti = document.querySelector('.confetti');
    if (!confetti) return;

    // Create confetti pieces
    const emojis = ['🎉', '🎊', '⭐', '✨', '🌟', '💫'];

    for (let i = 0; i < 15; i++) {
        const piece = document.createElement('span');
        piece.textContent = emojis[Math.floor(Math.random() * emojis.length)];
        piece.style.position = 'absolute';
        piece.style.left = Math.random() * 100 + '%';
        piece.style.fontSize = (Math.random() * 1.5 + 1) + 'rem';
        piece.style.animation = `confettiFall ${Math.random() * 2 + 3}s linear infinite`;
        piece.style.animationDelay = Math.random() * 3 + 's';
        confetti.appendChild(piece);
    }
}

function addTrophyHoverEffect() {
    const trophy = document.querySelector('.trophy');
    if (!trophy) return;

    trophy.addEventListener('mouseenter', function () {
        this.style.transform = 'scale(1.2) rotate(10deg)';
        this.style.transition = 'transform 0.3s ease';
    });

    trophy.addEventListener('mouseleave', function () {
        this.style.transform = 'scale(1) rotate(0deg)';
    });
}

function addButtonHoverAnimations() {
    const buttons = document.querySelectorAll('.btn-action');

    buttons.forEach((button, index) => {
        // Initial entrance animation
        button.style.opacity = '0';
        button.style.transform = 'translateY(30px)';

        setTimeout(() => {
            button.style.transition = 'all 0.6s ease';
            button.style.opacity = '1';
            button.style.transform = 'translateY(0)';
        }, 1000 + (index * 200));

        // Hover animations
        button.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-5px) scale(1.05)';
        });

        button.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0) scale(1)';
        });

        button.addEventListener('mousedown', function () {
            this.style.transform = 'translateY(-2px) scale(1.02)';
        });

        button.addEventListener('mouseup', function () {
            this.style.transform = 'translateY(-5px) scale(1.05)';
        });
    });
}

function addMessageCardAnimation() {
    const messageCard = document.querySelector('.message-card');
    if (!messageCard) return;

    messageCard.style.opacity = '0';
    messageCard.style.transform = 'scale(0.8)';

    setTimeout(() => {
        messageCard.style.transition = 'all 0.6s cubic// Results Page JavaScript - Animations Only
        document.addEventListener('DOMContentLoaded', function () {
            initializeResults();
        });

        function initializeResults() {
            // Add score counting animation
            animateScoreCount();

            // Add confetti for perfect score
            addConfettiEffect();

            // Add button hover effects
            addButtonAnimations();

            // Add share button functionality
            addShareButtonHandlers();

            // Create gradient for SVG
            createSVGGradient();
        }

        function animateScoreCount() {
            const scoreNumber = document.querySelector('.score-number');
            if (!scoreNumber) return;

            const finalScore = parseInt(scoreNumber.textContent);
            const duration = 2000; // 2 seconds
            const steps = 50;
            const increment = finalScore / steps;
            const stepDuration = duration / steps;

            let currentScore = 0;
            scoreNumber.textContent = '0';

            const counter = setInterval(() => {
                currentScore += increment;
                if (currentScore >= finalScore) {
                    scoreNumber.textContent = finalScore;
                    clearInterval(counter);

                    // Add celebration animation
                    scoreNumber.style.animation = 'pulse 0.5s ease';
                    setTimeout(() => {
                        scoreNumber.style.animation = '';
                    }, 500);
                } else {
                    scoreNumber.textContent = Math.floor(currentScore);
                }
            }, stepDuration);
        }

        function addConfettiEffect() {
            const confetti = document.querySelector('.confetti');
            if (!confetti) return;

            // Create multiple confetti pieces
            const emojis = ['🎉', '🎊', '⭐', '✨', '🌟', '💫'];

            for (let i = 0; i < 15; i++) {
                const piece = document.createElement('span');
                piece.textContent = emojis[Math.floor(Math.random() * emojis.length)];
                piece.style.position = 'absolute';
                piece.style.left = Math.random() * 100 + '%';
                piece.style.fontSize = (Math.random() * 1.5 + 1) + 'rem';
                piece.style.animation = `confettiFall ${Math.random() * 2 + 3}s linear infinite`;
                piece.style.animationDelay = Math.random() * 3 + 's';
                confetti.appendChild(piece);
            }
        }

        function addButtonAnimations() {
            const buttons = document.querySelectorAll('.btn-action');

            buttons.forEach((button, index) => {
                // Initial entrance animation
                button.style.opacity = '0';
                button.style.transform = 'translateY(30px)';

                setTimeout(() => {
                    button.style.transition = 'all 0.6s ease';
                    button.style.opacity = '1';
                    button.style.transform = 'translateY(0)';
                }, 1000 + (index * 200));

                // Hover effects
                button.addEventListener('mouseenter', function () {
                    this.style.transform = 'translateY(-5px) scale(1.05)';
                });

                button.addEventListener('mouseleave', function () {
                    this.style.transform = 'translateY(0) scale(1)';
                });

                button.addEventListener('mousedown', function () {
                    this.style.transform = 'translateY(-2px) scale(1.02)';
                });

                button.addEventListener('mouseup', function () {
                    this.style.transform = 'translateY(-5px) scale(1.05)';
                });
            });
        }

        function addShareButtonHandlers() {
            const shareButtons = document.querySelectorAll('.share-btn');

            shareButtons.forEach(button => {
                button.addEventListener('click', function () {
                    // Add click animation
                    this.style.transform = 'scale(0.9)';
                    setTimeout(() => {
                        this.style.transform = 'scale(1)';
                    }, 150);

                    // Get score info
                    const scoreNumber = document.querySelector('.score-number')?.textContent || '0';
                    const scoreTotal = document.querySelector('.score-total')?.textContent || '0';
                    const shareText = `I scored ${scoreNumber}/${scoreTotal} on Hal Taalam Quiz! 🎉`;

                    // Share functionality (you can customize these)
                    if (this.classList.contains('facebook')) {
                        // Facebook share
                        console.log('Share to Facebook:', shareText);
                        alert('Facebook sharing coming soon!');
                    } else if (this.classList.contains('twitter')) {
                        // Twitter share
                        const twitterUrl = `https://twitter.com/intent/tweet?text=${encodeURIComponent(shareText)}`;
                        window.open(twitterUrl, '_blank', 'width=600,height=400');
                    } else if (this.classList.contains('whatsapp')) {
                        // WhatsApp share
                        const whatsappUrl = `https://wa.me/?text=${encodeURIComponent(shareText)}`;
                        window.open(whatsappUrl, '_blank');
                    }
                });
            });
        }

        function createSVGGradient() {
            // Create gradient for score ring
            const svg = document.querySelector('.score-ring');
            if (!svg) return;

            const defs = document.createElementNS('http://www.w3.org/2000/svg', 'defs');
            const gradient = document.createElementNS('http://www.w3.org/2000/svg', 'linearGradient');
            gradient.setAttribute('id', 'gradient');
            gradient.setAttribute('x1', '0%');
            gradient.setAttribute('y1', '0%');
            gradient.setAttribute('x2', '100%');
            gradient.setAttribute('y2', '0%');

            const stop1 = document.createElementNS('http://www.w3.org/2000/svg', 'stop');
            stop1.setAttribute('offset', '0%');
            stop1.setAttribute('style', 'stop-color:#ff9900;stop-opacity:1');

            const stop2 = document.createElementNS('http://www.w3.org/2000/svg', 'stop');
            stop2.setAttribute('offset', '100%');
            stop2.setAttribute('style', 'stop-color:#e67300;stop-opacity:1');

            gradient.appendChild(stop1);
            gradient.appendChild(stop2);
            defs.appendChild(gradient);
            svg.insertBefore(defs, svg.firstChild);
        }

        // Add trophy animation on hover
        document.addEventListener('DOMContentLoaded', function () {
            const trophy = document.querySelector('.trophy');
            if (trophy) {
                trophy.addEventListener('mouseenter', function () {
                    this.style.transform = 'scale(1.2) rotate(10deg)';
                });

                trophy.addEventListener('mouseleave', function () {
                    this.style.transform = 'scale(1) rotate(0deg)';
                });
            }
        });

        // Add message card entrance animation
        document.addEventListener('DOMContentLoaded', function () {
            const messageCard = document.querySelector('.message-card');
            if (messageCard) {
                messageCard.style.opacity = '0';
                messageCard.style.transform = 'scale(0.8)';

                setTimeout(() => {
                    messageCard.style.transition = 'all 0.6s cubic-bezier(0.34, 1.56, 0.64, 1)';
                    messageCard.style.opacity = '1';
                    messageCard.style.transform = 'scale(1)';
                }, 800);
            }
        });

        // Add celebration sound (optional - you can add actual sound files)
        function playCelebrationSound(scorePercentage) {
            // You can implement this with actual audio files
            /*
            let soundFile = '';
            if (scorePercentage === 100) {
                soundFile = '/sounds/perfect.mp3';
            } else if (scorePercentage >= 75) {
                soundFile = '/sounds/excellent.mp3';
            } else if (scorePercentage >= 50) {
                soundFile = '/sounds/good.mp3';
            }
            
            if (soundFile) {
                const audio = new Audio(soundFile);
                audio.volume = 0.5;
                audio.play();
            }
            */
        }