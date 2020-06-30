using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace API.Copa.Business.Models.Validations
{
	public class FaseFinalValidation : AbstractValidator<FaseFinal>
	{
		public FaseFinalValidation()
		{
			RuleFor(x => x.Participantes)
				.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

			RuleFor(x => x.Copa)
				.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

			RuleFor(x => x.NumeroParticipantes)
				.GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");


			When(f => f.NumeroParticipantes > 0, () =>
			{
				RuleFor(f => f.Participantes.Count()).Equal(f => f.NumeroParticipantes)
				.WithMessage("A quantidade de {ComparisonValue} deve ser {PropertyValue}");
				
			});

		}
	}
}
