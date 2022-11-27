$(document).ready(function () {
    $(".productoag").click(e => {
        const libroId = parseInt($(e.currentTarget).attr("data-id"));
        const cantidad = parseInt($(`.cantidad[data-id=${libroId}]`).val());

        const informacion = {
            libroId: libroId,
            cantidad: cantidad
        };

        $.ajax({
            url: "/Carritoes/AgregarLibroAlCarrito",
            type: "POST",
            data: informacion,
            success: function (msg) {
                alert(msg);
            },
            error: function (err) {
                console.error(err);
                alert("Ocurrio un error innesperado!");
            },
            dataType: "text"
        });
    });
});