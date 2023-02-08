using System.Text.RegularExpressions;
using CustomerCare.Domain.Entities;
using FluentValidation;

namespace CustomerCare.Application.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11)
                .Must(cpf => !Regex.IsMatch(cpf, "[^\\d]"))
                .WithMessage("CPF inválido");
            
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Você precisa informar uma senha")
                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("O email é obrigatório")
                .EmailAddress()
                .WithMessage("Informe um email válido");
            
            RuleFor(user => user.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(user => user.Phone)
                .NotNull()
                .Length(10, 11)
                .WithMessage("Telefone inválido")
                .Must(phone => !Regex.IsMatch(phone, "[^\\d]"))
                .WithMessage("Telefone inváliod");

            RuleFor(user => user.Address)
                .NotEmpty()
                .WithMessage("O endereço é obrigatório");
        }
    }
}