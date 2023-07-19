
var deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'), {
    keyboard: false
});

document.querySelectorAll('.delete-button').forEach(function(deleteButton) {
    deleteButton.addEventListener('click', function (e) {
        e.preventDefault();
        var url = this.getAttribute('data-url');

        document.getElementById('deleteForm').action = url;
        deleteModal.show();
    });
});

document.getElementById('cancelButton').addEventListener('click', function() {
    deleteModal.hide();
});

document.getElementById('closeButton').addEventListener('click', function() {
    deleteModal.hide();
});