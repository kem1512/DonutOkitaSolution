var alertMessage = function (mess, status) {
    if (mess != null) {
        Swal.fire({
            icon: status,
            padding: '3em',
            title: mess,
            timer: 2000
        })
    }
}