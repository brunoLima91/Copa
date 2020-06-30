﻿using API.Copa.Business.Interfaces;
using API.Copa.Business.Models;
using API.Copa.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;


namespace API.Copa.Business.Services
{
	public abstract class BaseService
	{
		protected readonly INotificador _notificador;

		public BaseService(INotificador notificador)
		{
			_notificador = notificador;
		}

		protected void Notificar(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				Notificar(error.ErrorMessage);
			}
		}

		protected void Notificar(string mensagem)
		{
			_notificador.Handle(new Notificacao(mensagem));

		}

		protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
		{
			var validator = validacao.Validate(entidade);
			if (validator.IsValid) return true;
			Notificar(validator);
			return false;
		}

	}
}
