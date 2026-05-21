const FetchProducts = async () => {

    const response = await fetch("/Product/GetProducts");
    const products = await response.json();

    //console.log(products);

    var data = "";

    products.forEach(function (d, k) {

        data += `
                <tr>
                    <td>${k + 1}</td>
                    <td>${d.productName}</td>
                    <td>${d.rate}</td>
                    <td>${d.gst}</td>
                    <td>${d.stock}</td>
                    <td><input type='button'id="Product" value='view' class='btn btn-info' onclick='ViewProduct (${d.productId})'/></td>
                    <td><input type='button'id="Product" value='delete' class='btn btn-danger' onclick='DeleteProduct (${d.productId})'/></td>
                </tr>
            `;
    });

    document.getElementById("tbldata").innerHTML = data;
}

FetchProducts();

const SubmitData = async () => {
    var pname = document.getElementById("txtproduct_name").value;
    var rate = document.getElementById("txtrate").value;
    var gst = document.getElementById("txtgst").value;
    var stock = document.getElementById("txtstock").value;

    var st = {
        ProductName: pname,
        Rate: rate,
        Gst: gst,
        Stock: stock
    };
    const response = await fetch("/Product/AddProduct", {
        method: "post",
        body: JSON.stringify(st),
        headers: {
            "content-type": "application/json"
        }
    });
    const msg = await response.text();
    alert(msg);
    ClearData();
    $("#Product").modal("hide");
    FetchProducts();
}

const ViewProduct = async (id) => {
    const response = await fetch("/Product/GetProduct/" + id);
    const p = await response.json();

    document.getElementById("txtproduct_id").value = p.productId;
    document.getElementById("txtproduct_name").value = p.productName;
    document.getElementById("txtrate").value = p.rate;
    document.getElementById("txtgst").value = p.gst;
    document.getElementById("txtstock").value = p.stock;
    document.getElementById("btnsubmit")
        .setAttribute("hidden", "hidden");

    document.getElementById("btnupdate")
        .removeAttribute("hidden");

    $("#Product").modal("show");
}

const UpdateData = async () => {
    var pid = document.getElementById("txtproduct_id").value;
    var pname = document.getElementById("txtproduct_name").value;
    var rate = document.getElementById("txtrate").value;
    var gst = document.getElementById("txtgst").value;
    var stock = document.getElementById("txtstock").value;
    var st = {
        ProductId: pid,
        ProductName: pname,
        Rate: rate,
        Gst: gst,
        Stock: stock
    };
    const response = await fetch("/Product/UpdateProduct", {
        method: "post",
        body: JSON.stringify(st),
        headers: {
            "content-type": "application/json"
        }
    });
    const msg = await response.text();
    alert(msg);
    ClearData();
    $("#Product").modal("hide");
    FetchProducts();
}

const DeleteProduct = async (id) => {
    if (confirm("really want to delete")) {
        const response = await fetch("/Product/DeleteProduct/" + id, {
            method: "post",
            headers: {
                "content-type": "application/json"
            }
        });
        const msg = await response.text();
        alert(msg);
        FetchProducts();
    }
}

const ClearData = () => {
    document.getElementById("txtproduct_id").value = "";
    document.getElementById("txtproduct_name").value = "";
    document.getElementById("txtrate").value = "";
    document.getElementById("txtgst").value = ""
    document.getElementById("txtstock").value = "";
    document.getElementById("btnsubmit").removeAttribute("hidden");
    document.getElementById("btnupdate").setAttribute("hidden", "hidden");
}
ClearData();