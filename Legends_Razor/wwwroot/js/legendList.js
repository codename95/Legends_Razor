var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').dataTable({
        "ajax": {
            "url": "/api/Legend",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "country", "width": "20%" },
            { "data": "superPower", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                     <a href="/LegendList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width: 70px;'>Edit<a/>
                     &nbsp;<a onclick="Delete('api/Legend?id=${data}')" class='btn btn-danger text-white' style='cursor:pointer; width: 70px;'> Delete </a></div>`;
                }, "width":  "40%"
            }
        ],
        "language": {
            "emptyTable" : "no data found"
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "Action not reversible",
        icon: "warning",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.api().ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}