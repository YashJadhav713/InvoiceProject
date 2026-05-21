const FetchCustomers = async () => {

    const response = await fetch("/Customer/GetCustomers");
    const Customer = await response.json();

    var data = "";

    Customer.forEach(function (d, k) {

        data += `
                <tr>
                    <td>${k + 1}</td>
                    <td>${d.customerName}</td>
                    <td>${d.email}</td>
                    <td>${d.mobile}</td>
                    <td>${d.city}</td>

                    <td>
                        <input type='button'
                        value='View'
                        class='btn btn-info'
                        onclick='ViewCustomer(${d.customerId})'/>
                    </td>

                    <td>
                        <input type='button'
                        value='Delete'
                        class='btn btn-danger'
                        onclick='DeleteCustomer(${d.customerId})'/>
                    </td>
                </tr>
            `;
    });

    document.getElementById("tbldata").innerHTML = data;
}

FetchCustomers();


const SubmitData = async () => {

    var cname = document.getElementById("txtCustomer_name").value;
    var email = document.getElementById("txtEmail").value;
    var mobile = document.getElementById("txtMobile").value;
    var city = document.getElementById("txtCity").value;

    var st = {
        customerName: cname,
        email: email,
        mobile: mobile,
        city: city
    };

    const response = await fetch("/Customer/AddCustomer", {

        method: "POST",

        body: JSON.stringify(st),

        headers: {
            "content-type": "application/json"
        }

    });

    const msg = await response.text();

    alert(msg);

    ClearData();

    $("#Customer").modal("hide");

    FetchCustomers();
}


const ViewCustomer = async (id) => {

    const response = await fetch("/Customer/GetCustomer/" + id);

    const c = await response.json();

    document.getElementById("txtCustomer_id").value = c.customerId;
    document.getElementById("txtCustomer_name").value = c.customerName;
    document.getElementById("txtEmail").value = c.email;
    document.getElementById("txtMobile").value = c.mobile;
    document.getElementById("txtCity").value = c.city;

    document.getElementById("btnsubmit")
        .setAttribute("hidden", "hidden");

    document.getElementById("btnupdate")
        .removeAttribute("hidden");

    $("#Customer").modal("show");
}


const UpdateData = async () => {

    var cid = document.getElementById("txtCustomer_id").value;
    var cname = document.getElementById("txtCustomer_name").value;
    var email = document.getElementById("txtEmail").value;
    var mobile = document.getElementById("txtMobile").value;
    var city = document.getElementById("txtCity").value;

    var st = {
        customerId: cid,
        customerName: cname,
        email: email,
        mobile: mobile,
        city: city
    };

    const response = await fetch("/Customer/UpdateCustomer", {

        method: "POST",

        body: JSON.stringify(st),

        headers: {
            "content-type": "application/json"
        }

    });

    const msg = await response.text();

    alert(msg);

    ClearData();

    $("#Customer").modal("hide");

    FetchCustomers();
}


const DeleteCustomer = async (id) => {

    if (confirm("Really want to delete?")) {

        const response = await fetch("/Customer/DeleteCustomer/" + id, {

            method: "POST"

        });

        const msg = await response.text();

        alert(msg);

        FetchCustomers();
    }
}


const ClearData = () => {

    document.getElementById("txtCustomer_id").value = "";
    document.getElementById("txtCustomer_name").value = "";
    document.getElementById("txtEmail").value = "";
    document.getElementById("txtMobile").value = "";
    document.getElementById("txtCity").value = "";

    document.getElementById("btnsubmit")
        .removeAttribute("hidden");

    document.getElementById("btnupdate")
        .setAttribute("hidden", "hidden");
}

ClearData();