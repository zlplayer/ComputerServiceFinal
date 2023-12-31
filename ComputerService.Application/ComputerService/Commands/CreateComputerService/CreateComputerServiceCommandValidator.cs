﻿using ComputerService.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Application.ComputerService.Commands.CreateComputerService
{
    public class CreateComputerServiceCommandValidator : AbstractValidator<CreateComputerServiceCommand>
    {
        public CreateComputerServiceCommandValidator(IComputerServiceRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Name should have maxium of 20 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
