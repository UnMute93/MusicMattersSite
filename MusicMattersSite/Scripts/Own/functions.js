jQuery(document).ready(function() {
    $(".EditCommentButton").click(showEditComment);
    $(".ReplyCommentButton").click(showReplyComment);
    $(".ReportCommentButton").click(showReportComment);
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