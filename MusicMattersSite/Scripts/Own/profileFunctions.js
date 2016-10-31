jQuery(document).ready(function() {
    $(".EditCommentButton").click(showEditComment);
    $(".ReplyCommentButton").click(showReplyComment);
    $(".ReportCommentButton").click(showReportComment);
    $(".Comment").each(addIndent);
});

function showEditComment() {
    $(".EditCommentField").hide();
    $(".ReplyCommentField").hide();
    $(this).siblings(".EditCommentField").show();
}

function showReplyComment() {
    $(".ReplyCommentField").hide();
    $(".EditCommentField").hide();
    $(this).siblings(".ReplyCommentField").show();
}

function showReportComment() {
    $(".ReportCommentField").hide();
    $(this).siblings(".ReportCommentField").show();
}

function addIndent() {
    var exp = new RegExp(/\./g);
    var dots = $(this).attr('data-value').match(exp);
    if (dots !== null && dots.length > 0) {
        $(this).css({ "margin-left": dots.length * 40 + "px" });
    }
}