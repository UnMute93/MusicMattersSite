var editButtons = Document.prototype.getElementsByClassName("EditCommentButton");

for (var i=0; i < editButtons.length; i++) {
    editButtons[i].addEventListener("click", showEditComment);
}

function showEditComment(e) {
    var div = e.target.parentNode.GetElementsByClassName("EditCommentField")[0];
    div.style.display = "normal";
}