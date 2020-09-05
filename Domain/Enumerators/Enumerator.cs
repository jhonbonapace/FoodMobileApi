using System.ComponentModel;

namespace Domain.Enumerators
{
    public class Enumerator
    {
        public enum UserType
        {
            [Description("Pessoal")]
            Personal = 1,
            [Description("Estabelecimento")]
            Establishment = 2,
            [Description("Administrador")]
            Administrator = 3,
        }
        public enum ContactType
        {
            [Description("Telefone")]
            Telephone = 1,
            [Description("Facebook")]
            Facebook = 2,
            [Description("Instagram")]
            Instagram = 3,
            [Description("Twitter")]
            Twitter = 4,
            [Description("Site")]
            WebSite = 5,
            [Description("E-mail")]
            Email = 6,
            [Description("Outro")]
            Other = 7,
        }
        
        public enum PaymentMethodType
        {
            [Description("Dinheiro")]
            CASH = 1,
            [Description("Cartão")]
            CARD = 2,
            [Description("Vale alimentação")]
            MEAL_VOUCHER = 3,
            [Description("Vale refeição")]
            FOOD_VOUCHER = 4,        
        }

        public enum Gender
        {
            [Description("Masculino")]
            Male = 1,
            [Description("Feminino")]
            Famale = 2,
            [Description("Other")]
            Other = 3,
        }
    }
}