function CheckData() {
    var comapnyInput = document.getElementById('company').value;
    var searchByComp = document.querySelector('.searchByComp:checked');
    var nameInput = document.getElementById('name').value;
    var searchByName = document.querySelector('.serachByName:checked');
    var phone = document.getElementById('phone').value;
    if (comapnyInput.length < 1 || searchByComp == null || nameInput.length < 1 || searchByName == null || phone.length < 1) {
        alert("You must fill in all fields");
    }
    else {
        getData(comapnyInput, searchByComp.value, nameInput, searchByName.value, phone)
        }
}
function getData(comapnyInput, searchByComp, nameInput, searchByName, phone) {
    var company = findParamSearch(comapnyInput, searchByComp);
    var name = findParamSearch(nameInput, searchByName);
    var postdata = JSON.stringify({
        "company": company,
        "name": name,
        "phone": phone
    });
    find(postdata);
}
function findParamSearch(value,param)
{
    switch (param) {
        case "START":
            return value + "%" ;
        case "MID":
            return "%" + value + "%";
        case "END":
            return "%"+ value ;
        case "=":
            return value;

    }
}
function find(postdata) {
    try {
        $.ajax({
            type: "POST",
            url: "MainPage.aspx/CompanySearch",
            contentType: 'application/json',
            cache: false,
            data: postdata,
            dataType: "json",
            success: getSuccess,
            error: getFail
        });
    } catch (error) {
        console.log(error.message)
    }
}
function getSuccess(data, textStatus, jqXHR) {
    console.log(data.d);
    CreateTable(data.d);
}
function getFail(jqXHR, textStatus,errorThrown ) {
    console.log(errorThrown);
}
function CreateTable(dataSearch) {
    $("#newBtn").show();
    var $table = $("<table>", {
        'border': '1', 'class':'table-light container table table-bordered mt-3 text-center text-center','id':"myTable"
    });
    var $thead = $("<thead>");
    var $tbody = $("<tbody>");

    // Add some headers
    $thead.append($('<th>', {
        'text': 'Company Name', 'class': 'table-light'
    }));
    $thead.append($('<th>', {
        'text': 'Contact Name', 'class': 'table-light'
    }));
    $thead.append($('<th>', {
        'text': 'Address', 'class': 'table-light'
    }));
    $thead.append($('<th>', {
        'text': 'Phone', 'class': 'table-light'
    }));
    $thead.append($('<th>', {
        'text': 'Total Orders', 'class': 'table-light'
    }));

    // Add some rows
    for (var i = 0; i < dataSearch.length; i++) {

        TrComp = $('<tr>');
        TrComp.append($('<td>', {
            'text': dataSearch[i].CompanyName, 'class': 'table-light'
        }));
        TrComp.append($('<td>', {
            'text': dataSearch[i].ContactName, 'class': 'table-light'
        }));
        TrComp.append($('<td>', {
            'text': dataSearch[i].Address, 'class': 'table-light'
        }));
        TrComp.append($('<td>', {
            'text': dataSearch[i].Phone, 'class': 'table-light'
        }));
        TrComp.append($('<td>', {
            'text': dataSearch[i].TotalOrders, 'class': 'table-light'
        }));
    }

    $tbody.append(TrComp);

    // Add table to DOM
    $table.append($thead);
    $table.append($tbody);

    $table.appendTo("body");
    $("#myBtn").addClass("disabled");
}
function NewSearch() {
    document.getElementById('company').value = ""
    document.getElementById('name').value = "";
    document.getElementById('phone').value = "";
    var radio1 = document.getElementsByClassName(".serachByName");
    radio1.checked = 'false';
    $("#myBtn").removeClass("disabled");
    $("#newBtn").hide();
    $("#myTable").remove();
}

  