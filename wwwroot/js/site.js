$(document).ready(function () {

    var activeRowId;
    var activeRowName;
    var activeRowDescription;
    var activeRowStatusName;
    var activeRowStatusId;


    // Клик по кнопке "Добавить"
    $('#btn-add').click(function () {
        let formIsHidden = $('#form-add').is(':hidden');
        $('.forms').hide();
        if (formIsHidden)
            $('#form-add').show();

        $('.alert-danger').hide();
    });

    // Клик по кнопке "Редактировать"
    $('#btn-edit').click(function () {
        let formIsHidden = $('#form-edit').is(':hidden');
        $('.forms').hide();
        if (formIsHidden)
            $('#form-edit').show();

        $('#form-edit textarea')
            .outerHeight(38)
            .outerHeight(
                $('#form-edit textarea')
                    .prop('scrollHeight') + 2
            );

        $('.alert-danger').hide();
    });

    // Клик по кнопке "Удалить"
    $('#btn-delete').click(function () {
        let formIsHidden = $('#form-delete').is(':hidden');
        $('.forms').hide();
        if (formIsHidden)
            $('#form-delete').show();

        $('.alert-danger').hide();
    });

    // Клик по кнопке отказа от удаления "Нет"
    $('#btnCloseFormDelete').click(function () {
        $('.forms').hide();

        $('.alert-danger').hide();
    });

    //ВЫделение и запоминание основных показателей отмеченной задачи по клику
    $('#indexTable tbody tr').click(function () {
        $('tbody tr').removeClass('active-row');
        $(this).addClass('active-row');

        activeRowId = parseInt($(this).attr('id'));
        activeRowName = $(this).find('.name').text();
        activeRowDescription = $(this).find('.description').text();
        activeRowStatusId = parseInt($(this).find('.status').attr('id'));
        activeRowStatusName = $(this).find('.status').text();

        $('#form-delete .activeRowName').empty();
        $('#form-delete .activeRowName').append(activeRowName);
        $('#form-delete .activeRowDescription').empty();
        $('#form-delete .activeRowDescription').append(activeRowDescription);
        $('#form-delete .activeRowStatusName').empty();
        $('#form-delete .activeRowStatusName').append(activeRowStatusName);

        $('#form-edit input').val(activeRowName);
        $('#form-edit textarea').val(activeRowDescription);

        $('#form-edit textarea')
            .outerHeight(38)
            .outerHeight(
                $('#form-edit textarea')
                    .prop('scrollHeight') + 2
            );

        $('#form-edit select option[value=' + activeRowStatusId + ']')
            .prop('selected', true);

        // Задаем значение активной строки таблицы, скрытому полю ввода формы изменения и формы удаления
        $('.activeTableRow').val(activeRowId);
    });

    // Автоматическое увеличение textarea в высоту при заполнении
    $(document).on('input', 'textarea', function () {
        $(this).outerHeight(38).outerHeight(this.scrollHeight + 2);
    });

    // При ошибке ввода в форме "Редатктирования", при обновлении страницы отметить активную строку таблицы
    var lastactiveEditRow = $('#activeEditRow').attr('value');
    if (lastactiveEditRow)
        $('tbody #' + lastactiveEditRow).addClass('active-row');
});

$(document).ready(function () {
    $('#form-add textarea')
        .outerHeight(38)
        .outerHeight(
            $('#form-add textarea')
                .prop('scrollHeight') + 2
        );
    $('#form-edit textarea')
        .outerHeight(38)
        .outerHeight(
            $('#form-edit textarea')
                .prop('scrollHeight') + 2
        );
});
