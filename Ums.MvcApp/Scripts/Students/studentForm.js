$(document.body).on("change", "#DepartmentId", function () {

    var department = $("#DepartmentId").val();

    var $ddl = $("#CourseId");
    $ddl.empty(); // remove old options

    if (department > 0) {
        $.get("/Students/GetCourseByDepartment", { departmentId: department })
            .done(function (data) {

                $ddl.append($("<option></option>")
                    .attr("value", '').text(''));

                $.each(data, function (key, value) {
                    $ddl.append($('<option>', {
                        value: value.Id,
                        text: value.Name
                    }));
                });
            });
    }
});