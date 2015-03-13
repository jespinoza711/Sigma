var canvas = document.getElementById('myCanvas');
var canvas2 = document.getElementById('gasolinaCanvas');
var context = canvas.getContext('2d');
var context2 = canvas2.getContext('2d');
var Coordenadas = [];
var CoordenadasGasolina = [];
var sizeCircle = 8;
var EstadoAutoparte = "";
var tipoEstado = "";
var circulos = [];
var circulosgasolina = [];


var draw = function (context, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext) {
    context.beginPath();
    context.arc(x, y, radius, 0, 2 * Math.PI, false);
    context.fillStyle = fillcolor;
    context.fill();
    context.lineWidth = linewidth;
    context.strokeStyle = strokestyle;
    context.stroke();

    context.fillStyle = fontcolor;
    context.textAlign = textalign;
    context.font = fonttype;

    context.fillText(filltext, x, y);
};

var drawGasolina = function (context2, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext) {
    context2.beginPath();
    context2.arc(x, y, radius, 0, 2 * Math.PI, false);
    context2.fillStyle = fillcolor;
    context2.fill();
    context2.lineWidth = linewidth;
    context2.strokeStyle = strokestyle;
    context2.stroke();

    context2.fillStyle = fontcolor;
    context2.textAlign = textalign;
    context2.font = fonttype;

    context2.fillText(filltext, x, y);
};

var Circle = function (x, y, radius, estado) {

        this.PointLeft = x - radius;
        this.PointTop = y - radius;
        this.PointRight = x + radius;
        this.PointBottom = y + radius;
        this.EstadoAutoparte = estado;

        
};

var drawCircle = function (context, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext, circles) {
    draw(context, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext);
    var circle = new Circle(x, y, radius);
    Coordenadas.push(circle);
    //console.log(circle);
    //console.log(Coordenadas);
};

var redrawCircle = function (context, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext, circles, estado) {
    draw(context, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext);
    var circle = new Circle(x, y, radius, estado);
    Coordenadas.push(circle);
    //console.log(circle);
    //console.log(Coordenadas);
};

var drawCircleGasolina = function (context2, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext, circles) {
    drawGasolina(context2, x, y, fillcolor, radius, linewidth, strokestyle, fontcolor, textalign, fonttype, filltext);
    var circle = new Circle(x, y, radius);
    CoordenadasGasolina.push(circle);
    //console.log(circle);
    //console.log(Coordenadas);
};

var clickedX = 0;
var clickedY = 0;
$('#myCanvas').click(function (e) {
    clickedX = e.offsetX;
    clickedY = e.offsetY;
    $('#modalAutoparte').modal('show');
    for (var i = 0; i < Coordenadas.length; i++) {
        if (clickedX < Coordenadas[i].PointRight && clickedX > Coordenadas[i].PointLeft && clickedY > Coordenadas[i].PointTop && clickedY < Coordenadas[i].PointBottom) {
            Coordenadas.splice(i, 1);
            dibujarCirculos2(Coordenadas);
            $('#modalAutoparte').modal('hide');
        }
        
    }
    
    
});

$('#gasolinaCanvas').click(function (e) {
    clickedX = e.offsetX;
    clickedY = e.offsetY;
    $('#modalGasolina').modal('show');
    for (var i = 0; i < CoordenadasGasolina.length; i++) {
        if (clickedX < CoordenadasGasolina[i].PointRight && clickedX > CoordenadasGasolina[i].PointLeft && clickedY > CoordenadasGasolina[i].PointTop && clickedY < CoordenadasGasolina[i].PointBottom) {
            CoordenadasGasolina.splice(i, 1);
            dibujarCirculosGasolina(CoordenadasGasolina);
            $('#modalGasolina').modal('hide');
        }

    }

});

function dibujarCirculo(x, y) {
    switch (EstadoAutoparte) {
        
        case "Rayado":
            tipoEstado = "R"
            break;
        case "Abollado":
            tipoEstado = "A"
            break;
        case "Falta":
            tipoEstado = "F"
            break;
        default:
            tipoEstado = "G"
            break;
    }
    
    redrawCircle(context, x, y, "green", sizeCircle, 1, "#003300", "white", "center", "bold 10px Arial", tipoEstado, Coordenadas, tipoEstado);
    
}

function dibujarCirculo2(x, y, Estado) {
    switch (Estado) {

        case "Rayado":
            tipoEstado = "R"
            break;
        case "Abollado":
            tipoEstado = "A"
            break;
        case "Falta":
            tipoEstado = "F"
            break;
        default:
            tipoEstado = "G"
            break;
    }

    drawCircle(context, x, y, "green", sizeCircle, 1, "#003300", "white", "center", "bold 10px Arial", tipoEstado, Coordenadas);

}

function redibujarCirculo(x, y, Estado) {
    tipoEstado = Estado;
    

    redrawCircle(context, x, y, "green", sizeCircle, 1, "#003300", "white", "center", "bold 10px Arial", tipoEstado, Coordenadas, Estado);

}

function dibujarCirculoGasolina(x, y) {

    drawCircleGasolina(context2, x, y, "green", sizeCircle, 1, "#003300", "white", "center", "bold 10px Arial", "G", CoordenadasGasolina);

}

function dibujarCirculos(coordenadas) {
    context.clearRect(0, 0, canvas.width, canvas.height);
    var copiaCoordenadas = JSON.parse(JSON.stringify(coordenadas));
    Coordenadas = [];

    for (var i = 0; i < copiaCoordenadas.length; i++) {
        dibujarCirculo2(copiaCoordenadas[i].PointRight - sizeCircle, copiaCoordenadas[i].PointBottom - sizeCircle, copiaCoordenadas[i].EstadoAutoparte);
    }
}

function dibujarCirculos2(coordenadas) {
    context.clearRect(0, 0, canvas.width, canvas.height);
    var copiaCoordenadas = JSON.parse(JSON.stringify(coordenadas));
    Coordenadas = [];
    debugger;

    for (var i = 0; i < copiaCoordenadas.length; i++) {
        redibujarCirculo(copiaCoordenadas[i].PointRight - sizeCircle, copiaCoordenadas[i].PointBottom - sizeCircle, copiaCoordenadas[i].EstadoAutoparte);
    }
}

function dibujarCirculosGasolina(coordenadas) {
    context2.clearRect(0, 0, canvas.width, canvas.height);
    var copiaCoordenadasGasolina = JSON.parse(JSON.stringify(coordenadas));
    CoordenadasGasolina = [];

    for (var i = 0; i < copiaCoordenadasGasolina.length; i++) {
        dibujarCirculoGasolina(copiaCoordenadasGasolina[i].PointRight - sizeCircle, copiaCoordenadasGasolina[i].PointBottom - sizeCircle);
    }
}
