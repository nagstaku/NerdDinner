var getPage = function () {
    var $a = $(this);

    var options = {
        url: $a.attr("href"),
        type: "get"
    };

    $.ajax(options).done(function (data) {
        var target = $a.parents("div.pagedList").attr("data-nerd-target");
        $(target).replaceWith(data);
    });

    deleteMarkers();
    initialize();
    return false;
}

$(".body-content").on("click", ".pagedList a", getPage);


//So how this works is each of the 3 Dinners shown on screen
//have a hidden div after it which contains the content for
//a modal. So when you click the panel-header of a dinner,
//it traverses up to the parent, then to the next DOM element
//which is a modal, and then executes the function to show it.
$(".modal-target").click(function () {
    $(this).parent().next().modal('show');
});