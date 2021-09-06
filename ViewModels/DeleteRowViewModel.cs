using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class DeleteRowViewModel
    {
        [Required(ErrorMessage = "Сообщение: Не отмеченна задача для удаления!")]
        public int? ActiveTableRow { get; set; }
    }
}