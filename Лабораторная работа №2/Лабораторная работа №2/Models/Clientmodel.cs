using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Лабораторная_работа__2.Models
{
    public class ClientModel
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DisplayName("Телефон")]
        [DataType(DataType.PhoneNumber)] 
                                           
        public string Phone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }

        [DisplayName("Обработан")]
        public bool IsProcessed { get; set; }
    }
}