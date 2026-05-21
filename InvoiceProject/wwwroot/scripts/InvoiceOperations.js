
var product = [];
var rate = 0;
var gst = 0;
var pname = "";

// FETCH CUSTOMER
const FetchCustomer = async () => {

    var cid = document.getElementById("ddcustomer").value;

    if (cid == "") return;

    const response = await fetch("/Customer/GetCustomer/" + cid);

    const c = await response.json();

    document.getElementById("txtmobile").value = c.mobile;
    document.getElementById("txtemail").value = c.email;
}


// FETCH PRODUCT
const FetchProduct = async () => {

    var pid = document.getElementById("ddproduct").value;

    if (pid == "") return;

    const response = await fetch("/Product/GetProduct/" + pid);

    const p = await response.json();

    pname = p.productName;

    document.getElementById("txtrate").value = p.rate;
    document.getElementById("txtgst").value = p.gst;
    document.getElementById("txtstock").value = p.stock;

    rate = p.rate;
    gst = p.gst;
}


// TOTAL
const Total = () => {

    var qty = document.getElementById("txtquantity").value;

    var t =
        (Number(rate) * Number(qty) * Number(gst)) / 100
        + Number(rate) * Number(qty);

    document.getElementById("txttotal").value = t;
}


// ADD PRODUCT
const AddProduct = () => {

    var pid = document.getElementById("ddproduct").value;
    var prate = document.getElementById("txtrate").value;
    var pgst = document.getElementById("txtgst").value;
    var qty = document.getElementById("txtquantity").value;
    var t = document.getElementById("txttotal").value;

    var pr = {
        Product: pid,
        ProductName: pname,
        Rate: prate,
        Gst: pgst,
        Quantity: qty,
        Total: t
    };

    product.push(pr);

    ClearData();

    DisplayTable();
}


// DISPLAY TABLE
const DisplayTable = () => {

    var data = "";

    var final = 0;

    product.forEach(function (d, k) {

        final = Number(final) + Number(d.Total);

        data += `
                 <tr>
                     <td>${k + 1}</td>
                     <td>${d.ProductName}</td>
                     <td>${d.Rate}</td>
                     <td>${d.Gst}</td>
                     <td>${d.Quantity}</td>
                     <td>${d.Total}</td>
                 </tr>
             `;
    });

    document.getElementById("tbldata").innerHTML = data;

    document.getElementById("finaltotal").innerHTML = final;
}


// CLEAR DATA
const ClearData = () => {

    document.getElementById("ddproduct").value = "";
    document.getElementById("txtrate").value = "";
    document.getElementById("txtgst").value = "";
    document.getElementById("txtstock").value = "";
    document.getElementById("txtquantity").value = "";
    document.getElementById("txttotal").value = "";
}