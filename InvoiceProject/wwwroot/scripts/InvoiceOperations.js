
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

// SUBMIT INVOICE
const SubmitInvoice = () => {

    // CUSTOMER NAME
    var customer =
        document.getElementById("ddcustomer");

    var customerName =
        customer.options[customer.selectedIndex].text;

    // DATE
    var invoiceDate =
        document.getElementById("txtdate").value;

    // SHOW CUSTOMER NAME
    document.getElementById("cname").innerHTML =
        "Customer Name : " + customerName;

    // SHOW DATE
    document.getElementById("idate").innerHTML =
        "Invoice Date : " + invoiceDate;

    // TABLE DATA
    var data = "";

    var grandTotal = 0;

    product.forEach(function (d, k) {

        grandTotal =
            Number(grandTotal) + Number(d.Total);

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

    // SHOW DATA IN FINAL TABLE
    document.getElementById("invoicebody").innerHTML = data;

    // SHOW TOTAL
    document.getElementById("invoicefinaltotal").innerHTML =
        grandTotal;

    // CREATE QR CODE
    var qr =
        "https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=Total Amount ₹"
        + grandTotal;

    document.getElementById("qrimage").src = qr;
}

// DOWNLOAD LAST INVOICE PAGE
const DownloadInvoice = () => {

    var printContents =
        document.querySelector(".mt-5").innerHTML;

    var originalContents =
        document.body.innerHTML;

    document.body.innerHTML = `
        <html>

        <head>

            <title>Invoice</title>

            <style>

                body{
                    font-family:Arial;
                    padding:20px;
                }

                table{
                    width:100%;
                    border-collapse:collapse;
                }

                table,th,td{
                    border:1px solid black;
                    padding:20px;
                    text-align:center;
                }

                h5{
                    margin:10px 0;
                }

            </style>

        </head>

        <body>

            ${printContents}

        </body>

        </html>
    `;

    window.print();

    document.body.innerHTML =
        originalContents;

    location.reload();
}