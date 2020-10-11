$(function () {
    var filter = { search: null, page: 1, pageSize: 6 };

    var search = function () {
        $.ajax({
            contentType: 'application/json',
            data: JSON.stringify(filter),
            dataType: 'json',
            success: function (data) {
                populateList(data);
            },
            error: function () {
                //console.log(data);
            },
            processData: false,
            type: 'POST',
            url: 'api/blog/list'
        });
    };

    var populateList = function (posts) {
        var html = '';

        $.each(posts, function (index, post) {
            html += "<div class=\"col-12 col-md-6 col-lg-4 d-flex pt-30\">";
            html += "     <div class=\"card mb-6 mb-lg-0 shadow-light-lg lift lift-lg\">";
            html += "         <a class=\"card-img-top\" href=\"#!\">";
            html += "             <img src=\"https://landkit.goodthemes.co/assets/img/photos/photo-15.jpg\" alt=\"...\" class=\"card-img-top\">";
            html += "         </a>";
            html += "         <a class=\"card-body\" href=\"#!\">";
            html += "             <h4>" + post.name + "</h4>";
            html += "             <p class=\"mb-0 text-muted\">" + post.content + "</p>";
            html += "         </a>";
            html += "     </div>";
            html += "</div>";
        });

        $("#posts").append(html);

        posts.length < filter.pageSize ? $("#pagination").hide() : $("#pagination").show();
    };

    $("#pagination-button").click(function () {
        filter.page += 1;
        search();
    });

    $("#search-button").click(function () {
        filter.page = 1;
        filter.search = $("#search-text").val();
        $("#posts").html('');
        search();
    });

    search();
});