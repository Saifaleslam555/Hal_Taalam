// --- AdminQuestions.js ---

function openAddModal() {
    document.getElementById('modalTitle').innerText = 'Add New Question';
    document.getElementById('questionForm').action = '/Admin/CreateQuestion';

    document.getElementById('questionForm').reset();
    document.getElementById('QuestionId').value = '0';

    document.getElementById('questionModal').style.display = 'flex';
}

function openEditModal(buttonElement) {
    document.getElementById('modalTitle').innerText = 'Edit Question';
    document.getElementById('questionForm').action = '/Admin/UpdateQuestion';

    document.getElementById('QuestionId').value = buttonElement.getAttribute('data-id');
    document.getElementById('QuestionText').value = buttonElement.getAttribute('data-question');
    document.getElementById('Answer1').value = buttonElement.getAttribute('data-a1');
    document.getElementById('Answer2').value = buttonElement.getAttribute('data-a2');
    document.getElementById('Answer3').value = buttonElement.getAttribute('data-a3');
    document.getElementById('Answer4').value = buttonElement.getAttribute('data-a4');
    document.getElementById('CorrectAnswer').value = buttonElement.getAttribute('data-correct');
    document.getElementById('Level').value = buttonElement.getAttribute('data-level');
    document.getElementById('Category').value = buttonElement.getAttribute('data-category');

    document.getElementById('questionModal').style.display = 'flex';
}

function closeModal() {
    document.getElementById('questionModal').style.display = 'none';
}

// عشان لو داس بره المربع يقفل النافذة
window.onclick = function (event) {
    var modal = document.getElementById('questionModal');
    if (event.target == modal) {
        closeModal();
    }
}

function confirmDelete(questionId) {
    if (confirm("هل أنت متأكد أنك تريد حذف هذا السؤال؟")) {
        window.location.href = `/Admin/DeleteQuestion/${questionId}`;
    }
}