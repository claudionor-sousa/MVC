// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.btn-total-usuario').click(function () {
        var usuarioId = $(this).attr('usuario-id')
        $.ajax({
            type: 'GET',
            url: '/UsuarioDoSistema/Editar/' + usuarioId,
            success: function (result) {
                $('#dados').html(result);
            }
        })
    })
})
$(document).ready(function () {
    $('.btn-total-usuario-delete').click(function () {
        var usuariodelete = $(this).attr('usuario-delete')
        $.ajax({
            type: 'GET',
            url: '/UsuarioDoSistema/Delete/' + usuariodelete,
            success: function (result) {
                $('#dadosdelete').html(result);
            }
        })
    })
})

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

Window.SetTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 4000);