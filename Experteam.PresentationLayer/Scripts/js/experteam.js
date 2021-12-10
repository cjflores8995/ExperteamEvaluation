function BeginMethodAjax() {
    Dashmix.layout('header_loader_on');
}

function SuccessMethodAjax(data) {

    if (data.Ok) {
        GenericMessageAjax('success', data.Mensaje);
    }
    else {
        GenericMessageAjax('danger', data.Mensaje);
    }

    Dashmix.layout('header_loader_off');
}

function SuccessMethodAjaxAddGuia(data) {

    if (data.Ok) {
        GenericMessageAjax('success', data.Mensaje);
        document.getElementById(data.Data).disabled = true;
    }
    else {
        GenericMessageAjax('danger', data.Mensaje);
    }

    Dashmix.layout('header_loader_off');
}

function SuccessMethodAjaxRedirect(data) {

    if (data.Ok) {
        GenericMessageAjax('success', data.Mensaje);

        setTimeout(function () {
            location.href = data.Data;
        }, 1000);
    }
    else {
        GenericMessageAjax('danger', data.Mensaje);
    }

    Dashmix.layout('header_loader_off');
}

function FailureMethodAjax(err) {
    GenericMessageAjax(err.responseText);
    Dashmix.layout('header_loader_off');
}

//Esta funcion es generica para manejar los 3 mensajes de alerta [info, success, danger]
function GenericMessageAjax(tipo_mensaje, mensaje = null) {

    var tipoMensaje = 'info';
    var mensajeInterno = 'Variable mensajeInterno no cargada';
    var icono = 'fa fa-info-circle mr-1';

    switch (tipo_mensaje) {
        case 'info':
            tipoMensaje = 'info';
            mensajeInterno = 'Ejecutando proceso...';
            icono = 'fa fa-info-circle mr-1';
            break;
        case 'success':
            tipoMensaje = 'success';
            mensajeInterno = mensaje;
            icono = 'fa fa-check mr-1';
            break;
        case 'danger':
            tipoMensaje = 'danger';
            mensajeInterno = mensaje;
            icono = 'fa fa-times mr-1';
            break;
        default:
            tipoMensaje = 'info';
            mensajeInterno = 'Ejecutando proceso...';
            icono = 'fa fa-info-circle mr-1';
            break;
    }

    return Dashmix.helpers('notify', { type: tipoMensaje, icon: icono, message: mensajeInterno });

}
