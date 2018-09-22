﻿
function AddCategory() {
    var category = new Object();
    category.Name = $("#categoryName").val();
    category.Url = $("#categoryUrl").val();
    category.Status = $("#status").val() ? $("#status").val() : 0;
    category.CategoryID = $("#categoryID").val();
    var arr = []
    $("input[dataname]:checked").each(function () {
        arr.push($(this).attr("dataname"));
    });
    
    category.LessonIDs = arr.toString();

    $.ajax({
        url: "/category/add",
        data: category,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}

/* Delete Category Function Start */
$(document).on("click", "#catDeleteBtn", function () {
    var categoryId = $(this).attr("data-id");
    var deleteRow = $(this).closest("tr");

    bootbox.confirm("Are you sure want to delete?", function (result) {
            if (result) {
                $.ajax({
                    url: '/category/delete/' + categoryId,
                    type: "POST",
                    datatype: 'json',
                    success: function (response) {
                        if (response.Success) {
                            $.notify(response.Message, "success");
                            deleteRow.fadeOut(300,
                                function() {
                                    deleteRow.remove();
                                });
                        }
                        else {
                            $.notify(response.Message, "error");
                        }
                    }
                });
            }
        });
});
/* Delete Category Function End */


function UpdateCategory() {
    var category = new Object();
    category.Name = $("#categoryName").val();
    category.Status = $("#status").val() ? $("#status").val() : 0;
    category.CategoryID = $("#categoryID").val();
    category.ID = $("#ID").val();
    var arr = []
    $("input[dataname]:checked").each(function () {
        arr.push($(this).attr("dataname"));
    });

    category.LessonIDs = arr.toString();

    $.ajax({
        url: "/category/update",
        data: category,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}



function AddLesson() {


    var lesson = new Object();
    lesson.Name = $("#lessonName").val();
    lesson.Status = $("#status").val() ? $("#status").val() : 0;

    $.ajax({
        url: "/lesson/add",
        data: lesson,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}
function UpdateLesson() {
    var lesson = new Object();
    lesson.Name = $("#lessonName").val();
    lesson.Status = $("#status").val() ? $("#status").val() : 0;
    lesson.ID = $("#ID").val();

    $.ajax({
        url: "/lesson/update",
        data: lesson,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}
/* Delete Lesson Function Start */
$(document).on("click", "#lesssonDeleteBtn", function () {
    var lessonId = $(this).attr("data-id");
    var deleteRow = $(this).closest("tr");

    bootbox.confirm("Are you sure want to delete?", function (result) {
        if (result) {
            $.ajax({
                url: '/lesson/delete/' + lessonId,
                type: "POST",
                datatype: 'json',
                success: function (response) {
                    if (response.Success) {
                        $.notify(response.Message, "success");
                        deleteRow.fadeOut(300,
                            function () {
                                deleteRow.remove();
                            });
                    }
                    else {
                        $.notify(response.Message, "error");
                    }
                }
            });
        }
    });
});
/* Delete lesson Function End */





function AddPublisher() {


    var publisher = new Object();
    publisher.Name = $("#publisherName").val();
    publisher.Phone = $("#phoneNumber").val();
    publisher.Adress = $("#adress").val();
    publisher.Status = $("#status").val() ? $("#status").val() : 0;
    publisher.CityID = $("#cityId").val() ? $("#cityId").val() : 0;
    publisher.CountryID = $("#country").val() ? $("#country").val() : 0;

    $.ajax({
        url: "/publisher/add",
        data: publisher,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}
function UpdatePublisher() {
    var publisher = new Object();
    publisher.Name = $("#publisherName").val();
    publisher.Phone = $("#phoneNumber").val();
    publisher.Adress = $("#adress").val();
    publisher.Status = $("#status").val() ? $("#status").val() : 0;
    publisher.CityID = $("#cityId").val() ? $("#cityId").val() : 0;
    publisher.CountryID = $("#countryId").val() ? $("#countryId").val() : 0;
    publisher.ID = $("#ID").val();

    $.ajax({
        url: "/publisher/update",
        data: publisher,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}
/* Delete Publisher Function Start */
$(document).on("click", "#publisherDeleteBtn", function () {
    var publisherId = $(this).attr("data-id");
    var deleteRow = $(this).closest("tr");

    bootbox.confirm("Are you sure want to delete?", function (result) {
        if (result) {
            $.ajax({
                url: '/publisher/delete/' + publisherId,
                type: "POST",
                datatype: 'json',
                success: function (response) {
                    if (response.Success) {
                        $.notify(response.Message, "success");
                        deleteRow.fadeOut(300,
                            function () {
                                deleteRow.remove();
                            });
                    }
                    else {
                        $.notify(response.Message, "error");
                    }
                }
            });
        }
    });
});
/* Delete Publisher Function End */





function AddContentType() {


    var contentType = new Object();
    contentType.Name = $("#contentTypeName").val();
    contentType.Status = $("#status").val() ? $("#status").val() : 0;

    $.ajax({
        url: "/contenttype/add",
        data: contentType,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}
function UpdateContentType() {
    var contentType = new Object();
    contentType.Name = $("#contentTypeName").val();
    contentType.Status = $("#status").val() ? $("#status").val() : 0;
    contentType.ID = $("#ID").val();

    $.ajax({
        url: "/contenttype/update",
        data: contentType,
        type: "POST",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    });
}
/* Delete Lesson Function Start */
$(document).on("click", "#contentTypeDeleteBtn", function () {
    var contentTypeId = $(this).attr("data-id");
    var deleteRow = $(this).closest("tr");

    bootbox.confirm("Are you sure want to delete?", function (result) {
        if (result) {
            $.ajax({
                url: '/contenttype/delete/' + contentTypeId,
                type: "POST",
                datatype: 'json',
                success: function (response) {
                    if (response.Success) {
                        $.notify(response.Message, "success");
                        deleteRow.fadeOut(300,
                            function () {
                                deleteRow.remove();
                            });
                    }
                    else {
                        $.notify(response.Message, "error");
                    }
                }
            });
        }
    });
});
/* Delete lesson Function End */