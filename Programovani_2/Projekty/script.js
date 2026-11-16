function zobrazRok(rok) {
    let text = "";

    if (rok == 1946) {
        text = "1946 – Veřejné představení počítače ENIAC. Vážil asi 30 tun a obsahoval kolem 18 000 elektronek.";
    } else if (rok == 1972) {
        text = "1972 – Atari vydalo Pong, jednu z prvních komerčně úspěšných videoher.";
    } else if (rok == 1981) {
        text = "1981 – IBM představila osobní počítač IBM PC 5150 s procesorem Intel 8088.";
    } else if (rok == 1989) {
        text = "1989 – Tim Berners-Lee v CERNu navrhl World Wide Web.";
    } else if (rok == 2007) {
        text = "2007 – Steve Jobs představil první iPhone s 3,5palcovým dotykovým displejem.";
    } else if (rok == 2022) {
        text = "2022 – ChatGPT se stal veřejně dostupným a přiblížil konverzační AI širokému publiku.";
    }

    document.getElementById("udalost").innerHTML = text;
}

function spocitejStari() {
    let rok = Number(document.getElementById("rokVynalezu").value);
    let aktualniRok = new Date().getFullYear();

    if (rok >= 1800 && rok <= aktualniRok) {
        let stari = aktualniRok - rok;
        document.getElementById("stariVysledek").innerHTML =
            "Od roku " + rok + " uplynulo " + stari + " let.";
    } else {
        document.getElementById("stariVysledek").innerHTML =
            "Zadej rok od 1800 do " + aktualniRok + ".";
    }
}

function zkontrolujOdpoved(rok) {
    if (rok == 2007) {
        document.getElementById("kvizVysledek").innerHTML =
            "Správně! První iPhone byl představen v roce 2007.";
    } else {
        document.getElementById("kvizVysledek").innerHTML =
            "To není správně. Zkus jiný rok.";
    }
}
