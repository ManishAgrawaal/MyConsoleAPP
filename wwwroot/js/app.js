async function loadMedicines() {
    let res = await fetch('/api/medicine');
    let data = await res.json();

    let search = document.getElementById("search").value.toLowerCase();
    let table = document.getElementById("medicineTable");
    table.innerHTML = "";

    data
        .filter(m => m.fullName.toLowerCase().includes(search))
        .forEach(m => {

            let tr = document.createElement("tr");

            let expiryDate = new Date(m.expiryDate);
            let today = new Date();

            // remove time (important fix)
            expiryDate.setHours(0, 0, 0, 0);
            today.setHours(0, 0, 0, 0);

            let diffDays = (expiryDate - today) / (1000 * 60 * 60 * 24);

            // 🎨 COLOR LOGIC
            if (diffDays < 30 && m.quantity < 10) {
                tr.style.backgroundColor = "#ff9999"; // both
            }
            else if (diffDays < 30) {
                tr.style.backgroundColor = "#ffcccc"; // expiry
            }
            else if (m.quantity < 10) {
                tr.style.backgroundColor = "#fff3cd"; // yellow
            }

            tr.innerHTML = `
                <td>${m.fullName}</td>
                <td>${expiryDate.toLocaleDateString()}</td>
                <td>${m.quantity}</td>
                <td>${m.price.toFixed(2)}</td>
                <td>${m.brand}</td>
            `;

            table.appendChild(tr);
        });
}

async function addMedicine() {
    let medicine = {
        fullName: document.getElementById("name").value,
        notes: document.getElementById("notes").value,
        expiryDate: document.getElementById("expiry").value,
        quantity: parseInt(document.getElementById("qty").value),
        price: parseFloat(document.getElementById("price").value),
        brand: document.getElementById("brand").value
    };

    await fetch('/api/medicine', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(medicine)
    });

    // refresh UI
    loadMedicines();

    // clear form
    document.getElementById("name").value = "";
    document.getElementById("notes").value = "";
    document.getElementById("expiry").value = "";
    document.getElementById("qty").value = "";
    document.getElementById("price").value = "";
    document.getElementById("brand").value = "";
}