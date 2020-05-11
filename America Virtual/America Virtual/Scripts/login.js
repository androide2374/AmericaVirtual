const login = async (form) => {
    var user = document.getElementById("Usuario1").value
    var password = document.getElementById("Password").value
    var params = { Usuario1: user, Password: password }
    var json = JSON.stringify(params);

    var url = "../Account/Login"

    try {
        const result = await fetch(url, { method: 'POST', body: json, headers: { 'Content-Type': 'application/json' } });
        if (result.ok) {
            let resultado = await result.text();
                document.getElementById("Login").innerHTML = resultado;
            console.log(resultado)
        }
    }
    catch (e) {
        alert(e);
    }
}

