using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class AddRowViewModel
    {
        [Required(ErrorMessage = "Сообщение: Отсутствует наименование задачи!")]
        [StringLength(50, ErrorMessage = "Сообщение: Длинна наименования задачи не должна превышать 50 символов!")]
        public string EnteredName { get; set; }
      
        [Required(ErrorMessage = "Сообщение: Отсутствует описание задачи!")]
        [StringLength(255, ErrorMessage = "Сообщение: Длинна описания задачи не должна превышать 255 символов!")]
        public string EnteredDescription { get; set; }
      
        public int EnteredStatusId { get; set; }
    }
}